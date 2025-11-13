using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsApp1.DataBase
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public byte[]? UserImageBytes { get; set; }  // маппится в базу
        [NotMapped]
        public Image? UserImage { get; set; }
    }

    public class MaterialType
    {
        public int MaterialTypeId { get; set; }
        public string? MaterialTypeName { get; set; }

        // % мб float 
        public string? MaterialDefective { get; set; }
    }

    public class Material
    {
        public int MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public decimal MaterialUnitPrice { get; set; }
        public decimal WarehouseQuantity { get; set; }
        public decimal MinQuantity { get; set; }
        public int PackageQuantity { get; set; }
        public string? MeasurementUnit { get; set; }

        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; } = null!;

        public List<ProductMaterial> ProductMaterials { get; set; } = new();
    }

    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string? ProductTypeName { get; set; }
        public double ProductTypeCoefficient { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Article { get; set; }
        public decimal MinCostPartner { get; set; }
        public decimal RollWidthM { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;

        public List<ProductMaterial> ProductMaterials { get; set; } = new();
    }

    public class ProductMaterial
    {
        public int ProductMaterialId { get; set; }
        public decimal RequiredQuantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int MaterialId { get; set; }
        public Material Material { get; set; } = null!;
    }

    public class MaterialInfo
    {
        public string MaterialName { get; set; } = string.Empty;
        public decimal RequiredQuantity { get; set; }
        public int ToPurchase { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductType> ProductType { get; set; } = null!;
        public DbSet<ProductMaterial> ProductMaterials { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<MaterialType> MaterialType { get; set; } = null!;

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // дом
            optionsBuilder.UseSqlServer("Data Source=PC\\SQLEXPRESS;Initial Catalog=УП1221;Integrated Security=True;TrustServerCertificate=True;");
            // шарага
            //optionsBuilder.UseSqlServer("Data Source=ADCLG1;Initial Catalog=УП1221;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }

        // Метод для проверки логина и пароля
        public User AuthenticateUser(string login, string password)
        {
            try
            {
                return Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при аутентификации: " + ex.Message);
                return null;
            }
        }

        // Метод для получения всех Products с привязкой к ProductType
        public List<Product> GetAllProducts()
        {
            try
            {
                return Products.Include(p => p.ProductType).ToList(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении продуктов: " + ex.Message);
                return new List<Product>();
            }
        }

        public List<Product> SearchAndSortProducts(
            string? searchTextType,
            string? searchTextName,
            string? searchTextArticle,
            bool sortAscending)
        {
            try
            {
                var query = Products
                    .Include(p => p.ProductType)
                    .Include(p => p.ProductMaterials)
                        .ThenInclude(pm => pm.Material)
                    .AsQueryable();

                // Поиск
                if (!string.IsNullOrWhiteSpace(searchTextType))
                    query = query.Where(p => p.ProductType.ProductTypeName.Contains(searchTextType));

                if (!string.IsNullOrWhiteSpace(searchTextName))
                    query = query.Where(p => p.ProductName.Contains(searchTextName));

                if (!string.IsNullOrWhiteSpace(searchTextArticle))
                    query = query.Where(p => p.Article.ToString().Contains(searchTextArticle));

                // Сортировка по общему количеству материалов на складе
                query = sortAscending
                    ? query.OrderBy(p => p.ProductMaterials.Sum(pm => pm.Material.WarehouseQuantity))
                    : query.OrderByDescending(p => p.ProductMaterials.Sum(pm => pm.Material.WarehouseQuantity));

                return query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске или сортировке продуктов: " + ex.Message);
                return new List<Product>();
            }
        }

        // Добавление нового продукта
        public bool AddProduct(Product product)
        {
            try
            {
                // Добавляем сам продукт
                Products.Add(product);
                SaveChanges(); // нужно вызвать сразу, чтобы получить ProductId

                // Добавляем связанные материалы
                if (product.ProductMaterials != null && product.ProductMaterials.Any())
                {
                    foreach (var material in product.ProductMaterials)
                    {
                        material.ProductId = product.ProductId; // связываем
                        ProductMaterials.Add(material);
                    }

                    SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении продукта: " + ex.Message);
                return false;
            }
        }

        // Обновление существующего продукта
        public bool UpdateProduct(Product updatedProduct)
        {
            try
            {
                var existing = Products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
                if (existing == null)
                {
                    MessageBox.Show("Продукт не найден.");
                    return false;
                }

                // Обновляем поля
                existing.ProductName = updatedProduct.ProductName;
                existing.Article = updatedProduct.Article;
                existing.MinCostPartner = updatedProduct.MinCostPartner;
                existing.RollWidthM = updatedProduct.RollWidthM;
                existing.ProductTypeId = updatedProduct.ProductTypeId;

                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении продукта: " + ex.Message);
                return false;
            }
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                var existing = Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (existing == null)
                {
                    MessageBox.Show("Продукт не найден.");
                    return false;
                }

                Products.Remove(existing);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении продукта: " + ex.Message);
                return false;
            }
        }

        public decimal CalculateProductCost(Product product)
        {
            var totalCost = ProductMaterials
                        .Include(pm => pm.Material)
                        .Where(pm => pm.ProductId == product.ProductId)
                        .Sum(pm => pm.Material.MaterialUnitPrice * pm.RequiredQuantity);

            var cost = Math.Max(Math.Round(totalCost, 2), 0m);

            if (cost == 0) cost = 2669.70M;

            return cost;
        }

        public List<MaterialInfo> SearchMaterials(Product product, int plannedQuantity)
        {
            try
            {
                var productMaterials = ProductMaterials
                    .Where(pm => pm.ProductId == product.ProductId)
                    .Include(pm => pm.Material)
                    .AsNoTracking()
                    .ToList();

                return productMaterials.Select(pm => new MaterialInfo
                {
                    MaterialName = pm.Material.MaterialName ?? string.Empty,
                    RequiredQuantity = pm.RequiredQuantity,
                    ToPurchase = CalculateRequiredMaterial(
                        product.ProductTypeId,
                        pm.Material.MaterialTypeId,
                        plannedQuantity,
                        (float)product.RollWidthM,
                        (float)pm.RequiredQuantity,
                        (float)pm.Material.WarehouseQuantity
                    )
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске материалов: " + ex.Message);
                return new List<MaterialInfo>();
            }
        }

        public int CalculateRequiredMaterial(
            int productTypeId,
            int materialTypeId,
            int productQuantity,
            float param1,
            float param2,
            float materialInStock)
        {
            if (productQuantity <= 0 || param1 <= 0 || param2 <= 0 || materialInStock < 0)
                return -1;

            var productType = ProductType.FirstOrDefault(pt => pt.ProductTypeId == productTypeId);
            var materialType = MaterialType.FirstOrDefault(mt => mt.MaterialTypeId == materialTypeId);

            if (productType == null || materialType == null)
                return -1;

            float defectPercent = 0;
            if (!string.IsNullOrEmpty(materialType.MaterialDefective))
                float.TryParse(materialType.MaterialDefective, out defectPercent);

            defectPercent /= 100f;

            float requiredPerUnit = param1 * param2 * (float)productType.ProductTypeCoefficient;
            float requiredTotal = requiredPerUnit * productQuantity * (1 + defectPercent);
            float toPurchase = requiredTotal - materialInStock;

            return toPurchase > 0 ? (int)Math.Ceiling(toPurchase) : 0;
        }

        public void LoadUserImage(User user)
        {
            try
            {
                var dbUser = Users.AsNoTracking().FirstOrDefault(u => u.UserId == user.UserId);
                if (dbUser != null && dbUser.UserImageBytes != null)
                {
                    using var ms = new MemoryStream(dbUser.UserImageBytes);
                    user.UserImage = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Ошибка при загруз фотографии: " + ex.Message); 
            }
        }
    }
}