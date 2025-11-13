namespace WinFormsApp1
{
    public partial class InputForm : BaseForm
    {
        public string EnteredText { get; private set; }

        public InputForm(string title = "Фильтрация по логину", string prompt = "Введите логин:")
        {
            InitializeComponent();
            Text = title;
            labelPrompt.Text = prompt;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            EnteredText = textBoxInput.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
