namespace WinFormsApp1
{
    partial class GuestForm
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
            выходToolStripMenuItem = new ToolStripMenuItem();
            гостьToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(187, 217, 178);
            menuStrip1.Font = new Font("Gabriola", 14F);
            menuStrip1.Items.AddRange(new ToolStripItem[] { выходToolStripMenuItem, гостьToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 1, 0, 1);
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(700, 41);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(65, 39);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // гостьToolStripMenuItem
            // 
            гостьToolStripMenuItem.Enabled = false;
            гостьToolStripMenuItem.Name = "гостьToolStripMenuItem";
            гостьToolStripMenuItem.Size = new Size(61, 39);
            гостьToolStripMenuItem.Text = "Гость";
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Font = new Font("Gabriola", 14F);
            flowLayoutPanel.Location = new Point(12, 42);
            flowLayoutPanel.Margin = new Padding(3, 1, 3, 1);
            flowLayoutPanel.MinimumSize = new Size(675, 440);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(675, 440);
            flowLayoutPanel.TabIndex = 2;
            flowLayoutPanel.WrapContents = false;
            // 
            // GuestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 496);
            Controls.Add(flowLayoutPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 1, 3, 1);
            Name = "GuestForm";
            Text = "Наш декор - Главная";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel;
        private ToolStripMenuItem гостьToolStripMenuItem;
    }
}