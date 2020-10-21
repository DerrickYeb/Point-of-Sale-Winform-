using DesktopUI.Controller;
using DesktopUI.Handler;
using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            this.KeyPreview = true;

        }
        SettingsModel s = new SettingsModel();
        SettingsController scontroller = new SettingsController();
        private readonly DataConnection connection = new DataConnection();


        //AppSettings appSettings = new AppSettings();

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            user.ShowDialog();
        }


        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            s.ShopName = txtShopName.Text;
            s.Phone = txtShopPhone.Text;
            s.Location = txtLocation.Text;
            s.LicenseId = txtLicensedNum.Text;
            s.DateLicensed = txtLIcensedDt.Text;
            s.DateRenewed = txtRenewed.Text;

            scontroller.UpdateNow(s);

            if (txtShopName.Text != " ")
            {

                MessageBox.Show("Update Successfully!! Changes will take effect on next startup","Updating Settings",MessageBoxButtons.YesNo);

            }
            else
            {
                MessageBox.Show("Failed to Update");
            }
        }

        private async void Settings_Load(object sender, EventArgs e)
        {
            await GetAutoCompleTeDataAsync();
            txtSearch.Focus();

            LoadUsers();
        }

        private void SearchShopName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public async Task GetAutoCompleTeDataAsync()
        {

            string connection = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            string query = ("Select Name from Settings");

            using (SqlConnection conn = new SqlConnection(connection))
            {

                SqlCommand cmd = new SqlCommand(query, conn);

                await conn.OpenAsync();


                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    while (await dr.ReadAsync())
                    {
                        collection.Add(dr.GetString(0));


                    }


                    txtSearch.AutoCompleteCustomSource = collection;




                    dr.Close();
                }
                conn.Close();
            }


        }

        private void SearchShopName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSearch_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                connection.MyConnection();
                connection.SqlQuery("Select Name,LicensedNumber,DateLicensed,Renewed,Phone from [Settings]");
                connection.command.Parameters.AddWithValue("@name", txtShopName.Text);

                using (SqlDataReader dr = connection.command.ExecuteReader())
                {
                    bool productFound;


                    if (productFound = dr.Read())
                    {
                        txtShopName.Text = dr["Name"].ToString();
                        txtLicensedNum.Text = dr["LicensedNumber"].ToString();
                        txtLIcensedDt.Text = dr["DateLicensed"].ToString();
                        txtRenewed.Text = dr["Renewed"].ToString();
                        txtShopPhone.Text = dr["Phone"].ToString();
                        dr.Close();
                    }
                    else
                    {
                        MessageBox.Show("Shop Name not Available");
                    }
                }






            }
        }
        private void LoadUsers()
        {
            //ShopDataContext db = new ShopDataContext();
            //var gettem = from c in db.Users
            //             select c;

            //UsersGridView.DataSource = gettem;
        }
        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to close","Closing Settings Form",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                new Dashboard().Show();
                Hide();
            }
        }

        private void Btnload_Click(object sender, EventArgs e)
        {
            //DataTable x = await shop.LoadSaleDetails();
            //salesdetailsControl.DataSource = x;
        }
    }
}

