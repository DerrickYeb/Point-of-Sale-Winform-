using DesktopUI.Controller;
using DesktopUI.Models;
using DesktopUI.Properties;
using DevExpress.XtraReports.UI;
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
    public partial class Cashier : Form
    {
        private readonly DataConnection connection = new DataConnection();
        private readonly ProductsModel prdt = new ProductsModel();
        private readonly Operation op = new Operation();

        private readonly SalesRepository repo = new SalesRepository();
        private readonly ShopDetails sd = new ShopDetails();
        public decimal GrandTotal;
        public decimal Subtotal;
        private readonly ShopRepository shop = new ShopRepository();
        OrderDetails od = new OrderDetails();
        public Cashier()
        {
            InitializeComponent();
            this.KeyPreview = true;
            sdate.Text = DateTime.UtcNow.ToLongDateString();
            lblSalesId.Text = od.SalesId;
            repo.GetSalesId(od);
        }
        public void DecreaseQty()
        {
            connection.SqlQuery(@"Update Product SET ProductUnit = ProductUnit - @qun");
            connection.command.Parameters.Add("@qun", SqlDbType.Float).Value = txtQty.Text;

            connection.command.ExecuteNonQuery();
        }
        private void AddToCartOperator()
        {
            try
            {


                string ProductName = txtPName.Text;
                decimal Price = decimal.Parse(txtPrice.Text);
                decimal Qty = decimal.Parse(txtQty.Text);

                decimal Total = Price * Qty;

                decimal SubTotal = decimal.Parse(txtSubtotal.Text);
                SubTotal += Total;

                bool Found = false;
                Total = Convert.ToDecimal(txtPrice.Text) * Qty;





                if (shoppingCart.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in shoppingCart.Rows)
                    {
                        if (Convert.ToString(row.Cells[0].Value) == ProductName && Convert.ToDecimal(row.Cells[2].Value) == Price)
                        {
                            //Update quantity
                            row.Cells[1].Value = Convert.ToString(Qty + Convert.ToInt16(row.Cells[1].Value));
                            row.Cells[3].Value = Convert.ToDouble(row.Cells[1].Value) * Convert.ToDouble(row.Cells[2].Value);

                            Found = true;

                            txtSubtotal.Text = SubTotal.ToString();
                            Clear();
                            txtSearchProdt.Focus();
                        }
                    }
                    if (!Found)
                    {
                        shoppingCart.Rows.Add(ProductName, Qty, Price, Total);

                        txtSubtotal.Text = SubTotal.ToString();

                        Clear();
                    }


                }
                else
                {


                    shoppingCart.Rows.Add(ProductName, Qty, Price, Total);


                    txtSubtotal.Text = SubTotal.ToString();

                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;

            }
        }

        private void Clear()
        {
            ResetText();
        }

        public DataSet GetDataset()
        {
            DataSet orderset = new DataSet();
            orderset.DataSetName = "OrderSet";
            DataTable dataTable = new DataTable();

            orderset.Tables.Add(dataTable);
            // dataTable = shoppingCart.DataSource as DataTable;
            dataTable.Namespace = "ShoppingCart";


            dataTable.Columns.Add("Product");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Total");


            DataRow drlocal = null;
            foreach (DataGridViewRow dr in shoppingCart.Rows)
            {
                drlocal = dataTable.NewRow();
                drlocal["Product"] = dr.Cells["Product"].Value;
                drlocal["Quantity"] = dr.Cells["Quantity"].Value;
                drlocal["Price"] = dr.Cells["Price"].Value;
                drlocal["Total"] = dr.Cells["Total"].Value;
                dataTable.Rows.Add(drlocal);
            }

            return orderset;
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
                        txtSearchProdt.AutoCompleteCustomSource = collection;
                    }));


                    dr.Close();
                }
                conn.Close();
            }


        }

        private void TxtSearchProdt_TextChanged(object sender, EventArgs e)
        {

        }


        private async void Cashier_Load(object sender, EventArgs e)
        {
            lblSalesId.Text = od.SalesId;
            repo.GetSalesId(od);




            await GetAutoCompleTeDataAsync();

            txtSearchProdt.Focus();
        }

        private void BtnExpenses_Click(object sender, EventArgs e) => new AddExpenses(new Expenses()).ShowDialog();

        private void BtnProducts_Click(object sender, EventArgs e) => new AddProduct(new Products()).Show();

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmation = MessageBox.Show("Are you want to delete item", "Deleting Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmation == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in shoppingCart.SelectedRows)
                    {
                        decimal Price_To_Deduct = 0;
                        decimal Current_Total = 0;
                        decimal New_Total_Price = 0;

                        Price_To_Deduct = Convert.ToInt32(item.Cells[3].Value);
                        Current_Total = Convert.ToDecimal(txtSubtotal.Text);
                        // Current_Total = Convert.ToDecimal(txtTotal.Text);
                        New_Total_Price = Current_Total - Price_To_Deduct;
                        shoppingCart.Rows.Remove(item);


                        txtSubtotal.Text = " ";
                        txtSubtotal.Text = Convert.ToDecimal(New_Total_Price).ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BtnAddToCart_Click(object sender, EventArgs e) => AddToCartOperator();

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            connection.MyConnection();
            connection.SqlQuery("Select * from [Product] where ProductName=@name");
            connection.command.Parameters.AddWithValue("@name", txtSearchProdt.Text);

            SqlDataReader dr = connection.command.ExecuteReader();

            bool productFound;


            if (productFound = dr.Read())
            {
                txtPName.Text = dr["ProductName"].ToString();
                txtPrice.Text = dr["RetailPrice"].ToString();
                txtQuantityLeft.Text = dr["ProductUnit"].ToString();

                prdt.ProductUnit = dr["ProductUnit"].ToString();
                var product = prdt.ProductUnit;
                decimal qty = 0;
                if (product == Convert.ToString(qty))
                {
                    MessageBox.Show("Selected Product Out Of Stock", "Out Stocked Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPName.ResetText();
                    txtPrice.ResetText();
                    txtQuantityLeft.Text = prdt.ProductUnit;
                    btnAddToCart.Enabled = false;
                    txtSearchProdt.Focus();
                    return;
                }
                else
                {
                    txtQty.Focus();
                    txtQuantityLeft.Text = prdt.ProductUnit.ToString();
                }

                dr.Close();
            }
            else
            {
                MessageBox.Show("Product not Added");
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            SalesModel model = new SalesModel();

            if (string.IsNullOrEmpty(txtPaidAmount.Text) || !op.ContainsValidNumbers(txtPaidAmount.Text, txtReturnAmnt.Text, txtTotal.Text))
                return;
            //Parsing values of controls to variables to prevent cross-thread calls
            var salesId = lblSalesId.Text;
            salesId = od.SalesId;
            repo.GetSalesId(od);
            var amount = txtPaidAmount.Text;
            var grandTotal = decimal.Parse(txtTotal.Text);
            var balance = txtReturnAmnt.Text;
            var subtotal = decimal.Parse(txtSubtotal.Text);
            var items = txtQuantityBought.Text;
            var cashier = Settings.Default.Cashier;
            var customer = txtCustomer.Text;
            var status = statusCombo.Text;
            var discount = Convert.ToDecimal(txtDiscount.Text);
            AdminView admin = new AdminView();
            var shopname = admin.lblShopName.Text;
            shopname = sd.Shopname;
            AppSettings app = new AppSettings();
            app.GetAppSettings(sd);


            var confrim = MessageBox.Show("Do you want to print receipt", "Print Receipt Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confrim == DialogResult.No)
            {
                if (string.IsNullOrEmpty(Settings.Default.PrinterName))
                {
                    //Committing And Printing

                    //Just Commiting Without Printing

                    shop.SaveChanges(shoppingCart, cashier, salesId, status, customer, discount, grandTotal,subtotal,items);
                    shop.SaveCartItems(shoppingCart, discount, salesId);
                    DecreaseQty();
                    btnReset.PerformClick();
                    this.Refresh();
                    return;

                }
            }
            else if (confrim == DialogResult.Yes)
            {
                //Executing Commitment && Print Operations Concurrently
                Parallel.Invoke(new Action[]
                {
                    ()=>
                    {
                      
                        //Begining Print Operation
                         
                        Receipt receipt = new Receipt();
                        receipt.Parameters["pShopName"].Value = shopname;
                        receipt.Parameters["pTelephone"].Value = Settings.Default.Phone;
                       // receipt.Parameters["CashierId"].Value = repo.CashieId();
                        receipt.Parameters["pDate"].Value = DateTime.Now;
                        receipt.Parameters["pAmountPaid"].Value = amount;
                        receipt.Parameters["pChange"].Value = balance;
                      receipt.Parameters["pSalesID"].Value = salesId;
                        receipt.Parameters["pCustomer"].Value = customer;
                        receipt.Parameters["pGrandTotal"].Value = grandTotal;
                       receipt.DataSource = GetDataset();
                        receipt.DataMember = GetDataset().Tables[0].TableName;
                        ReportPrintTool printTool = new ReportPrintTool(receipt);
                        ReportPrintTool tool = new ReportPrintTool(receipt);
                       // tool.ShowPreviewDialog();
                       printTool.PrintingSystem.ShowPrintStatusDialog = false;
                       receipt.RequestParameters = false;
                       receipt.CreateDocument(false);
                       printTool.Print();
                       printTool.Dispose();
                       receipt.Dispose();

                    },
                    ()=>
                    {
                        //Saving Everything and Appending Changes
                        shoppingCart.Invoke((MethodInvoker)delegate
                        {
                            shop.SaveChanges(shoppingCart, cashier, salesId, status, customer, discount, grandTotal,subtotal,items);
                            shop.SaveCartItems(shoppingCart,discount,salesId);
                            DecreaseQty();
                        });

                    }
                });
            }

            btnReset.PerformClick();
            GC.Collect();
        }

        private void ShoppingCart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var confirmation = MessageBox.Show("Are you want to delete item", "Deleting Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow item in shoppingCart.SelectedRows)
                        {
                            decimal Price_To_Deduct = 0;
                            decimal Current_Total = 0;
                            decimal New_Total_Price = 0;

                            Price_To_Deduct = Convert.ToInt32(item.Cells[3].Value);
                            Current_Total = Convert.ToDecimal(txtSubtotal.Text);
                            // Current_Total = Convert.ToDecimal(txtTotal.Text);
                            New_Total_Price = Current_Total - Price_To_Deduct;
                            shoppingCart.Rows.Remove(item);


                            txtSubtotal.Text = " ";
                            txtSubtotal.Text = Convert.ToDecimal(New_Total_Price).ToString();

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtDiscount_TextChanged_1(object sender, EventArgs e)
        {

            decimal Subtotal = decimal.Parse(txtSubtotal.Text);
            decimal discount = 0.00M; /*=/* Convert.ToDecimal(txtDiscount.Text);*/
            decimal.TryParse(txtDiscount.Text.ToString(), out discount);


            decimal GrandTotal = Convert.ToDecimal((100 - discount) / 100) * Subtotal;

            txtTotal.Text = GrandTotal.ToString("0.00");

            txtDiscount.Text = discount.ToString("0.00");
            txtSubtotal.Text = Subtotal.ToString("0.00");
        }

        private void TxtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (!op.ContainsValidNumbers(txtPaidAmount.Text, txtDiscount.Text, txtPrice.Text))
            {
                txtPaidAmount.ResetText();
                txtReturnAmnt.ResetText();
                return;
            }

            decimal PaidAmount = decimal.Parse(txtPaidAmount.Text);
            decimal GrandTotal = decimal.Parse(txtTotal.Text);

            decimal ReturnAmount = PaidAmount - GrandTotal;

            txtReturnAmnt.Text = ReturnAmount.ToString("0.00");
        }

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!op.ContainsValidNumbers(txtQty.Text, txtPrice.Text, txtQuantityLeft.Text) || string.IsNullOrEmpty(txtPName.Text))
                {
                    txtQty.ResetText();
                    btnAddToCart.Enabled = false;

                    return;
                }

                var qty = Convert.ToInt32(txtQty.Text.Trim());


                var quantity = Convert.ToInt32(txtQuantityLeft.Text);
                if (quantity != 0)
                {
                    if (qty <= quantity && qty > 0)
                        btnAddToCart.Enabled = true;

                    else
                        btnAddToCart.Enabled = false;

                }

                else
                {
                    btnAddToCart.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void TxtSearchProdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                connection.MyConnection();
                connection.SqlQuery("Select * from [Product] where ProductName=@name");
                connection.command.Parameters.AddWithValue("@name", txtSearchProdt.Text);

                SqlDataReader dr = connection.command.ExecuteReader();

                bool productFound;


                if (productFound = dr.Read())
                {
                    txtPName.Text = dr["ProductName"].ToString();
                    txtPrice.Text = dr["RetailPrice"].ToString();
                    txtQuantityLeft.Text = dr["ProductUnit"].ToString();

                    prdt.ProductUnit = dr["ProductUnit"].ToString();
                    var product = prdt.ProductUnit;
                    decimal qty = 0;
                    if (product == Convert.ToString(qty))
                    {
                        MessageBox.Show("Selected Product Out Of Stock", "Out Stocked Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPName.ResetText();
                        txtPrice.ResetText();
                        txtQuantityLeft.Text = prdt.ProductUnit;
                        btnAddToCart.Enabled = false;
                        txtSearchProdt.Focus();
                        return;
                    }
                    else
                    {
                        txtQty.Focus();
                        txtQuantityLeft.Text = prdt.ProductUnit.ToString();
                    }

                    dr.Close();
                }
                else
                {
                    MessageBox.Show("Product not Added");
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            op.Clear(Controls);
            txtSearchProdt.Focus();
            shoppingCart.Rows.Clear();
            txtPName.Focus();
            GrandTotal = 0.00M;
            txtTotal.Text = GrandTotal.ToString("0.00");
            decimal Discount = 0.00M;
            txtDiscount.Text = Discount.ToString("0.00");
        }
    }
}
