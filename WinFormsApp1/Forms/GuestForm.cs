using WinFormsApp1.FormTools;

namespace WinFormsApp1
{
    public partial class GuestForm : BaseForm
    {
        private Tools _tools;

        public GuestForm()
        {
            InitializeComponent();
            _tools = new Tools(this);
            _tools.LoadProducts(flowLayoutPanel);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => _tools.ChangeForm(new AuthForm(), false, true);
    }
}
