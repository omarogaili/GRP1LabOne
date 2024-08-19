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
            SuspendLayout();
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new Point(28, 65);
            InputTextBox.Multiline = true;
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(230, 113);
            InputTextBox.TabIndex = 0;
            // 
            // ResultatTextBox
            // 
            ResultatTextBox.Location = new Point(548, 65);
            ResultatTextBox.Multiline = true;
            ResultatTextBox.Name = "ResultatTextBox";
            ResultatTextBox.Size = new Size(230, 113);
            ResultatTextBox.TabIndex = 1;
            // 
            // Encrypt
            // 
            Encrypt.Location = new Point(61, 284);
            Encrypt.Name = "Encrypt";
            Encrypt.Size = new Size(155, 64);
            Encrypt.TabIndex = 2;
            Encrypt.Text = "Encrypt";
            Encrypt.UseVisualStyleBackColor = true;
            Encrypt.Click += Encrypt_Click;
            // 
            // Decrypt
            // 
            Decrypt.Location = new Point(588, 284);
            Decrypt.Name = "Decrypt";
            Decrypt.Size = new Size(155, 64);
            Decrypt.TabIndex = 3;
            Decrypt.Text = "Decrypt";
            Decrypt.UseVisualStyleBackColor = true;
            Decrypt.Click += Decrypt_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(341, 48);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(100, 23);
            PasswordTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PasswordTextBox);
            Controls.Add(Decrypt);
            Controls.Add(Encrypt);
            Controls.Add(ResultatTextBox);
            Controls.Add(InputTextBox);
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
    }
}
