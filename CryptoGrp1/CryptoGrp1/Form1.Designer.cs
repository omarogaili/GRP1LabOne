namespace CryptoGrp1
{
    partial class Form1
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
            InputTextBox = new TextBox();
            ResultatTextBox = new TextBox();
            Encrypt = new Button();
            Decrypt = new Button();
            PasswordTextBox = new TextBox();
            ClearDataBtn = new Button();
            SuspendLayout();
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new Point(32, 87);
            InputTextBox.Margin = new Padding(3, 4, 3, 4);
            InputTextBox.Multiline = true;
            InputTextBox.Name = "InputTextBox";
            InputTextBox.PlaceholderText = "Input..";
            InputTextBox.Size = new Size(262, 149);
            InputTextBox.TabIndex = 0;
            // 
            // ResultatTextBox
            // 
            ResultatTextBox.Location = new Point(626, 87);
            ResultatTextBox.Margin = new Padding(3, 4, 3, 4);
            ResultatTextBox.Multiline = true;
            ResultatTextBox.Name = "ResultatTextBox";
            ResultatTextBox.PlaceholderText = "Output..";
            ResultatTextBox.Size = new Size(262, 149);
            ResultatTextBox.TabIndex = 1;
            // 
            // Encrypt
            // 
            Encrypt.Location = new Point(70, 379);
            Encrypt.Margin = new Padding(3, 4, 3, 4);
            Encrypt.Name = "Encrypt";
            Encrypt.Size = new Size(177, 85);
            Encrypt.TabIndex = 2;
            Encrypt.Text = "Encrypt";
            Encrypt.UseVisualStyleBackColor = true;
            Encrypt.Click += Encrypt_Click;
            // 
            // Decrypt
            // 
            Decrypt.Location = new Point(672, 379);
            Decrypt.Margin = new Padding(3, 4, 3, 4);
            Decrypt.Name = "Decrypt";
            Decrypt.Size = new Size(177, 85);
            Decrypt.TabIndex = 3;
            Decrypt.Text = "Decrypt";
            Decrypt.UseVisualStyleBackColor = true;
            Decrypt.Click += Decrypt_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(390, 144);
            PasswordTextBox.Margin = new Padding(3, 4, 3, 4);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.PlaceholderText = "Password";
            PasswordTextBox.Size = new Size(114, 27);
            PasswordTextBox.TabIndex = 4;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            // 
            // ClearDataBtn
            // 
            ClearDataBtn.Location = new Point(390, 312);
            ClearDataBtn.Name = "ClearDataBtn";
            ClearDataBtn.Size = new Size(114, 27);
            ClearDataBtn.TabIndex = 5;
            ClearDataBtn.Text = "Clear Data";
            ClearDataBtn.UseVisualStyleBackColor = true;
            ClearDataBtn.Click += ClearDataBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(ClearDataBtn);
            Controls.Add(PasswordTextBox);
            Controls.Add(Decrypt);
            Controls.Add(Encrypt);
            Controls.Add(ResultatTextBox);
            Controls.Add(InputTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputTextBox;
        private TextBox ResultatTextBox;
        private Button Encrypt;
        private Button Decrypt;
        private TextBox PasswordTextBox;
        private Button ClearDataBtn;
    }
}
