﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CryptoGrp1
//{
//    //using System;
//    //using System.IO;
//    //using System.Security.Cryptography;

//    //namespace MyNiceApp;

//    class Cheting
//    {
//        static void Main(string[] args)
//        {
//            // The plaintext string
//            string plaintext = "Hello, Baha'is of the World!";

//            // The password used to encrypt the string
//            string password = "my-secret-ian-password";

//            // Encrypt the string
//            string encrypted = EncryptString(plaintext, password);

//            // Decrypt the encrypted string
//            string decrypted = DecryptString(encrypted, password);

//            // Print the original and decrypted strings
//            Console.WriteLine("Original:  " + plaintext);
//            Console.WriteLine("Decrypted: " + decrypted);
//        }

//        static string EncryptString(string plaintext, string password)
//        {
//            // Convert the plaintext string to a byte array
//            byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);

//            // Derive a new password using the PBKDF2 algorithm and a random salt
//            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(password, 20);

//            // Use the password to encrypt the plaintext
//            Aes encryptor = Aes.Create();
//            encryptor.Key = passwordBytes.GetBytes(32);
//            encryptor.IV = passwordBytes.GetBytes(16);
//            using (MemoryStream ms = new MemoryStream())
//            {
//                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
//                {
//                    cs.Write(plaintextBytes, 0, plaintextBytes.Length);
//                }
//                return Convert.ToBase64String(ms.ToArray());
//            }
//        }

//        static string DecryptString(string encrypted, string password)
//        {
//            // Convert the encrypted string to a byte array
//            byte[] encryptedBytes = Convert.FromBase64String(encrypted);

//            // Derive the password using the PBKDF2 algorithm
//            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(password, 20);

//            // Use the password to decrypt the encrypted string
//            Aes encryptor = Aes.Create();
//            encryptor.Key = passwordBytes.GetBytes(32);
//            encryptor.IV = passwordBytes.GetBytes(16);
//            using (MemoryStream ms = new MemoryStream())
//            {
//                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
//                {
//                    cs.Write(encryptedBytes, 0, encryptedBytes.Length);
//                }
//                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
//            }
//        }
//    }
//}
