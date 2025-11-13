using WinFormsApp1.FormTools;

namespace WinFormsApp1
{
    public partial class ClientForm : BaseForm
    {
        private Tools _tools;

        private bool _isSortAscending = false;

        public ClientForm(string name)
        {
            InitializeComponent();
            nameToolStripMenuItem.Text = name;
            _tools = new Tools(this);
            _tools.LoadProducts(flowLayoutPanel);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => _tools.ChangeForm(new AuthForm(), false, true);

        private void searchTB_TextChanged(object sender, EventArgs e) => _tools.LoadProducts(flowLayoutPanel, searchTypeTB.Text, searchNameTB.Text, searchArticleTB.Text, _isSortAscending);
        private void searchTypeTB_TextChanged(object sender, EventArgs e) => _tools.LoadProducts(flowLayoutPanel, searchTypeTB.Text, searchNameTB.Text, searchArticleTB.Text, _isSortAscending);
        private void searchArticleTB_TextChanged(object sender, EventArgs e) => _tools.LoadProducts(flowLayoutPanel, searchTypeTB.Text, searchNameTB.Text, searchArticleTB.Text, _isSortAscending);

        private void button1_Click(object sender, EventArgs e)
        {
            _isSortAscending = !_isSortAscending;
            button1.Text = _isSortAscending ? "Кол-во по возрастанию" : "Кол-во по убыванию";
            _tools.LoadProducts(flowLayoutPanel, searchTypeTB.Text, searchNameTB.Text, searchArticleTB.Text, _isSortAscending);
        }
    }
}
