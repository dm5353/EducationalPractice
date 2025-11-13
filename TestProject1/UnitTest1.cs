using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using WinFormsApp1.DataBase;
using WinFormsApp1.FormTools;

namespace TestWinFormsApp1
{
    public class ToolsTests
    {
        [Fact]
        public void GetSelectedProduct_Returns_Product_From_SelectedCard()
        {
            // Arrange
            var dummyForm = new Form();
            var tools = new Tools(dummyForm);
            var panel = new Panel();
            var product = new Product { ProductId = 1, ProductName = "Test" };

            typeof(Tools)
                .GetField("_selectedCard", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(tools, panel);

            panel.Tag = product;

            // Act
            var result = tools.GetSelectedProduct();

            // Assert
            Assert.Equal(product, result);
        }

        [Fact]
        public void LoadMaterials_Sets_DataGridView_DataSource()
        {
            // Arrange: создаём контекст в памяти и добавляем тестовые данные
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_LoadMaterials")
                .Options;

            using var context = new AppDbContext(options);

            var materialType = new MaterialType { MaterialTypeName = "Тип1", MaterialDefective = "5" };
            var material = new Material
            {
                MaterialName = "TestMat",
                MaterialType = materialType,
                WarehouseQuantity = 10,
                MaterialUnitPrice = 100
            };
            var productType = new ProductType { ProductTypeName = "ПродуктТип", ProductTypeCoefficient = 1.2 };
            var product = new Product
            {
                ProductName = "Prod",
                ProductType = productType,
                RollWidthM = 2,
                Article = 123
            };
            context.MaterialType.Add(materialType);
            context.ProductType.Add(productType);
            context.Materials.Add(material);
            context.Products.Add(product);
            context.ProductMaterials.Add(new ProductMaterial
            {
                Product = product,
                Material = material,
                RequiredQuantity = 5
            });
            context.SaveChanges();

            var form = new Form();
            var tools = new Tools(form) { AppDb = context };
            var grid = new DataGridView();

            // Act
            tools.LoadMaterials(grid, product, 3);

            // Assert
            Assert.NotNull(grid.DataSource);
            var data = (List<MaterialInfo>)grid.DataSource;
            Assert.Single(data);
            Assert.Equal("TestMat", data[0].MaterialName);
        }

        [Fact]
        public void LoadProducts_Adds_ProductCards_To_FlowLayoutPanel()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb_LoadProducts")
                .Options;

            using var context = new AppDbContext(options);

            var productType = new ProductType { ProductTypeName = "Тип1", ProductTypeCoefficient = 1.2 };
            var product = new Product
            {
                ProductName = "TestProduct",
                ProductType = productType,
                RollWidthM = 1.5m,
                Article = 555,
                MinCostPartner = 100
            };

            context.ProductType.Add(productType);
            context.Products.Add(product);
            context.SaveChanges();

            var form = new Form();
            var tools = new Tools(form) { AppDb = context };
            var panel1 = new FlowLayoutPanel { Width = 500 };
            var panel2 = new FlowLayoutPanel { Width = 500 };

            // Act
            tools.LoadProducts(panel1);
            tools.LoadProducts(panel2, "Тип2", "", "", false);

            // Assert
            Assert.Single(panel1.Controls); // должна быть одна карточка
            var card1 = panel1.Controls[0] as Panel;
            Assert.Empty(panel2.Controls); // должно быть ноль карточек
            Assert.NotNull(card1);
            Assert.Equal(product, card1.Tag); // продукт сохранён в Tag

            // Проверим, что нужные лейблы есть
            var labels = card1.Controls.OfType<Label>().Select(l => l.Text).ToList();
            Assert.Contains("TestProduct", labels.First());
            Assert.Contains("Артикул: 555", labels);
            Assert.Contains("Мин. цена: 100 р", labels);
        }
    }

    public class AppDbContextTests
    {
        private AppDbContext CreateContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public void AddProduct_SavesProductToDatabase()
        {
            using var context = CreateContext(nameof(AddProduct_SavesProductToDatabase));

            var productType = new ProductType { ProductTypeName = "Тип", ProductTypeCoefficient = 1.1 };
            context.ProductType.Add(productType);
            context.SaveChanges();

            var product = new Product
            {
                ProductName = "Тестовый",
                ProductTypeId = productType.ProductTypeId,
                Article = 111
            };

            var result = context.AddProduct(product);

            Assert.True(result);
            Assert.Single(context.Products);
            Assert.Equal("Тестовый", context.Products.First().ProductName);
        }

        [Fact]
        public void UpdateProduct_ChangesProductName()
        {
            using var context = CreateContext(nameof(UpdateProduct_ChangesProductName));

            var type = new ProductType { ProductTypeName = "Тип" };
            var product = new Product { ProductName = "Old", ProductType = type };
            context.AddRange(type, product);
            context.SaveChanges();

            product.ProductName = "New";
            var updated = context.UpdateProduct(product);

            Assert.True(updated);
            Assert.Equal("New", context.Products.First().ProductName);
        }

        [Fact]
        public void DeleteProduct_RemovesProduct()
        {
            using var context = CreateContext(nameof(DeleteProduct_RemovesProduct));

            var type = new ProductType { ProductTypeName = "Тип" };
            var product = new Product { ProductName = "DelTest", ProductType = type };
            context.AddRange(type, product);
            context.SaveChanges();

            var result = context.DeleteProduct(product);

            Assert.True(result);
            Assert.Empty(context.Products);
        }

        [Fact]
        public void CalculateProductCost_ReturnsCorrectValue()
        {
            using var context = CreateContext(nameof(CalculateProductCost_ReturnsCorrectValue));

            var type = new ProductType { ProductTypeName = "Тип" };
            var matType = new MaterialType { MaterialTypeName = "МатТип" };
            var mat = new Material
            {
                MaterialName = "Мат1",
                MaterialType = matType,
                MaterialUnitPrice = 100,
                WarehouseQuantity = 10
            };
            var product = new Product { ProductName = "Prod", ProductType = type };
            var link = new ProductMaterial { Product = product, Material = mat, RequiredQuantity = 2 };

            context.AddRange(type, matType, mat, product, link);
            context.SaveChanges();

            var cost = context.CalculateProductCost(product);

            Assert.Equal(200, cost);
        }

        [Fact]
        public void SearchMaterials_ReturnsExpectedList()
        {
            using var context = CreateContext(nameof(SearchMaterials_ReturnsExpectedList));

            var pt = new ProductType { ProductTypeName = "Тип", ProductTypeCoefficient = 1.0 };
            var mt = new MaterialType { MaterialTypeName = "МатТип", MaterialDefective = "10" };
            var mat = new Material { MaterialName = "Мат1", MaterialType = mt, WarehouseQuantity = 5 };
            var prod = new Product { ProductName = "Prod", ProductType = pt, RollWidthM = 2 };
            var link = new ProductMaterial { Product = prod, Material = mat, RequiredQuantity = 3 };

            context.AddRange(pt, mt, mat, prod, link);
            context.SaveChanges();

            var result = context.SearchMaterials(prod, 2);

            Assert.Single(result);
            Assert.Equal("Мат1", result.First().MaterialName);
            Assert.True(result.First().ToPurchase >= 0);
        }

        [Fact]
        public void CalculateRequiredMaterial_WorksCorrectly()
        {
            using var context = CreateContext(nameof(CalculateRequiredMaterial_WorksCorrectly));

            var pt = new ProductType { ProductTypeName = "Тип", ProductTypeCoefficient = 1.5 };
            var mt = new MaterialType { MaterialTypeName = "МатТип", MaterialDefective = "10" };
            context.AddRange(pt, mt);
            context.SaveChanges();

            var res = context.CalculateRequiredMaterial(
                pt.ProductTypeId,
                mt.MaterialTypeId,
                3,
                2f,
                4f,
                5f
            );

            Assert.True(res > 0);
        }

        [Fact]
        public void AuthenticateUser_ReturnsUser_WhenCredentialsCorrect()
        {
            using var context = CreateContext(nameof(AuthenticateUser_ReturnsUser_WhenCredentialsCorrect));

            var user = new User { Login = "test", Password = "pass" };
            context.Users.Add(user);
            context.SaveChanges();

            var result = context.AuthenticateUser("test", "pass");

            Assert.NotNull(result);
            Assert.Equal("test", result.Login);
        }

        [Fact]
        public void AuthenticateUser_ReturnsNull_WhenCredentialsIncorrect()
        {
            using var context = CreateContext(nameof(AuthenticateUser_ReturnsNull_WhenCredentialsIncorrect));

            context.Users.Add(new User { Login = "test", Password = "pass" });
            context.SaveChanges();

            var result = context.AuthenticateUser("test", "wrong");

            Assert.Null(result);
        }

        [Fact]
        public void LoadUserImage_SetsImage_WhenUserHasNotImage()
        {
            using var context = CreateContext(nameof(LoadUserImage_SetsImage_WhenUserHasNotImage));

            var user = new User { UserId = 1 };
            context.Users.Add(user);
            context.SaveChanges();

            var targetUser = new User { UserId = 1 };
            context.LoadUserImage(targetUser);

            Assert.Null(targetUser.UserImage);
        }

        [Fact]
        public void GetAllProducts_ReturnsProductsWithType()
        {
            using var context = CreateContext(nameof(GetAllProducts_ReturnsProductsWithType));

            var type = new ProductType { ProductTypeName = "Тип" };
            var product = new Product { ProductName = "Prod", ProductType = type };
            context.AddRange(type, product);
            context.SaveChanges();

            var result = context.GetAllProducts();

            Assert.Single(result);
            Assert.NotNull(result.First().ProductType);
        }

        [Fact]
        public void SearchAndSortProducts_FiltersAndSortsCorrectly()
        {
            using var context = CreateContext(nameof(SearchAndSortProducts_FiltersAndSortsCorrectly));

            var type1 = new ProductType { ProductTypeName = "TypeA" };
            var type2 = new ProductType { ProductTypeName = "TypeB" };
            var mat = new Material { MaterialName = "Mat", WarehouseQuantity = 10 };
            var prod1 = new Product { ProductName = "Prod1", ProductType = type1, Article = 100 };
            var prod2 = new Product { ProductName = "Prod2", ProductType = type2, Article = 101 };
            var link1 = new ProductMaterial { Product = prod1, Material = mat, RequiredQuantity = 2 };
            var link2 = new ProductMaterial { Product = prod2, Material = mat, RequiredQuantity = 3 };

            context.AddRange(type1, type2, mat, prod1, prod2, link1, link2);
            context.SaveChanges();

            var result = context.SearchAndSortProducts("TypeA", "Prod1", "100", true);

            Assert.Single(result);
            Assert.Equal("Prod1", result.First().ProductName);
        }
    }

    public class LocalDbContextTests
    {
        private LocalDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<LocalDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new LocalDbContext(options);
        }

        [Fact]
        public void AddLoginHistory_AddsEntrySuccessfully()
        {
            using var context = CreateContext();
            context.AddLoginHistory("user1", true);
            var result = context.LoginHistories.FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal("user1", result.Login);
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void GetLoginHistory_ReturnsAllEntries()
        {
            using var context = CreateContext();

            context.AddLoginHistory("user1", true);
            context.AddLoginHistory("user2", false);

            var history = context.GetLoginHistory();

            Assert.Equal(2, history.Count);
        }

        [Fact]
        public void GetLoginHistory_FiltersByLogin()
        {
            using var context = CreateContext();

            context.AddLoginHistory("alice", true);
            context.AddLoginHistory("bob", false);

            var filtered = context.GetLoginHistory("alice");

            Assert.Single(filtered);
            Assert.Equal("alice", filtered.First().Login);
        }

        [Fact]
        public void GetLoginHistory_SortsDescending()
        {
            using var context = CreateContext();

            context.AddLoginHistory("first", true);
            System.Threading.Thread.Sleep(10); // чтобы гарантировать разное время
            context.AddLoginHistory("second", true);

            var sorted = context.GetLoginHistory(sortDesc: true);

            Assert.Equal("second", sorted.First().Login);
            Assert.Equal("first", sorted.Last().Login);
        }

        [Fact]
        public void GetLoginHistory_SortsAscending()
        {
            using var context = CreateContext();

            context.AddLoginHistory("first", true);
            System.Threading.Thread.Sleep(10);
            context.AddLoginHistory("second", true);

            var sorted = context.GetLoginHistory(sortDesc: false);

            Assert.Equal("first", sorted.First().Login);
            Assert.Equal("second", sorted.Last().Login);
        }
    }
}