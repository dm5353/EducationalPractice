using CapchaCreator;
using WinFormsApp1.FormTools;

namespace WinFormsApp1
{
    public partial class AuthForm : BaseForm
    {
        private bool _showPassword = true;
        private bool _isCapcha = false;
        private bool isBlocked = false;

        private int failedAttempts = 0;
        private int _blockTimeLeft = 180;

        private System.Windows.Forms.Timer _blockTimer;

        private string _role;
        private string _capchaText;

        private Tools _tools;

        public AuthForm()
        {
            InitializeComponent();
            _tools = new Tools(this);
        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            if (isBlocked) return;

            if (!_isCapcha)
            {
                var user = _tools.AppDb.AuthenticateUser(login, password);

                if (user != null)
                {
                    _role = user.Role;
                    string name = user.Name;
                    var roleForm = new Form();

                    switch (_role)
                    {
                        case "Авторизированный клиент":
                            roleForm = new ClientForm(name);
                            break;
                        case "Администратор":
                            roleForm = new AdminForm(name);
                            break;
                        case "Менеджер":
                            roleForm = new ManagerForm(name);
                            break;
                        default:
                            roleForm = new GuestForm();
                            break;
                    }

                    _tools.LocalDb.AddLoginHistory(login,true);

                    _tools.ChangeForm(roleForm);
                    _tools.ChangeForm(new RoleForm(user));
                }
                else
                {
                    if (string.IsNullOrEmpty(login)) login = "Unnamed";
                    _tools.LocalDb.AddLoginHistory(login, false);

                    failedAttempts++;
                    if (failedAttempts == 3) Application.Exit();
                    if (failedAttempts == 2)
                    {
                        BlockAuth();
                        MessageBox.Show("Вход заблокирован на 3 минуты из-за нескольких неудачных попыток.");
                        return;
                    }

                    MessageBox.Show("Неверный логин или пароль. Введите капчу и попробуйте снова.");
                    _isCapcha = true;
                    ShowCapcha();
                }
            }
            else MessageBox.Show("Введите капчу.");
        }

        private void showPasswordButton_Click(object sender, EventArgs e)
        {
            _showPassword = !_showPassword;
            textBoxPassword.UseSystemPasswordChar = _showPassword;
            showPasswordButton.BackgroundImage = _showPassword ? Properties.Resources.eye_icon_off : Properties.Resources.eye_icon_on;
        }

        private void GuestButton_Click(object sender, EventArgs e)
        {
            _tools.LocalDb.AddLoginHistory("Гость",true);
            _tools.ChangeForm(new GuestForm());
        }

        private void capchaButton_Click(object sender, EventArgs e)
        {
            if (capchaTB.Text == _capchaText)
                _isCapcha = false;
            capchaTB.Text = string.Empty;
            ShowCapcha();
        }

        private void ShowCapcha()
        {
            this.Height = _isCapcha ? 510 : 280;
            capchaPanel.Visible = _isCapcha;
            capchaPB.Image = Capcha.Create(out _capchaText);
        }

        private void BlockAuth()
        {
            isBlocked = true;
            _blockTimeLeft = 180;

            _blockTimer = new System.Windows.Forms.Timer();
            _blockTimer.Interval = 1000;
            _blockTimer.Tick += BlockTimer_Tick;
            _blockTimer.Start();

            AuthButton.Enabled = false;
            this.Height = 330;
            timerLabel.Visible = true;
        }

        private void BlockTimer_Tick(object sender, EventArgs e)
        {
            _blockTimeLeft--;

            timerLabel.Text = TimeSpan.FromSeconds(_blockTimeLeft).ToString(@"mm\:ss");

            if (_blockTimeLeft <= 0)
            {
                _blockTimer.Stop();
                isBlocked = false;
                AuthButton.Enabled = true;
                this.Height = 320;
                timerLabel.Visible = false;
            }
        }

        private void историяToolStripMenuItem_Click(object sender, EventArgs e) => _tools.ChangeForm(new HistoryForm(), false);
    }
}