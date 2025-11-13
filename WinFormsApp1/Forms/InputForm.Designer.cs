namespace WinFormsApp1
{
    partial class InputForm
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
            labelPrompt = new Label();
            textBoxInput = new TextBox();
            cancelButton = new Button();
            okButton = new Button();
            SuspendLayout();
            // 
            // labelPrompt
            // 
            labelPrompt.AutoSize = true;
            labelPrompt.BackColor = Color.White;
            labelPrompt.Font = new Font("Gabriola", 14F);
            labelPrompt.ForeColor = Color.FromArgb(45, 96, 51);
            labelPrompt.Location = new Point(12, 9);
            labelPrompt.Name = "labelPrompt";
            labelPrompt.Size = new Size(109, 35);
            labelPrompt.TabIndex = 0;
            labelPrompt.Text = "Введите логин:";
            // 
            // textBoxInput
            // 
            textBoxInput.BackColor = Color.FromArgb(187, 217, 178);
            textBoxInput.Font = new Font("Gabriola", 14F);
            textBoxInput.Location = new Point(127, 6);
            textBoxInput.Margin = new Padding(3, 1, 3, 1);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(185, 39);
            textBoxInput.TabIndex = 1;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(45, 96, 51);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(12, 73);
            cancelButton.Margin = new Padding(3, 1, 3, 1);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(103, 43);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // okButton
            // 
            okButton.BackColor = Color.FromArgb(45, 96, 51);
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.Font = new Font("Gabriola", 16F, FontStyle.Bold);
            okButton.ForeColor = Color.White;
            okButton.Location = new Point(209, 73);
            okButton.Margin = new Padding(3, 1, 3, 1);
            okButton.Name = "okButton";
            okButton.Size = new Size(103, 43);
            okButton.TabIndex = 3;
            okButton.Text = "ОК";
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += okButton_Click;
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 135);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Controls.Add(textBoxInput);
            Controls.Add(labelPrompt);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 1, 3, 1);
            Name = "InputForm";
            Text = "InputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPrompt;
        private TextBox textBoxInput;
        private Button cancelButton;
        private Button okButton;
    }
}