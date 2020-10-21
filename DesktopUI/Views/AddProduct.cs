using DesktopUI.Controller;
using DesktopUI.Handler;
using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class AddProduct : Form
    {
        ProductsModel p = new ProductsModel();
        ProductsController controller = new ProductsController();
        DataConnection connection = new DataConnection();
        Products products;


        public AddProduct(Products prop)
        {
            InitializeComponent();
            products = prop;
            
        }
        void LoadSuppliers()
        {
            using (ShopDataContext db = new ShopDataContext())
            {
                SelectSupplier.Items.Clear();
                SelectSupplier.DataSource = db.Suppliers.ToList();
                SelectSupplier.DisplayMember = "Name";
                SelectSupplier.ValueMember = "Id";
                SelectSupplier.SelectedValue = "";
            }
        }
        void LoadCategory()
        {
            using (ShopDataContext db = new ShopDataContext())
            {
                CategorySelect.Items.Clear();
                CategorySelect.DataSource = db.Categories.ToList();
                CategorySelect.DisplayMember = "CategoryName";
                CategorySelect.ValueMember = "Id";
                CategorySelect.SelectedValue = "";
            }
        }
       
        public async Task ComboPopulateForPCategory()
        {
            var das = new DataSet();
            await Task.Run(() =>
            {
                connection.MyConnection();
                connection.SqlQuery("Select CategoryName from Category");
                SqlDataReader dr = connection.command.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            CategorySelect.Items.Add(dr.GetString(i));
                        }));

                    }
                }
                dr.Close();
            });
        }
        public async Task ComboPopulateForSuppliers()
        {
            try
            {
                var das = new DataSet();
                await Task.Run(() =>
                {
                    connection.MyConnection();
                    connection.SqlQuery("Select Name from Supplier");
                    SqlDataReader dr = connection.command.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                SelectSupplier.Items.Add(dr.GetString(i));
                            }));

                        }
                    }
                    dr.Close();
                });
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
           

            p.ProductCode = txtCode.Text;
            p.ProductName = txtName.Text;
            p.Category = CategorySelect.Text;
            p.Supplier = SelectSupplier.Text;
            p.CostPrice = txtPurchasePrice.Text;
            p.RetailPrice = txtSellingPrice.Text;
            p.ProductUnit = txtProductUnit.Text;

            p.Description = productDescription.Text;


            bool success = controller.Insert(p);


            if (success = string.IsNullOrWhiteSpace(txtName.Text))
            {

                MessageBox.Show("Empty fields");
                return;

            }
            else if (success == true)
            {
                MessageBox.Show("Are you sure want to add","Adding Product",MessageBoxButtons.OK,MessageBoxIcon.Information);

                Clear();

                

            }
            else if(success == false)
            {
                MessageBox.Show("Failed to Add");
            }
        }

        public void Clear()
        {
            txtName.Text = "";
            txtCode.Text = "";
            SelectSupplier.Text = "";
            CategorySelect.Text = "";
            txtProductUnit.Text = "";
            txtPurchasePrice.Text = "";
            txtSellingPrice.Text = "";
            productDescription.Text = "";
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            
            //p.Id = txtPrdtId.Text;
            //p.ProductCode = txtCode.Text;
            //p.ProductName = txtName.Text;
            //p.Category = CategorySelect.Text;
            //p.Supplier = SelectSupplier.Text;
            //p.CostPrice = txtPurchasePrice.Text;
            //p.RetailPrice = txtSellingPrice.Text;
            //p.ProductUnit = txtProductUnit.Text;
            //p.Description = productDescription.Text;

            //bool Success = controller.Update(p);

            //if (Success == true)
            //{
            //    MessageBox.Show("Updated Successfully");

                
            //}
            //else
            //{
            //    MessageBox.Show("Updating the product details failed");
            //}
        }
        //if ((e.KeyChar< 48) || (e.KeyChar< 57))
        //   {
        //       e.Handled = true;
        //   }
        private void TxtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {

            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void TxtPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {

            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void TxtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {

            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void TxtProductUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {

            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private async void AddProduct_Load(object sender, EventArgs e)
        {
            //await ComboPopulateForSuppliers();
            await ComboPopulateForPCategory();
        }
    }

}
