using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

using System.Security.Cryptography;

namespace InjectionInloggning
{
    public partial class Form1 : Form
    {

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


    //    private bool IsValidEmail(string email)
    //{
    //    string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";  // kontorllera emailen
    //    return Regex.IsMatch(email, emailPattern);
    //}

    //private bool IsValidPhoneNumber(string phoneNumber)
    //{
    //    string phonePattern = @"^\d{10,15}$";  // kontrollerar att för telefonnummer med 10 siffror elle 15 siffror for utlandska nummer
    //    return Regex.IsMatch(phoneNumber, phonePattern);
    //}


    public Form1()
        {
            InitializeComponent();
        }

        private void Inloggning()
        {
            string server = "localhost";
            string database = "sqlinkectexample";

            string dbUser = "root";
            string dbPass = "******";

            string connString = $"SERVER={server};DATABASE={database};UID={dbUser};PASSWORD={dbPass};";

            MySqlConnection conn = new MySqlConnection(connString);

            //Hämta data från textfält
            string user = txtUser.Text;
            string pass = txtPass.Text;

            // Validera att användarnamnet är en e-postadress eller telefonnummer
            //if (!IsValidEmail(user) && !IsValidPhoneNumber(user))
            //{
            //    lblStatus.Text = "Användarnamnet måste vara en giltig e-postadress eller telefonnummer.";
            //    return;
            //}
            //if (!IsValidPhoneNumber(user))
            //{
            //    lblStatus.Text = "Användarnamnet måste vara en giltig e-postadress eller telefonnummer.";
            //    return;
            //}

            //Bygger upp SQL querry 
            string hashedPass = HashPassword(pass);
            string sqlQuerry = "SELECT * FROM users WHERE users_username = @user AND users_password = @pass";
            MySqlCommand cmd = new MySqlCommand(sqlQuerry, conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", hashedPass);



            lblQuerry.Text = sqlQuerry;


            //Exekverar querry
            try
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                //Kontrollerar resultatet
                if (reader.Read())
                    lblStatus.Text = "Du har loggat in";
                else
                    lblStatus.Text = "Du är utloggad";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } 
            finally
            {
                conn.Close();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inloggning();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


    }
}
