using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using DesktopUI.Models;
using DesktopUI.Handler;
using DesktopUI.Controller;

namespace DesktopUI.Views
{
    public partial class UpdateProduct : XtraForm
    {
        DataConnection connection = new DataConnection();
        private DataRow _DataRow;
        private bool _Cancelling;
        ProductsController controller = new ProductsController();

        public DataRow DataRow
        {
            get
            {
                return _DataRow;
            }
            set
            {
                if (_DataRow == value) return;

                _DataRow = value;
                UpdateControls();

            }
        }
        public UpdateProduct()
        {
            InitializeComponent();


        }
        public async Task GetAutoCompleTeDataAsync()
        {

            string connection = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            string query = ("Select ProductName from Product");

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
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        txtSearchPrdt.AutoCompleteCustomSource = collection;
                    }));


                    dr.Close();
                }
                conn.Close();
            }


        }
        private void SearchProduct()
        {

            connection.MyConnection();
            connection.SqlQuery("Select * from [Product] where ProductName=@name");
            connection.command.Parameters.AddWithValue("@name", txtSearchPrdt.Text);

            SqlDataReader dr = connection.command.ExecuteReader();

            bool productFound;


            if (productFound = dr.Read())
            {
                txtProdtId.Text = dr["Id"].ToString();
                txtCode.Text = dr["ProductCode"].ToString();
                txtProduct.Text = dr["ProductName"].ToString();
                txtCategory.Text = dr["Category"].ToString();
                txtUnits.Text = dr["ProductUnit"].ToString();
                txtPurchase.Text = dr["CostPrice"].ToString();
                txtSellingP.Text = dr["RetailPrice"].ToString();
                txtSupplier.Text = dr["Supplier"].ToString();
                txtDescription.Text = dr["Description"].ToString();

                dr.Close();
            }
            else
            {
                MessageBox.Show("Product not Added");
            }

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!_Cancelling)
            {
                UpdateRows();
            }
        }

        private void UpdateControls()
        {
            //txtPrdtId.Text = DataRow[0].ToString();
            txtCode.Text = DataRow[0].ToString();
            txtProduct.Text = DataRow[1].ToString();
            txtCategory.Text = DataRow[3].ToString();
            txtDescription.Text = DataRow[4].ToString();
            txtUnits.Text = DataRow[2].ToString();
            txtPurchase.Text = DataRow[5].ToString();
            txtSellingP.Text = DataRow[6].ToString();
            txtSupplier.Text = DataRow[7].ToString();
        }
        private void UpdateRows()
        {
            DataRow[0] = txtProdtId.Text;
            DataRow[1] = txtCode.Text;
            DataRow[2] = txtProduct.Text;
            DataRow[4] = txtCategory.Text;
            DataRow[5] = txtDescription.Text;
            DataRow[3] = txtUnits.Text;
            DataRow[6] = txtPurchase.Text;
            DataRow[7] = txtSellingP.Text;
            DataRow[8] = txtSupplier.Text;

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ProductsModel m = new ProductsModel();
            m.Id = txtProdtId.Text;
            m.ProductCode = txtCode.Text;
            m.ProductName = txtProduct.Text;
            m.ProductUnit = txtUnits.Text;
            m.RetailPrice = txtSellingP.Text;
            m.Supplier = txtSupplier.Text;
            m.CostPrice = txtPurchase.Text;
            m.Category = txtCategory.Text;
            m.Description = txtDescription.Text;

            controller.Update(m);

            if (txtProduct.Text != " ")
            {
                MessageBox.Show("Updated Successfully");
                Clear();

            }
            else
            {
                MessageBox.Show("Update Failed");
            }
        }
        private void Clear()
        {
            txtCode.Text = " ";
            txtProduct.Text = " ";
            txtUnits.Text = " ";
            txtSellingP.Text = " ";
            txtSupplier.Text = " ";
            txtPurchase.Text = " ";
            txtCategory.Text = " ";
            txtDescription.Text = " ";
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var checker = MessageBox.Show("Do you want to cancel Product Update","Cancel Product Update",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (checker == DialogResult.Yes)
            {
                new Dashboard().Show();
                Hide();
            }

        }

        private void TxtSearchPrdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchProduct();
            }
        }

        private async void UpdateProduct_Load(object sender, EventArgs e)
        {
            await GetAutoCompleTeDataAsync();
            txtSearchPrdt.Focus();
        }
    }
}