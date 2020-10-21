using Dapper;
using DesktopUI.Controller;
using DesktopUI.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class Sales : XtraForm
    {
        ShopRepository shop = new ShopRepository();
        public Sales()
        {
            InitializeComponent();


        }

        private async void Sales_Load(object sender, EventArgs e)
        {
            DataTable x = await shop.LoadSales();
            SalesGridControl.DataSource = x;

        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    string query = "Select Id,SalesNumber,CashierId,SalesDate,Subtotal,Discount,Total,TotalItems,CustomerName,Status from Sales where SalesDate between " +
                        $" convert(varchar(25),'{dtFromdate.EditValue}',103) and convert(varchar(25),'{dtTodate.EditValue}',103) ";
                    salesModelBindingSource.DataSource = connection.Query<SalesModel>(query, commandType: CommandType.Text);
                }
            }

            //DataTable x = await shop.LoadSales();
            ////SalesGridControl.DataSource = x;
            //salesModelBindingSource.DataSource = x;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            SalesModel obj = salesModelBindingSource.Current as SalesModel;

            if (obj != null)
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                        string query = "Select SalesId,Product,Quantity,Price,Discount from [SalesDetails]  " +
                            $" where SalesId = '{obj.Id}'";
                        List<SalesDetails> list = connection.Query<SalesDetails>(query, commandType: CommandType.Text).ToList();
                        using (frmPrint frm = new frmPrint())
                        {
                            frm.PrintInvoice(obj, list);

                            frm.ShowDialog();
                        }


                    }
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CLosing Sales Data", "Sales Details Form", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                new Dashboard().Show();
                this.Dispose();
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

    }
}
