using WinFormsApp1.DataBase;

namespace WinFormsApp1.FormTools
{
    public class Tools
    {
        public AppDbContext AppDb;
        public LocalDbContext LocalDb;

        private Form _thisForm;
        private FlowLayoutPanel _flowLayoutPanel;
        private bool _isEditorFormOpen = false;

        private Panel _selectedCard;

        private string _role;

        public Tools(Form thisForm, string role = "none")
        {
            AppDb = new AppDbContext();
            LocalDb = new LocalDbContext();
            _thisForm = thisForm;
            _role = role;
        }

        public void ChangeForm(Form form, bool hide = true, bool close = false)
        {
            form.Show();
            if (hide) _thisForm.Hide();
            if (close) _thisForm.Close();
        }

        public void LoadProducts(FlowLayoutPanel flowLayoutPanel)
        {
            var products = AppDb.GetAllProducts();
            flowLayoutPanel.Controls.Clear();

            foreach (var p in products)
            {
                decimal totalCost = AppDb.CalculateProductCost(p);
                Panel card = CreateProductCard(p, totalCost, flowLayoutPanel.Width);

                    _flowLayoutPanel = flowLayoutPanel;
                    card.Tag = p; // сохраняем продукт в Tag

                    // Навешиваем клик на саму карточку и все внутренние контролы
                    card.Click += Card_Click;
                    foreach (Control ctrl in card.Controls)
                        ctrl.Click += Card_Click;

                flowLayoutPanel.Controls.Add(card);
            }
        }

        public void LoadProducts(FlowLayoutPanel flowLayoutPanel, string searchTextType, string searchTextName, string searchTextArticle, bool isSortAscending)
        {
            var products = AppDb.SearchAndSortProducts(searchTextType, searchTextName, searchTextArticle, isSortAscending);
            flowLayoutPanel.Controls.Clear();

            foreach (var p in products)
            {
                decimal totalCost = AppDb.CalculateProductCost(p);
                Panel card = CreateProductCard(p, totalCost, flowLayoutPanel.Width);

                    _flowLayoutPanel = flowLayoutPanel;
                    card.Tag = p; // сохраняем продукт в Tag

                    // Навешиваем клик на саму карточку и все внутренние контролы
                    card.Click += Card_Click;
                    foreach (Control ctrl in card.Controls)
                        ctrl.Click += Card_Click;

                flowLayoutPanel.Controls.Add(card);
            }
        }

        private Panel CreateProductCard(Product p, decimal totalCost, int panelWidth)
        {
            Panel card = new Panel
            {
                Width = panelWidth - 40,
                Height = 130,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(10),
                Tag = p // Сохраняем сам продукт для последующего редактирования
            };

            Label header = new Label
            {
                Text = $"{p.ProductType.ProductTypeName} | {p.ProductName}",
                AutoSize = true,
                Location = new Point(10, 10)
            };
            card.Controls.Add(header);

            Label article = new Label
            {
                Text = $"Артикул: {p.Article}",
                AutoSize = true,
                Location = new Point(10, 35)
            };
            card.Controls.Add(article);

            Label minCost = new Label
            {
                Text = $"Мин. цена: {p.MinCostPartner} р",
                AutoSize = true,
                Location = new Point(10, 55)
            };
            card.Controls.Add(minCost);

            Label width = new Label
            {
                Text = $"Ширина: {p.RollWidthM} м",
                AutoSize = true,
                Location = new Point(10, 75)
            };
            card.Controls.Add(width);

            Label price = new Label
            {
                Text = $"Себестоимость: {totalCost} р",
                AutoSize = true,
                Location = new Point(card.Width - 180, 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            card.Controls.Add(price);

            return card;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Panel clickedCard = sender as Panel ?? (sender as Control)?.Parent as Panel;
            if (clickedCard?.Tag is Product selectedProduct)
            {
                // Снимаем выделение с предыдущей
                if (_selectedCard != null)
                    _selectedCard.BackColor = Color.White;

                _selectedCard = clickedCard;
                _selectedCard.BackColor = ColorTranslator.FromHtml("#BBD9B2");

                if (_role == "Admin") // редактирование только для админа
                {
                    if (_isEditorFormOpen) return;
                    _isEditorFormOpen = true;

                    using var form = new EditorForm(selectedProduct);
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadProducts(_flowLayoutPanel);

                    _isEditorFormOpen = false;
                }
            }
        }

        public void LoadMaterials(DataGridView dataGridView, Product product, int plannedQuantity)
        {
            var materials = AppDb.SearchMaterials(product, plannedQuantity);

            dataGridView.DataSource = materials;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;
        }

        public Product GetSelectedProduct()
        {
            return _selectedCard?.Tag as Product;
        }
    }
}