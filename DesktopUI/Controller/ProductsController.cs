using DesktopUI.Models;
using DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Controller
{
    public class ProductsController
    {
        string connection = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        #region Select method for Product

        SqlDataReader dr;
        public SqlDataReader LoadRecord()
        {
            SqlDataReader dr;
            Products produc = new Products();
            string loadrecd = "Select * from [Product]";
            int i = 0;

            ///produc.ProductsGridView.Rows.Clear();
            SqlConnection sql = new SqlConnection(connection);
            sql.Open();
            SqlCommand cmd = new SqlCommand(loadrecd, sql);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i += 1;

                //produc.ProductsGridView.Rows.Add(i,
                //    dr["ProductCode"].ToString(),
                //    dr["ProductName"].ToString(),
                //    dr["Category"].ToString(),
                //    dr["Description"].ToString(),
                //    dr["ProductUnit"].ToString(),
                //    dr["AlertQty"].ToString(),
                //    dr["CostPrice"].ToString(),
                //    dr["RetailPrice"].ToString(),
                //    dr["Supplier"].ToString(),
                //    dr["CreatedDate"].ToString()
                    
                //    );
                    

            }
            dr.Close();

            sql.Close();

            return dr;

        }

        public async Task<DataTable> Select()
        {
            Products produc = new Products();

            //SqlConnection sql = new SqlConnection(connection);

           DataTable dt = new DataTable();

            SqlDataReader dr;

            using (SqlConnection conn = new SqlConnection(connection))
            {
                string load = "Select * from [Product]";
                SqlCommand cmd = new SqlCommand(load,conn);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                   await conn.OpenAsync();
                   adapter.Fill(dt);
                }
            }

           

            return dt;
        }

        #endregion

        #region Method to Insert into Database
        public bool Insert(ProductsModel p)
        {
            bool iSuccess = false;

            SqlConnection conn = new SqlConnection(connection);

            try
            {


                string insert = "Insert Into [Product] (productcode,productname,category,description,productunit,costprice,retailprice,supplier) VALUES (@productcode,@productname,@category,@description,@productunit,@costprice,@retailprice,@supplier)";

                SqlCommand cmd = new SqlCommand(insert, conn);

                cmd.Parameters.AddWithValue("@productcode", p.ProductCode);
                cmd.Parameters.AddWithValue("@productname", p.ProductName);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@category", p.Category);
                cmd.Parameters.AddWithValue("@productunit", p.ProductUnit);
                cmd.Parameters.AddWithValue("@costprice", p.CostPrice);
                cmd.Parameters.AddWithValue("@retailprice", p.RetailPrice);
                cmd.Parameters.AddWithValue("@supplier", p.Supplier);

                conn.Open();

                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    iSuccess = true;
                }
                else
                {
                    iSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }



            return iSuccess;
        }
        #endregion

        #region Method to Update Product
        public void Update(ProductsModel p)
        {
            bool iSuccess = false;

            SqlConnection con = new SqlConnection(connection);

            try
            {
                string update = "UPDATE Product SET productcode=@productcode,productname=@productname,category=@category,description=@description,productunit=@productunit,costprice=@costprice,retailprice=@retailprice,supplier=@supplier,lastmodified=@lastmodified where Id like '"+p.Id+"' ";

                SqlCommand cmd = new SqlCommand(update, con);

                con.Open();
               // cmd.Parameters.AddWithValue("@id", SqlDbType.Int);
                cmd.Parameters.AddWithValue("@productcode", p.ProductCode);
                cmd.Parameters.AddWithValue("@productname", p.ProductName);
                cmd.Parameters.AddWithValue("@category", p.Category);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@productunit", p.ProductUnit);   
                cmd.Parameters.AddWithValue("@costprice", p.CostPrice);
                cmd.Parameters.AddWithValue("@retailprice", p.RetailPrice);
                cmd.Parameters.AddWithValue("@supplier", p.Supplier);
                cmd.Parameters.AddWithValue("@lastmodified", DateTime.UtcNow);

                

                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    iSuccess = true;
                }
                else
                {
                    iSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


       
        }
        #endregion

        #region Method to Delete Product
        public bool Delete(ProductsModel p)
        {
            bool iSuccess = false;

            SqlConnection con = new SqlConnection(connection);

            string delete = "DELETE FROM [Product] WHERE id=@id";

            SqlCommand cmd = new SqlCommand(delete, con);

            cmd.Parameters.AddWithValue("id", p.Id);

            con.Open();

            int row = cmd.ExecuteNonQuery();

            if (row > 0)
            {
                iSuccess = true;
            }
            else
            {
                iSuccess = false;
            }

            return iSuccess;
        }
        #endregion

    }
}
