using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DbHandlerGrp1;
using AppContext = DbHandlerGrp1.AppContext;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Configuration;


namespace CryptoGrp1
{
    public partial class Form1 : Form
    {
        private SHA512 sha = SHA512.Create();
        private AppContext _context;
        private Password passDb;
        private byte[] pepper = new byte[16];//Create a salt array with 16 p.
        private byte[] iv = new byte[16]; //Create a IV array with 16 p.



        public Form1()
        {
            InitializeComponent();
            _context = new AppContext();

        }
        /// <summary>
        /// in this method do the Encrypt for the text that the user want to do a cryptation for. 
        /// first i save the Text in the InputTextBox "which the user want to encrypt". than i create a random pepper "salt" and IV. from line
        /// 47 to 52, by using this method RNGCryptoServiceProvider. 
        /// after that and by using the Rfc2898DerivesBytes class we do encryption for the password which the user wrote in the password input.
        /// and by adding the pepper value to it and another random 20 bits.
        /// Aes used to create a encrypt method, the same key is used to encrypt and decrypt the text. 
        /// the key and is created by the crypted password. and the IV is created by the same iv which i generated at line55
        /// need to understand the memory method more... 
        /// after that i save the pepper"salt" value , IV value and the text value att the database, that well help to decrypt the text lateron. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Encrypt_Click(object sender, EventArgs e)
        {
            string inputText = InputTextBox.Text;
            byte[] inputTextEnc = Encoding.UTF8.GetBytes(inputText);
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(pepper);
                rng.GetBytes(iv);
            }

            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(PasswordTextBox.Text, pepper, 20);
            Aes encryptor = Aes.Create();
            encryptor.Key = passwordBytes.GetBytes(32);
            encryptor.IV = iv;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputTextEnc, 0, inputTextEnc.Length);
                    cs.FlushFinalBlock();
                }
                byte[] encryptedDate = ms.ToArray();
                passDb = new Password
                {
                    EncryptedText = Convert.ToBase64String(encryptedDate),
                    Salt = Convert.ToBase64String(pepper),
                    IV = Convert.ToBase64String(iv)

                };

                _context.Passwords.Add(passDb);
                _context.SaveChanges();
                ResultatTextBox.Text = Convert.ToBase64String(encryptedDate);

            }
            InputTextBox.Clear();
            PasswordTextBox.Clear();
        }
        /// <summary>
        /// in this metod used to DEcrypt the text by getting the first match at the database"Bad or Too Bad". 
        /// by using the data Salt, IV and EncryptedText and save them att diffrentce array varibales and use the papper for the password and the same 
        /// iv to create the Key and the IV, so what i did here is to recreate the key and the password and the IV to make a Decrypt for the text which 
        /// the user have saved. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Decrypt_Click(object sender, EventArgs e)
        {
            byte[] inputDecrypt = Convert.FromBase64String(ResultatTextBox.Text);
            passDb = _context.Passwords.FirstOrDefault();
            pepper = Convert.FromBase64String(passDb.Salt);
            byte[] CryptedText = Convert.FromBase64String(passDb.EncryptedText);
            iv = Convert.FromBase64String(passDb.IV);
            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(PasswordTextBox.Text, pepper, 20);
            Aes encryptor = Aes.Create();
            encryptor.Key = passwordBytes.GetBytes(32);
            encryptor.IV = iv;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputDecrypt, 0, inputDecrypt.Length);
                    cs.FlushFinalBlock();
                }
                InputTextBox.Text = Encoding.UTF8.GetString(ms.ToArray());
                ResultatTextBox.Clear();
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearDataBtn_Click(object sender, EventArgs e)
        {
            // Remove all entries from the Passwords table
            _context.Passwords.RemoveRange(_context.Passwords);
            _context.SaveChanges();

            // Clear the input and output text boxes
            InputTextBox.Clear();
            PasswordTextBox.Clear();
            ResultatTextBox.Clear();

            MessageBox.Show("All data has been cleared from the database.");
        }
    }
}