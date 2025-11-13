namespace WinFormsApp1
{
    public partial class BaseForm : Form
    {
        // Цвета по умолчанию
        protected Color MainBackground => Color.White;
        protected Color SecondaryBackground => ColorTranslator.FromHtml("#BBD9B2");
        protected Color AccentColor => ColorTranslator.FromHtml("#2D6033");

        // Шрифт по умолчанию
        protected new Font DefaultFont => new Font("Gabriola", 14, FontStyle.Regular);

        public BaseForm()
        {
            InitializeComponent();

            // Основной фон формы
            this.BackColor = MainBackground;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = DefaultFont;

            this.Icon = Properties.Resources.Наш_декор;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
        }

        // Переопределяем добавление контролов
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            ApplyStyle(e.Control);
        }

        // Рекурсивное применение стилей к контролам
        private void ApplyStyle(Control control)
        {
            // Применяем шрифт
            control.Font = DefaultFont;
            control.BackColor = Color.White;

            // Кнопки — акцентные по умолчанию
            if (control is Button btn)
            {
                btn.BackColor = AccentColor;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Gabriola", 16, FontStyle.Bold);
            }

            if (control is Label lbl)
            {
                lbl.ForeColor = AccentColor;
            }

            // Панели можно использовать как второстепенный фон
            if (control is Panel pnl && pnl.BackColor == Color.Empty)
            {
                pnl.BackColor = SecondaryBackground;
            }

            if (control is TextBox tbx)
            {
                tbx.BackColor = SecondaryBackground;
            }

            if (control is MenuStrip ms)
            {
                ms.BackColor = SecondaryBackground;
            }

            // Рекурсивно применяем к дочерним контролам
            foreach (Control child in control.Controls)
            {
                ApplyStyle(child);
            }
        }
    }
}
