using DesktopUI.Controller;
using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class Report : Form
    {
        SalesModel model = new SalesModel();
        SalesDetails details = new SalesDetails();
        ReportWorker worker = new ReportWorker();
        ProductDetails detail = new ProductDetails();
        DataConnection connection = new DataConnection();
        ReportParameters parameters = new ReportParameters();
        public Report()
        {
            InitializeComponent();


        }
        public async Task ComboPopulateForClients()
        {
            var das = new DataSet();
            await Task.Run(() =>
            {
                connection.MyConnection();
                connection.SqlQuery("Select CustomerName from Sales");
                SqlDataReader dr = connection.command.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            comboSelectClient.Items.Add(dr.GetString(i));
                        }));

                    }
                }
                dr.Close();
            });
        }
        public async Task ComboPopulateForProducts()
        {
            var das = new DataSet();
            await Task.Run(() =>
            {
                connection.MyConnection();
                connection.SqlQuery("Select ProductName from Product");
                SqlDataReader dr = connection.command.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            comboSelectProdt.Items.Add(dr.GetString(i));
                        }));
                       
                    }
                }
                dr.Close();
            });
        }
        private void Button1_Click(object sender, EventArgs e)
        {

        }
        public void ReportDetails()
        {
            //Total Customers
            connection.MyConnection();
            connection.SqlQuery("Select Count(Supplier) from [Product]");
            lblTotalCustomers.Text = connection.command.ExecuteScalar().ToString();

            //Total Products
            connection.MyConnection();
            connection.SqlQuery("Select Count(ProductName) from [Product]");
            lblTotalProducts.Text = connection.command.ExecuteScalar().ToString();

            // //Total Sales
            connection.MyConnection();
            connection.SqlQuery("Select Sum(CostPrice) from Product");
            lblTotalSales.Text = connection.command.ExecuteScalar().ToString();
        }
        public void WaitingForm()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(10);
            }
        }
        private async void Report_Load(object sender, EventArgs e)
        {
            await ComboPopulateForClients();
            await ComboPopulateForProducts();
            ReportDetails();
            WaitingForm();


        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are sure want to close","Closing Report",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                new Dashboard().Show();
                Dispose();
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
       
    }
}
