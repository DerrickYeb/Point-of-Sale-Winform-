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
    public partial class BatchAdd : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        DataTable dtTable = new DataTable("Add Products");
        public BatchAdd()
        {
            InitializeComponent();
            
            // batchAddGridView.AllowUserToAddRows = false;

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public DataTable GetDataTableFromDGv(DataGridView gridView)
        {
            var columns = new[] { "ProductCode", "ProductName", "Quantity", "Category", "PurchasePrice", "SellingPrice", "Supplier", "ProductDescription" };
            var dt = new DataTable();
            foreach (DataGridViewColumn column in gridView.Columns)
            {

                if (columns.Contains(column.Name))
                {
                    dt.Columns.Add();
                }

            }
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (row.Cells["Code"] == null)
                {
                    continue;
                }
                DataRow dataRow = dt.NewRow();
                foreach (string columnName in columns)
                {
                    dataRow[columnName] = row.Cells[columnName].Value;
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }
        public void InsertDataToDB(DataGridView gridView)
        {
            DataTable dt = GetDataTableFromDGv(gridView);

            using (SqlConnection cn = new SqlConnection(connection))
            {
                cn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cn))
                {
                    //bulkCopy.ColumnMappings.Add("Code", "ProductCode");
                    //bulkCopy.ColumnMappings.Add("ProductName", "ProdcutName");
                    //bulkCopy.ColumnMappings.Add("Quantity", "ProductUnit");
                    //bulkCopy.ColumnMappings.Add("Category", "Category");
                    //bulkCopy.ColumnMappings.Add("PurchasePrice", "PurchasePrice");
                    //bulkCopy.ColumnMappings.Add("SellingPrice", "SellingPrice");
                    //bulkCopy.ColumnMappings.Add("Supplier", "Supplier");
                    //bulkCopy.ColumnMappings.Add("ProductDescription", "ProductDescription");
                    //bulkCopy.DestinationTableName = "Product";
                    bulkCopy.WriteToServer(dt);
                }
            }
            MessageBox.Show("Inserted");
        }
        private void SaveProducts(DataGridView view)
        {
            string code;
            string productname;
            string productunit;
            string category;
            decimal costprice;
            decimal retailprice;
            string supplier;
            string description;


            for (int i = 0; i < view.Rows.Count; i++)
            {

                code = Convert.ToString(view.Rows[i].Cells[0].Value);
                productname = Convert.ToString(view.Rows[i].Cells[1].Value);
                productunit = Convert.ToString(view.Rows[i].Cells[2].Value);
                category = Convert.ToString(view.Rows[i].Cells[3].Value);
                costprice = Convert.ToDecimal(view.Rows[i].Cells[4].Value);
                retailprice = Convert.ToDecimal(view.Rows[i].Cells[5].Value);
                supplier = Convert.ToString(view.Rows[i].Cells[6].Value);
                description = Convert.ToString(view.Rows[i].Cells[7].Value);



                // batchAddGridView.Rows.RemoveAt(batchAddGridView.CurrentCell.RowIndex);
                ShopDataContext db = new ShopDataContext();
                db.Products.InsertOnSubmit(new Product
                {
                    ProductCode = code,
                    ProductName = productname,
                    ProductUnit = productunit,
                    Category = category,
                    CostPrice = costprice,
                    RetailPrice = retailprice,
                    Supplier = supplier,
                    Description = description,
                    CreatedDate = DateTime.UtcNow

                });
                db.SubmitChanges();


                MessageBox.Show("Added,Reopen if you want to add new products");

                batchAddGridView.AllowUserToAddRows = false;
                
                //else
                //{
                //    // batchAddGridView.Rows.RemoveAt(batchAddGridView.CurrentCell.RowIndex);
                //    ShopDataContext db = new ShopDataContext();
                //    db.Products.InsertOnSubmit(new Product
                //    {
                //        ProductCode = code,
                //        ProductName = productname,
                //        ProductUnit = productunit,
                //        Category = category,
                //        CostPrice = costprice,
                //        RetailPrice = retailprice,
                //        Supplier = supplier,
                //        Description = description,
                //        CreatedDate = DateTime.UtcNow

                //    });
                //    db.SubmitChanges();


                //    MessageBox.Show("Added");
                //    batchAddGridView.AllowUserToAddRows = false;
                //}
                   

            }
        }

        private void BtnAddProducts_Click(object sender, EventArgs e)
        {


            
        }


        private void BatchAddGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //batchAddGridView.AllowUserToAddRows = false;
        }

        private void BatchAddGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (MessageBox.Show("Adding Product,do you want to add new product?", "Add new Product?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    batchAddGridView.AllowUserToAddRows = true;
            //else
            //    batchAddGridView.AllowUserToAddRows = false;
        }

        private void BatchAddGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void BatchAddGridView_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Adding Product,do you want to add new product?", "Add new Product?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    batchAddGridView.AllowUserToAddRows = true;
            //else
            //    batchAddGridView.AllowUserToAddRows = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            var dashboard = new Dashboard();
            dashboard.Show();
            Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            SaveProducts(batchAddGridView);
            batchAddGridView.Rows.RemoveAt(batchAddGridView.CurrentCell.RowIndex);
        }
    }
}
