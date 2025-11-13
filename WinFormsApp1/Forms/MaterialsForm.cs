using WinFormsApp1.DataBase;
using WinFormsApp1.FormTools;

namespace WinFormsApp1
{
    public partial class MaterialsForm : BaseForm
    {
        private Tools _tools;

        public MaterialsForm(Product product)
        {
            InitializeComponent();
            _tools = new Tools(this);
            Text = $"Материалы для {product.ProductName}";
            _tools.LoadMaterials(dataGridView1, product, 1000);
        }
    }
}
