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

namespace InjectionInloggning
{
    public partial class Form1 : Form
    {
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";  // Kontrollerar e-posten
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^\d{10,15}$";  // Kontrollerar att telefonnumret är 10-15 siffror långt
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Inloggning()
        {
            string server = "localhost";
            string database = "********";
            string dbUser = "root";
            string dbPass = "*********";
            string connString = $"SERVER={server};DATABASE={database};UID={dbUser};PASSWORD={dbPass};";
            MySqlConnection conn = new MySqlConnection(connString);

            // Hämta data från textfält
            string user = txtUser.Text;
            string pass = txtPass.Text;

            // Validera att användarnamnet är en e-postadress eller telefonnummer
            if (!IsValidEmail(user) && !IsValidPhoneNumber(user))
            {
                lblStatus.Text = "Användarnamnet måste vara en giltig e-postadress eller telefonnummer.";
                return;
            }

            // Bygg upp SQL-query utan hashning
            string sqlQuery = "SELECT * FROM users WHERE users_username = @user AND users_password = @pass";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass); // Använd lösenord direkt, utan hashning
            lblQuerry.Text = sqlQuery;

            // Exekvera query
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                // Kontrollera resultatet
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
