using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace GambitStore
{
    public partial class GambitStore : Form
    {
        
        string gName;
        int i = 0;
        double Sum;
        int LG;
        int Id = LoginScreen.id;
        SqlConnection SqlConnection;
        SqlDataReader sqlReader = null;
        //string CommandText = "Наш SQL скрипт";
        //string connStr = "server=localhost;user=root;database=gamelibrary;";
        //MySqlConnection conn = new MySqlConnection(connStr);
        //conn.Open(); 
        string[] metrosc;
        int index1 = 0;
        string[] dotasc;
        int index2 = 0;
        string[] gtasc;
        int index3 = 0;
        string[] witchersc;
        int index4 = 0;
        string[] doomsc;
        int index5 = 0;
        string[] rainbowsc;
        int index6 = 0;
        LoginScreen log = new LoginScreen();
        public GambitStore(SqlConnection connection)
        {
            InitializeComponent();
            SqlConnection = connection;
            
        }
        string sName;
        double balance;
        double cost = 0;
        OpenFileDialog opf = new OpenFileDialog();
        private async void GambitStore_Load(object sender, EventArgs e)
        {
            UsersGamesList.Items.Clear();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\GambitStore\GambitStore\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);
            //connection.Open();
            SqlCommand getProductsInfoCommand = new SqlCommand("SELECT [login], [password], [balance] FROM [Users] WHERE [Id]="+ Id, SqlConnection);
            await SqlConnection.OpenAsync();
            getProductsInfoCommand.Parameters.AddWithValue("balance", balance);
            sqlReader = await getProductsInfoCommand.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                Balance.Text = "Баланс: " + Convert.ToString(sqlReader["balance"]);
                balance = Convert.ToDouble(sqlReader["balance"]);
                Login.Text = Convert.ToString(sqlReader["login"]);
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }

           


            SqlCommand labelway = new SqlCommand("SELECT [way] FROM [Way] WHERE [Id]=1", SqlConnection);
            //await SqlConnection.OpenAsync();
            labelway.Parameters.AddWithValue("way", FolderDialogLabel.Text);
            sqlReader = await labelway.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                FolderDialogLabel.Text = Convert.ToString(sqlReader["way"]);
               
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }
           

            SqlCommand Metro = new SqlCommand("SELECT [Ids], [Idr], [Idgp], [Idd] FROM [Gamess] WHERE [Idg]=1", SqlConnection);
            //await SqlConnection.OpenAsync();
            Metro.Parameters.AddWithValue("Ids", MetroSp.Text);
            Metro.Parameters.AddWithValue("Idr", MetroRates.Text);
            Metro.Parameters.AddWithValue("Idgp", MetroGp.Text);
            Metro.Parameters.AddWithValue("Idd", MetroD.Text);
            sqlReader = await Metro.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                MetroSp.Text = "Поддержка геймпада: " + Convert.ToString(sqlReader["Ids"]);
                MetroRates.Text = "Отзывы: " + Convert.ToString(sqlReader["Idr"]);
                MetroGp.Text = "Издатели: " + Convert.ToString(sqlReader["Idgp"]);
                MetroD.Text = "Разработчики: " + Convert.ToString(sqlReader["Idd"]);
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }
            SqlCommand Dota = new SqlCommand("SELECT [Ids], [Idr], [Idgp], [Idd] FROM [Gamess] WHERE [Idg]=2", SqlConnection);
            //await SqlConnection.OpenAsync();
            Dota.Parameters.AddWithValue("Ids", Dotas.Text);
            Dota.Parameters.AddWithValue("Idr", Dotar.Text);
            Dota.Parameters.AddWithValue("Idgp", Dotagp.Text);
            Dota.Parameters.AddWithValue("Idd", Dotad.Text);
            sqlReader = await Dota.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                Dotas.Text = "Поддержка геймпада: " + Convert.ToString(sqlReader["Ids"]);
                Dotar.Text = "Отзывы: " + Convert.ToString(sqlReader["Idr"]);
                Dotagp.Text = "Издатели: " + Convert.ToString(sqlReader["Idgp"]);
                Dotad.Text = "Разработчики: " + Convert.ToString(sqlReader["Idd"]);
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }

            SqlCommand Gta = new SqlCommand("SELECT [Ids], [Idr], [Idgp], [Idd] FROM [Gamess] WHERE [Idg]=3", SqlConnection);
            //await SqlConnection.OpenAsync();
            Gta.Parameters.AddWithValue("Ids", Gtas.Text);
            Gta.Parameters.AddWithValue("Idr", Gtar.Text);
            Gta.Parameters.AddWithValue("Idgp", Gtagp.Text);
            Gta.Parameters.AddWithValue("Idd", Gtad.Text);
            sqlReader = await Gta.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                Gtas.Text = "Поддержка геймпада: " + Convert.ToString(sqlReader["Ids"]);
                Gtar.Text = "Отзывы: " + Convert.ToString(sqlReader["Idr"]);
                Gtagp.Text = "Издатели: " + Convert.ToString(sqlReader["Idgp"]);
                Gtad.Text = "Разработчики: " + Convert.ToString(sqlReader["Idd"]);
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }

            SqlCommand Witcher = new SqlCommand("SELECT [Ids], [Idr], [Idgp], [Idd] FROM [Gamess] WHERE [Idg]=4", SqlConnection);
            //await SqlConnection.OpenAsync();
            Witcher.Parameters.AddWithValue("Ids", Witchers.Text);
            Witcher.Parameters.AddWithValue("Idr", Witcherr.Text);
            Witcher.Parameters.AddWithValue("Idgp", Witchergp.Text);
            Metro.Parameters.AddWithValue("Idd", Witcherd.Text);
            sqlReader = await Witcher.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                Witchers.Text = "Поддержка геймпада: " + Convert.ToString(sqlReader["Ids"]);
                Witcherr.Text = "Отзывы: " + Convert.ToString(sqlReader["Idr"]);
                Witchergp.Text = "Издатели: " + Convert.ToString(sqlReader["Idgp"]);
                Witcherd.Text = "Разработчики: " + Convert.ToString(sqlReader["Idd"]);
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }

            SqlCommand Doom = new SqlCommand("SELECT [Ids], [Idr], [Idgp], [Idd] FROM [Gamess] WHERE [Idg]=1", SqlConnection);
            //await SqlConnection.OpenAsync();
            Doom.Parameters.AddWithValue("Ids", Dooms.Text);
            Doom.Parameters.AddWithValue("Idr", Doomr.Text);
            Doom.Parameters.AddWithValue("Idgp", Doomgp.Text);
            Doom.Parameters.AddWithValue("Idd", Doomd.Text);
            sqlReader = await Doom.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                Dooms.Text = "Поддержка геймпада: " + Convert.ToString(sqlReader["Ids"]);
                Doomr.Text = "Отзывы: " + Convert.ToString(sqlReader["Idr"]);
                Doomgp.Text = "Издатели: " + Convert.ToString(sqlReader["Idgp"]);
                Doomd.Text = "Разработчики: " + Convert.ToString(sqlReader["Idd"]);
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }

            SqlCommand Rainbow = new SqlCommand("SELECT [Ids], [Idr], [Idgp], [Idd] FROM [Gamess] WHERE [Idg]=1", SqlConnection);
            //await SqlConnection.OpenAsync();
            Rainbow.Parameters.AddWithValue("Ids", Rainbows.Text);
            Rainbow.Parameters.AddWithValue("Idr", Rainbowr.Text);
            Rainbow.Parameters.AddWithValue("Idgp", Rainbowgp.Text);
            Rainbow.Parameters.AddWithValue("Idd", RAinbowd.Text);
            sqlReader = await Rainbow.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                Rainbows.Text = "Поддержка геймпада: " + Convert.ToString(sqlReader["Ids"]);
                Rainbowr.Text = "Отзывы: " + Convert.ToString(sqlReader["Idr"]);
                Rainbowgp.Text = "Издатели: " + Convert.ToString(sqlReader["Idgp"]);
                RAinbowd.Text = "Разработчики: " + Convert.ToString(sqlReader["Idd"]);
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }
            SqlCommand UsersGames = new SqlCommand("SELECT [gName], [Idu] FROM [UsersGames] WHERE [Idu]=" + Id, SqlConnection);
            //await SqlConnection.OpenAsync();
            UsersGames.Parameters.AddWithValue("gName", label11.Text);
            sqlReader = await UsersGames.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                sName = Convert.ToString(sqlReader["gName"]);
                UsersGamesList.Items.Add(sqlReader.GetValue(0).ToString());
                
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }



            metrosc = Directory.GetFiles(@"..\..\Resources\MetroScreen", "*.jpg");
            dotasc = Directory.GetFiles(@"..\..\Resources\DotaScreen", "*.jpg");
            gtasc = Directory.GetFiles(@"..\..\Resources\GTAScreen", "*.jpg");
            witchersc = Directory.GetFiles(@"..\..\Resources\WitcherScreen", "*.jpg");
            doomsc = Directory.GetFiles(@"..\..\Resources\DoomScreen", "*.jpg");
            rainbowsc = Directory.GetFiles(@"..\..\Resources\RainbowScreen", "*.jpg");
            //
            
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(MainPage);
        }

        private void LibraryButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(LibraryPage);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(FolderDialogLabel.Text + "//Dota 2.url");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(FolderDialogLabel.Text + "//Grand Theft Auto V.url");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(FolderDialogLabel.Text + "//The Witcher 3 Wild Hunt.url");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void BuyButton_Click(object sender, EventArgs e)
        {
            SqlCommand metrocost = new SqlCommand("SELECT [Idsp] FROM [Gamess] WHERE [Idg]=1", SqlConnection);
            //await SqlConnection.OpenAsync();
            metrocost.Parameters.AddWithValue("Idsp", cost);
            sqlReader = await metrocost.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                cost = 0;
                tabControl1.SelectTab(CartPage);
                cost = Convert.ToDouble(sqlReader["Idsp"]);
                GameCart.Text = "Metro 2033 Redux";
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(CartPage);
        }

        private void ThanksButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(MainPage);
        }

        private async void BuyButton_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (GameCart.Text == UsersGamesList.Items.ToString())
                {
                    MessageBox.Show("Эта игра у вас уже есть", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (GameCart.Text.Contains("Metro 2033 Redux")) { LG = 1; gName = "Metro 2033 Redux"; }
                    if (GameCart.Text.Contains("Dota 2")) { LG = 2; gName = "Dota 2"; }
                    if (GameCart.Text.Contains("Grand Theft Auto V")) { LG = 3; gName = "Grand Theft Auto V"; }
                    if (GameCart.Text.Contains("The Witcher 3")) { LG = 4; gName = "The Witcher 3"; }
                    if (GameCart.Text.Contains("Doom")) { LG = 5; gName = "Doom"; }
                    if (GameCart.Text.Contains("Tom Clansy's Rainbow Six Siedge")) { LG = 6; gName = "Tom Clansy's Rainbow Six Siedge"; }

                    SqlCommand lg = new SqlCommand("INSERT INTO [UsersGames] (Idu, IDg, gName)VALUES(@Idu, @Idg, @gName)", SqlConnection);
                    lg.Parameters.AddWithValue("Idu", Id);
                    lg.Parameters.AddWithValue("Idg", LG);
                    lg.Parameters.AddWithValue("gName", gName);
                    try
                    {
                        await lg.ExecuteNonQueryAsync();
                        UsersGamesList.Items.Add(gName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (balance >= cost)
                    {
                        tabControl1.SelectTab(ThanksPage);
                        Balance.Text = "Баланс: " + (Sum = balance - cost);
                        SqlCommand Balan = new SqlCommand("Update Users SET balance =" + Sum + "WHERE[Id] =" + Id, SqlConnection);
                        Balan.Parameters.AddWithValue("balance", Sum);
                        try
                        {
                            await Balan.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else MessageBox.Show("Не хватает средств", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Подтвердите что хотите купить игры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);  
        }

        private void Game1_Click(object sender, EventArgs e)
        {    
            tabControl1.SelectTab(GamePage1);
        }

        private void Game2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(GamePage2);
        }

        private async void FolderDialogButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                opf.InitialDirectory = folderBrowserDialog1.SelectedPath;
                FolderDialogLabel.Text = folderBrowserDialog1.SelectedPath;
                SqlCommand way = new SqlCommand("UPDATE Way SET way ="+ FolderDialogLabel.Text + "WHERE[Id] =" + 1, SqlConnection);
                //await SqlConnection.OpenAsync();
                way.Parameters.AddWithValue("way", FolderDialogLabel.Text);
                try
                {
                    await way.ExecuteNonQueryAsync();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void CartButton2_Click(object sender, EventArgs e)
        {
            SqlCommand dotacost = new SqlCommand("SELECT [Idsp] FROM [Gamess] WHERE [Idg]=2", SqlConnection);
            //await SqlConnection.OpenAsync();
            dotacost.Parameters.AddWithValue("Idsp", cost);
            sqlReader = await dotacost.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                cost = 0;
                tabControl1.SelectTab(CartPage);
                cost = Convert.ToDouble(sqlReader["Idsp"]);
                GameCart.Text = "Dota 2";
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }
            
        }

        private void MetroScreenshots_Click(object sender, EventArgs e)
        {
            MetroScreenshots.Image = new Bitmap(metrosc[index1++]);
            if (index1 == metrosc.Length)
                index1 = 0;
            //MetroScreenshots.Image = Properties.Resources.metroscr2;
        }

        private void DotaScreenshots_Click(object sender, EventArgs e)
        {
            DotaScreenshots.Image = new Bitmap(dotasc[index2++]);
            if (index2 == dotasc.Length)
                index2 = 0;
        }

        private void ApplicationCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GtaScreenshots_Click(object sender, EventArgs e)
        {
            GtaScreenshots.Image = new Bitmap(gtasc[index3++]);
            if (index3 == gtasc.Length)
                index3 = 0;
        }

        private void Game3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(GamePage3);
        }

        private void Game4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(GamePage4);
        }

        private void Game5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(GamePage5);
        }

        private void Game6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(GamePage6);
        }

        private void WitcherScreenshots_Click(object sender, EventArgs e)
        {
            WitcherScreenshots.Image = new Bitmap(witchersc[index4++]);
            if (index4 == witchersc.Length)
                index4 = 0;
        }

        private void DoomScreenshots_Click(object sender, EventArgs e)
        {
            DoomScreenshots.Image = new Bitmap(doomsc[index5++]);
            if (index5 == doomsc.Length)
                index5 = 0;
        }

        private void RainbowScreenshots_Click(object sender, EventArgs e)
        {
            RainbowScreenshots.Image = new Bitmap(rainbowsc[index6++]);
            if (index6 == rainbowsc.Length)
                index6 = 0;
        }

        private void сменитьАкааунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form lgs = new LoginScreen();
            this.Close();
            lgs.ShowDialog();
        }

        private void ApplicationCloseButton_MouseMove(object sender, MouseEventArgs e)
        {
            ApplicationCloseButton.BackColor = Color.Firebrick;
        }

        private void ApplicationCloseButton_MouseLeave(object sender, EventArgs e)
        {
            ApplicationCloseButton.BackColor = Color.Transparent;
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(CartPage);
        }

        private void SearchButton_MouseMove(object sender, MouseEventArgs e)
        {
            SearchButton.BackColor = Color.LightGreen;
            SearchButton.ForeColor = Color.DarkGreen;
    }

        private void SearchButton_MouseLeave(object sender, EventArgs e)
        {
            SearchButton.BackColor = Color.Transparent;
            SearchButton.ForeColor = Color.White;
        }

        private void CartButton_MouseMove(object sender, MouseEventArgs e)
        {
            CartButton.ForeColor = Color.LightCoral;
        }

        private void CartButton_MouseLeave(object sender, EventArgs e)
        {
            
            CartButton.ForeColor = Color.White;
        }

        private void LibraryButton_MouseMove(object sender, MouseEventArgs e)
        {
            LibraryButton.ForeColor = Color.LightCoral;
        }

        private void LibraryButton_MouseLeave(object sender, EventArgs e)
        {
            LibraryButton.ForeColor = Color.White;
        }

        private void MainButton_MouseMove(object sender, MouseEventArgs e)
        {
            MainButton.ForeColor = Color.LightCoral;
        }

        private void MainButton_MouseLeave(object sender, EventArgs e)
        {
            MainButton.ForeColor = Color.White;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text == "Metro" || SearchBox.Text == "Metro 2033" || SearchBox.Text == "Metro 2033 Redux")
            {
                tabControl1.SelectTab(GamePage1);
            }
            else if (SearchBox.Text == "Dota" || SearchBox.Text == "Dota 2")
            {
                tabControl1.SelectTab(GamePage2);
            }
            else if (SearchBox.Text == "Grand Theft Auto V")
            {
                tabControl1.SelectTab(GamePage3);
            }
            else if (SearchBox.Text == "Witcher 3" || SearchBox.Text == "The Witcher 3" || SearchBox.Text == "The Witcher 3 Wild Hunt")
            {
                tabControl1.SelectTab(GamePage4);
            }
            else if (SearchBox.Text == "Doom")
            {
                tabControl1.SelectTab(GamePage5);
            }
            else if (SearchBox.Text == "Rainbow" || SearchBox.Text == "Rainbox Six" || SearchBox.Text == "Rainbow Six Siedge" || SearchBox.Text == "Tom Clancy's Rainbow Six Siedge")
            {
                tabControl1.SelectTab(GamePage6);
            }
        }

        private async void CartButton3_Click(object sender, EventArgs e)
        {
            SqlCommand gtacost = new SqlCommand("SELECT [Idsp] FROM [Gamess] WHERE [Idg]=3", SqlConnection);
            //await SqlConnection.OpenAsync();
            gtacost.Parameters.AddWithValue("Ids", cost);     
            sqlReader = await gtacost.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {        
                cost = 0;
                tabControl1.SelectTab(CartPage);
                cost = Convert.ToDouble(sqlReader["Idsp"]);
                GameCart.Text = "Grand Theft Auto V";
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }
            
        }

        private async void CartButton4_Click(object sender, EventArgs e)
        {
            SqlCommand witchercost = new SqlCommand("SELECT [Idsp] FROM [Gamess] WHERE [Idg]=4", SqlConnection);
            //await SqlConnection.OpenAsync();
            witchercost.Parameters.AddWithValue("Idsp", cost);
            sqlReader = await witchercost.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            { 
                cost = 0;
                tabControl1.SelectTab(CartPage);
                cost = Convert.ToDouble(sqlReader["Idsp"]);
                GameCart.Text = "The Witcher 3";
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            } 
        }

        private async void CartButton5_Click(object sender, EventArgs e)
        {
            SqlCommand doomcost = new SqlCommand("SELECT [Idsp] FROM [Gamess] WHERE [Idg]=5", SqlConnection);
            //await SqlConnection.OpenAsync();
            doomcost.Parameters.AddWithValue("Idsp", cost);
            sqlReader = await doomcost.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                cost = 0;
                tabControl1.SelectTab(CartPage);
                cost = Convert.ToDouble(sqlReader["Idsp"]);
                GameCart.Text = "Doom";
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }
        }

        private async void CartButton6_Click(object sender, EventArgs e)
        {
            SqlCommand rainbowcost = new SqlCommand("SELECT [Idsp] FROM [Gamess] WHERE [Idg]=6", SqlConnection);
            //await SqlConnection.OpenAsync();
            rainbowcost.Parameters.AddWithValue("Idsp", cost);
            sqlReader = await rainbowcost.ExecuteReaderAsync();
            while (await sqlReader.ReadAsync())
            {
                cost = 0;
                tabControl1.SelectTab(CartPage);
                cost = Convert.ToDouble(sqlReader["Idsp"]);
                GameCart.Text = "Tom Clansy's Rainbow Six Siedge";
            }
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
            }
 
        }

        private async void UpBalanceButton_Click(object sender, EventArgs e)
        {
             
            SqlCommand UpBalance = new SqlCommand("Update Users SET balance ="+(Convert.ToInt32(BalanceBox.Text) + balance)+ "WHERE[Id] =" +Id, SqlConnection);
            //await SqlConnection.OpenAsync();
            UpBalance.Parameters.AddWithValue("balance", BalanceBox.Text);
            try
            {
                balance += Convert.ToInt32(BalanceBox.Text);
                Balance.Text = "Баланс: " + Convert.ToString(balance);
                await UpBalance.ExecuteNonQueryAsync(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BalanceButton_MouseMove(object sender, MouseEventArgs e)
        {
            BalanceButton.ForeColor = Color.LightCoral;
        }

        private void BalanceButton_MouseLeave(object sender, EventArgs e)
        {
            BalanceButton.ForeColor = Color.White;
        }

        private void MetroStart_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(FolderDialogLabel.Text + "//Metro 2033.url");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoomStart_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(FolderDialogLabel.Text + "//Doom.url");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RainbowStart_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(FolderDialogLabel.Text + "//RainbowSixSiedge.url");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {
            if (UsersGamesList.SelectedItems.Contains("Dota 2"))
            {
                try
                {
                    Process.Start(FolderDialogLabel.Text + "//Dota 2.url");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (UsersGamesList.SelectedItems.Contains("Metro 2033 Redux"))
            {
                try
                {
                    Process.Start(FolderDialogLabel.Text + "//Metro 2033 Redux.url");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (UsersGamesList.SelectedItems.Contains("Grand Theft Auto V"))
            {
                try
                {
                    Process.Start(FolderDialogLabel.Text + "//Grand Theft Auto V.url");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (UsersGamesList.SelectedItems.Contains("The Witcher 3"))
            {
                try
                {
                    Process.Start(FolderDialogLabel.Text + "//The Witcher 3 Wild Hunt.url");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (UsersGamesList.SelectedItems.Contains("Doom"))
            {
                try
                {
                    Process.Start(FolderDialogLabel.Text + "//Doom.url");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (UsersGamesList.SelectedItems.Contains("Tom Clansy's Rainbow Six Siedge"))
            {
                try
                {
                    Process.Start(FolderDialogLabel.Text + "//RainbowSixSiedge.url");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программы создана для распространения продуктов игровой индустрии.\nФункциями программы являются – покупка и хранение игр" +
                "\nСборка от 29.05.2019" +
                "\nДля более подробной информации о программе прочтите руководство пользователя", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
