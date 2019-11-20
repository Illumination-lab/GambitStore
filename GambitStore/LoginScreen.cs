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
    
    public partial class LoginScreen : Form
    {
       static public int id;
        private SqlConnection SqlConnection = null;
        SqlDataReader sqlReader = null;
        int a = 0;
        public LoginScreen()
        {
            InitializeComponent();
        }


        private async void loginButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\GambitStore\GambitStore\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);
            await SqlConnection.OpenAsync();
            SqlCommand selectusers = new SqlCommand("SELECT [login], [Id], [password] FROM [Users]", SqlConnection);
            selectusers.Parameters.AddWithValue("login", login.Text);
            selectusers.Parameters.AddWithValue("password", password.Text);
            sqlReader = await selectusers.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                if (login.Text == Convert.ToString(sqlReader["login"]) && password.Text == Convert.ToString(sqlReader["password"]))
                {
                    id = Convert.ToInt32(sqlReader["Id"]);
                    Form gambitstore = new GambitStore(SqlConnection);
                    a = 1;
                    gambitstore.Show();
                    this.Hide();
                    return;
                }
            }

            
                if (a != 1) MessageBox.Show("Не правильный логин/пароль, проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            Form regfrm = new RegistrationForm(SqlConnection);
            regfrm.Show();
            this.Hide();
        }

        private async void LoginScreen_Load(object sender, EventArgs e)
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MeisterEnot\source\repos\GambitStore\GambitStore\Database1.mdf;Integrated Security=True";
            //SqlConnection = new SqlConnection(connectionString);
            //await SqlConnection.OpenAsync();
            //SqlCommand selectusers = new SqlCommand("SELECT [login], [password] FROM [Users] WHERE [Id]=@Id", SqlConnection);
            
            //selectusers.Parameters.AddWithValue("login", login.Text);
            //selectusers.Parameters.AddWithValue("password", password.Text);
            
            //try
            //{
            //    await selectusers.ExecuteNonQueryAsync();

            //    Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
               
                if (e.KeyChar == (char)Keys.Enter)      
                    password.Focus();
                return;
            }
        }

        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                    loginButton_Click(sender, e);
                return;
            }
        }
    }
    }
