namespace WinFormsApp1
{
    partial class AuthForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            label1 = new Label();
            label2 = new Label();
            showPasswordButton = new Button();
            AuthButton = new Button();
            GuestButton = new Button();
            capchaPB = new PictureBox();
            capchaButton = new Button();
            capchaTB = new TextBox();
            capchaPanel = new Panel();
            timerLabel = new Label();
            menuStrip1 = new MenuStrip();
            историяToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)capchaPB).BeginInit();
            capchaPanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = Color.FromArgb(187, 217, 178);
            textBoxPassword.Font = new Font("Gabriola", 14F);
            textBoxPassword.ForeColor = Color.FromArgb(45, 96, 51);
            textBoxPassword.Location = new Point(87, 124);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(214, 39);
            textBoxPassword.TabIndex = 0;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxLogin
            // 
            textBoxLogin.BackColor = Color.FromArgb(187, 217, 178);
            textBoxLogin.Font = new Font("Gabriola", 14F);
            textBoxLogin.ForeColor = Color.FromArgb(45, 96, 51);
            textBoxLogin.Location = new Point(87, 63);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(214, 39);
            textBoxLogin.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Gabriola", 14F);
            label1.ForeColor = Color.FromArgb(45, 96, 51);
            label1.Location = new Point(15, 65);
            label1.Name = "label1";
            label1.Size = new Size(56, 35);
            label1.TabIndex = 2;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Gabriola", 14F);
            label2.ForeColor = Color.FromArgb(45, 96, 51);
            label2.Location = new Point(15, 126);
            label2.Name = "label2";
            label2.Size = new Size(63, 35);
            label2.TabIndex = 3;
            label2.Text = "Пароль:";
            // 
            // showPasswordButton
            // 
            showPasswordButton.BackColor = Color.FromArgb(45, 96, 51);
            showPasswordButton.BackgroundImage = Properties.Resources.eye_icon_off;
            showPasswordButton.BackgroundImageLayout = ImageLayout.Stretch;
            showPasswordButton.FlatStyle = FlatStyle.Flat;
            showPasswordButton.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            showPasswordButton.ForeColor = Color.White;
            showPasswordButton.ImageKey = "(нет)";
            showPasswordButton.Location = new Point(307, 132);
            showPasswordButton.Name = "showPasswordButton";
            showPasswordButton.Size = new Size(24, 24);
            showPasswordButton.TabIndex = 4;
            showPasswordButton.UseVisualStyleBackColor = false;
            showPasswordButton.Click += showPasswordButton_Click;
            // 
            // AuthButton
            // 
            AuthButton.BackColor = Color.FromArgb(45, 96, 51);
            AuthButton.FlatStyle = FlatStyle.Flat;
            AuthButton.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            AuthButton.ForeColor = Color.White;
            AuthButton.Location = new Point(87, 185);
            AuthButton.Name = "AuthButton";
            AuthButton.Size = new Size(85, 43);
            AuthButton.TabIndex = 5;
            AuthButton.Text = "Войти";
            AuthButton.UseVisualStyleBackColor = false;
            AuthButton.Click += AuthButton_Click;
            // 
            // GuestButton
            // 
            GuestButton.BackColor = Color.FromArgb(45, 96, 51);
            GuestButton.FlatStyle = FlatStyle.Flat;
            GuestButton.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            GuestButton.ForeColor = Color.White;
            GuestButton.Location = new Point(216, 185);
            GuestButton.Name = "GuestButton";
            GuestButton.Size = new Size(85, 43);
            GuestButton.TabIndex = 6;
            GuestButton.Text = "Гость";
            GuestButton.UseVisualStyleBackColor = false;
            GuestButton.Click += GuestButton_Click;
            // 
            // capchaPB
            // 
            capchaPB.BackColor = Color.White;
            capchaPB.Font = new Font("Gabriola", 14F);
            capchaPB.ForeColor = Color.FromArgb(45, 96, 51);
            capchaPB.Location = new Point(20, 10);
            capchaPB.Margin = new Padding(3, 1, 3, 1);
            capchaPB.Name = "capchaPB";
            capchaPB.Size = new Size(150, 150);
            capchaPB.TabIndex = 7;
            capchaPB.TabStop = false;
            // 
            // capchaButton
            // 
            capchaButton.BackColor = Color.FromArgb(45, 96, 51);
            capchaButton.FlatStyle = FlatStyle.Flat;
            capchaButton.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            capchaButton.ForeColor = Color.White;
            capchaButton.Location = new Point(175, 161);
            capchaButton.Name = "capchaButton";
            capchaButton.Size = new Size(56, 46);
            capchaButton.TabIndex = 8;
            capchaButton.Text = "ОК";
            capchaButton.UseVisualStyleBackColor = false;
            capchaButton.Click += capchaButton_Click;
            // 
            // capchaTB
            // 
            capchaTB.BackColor = Color.FromArgb(187, 217, 178);
            capchaTB.Font = new Font("Gabriola", 14F);
            capchaTB.ForeColor = Color.FromArgb(45, 96, 51);
            capchaTB.Location = new Point(18, 164);
            capchaTB.Name = "capchaTB";
            capchaTB.Size = new Size(151, 39);
            capchaTB.TabIndex = 9;
            // 
            // capchaPanel
            // 
            capchaPanel.BackColor = Color.White;
            capchaPanel.Controls.Add(capchaTB);
            capchaPanel.Controls.Add(capchaButton);
            capchaPanel.Controls.Add(capchaPB);
            capchaPanel.Font = new Font("Gabriola", 14F);
            capchaPanel.ForeColor = Color.FromArgb(45, 96, 51);
            capchaPanel.Location = new Point(78, 245);
            capchaPanel.Margin = new Padding(3, 1, 3, 1);
            capchaPanel.Name = "capchaPanel";
            capchaPanel.Size = new Size(234, 216);
            capchaPanel.TabIndex = 10;
            capchaPanel.Visible = false;
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.BackColor = Color.White;
            timerLabel.Font = new Font("Gabriola", 14F);
            timerLabel.ForeColor = Color.FromArgb(45, 96, 51);
            timerLabel.Location = new Point(170, 245);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(50, 35);
            timerLabel.TabIndex = 11;
            timerLabel.Text = "label3";
            timerLabel.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(187, 217, 178);
            menuStrip1.Font = new Font("Gabriola", 14F);
            menuStrip1.ForeColor = Color.FromArgb(45, 96, 51);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, историяToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 1, 0, 1);
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(384, 41);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // историяToolStripMenuItem
            // 
            историяToolStripMenuItem.Name = "историяToolStripMenuItem";
            историяToolStripMenuItem.Size = new Size(84, 39);
            историяToolStripMenuItem.Text = "История";
            историяToolStripMenuItem.Click += историяToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.AutoSize = false;
            toolStripMenuItem1.BackgroundImage = Properties.Resources.Png;
            toolStripMenuItem1.BackgroundImageLayout = ImageLayout.Stretch;
            toolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(39, 39);
            toolStripMenuItem1.Text = "12";
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 241);
            Controls.Add(timerLabel);
            Controls.Add(capchaPanel);
            Controls.Add(GuestButton);
            Controls.Add(AuthButton);
            Controls.Add(showPasswordButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AuthForm";
            Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)capchaPB).EndInit();
            capchaPanel.ResumeLayout(false);
            capchaPanel.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Label label1;
        private Label label2;
        private Button showPasswordButton;
        private Button AuthButton;
        private Button GuestButton;
        private PictureBox capchaPB;
        private Button capchaButton;
        private TextBox capchaTB;
        private Panel capchaPanel;
        private Label timerLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem историяToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}
