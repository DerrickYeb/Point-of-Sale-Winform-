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
    public partial class POS : Form
    {
        private readonly DataConnection connection = new DataConnection();
        private readonly Operation op = new Operation();
        private readonly SalesRepository repo = new SalesRepository();
        private readonly ShopDetails sd = new ShopDetails();
        ProductsModel prdt = new ProductsModel();
        public decimal GrandTotal;
        OrderDetails od = new OrderDetails();
        ShopRepository shop = new ShopRepository();
        AccountDetails account = new AccountDetails();

        public POS()
        {
            InitializeComponent();
            this.KeyPreview = true;
            sdate.Text = DateTime.UtcNow.ToLongDateString();
            lblSalesId.Text = od.SalesId;
            repo.GetSalesId(od);

        }
        //using async to get autocomplete action
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
        private void PanelControl_Paint(object sender, PaintEventArgs e)
        {

        }
        //Getting data from datagridview using dataset
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
                if (dr.Cells["Product"] == null)
                {
                    continue;
                }

                drlocal = dataTable.NewRow();
                drlocal["Product"] = dr.Cells["Product"].Value;
                drlocal["Quantity"] = dr.Cells["Quantity"].Value;
                drlocal["Price"] = dr.Cells["Price"].Value;
                drlocal["Total"] = dr.Cells["Total"].Value;
                dataTable.Rows.Add(drlocal);
            }

            return orderset;
        }
        private async Task<DataTable> GetDataTable(DataGridView shopping)
        {

            var Cart = shopping;
            return await Task.Run(() =>
            {
                var data = new OrderSet().Tables[0];
                for (int i = 0; i < Cart.RowCount; i++)
                {
                    DataRow row = data.NewRow();
                    row["Product"] = Cart.Rows[i].Cells["Product"];
                    row["Price"] = Cart.Rows[i].Cells["Price"];
                    row["Quantity"] = Cart.Rows[i].Cells["Quantity"];
                    row["Total"] = Cart.Rows[i].Cells["Total"];
                    data.Rows.Add(row);

                    BindingSource bs = new BindingSource();

                    bs.DataSource = data;

                }

                return data;
            });


        }
        //Adding items to the cart
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

                decimal QuantityBought = decimal.Parse(txtQuantityBought.Text);
                QuantityBought += Qty;
                decimal sum = 0;
                


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
                            txtQuantityBought.Text = QuantityBought.ToString();
                          
                            Clear();
                            txtSearchProdt.Focus();
                        }
                        
                    }
                    if (!Found)
                    {
                        shoppingCart.Rows.Add(ProductName, Qty, Price, Total);
                        
                        txtSubtotal.Text = SubTotal.ToString();
                        txtQuantityBought.Text = QuantityBought.ToString();
                        Clear();
                    }


                }
                else
                {
                    shoppingCart.Rows.Add(ProductName, Qty, Price, Total);

                    txtQuantityBought.Text = QuantityBought.ToString();
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


        private void BtnAddToCart_Click(object sender, EventArgs e)
        {

            AddToCartOperator();

        }


        public void Clear()
        {
            txtPName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtQuantityLeft.Text = "";
            txtSearchProdt.Focus();
        }

        private async void POS_Load(object sender, EventArgs e)
        {
            lblSalesId.Text = od.SalesId;
            repo.GetSalesId(od);
            this.Refresh();
            // await GetDataTable(shoppingCart);


            await GetAutoCompleTeDataAsync();

            txtSearchProdt.Focus();

        }


        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {


            decimal Subtotal = decimal.Parse(txtSubtotal.Text);
            decimal discount = 0.00M; /*=/* Convert.ToDecimal(txtDiscount.Text);*/
            decimal.TryParse(txtDiscount.Text.ToString(), out discount);


            decimal GrandTotal = Convert.ToDecimal((100 - discount) / 100) * Subtotal;

            txtTotal.Text = GrandTotal.ToString("0.00");

            txtDiscount.Text = discount.ToString("0.00");
            txtSubtotal.Text = Subtotal.ToString("0.00");

        }

        private void TxtVat_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string check = txtTotal.Text;
            //    if (check == "")
            //    {
            //        MessageBox.Show("Check Total or Discount first");
            //    }
            //    else
            //    {
            //        decimal PreviousTotal = decimal.Parse(txtTotal.Text);
            //        decimal VAT = decimal.Parse(txtVat.Text);
            //        decimal TotalVAT = ((100 + VAT) / 100) * PreviousTotal;

            //        txtTotal.Text = TotalVAT.ToString();
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Please Input Discount first");
            //}
            //finally
            //{

            //}
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

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void TxtCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //connection = new DataConnection();
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
        public void DecreaseQty()
        {
            foreach (DataGridViewRow row in shoppingCart.Rows)
            {
                connection.SqlQuery(@"Update Product SET ProductUnit = ProductUnit - @qun where ProductName like '" + row.Cells[0].Value + "' ");
                var quantitybought = Convert.ToDouble(row.Cells[1].Value);
                connection.command.Parameters.AddWithValue("@qun", quantitybought);

                connection.command.ExecuteNonQuery();
            }

        }
        private void BtnPayment_Click(object sender, EventArgs e)
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
            var customer = txtCustomer.Text;
            var status = statusCombo.Text;
            var discount = Convert.ToDecimal(txtDiscount.Text);
            var items = txtQuantityBought.Text;
            AdminView admin = new AdminView();
            var shopname = admin.lblShopName.Text;
            shopname = sd.Shopname;
            Dashboard dash = new Dashboard();
            var cashier = dash.lblName.Text;
            cashier = account.Username;
            var contact = dash.lblContact.Text;
            var location = dash.lblLocation.Text;
            AppSettings app = new AppSettings();
            app.GetAppSettings(sd);


            var confirm = MessageBox.Show("Do you want to Print receipt", "Printing Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                if (string.IsNullOrEmpty(Settings.Default.PrinterName))
                {
                    //Just Commiting Without Printing

                    shop.SaveChanges(shoppingCart, cashier, salesId, status, customer, discount, grandTotal,subtotal,items);
                    shop.SaveCartItems(shoppingCart, discount, salesId);
                    DecreaseQty();
                    btnReset.PerformClick();
                    this.Refresh();
                    return;

                }
            }
            else if (confirm == DialogResult.Yes)
            {

                //Committing And Printing

                //Executing Commitment && Print Operations Concurrently
                Parallel.Invoke(new Action[]
                {
                    ()=>
                    {
                      
                        //Begining Print Operation
                         
                        Receipt receipt = new Receipt();
                        receipt.Parameters["pShopName"].Value = shopname;
                        receipt.Parameters["pTelephone"].Value = contact;
                        receipt.Parameters["pLocation"].Value = location;
                        receipt.Parameters["pStatus"].Value = status;
                       receipt.Parameters["pCashierId"].Value = cashier ;
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
                      //tool.ShowPreviewDialog();
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

        private void TxtPaidAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnCommit.PerformClick();
        }

        private void TxtSearchProdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void PanelListview_Paint(object sender, PaintEventArgs e)
        {

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

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnAddToCart.PerformClick();
                e.SuppressKeyPress = true;
            }
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

        private void TxtQuantityLeft_TextChanged(object sender, EventArgs e)
        {


        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void Label4_Click(object sender, EventArgs e)
        {

        }

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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            var confrimation = MessageBox.Show("Are you sure you want to exit", "Closing POS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confrimation == DialogResult.Yes)
            {

                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Dispose();
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void TxtQty_MouseDown(object sender, MouseEventArgs e)
        {

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void POS_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void POS_MouseUp(object sender, MouseEventArgs e)
        {


        }


        private void POS_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}



