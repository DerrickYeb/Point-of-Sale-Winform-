using DesktopUI.Handler;
using DesktopUI.Models;
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
    public class ShopRepository
    {
        string connection = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        SalesDetails sales = new SalesDetails();
        public void SaveCartItems(DataGridView view, decimal discount, string salesid)
        {
            ShopDataContext dbs = new ShopDataContext();
            int row1 = view.CurrentRow.Index;

            for (int i = 0; i < view.Rows.Count; i++)
            {
            
                dbs.SalesDetails.InsertOnSubmit(
                       new SalesDetail
                       {
                           Product = Convert.ToString(view.Rows[i].Cells[0].Value),
                           SalesID = salesid,
                           Discount = discount,
                           Price = Convert.ToDecimal(view.Rows[i].Cells[2].Value),
                           Quantity = Convert.ToInt32(view.Rows[i].Cells[1].Value),
                       });

                dbs.SubmitChanges();
            }

        }

        public async Task<DataTable> LoadSales()
        {
            DataTable dt = new DataTable();

            SqlDataReader dr;

            using (SqlConnection conn = new SqlConnection(connection))
            {
                string load = "Select * from Sales";
                SqlCommand cmd = new SqlCommand(load, conn);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    await conn.OpenAsync();
                    adapter.Fill(dt);
                }
            }



            return dt;

        }
        public async Task<DataTable> LoadSaleDetails()
        {
            DataTable data = new DataTable();
            using (SqlConnection connect = new SqlConnection(connection))
            {
                string load = "Select * from SalesDetails";
                SqlCommand command = new SqlCommand(load, connect);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    await connect.OpenAsync();
                    adapter.Fill(data);
                }
            }
            return data;
        }

        public void SaveChanges(DataGridView gridView, string cashier, string salesid, string status, string customer, decimal discount, decimal total,decimal subtotal,string items)
        {
            SalesModel model = new SalesModel();
            int rowindex = gridView.CurrentRow.Index;

            ShopDataContext db = new ShopDataContext();


            db.Sales.InsertOnSubmit(
            new Sale
            {
                SalesNumber = salesid,
                CashierId = cashier,
                Salesdate = DateTime.Now,
                Subtotal = subtotal,//Convert.ToInt32(gridView.Rows[rowindex].Cells[3].Value),
                Discount = discount,
                Total = total,
                TotalItems = items, //Convert.ToString(gridView.Rows[rowindex].Cells[1].Value),
                CustomerName = customer,
                Status = status

            });
            db.SubmitChanges();



            rowindex = 0;
        }
    }
}
