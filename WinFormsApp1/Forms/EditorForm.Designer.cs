namespace WinFormsApp1
{
    partial class EditorForm
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
            comboBoxType = new ComboBox();
            textBoxName = new TextBox();
            textBoxArticle = new TextBox();
            textBoxCost = new TextBox();
            textBoxRollWidth = new TextBox();
            buttonSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonDelete = new Button();
            SuspendLayout();
            // 
            // comboBoxType
            // 
            comboBoxType.BackColor = Color.White;
            comboBoxType.Font = new Font("Gabriola", 14F);
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(187, 9);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(224, 43);
            comboBoxType.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.FromArgb(187, 217, 178);
            textBoxName.Font = new Font("Gabriola", 14F);
            textBoxName.Location = new Point(187, 80);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(224, 39);
            textBoxName.TabIndex = 1;
            // 
            // textBoxArticle
            // 
            textBoxArticle.BackColor = Color.FromArgb(187, 217, 178);
            textBoxArticle.Font = new Font("Gabriola", 14F);
            textBoxArticle.Location = new Point(187, 145);
            textBoxArticle.Name = "textBoxArticle";
            textBoxArticle.Size = new Size(224, 39);
            textBoxArticle.TabIndex = 2;
            // 
            // textBoxCost
            // 
            textBoxCost.BackColor = Color.FromArgb(187, 217, 178);
            textBoxCost.Font = new Font("Gabriola", 14F);
            textBoxCost.Location = new Point(187, 213);
            textBoxCost.Name = "textBoxCost";
            textBoxCost.Size = new Size(224, 39);
            textBoxCost.TabIndex = 3;
            // 
            // textBoxRollWidth
            // 
            textBoxRollWidth.BackColor = Color.FromArgb(187, 217, 178);
            textBoxRollWidth.Font = new Font("Gabriola", 14F);
            textBoxRollWidth.Location = new Point(187, 279);
            textBoxRollWidth.Name = "textBoxRollWidth";
            textBoxRollWidth.Size = new Size(224, 39);
            textBoxRollWidth.TabIndex = 4;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(45, 96, 51);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(275, 356);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(136, 46);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Gabriola", 14F);
            label1.ForeColor = Color.FromArgb(45, 96, 51);
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(41, 35);
            label1.TabIndex = 6;
            label1.Text = "Тип:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Gabriola", 14F);
            label2.ForeColor = Color.FromArgb(45, 96, 51);
            label2.Location = new Point(12, 84);
            label2.Name = "label2";
            label2.Size = new Size(78, 35);
            label2.TabIndex = 7;
            label2.Text = "Название:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Gabriola", 14F);
            label3.ForeColor = Color.FromArgb(45, 96, 51);
            label3.Location = new Point(12, 149);
            label3.Name = "label3";
            label3.Size = new Size(73, 35);
            label3.TabIndex = 8;
            label3.Text = "Артикул:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Gabriola", 14F);
            label4.ForeColor = Color.FromArgb(45, 96, 51);
            label4.Location = new Point(12, 217);
            label4.Name = "label4";
            label4.Size = new Size(121, 35);
            label4.TabIndex = 9;
            label4.Text = "Мин. стоимость:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Gabriola", 14F);
            label5.ForeColor = Color.FromArgb(45, 96, 51);
            label5.Location = new Point(12, 283);
            label5.Name = "label5";
            label5.Size = new Size(127, 35);
            label5.TabIndex = 10;
            label5.Text = "Длина рулона (м):";
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(45, 96, 51);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(12, 356);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(136, 46);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 422);
            Controls.Add(buttonDelete);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Controls.Add(textBoxRollWidth);
            Controls.Add(textBoxCost);
            Controls.Add(textBoxArticle);
            Controls.Add(textBoxName);
            Controls.Add(comboBoxType);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditorForm";
            Text = "EditorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxType;
        private TextBox textBoxName;
        private TextBox textBoxArticle;
        private TextBox textBoxCost;
        private TextBox textBoxRollWidth;
        private Button buttonSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonDelete;
    }
}