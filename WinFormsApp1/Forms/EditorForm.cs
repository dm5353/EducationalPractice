using WinFormsApp1.DataBase;
using WinFormsApp1.FormTools;

namespace WinFormsApp1
{
    public partial class EditorForm : BaseForm
    {
        private readonly Product _product;
        private readonly bool _isEditMode;

        private Tools _tools;

        // Конструктор для добавления нового товара
        public EditorForm()
        {
            InitializeComponent();
            _tools = new Tools(this);
            _product = new Product();

            _isEditMode = false;
            this.Text = "Добавление товара";
            buttonDelete.Enabled = false;

            LoadProductTypes();
        }

        // Конструктор для редактирования существующего товара
        public EditorForm(Product product)
        {
            InitializeComponent();
            _tools = new Tools(this);
            _product = product;

            _isEditMode = true;
            this.Text = "Изменение товара";
            buttonDelete.Enabled = true;

            LoadProductTypes();
            LoadProductData();
        }

        private void LoadProductTypes()
        {
            comboBoxType.DataSource = _tools.AppDb.ProductType.ToList();
            comboBoxType.DisplayMember = "ProductTypeName";
            comboBoxType.ValueMember = "ProductTypeId";
        }

        private void LoadProductData()
        {
            textBoxName.Text = _product.ProductName;
            textBoxArticle.Text = _product.Article.ToString();
            textBoxCost.Text = _product.MinCostPartner.ToString();
            textBoxRollWidth.Text = _product.RollWidthM.ToString();
            comboBoxType.SelectedValue = _product.ProductTypeId;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Проверка на заполненность полей
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxArticle.Text) ||
                string.IsNullOrWhiteSpace(textBoxCost.Text) ||
                string.IsNullOrWhiteSpace(textBoxRollWidth.Text) ||
                comboBoxType.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка корректности числовых значений
            if (!int.TryParse(textBoxArticle.Text, out int article))
            {
                MessageBox.Show("Артикул должен быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBoxCost.Text, out decimal cost))
            {
                MessageBox.Show("Цена должна быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBoxRollWidth.Text, out decimal width))
            {
                MessageBox.Show("Ширина должна быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _product.ProductName = textBoxName.Text;
            _product.Article = int.Parse(textBoxArticle.Text);
            _product.MinCostPartner = decimal.Parse(textBoxCost.Text);
            _product.RollWidthM = decimal.Parse(textBoxRollWidth.Text);
            _product.ProductTypeId = (int)comboBoxType.SelectedValue;

            bool result = _isEditMode
                ? _tools.AppDb.UpdateProduct(_product)
                : _tools.AppDb.AddProduct(_product);

            if (result)
            {
                MessageBox.Show("Изменения сохранены!");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
           $"Удалить товар «{_product.ProductName}»?",
           "Подтверждение удаления",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (_tools.AppDb.DeleteProduct(_product))
                {
                    MessageBox.Show("Товар успешно удалён!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
