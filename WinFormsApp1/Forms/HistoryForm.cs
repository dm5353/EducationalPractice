using WinFormsApp1.FormTools;

namespace WinFormsApp1
{
    public partial class HistoryForm : BaseForm
    {
        private string _filter = string.Empty;
        private bool _sortDesc = false;

        private Tools _tools;

        public HistoryForm()
        {
            InitializeComponent();
            _tools = new Tools(this);
            LoadHistory();        
        }

        private void LoadHistory()
        {
            var list = _tools.LocalDb.GetLoginHistory(_filter, _sortDesc);

            dataGridView1.DataSource = list
                .Select(h => new
                {
                    Время = h.AttemptTime.ToString("dd.MM.yyyy HH:mm:ss"),
                    Логин = h.Login,
                    Результат = h.IsSuccessful ? "Успешно" : "Ошибка"
                })
                .ToList();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SortByDate_Click(object sender, EventArgs e)
        {
            _sortDesc = !_sortDesc;
            LoadHistory();
        }

        private void SortByLogin_Click(object sender, EventArgs e)
        {
            using var inputForm = new InputForm();
            _filter = inputForm.ShowDialog() == DialogResult.OK ? inputForm.EnteredText : string.Empty;
            LoadHistory();
        }
    }
}
