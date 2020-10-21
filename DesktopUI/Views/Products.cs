using DesktopUI.Controller;
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
using System.Xml;
using System.Windows.Forms;
using Dapper;
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace DesktopUI.Views
{
    public partial class Products : DevExpress.XtraEditors.XtraForm
    {

        public Products()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            Thread.Sleep(1000);
           
            InitializeComponent();

            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
     
            gridView1.RowCellClick += GridView1_RowCellClick;
        }

        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //using (UpdateProduct update = new UpdateProduct(gridView1.GetFocusedDataRow()))
            //{
            //    update.ShowDialog();
            //}
        }

        private void gridView1_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
        //    using (UpdateProduct update = new UpdateProduct(gridView1.GetFocusedDataRow()))
        //    {
        //        update.ShowDialog();
        //    }
        }
        private void gridView1_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //using (UpdateProduct update = new UpdateProduct(gridView1.GetFocusedDataRow()))
            //{
            //    update.ShowDialog();
            //}
        }

        ProductsController controller = new ProductsController();
        public void StartForm()
        {
            Application.Run(new WaitingFormLoader());
        }
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct product = new AddProduct(this); //add this
           // product.btnUpdate.Hide();
            product.ShowDialog();

        }

        private void BtnAddStock_Click(object sender, EventArgs e)
        {
            AddStock stock = new AddStock();
            stock.ShowDialog();

        }

        public async Task GetDataTable()
        {
            await Task.Run(async () => 
            {
                DataTable x = await controller.Select();
                ProductsGridView.DataSource = x;
            });
         
        }
        public void ShowDetailsInLabel()
        {
            //int sum = 0;
            //for (int i = 0; i < ProductsGridView.Rows.Count; ++i)
            //{
            //    sum += Convert.ToInt32(ProductsGridView.Rows[i].Cells[6].Value);
            //}
            //lblTotalAmount.Text = sum.ToString();
        }
        private void WaitFormLoad(EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitingFormLoader), true, true, false);
           
            SplashScreenManager.CloseForm();
        }

        private  void Products_Load(object sender, EventArgs e)
        {
          
            
        }

        private void ProductsGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void ProductsGridView_Click(object sender, EventArgs e)
        {
        }

        private void ProductsGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void SearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // GetDataTable();
            gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(gridView1_RowUpdated);
        }

        private void BtnAddProduct_Click_1(object sender, EventArgs e)
        {
            //AddProduct product = new AddProduct(this); //add this
            //product.btnUpdate.Enabled = false;
            //product.ShowDialog();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            ProductsModel objP = productsModelBindingSource.Current as ProductsModel;

            if (objP != null)
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                        string query = "Select ProductCode,ProductName,ProductUnit,RetailPrice,CostPrice,Category,Supplier,CreatedDate,Description from [ProductDetails] " +
                            $" where ProductCode = '{objP.ProductCode}'";
                        List<ProductDetails> list1 = connection.Query<ProductDetails>(query, commandType: CommandType.Text).ToList();
                        using (frmPrint frm = new frmPrint())
                        {
                            frm.PrintProductInvoice(objP, list1);

                            frm.ShowDialog();
                        }


                    }
                }
            }
        }

        private void ProductsGridView_Click_1(object sender, EventArgs e)
        {

        }

        private async void BtnLoad_Click_1(object sender, EventArgs e)
        {
            //WaitFormLoad(e);
            DataTable x = await controller.Select();
            ProductsGridView.DataSource = x;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddProduct product = new AddProduct(this);
           // product.btnUpdate.Enabled = false;
            product.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the form","Closing Products DataView",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                new Dashboard().Show();
                Hide();
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
       
    }
}
