namespace WinFormsApp1
{
    partial class ManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            nameToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            label4 = new Label();
            searchArticleTB = new TextBox();
            label3 = new Label();
            searchTypeTB = new TextBox();
            label2 = new Label();
            searchNameTB = new TextBox();
            label1 = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            buttonShowMaterials = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(187, 217, 178);
            menuStrip1.Font = new Font("Gabriola", 14F);
            menuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem, nameToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(1099, 43);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(65, 39);
            exitToolStripMenuItem.Text = "Выход";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // nameToolStripMenuItem
            // 
            nameToolStripMenuItem.Enabled = false;
            nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            nameToolStripMenuItem.Size = new Size(90, 39);
            nameToolStripMenuItem.Text = "Менеджер";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(45, 96, 51);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(786, 223);
            button1.Name = "button1";
            button1.Size = new Size(298, 53);
            button1.TabIndex = 27;
            button1.Text = "Кол-во по убыванию";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Gabriola", 14F);
            label4.ForeColor = Color.FromArgb(45, 96, 51);
            label4.Location = new Point(773, 173);
            label4.Name = "label4";
            label4.Size = new Size(73, 35);
            label4.TabIndex = 26;
            label4.Text = "Артикул:";
            // 
            // searchArticleTB
            // 
            searchArticleTB.BackColor = Color.FromArgb(187, 217, 178);
            searchArticleTB.Font = new Font("Gabriola", 14F);
            searchArticleTB.Location = new Point(873, 169);
            searchArticleTB.Name = "searchArticleTB";
            searchArticleTB.Size = new Size(211, 39);
            searchArticleTB.TabIndex = 25;
            searchArticleTB.TextChanged += searchArticleTB_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Gabriola", 14F);
            label3.ForeColor = Color.FromArgb(45, 96, 51);
            label3.Location = new Point(773, 128);
            label3.Name = "label3";
            label3.Size = new Size(41, 35);
            label3.TabIndex = 24;
            label3.Text = "Тип:";
            // 
            // searchTypeTB
            // 
            searchTypeTB.BackColor = Color.FromArgb(187, 217, 178);
            searchTypeTB.Font = new Font("Gabriola", 14F);
            searchTypeTB.Location = new Point(873, 124);
            searchTypeTB.Name = "searchTypeTB";
            searchTypeTB.Size = new Size(211, 39);
            searchTypeTB.TabIndex = 23;
            searchTypeTB.TextChanged += searchTypeTB_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Gabriola", 14F);
            label2.ForeColor = Color.FromArgb(45, 96, 51);
            label2.Location = new Point(773, 83);
            label2.Name = "label2";
            label2.Size = new Size(78, 35);
            label2.TabIndex = 22;
            label2.Text = "Название:";
            // 
            // searchNameTB
            // 
            searchNameTB.BackColor = Color.FromArgb(187, 217, 178);
            searchNameTB.Font = new Font("Gabriola", 14F);
            searchNameTB.Location = new Point(873, 79);
            searchNameTB.Name = "searchNameTB";
            searchNameTB.Size = new Size(211, 39);
            searchNameTB.TabIndex = 21;
            searchNameTB.TextChanged += searchTB_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Gabriola", 14F);
            label1.ForeColor = Color.FromArgb(45, 96, 51);
            label1.Location = new Point(773, 48);
            label1.Name = "label1";
            label1.Size = new Size(53, 35);
            label1.TabIndex = 20;
            label1.Text = "Поиск";
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Font = new Font("Gabriola", 14F);
            flowLayoutPanel.Location = new Point(12, 46);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(755, 467);
            flowLayoutPanel.TabIndex = 19;
            flowLayoutPanel.WrapContents = false;
            // 
            // buttonShowMaterials
            // 
            buttonShowMaterials.BackColor = Color.FromArgb(45, 96, 51);
            buttonShowMaterials.FlatStyle = FlatStyle.Flat;
            buttonShowMaterials.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            buttonShowMaterials.ForeColor = Color.White;
            buttonShowMaterials.Location = new Point(786, 456);
            buttonShowMaterials.Name = "buttonShowMaterials";
            buttonShowMaterials.Size = new Size(298, 53);
            buttonShowMaterials.TabIndex = 28;
            buttonShowMaterials.Text = "Показать Материалы";
            buttonShowMaterials.UseVisualStyleBackColor = false;
            buttonShowMaterials.Click += buttonShowMaterials_Click;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 521);
            Controls.Add(buttonShowMaterials);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(searchArticleTB);
            Controls.Add(label3);
            Controls.Add(searchTypeTB);
            Controls.Add(label2);
            Controls.Add(searchNameTB);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ManagerForm";
            Text = "ManagerForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Button button1;
        private Label label4;
        private TextBox searchArticleTB;
        private Label label3;
        private TextBox searchTypeTB;
        private Label label2;
        private TextBox searchNameTB;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem nameToolStripMenuItem;
        private Button buttonShowMaterials;
    }
}