using WinFormsApp1.DataBase;
using WinFormsApp1.FormTools;

namespace WinFormsApp1
{
    public partial class RoleForm : BaseForm
    {
        private Tools _tools;
        public RoleForm(User user)
        {
            InitializeComponent();
            _tools = new Tools(this);

            if (user.UserImageBytes != null)
            {
                _tools.AppDb.LoadUserImage(user);
                pictureBox1.BackgroundImage = user.UserImage;
            }
            else
                pictureBox1.BackColor = Color.Gray;

            label1.Text = user.Name;
            label2.Text = user.Role;
        }
    }
}
