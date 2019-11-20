using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace GambitStore
{
    public partial class RegistrationForm : Form
    {
        private SqlConnection sqlConnection = null;
        SqlDataReader sqlReader = null;
        public RegistrationForm(SqlConnection connection)
        {
            InitializeComponent();
            sqlConnection = connection;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Form lgs = new LoginScreen();
            this.Close();
            lgs.ShowDialog();  
        }

        private async void regButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\GambitStore\GambitStore\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand insertProductsCommand = new SqlCommand("INSERT INTO [Users] (login, password, phone)VALUES(@login, @password, @phone)", sqlConnection);
            await sqlConnection.OpenAsync();
            insertProductsCommand.Parameters.AddWithValue("login", LoginBox.Text);
            insertProductsCommand.Parameters.AddWithValue("password", PasswordBox.Text);
            insertProductsCommand.Parameters.AddWithValue("phone", PhoneBox.Text);

            try
            {
                await insertProductsCommand.ExecuteNonQueryAsync();
                Form lgs = new LoginScreen();
                this.Close();
                lgs.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //sqlConnection = new SqlConnection(connectionString);
            //SqlCommand setusers = new SqlCommand("SELECT [login], [password], [phone] FROM [Users]", SqlConnection);
            //string sql = "INSERT Users (id, login, password, phone, balance) VALUES (@id, @login, @password, @phone, @balance)";
            //await sqlConnection.OpenAsync();
            //setusers.Parameters.AddWithValue("login", LoginBox.Text);
            //setusers.Parameters.AddWithValue("password", PasswordBox.Text);
            //setusers.Parameters.AddWithValue("phone", PhoneBox.Text);
            //sqlReader = await setusers.ExecuteReaderAsync();
            //while (await sqlReader.ReadAsync())
            //{
            //    Convert.ToString(sqlReader["login"]);

            //    Convert.ToString(sqlReader["password"]);

            //    Convert.ToString(sqlReader["phone"]);
            //}
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LoginBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                    PasswordBox.Focus();
                return;
            }
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                    PasswordBox2.Focus();
                return;
            }
        }

        private void PasswordBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                    PhoneBox.Focus();
                return;
            }
        }

        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                    regButton_Click(sender, e);
                return;
            }
        }
    }
}
