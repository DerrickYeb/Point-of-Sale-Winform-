using DesktopUI.Models;
using DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Controller
{
    class SalesRepository
    {
      
         ShopDetails sd = new ShopDetails();

        public static SalesRepository instance { get; internal set; }

        public void GetSalesId(OrderDetails od)
        {

            DataConnection connection = new DataConnection();
            SqlDataReader dr;
            try
            {
                string salesdate = DateTime.Now.ToString("yyyyMMdd");
                string salesnum;
                int count;
                connection = new DataConnection();
                connection.MyConnection();
                connection.SqlQuery("Select top 1 SalesNumber from [Sales] where [SalesNumber] Like '" + salesdate + "%' order by id desc");
                dr = connection.command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    salesnum = dr[0].ToString();
                    count = int.Parse(salesnum.Substring(8, 4));
                    od.SalesId = salesdate + (count + 1);
                    
                }
                else
                {
                    salesnum = salesdate + "1001";
                    od.SalesId = salesnum;
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, sd.Shopname, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public  void CashieId(OrderDetails od)
        {
            DataConnection connection = new DataConnection();
            SqlDataReader dr;
            try
            {
                string salesdate = DateTime.Now.ToString("yyyyMMdd");
                string salesnum;
                int count;
                connection = new DataConnection();
                connection.MyConnection();
                connection.SqlQuery("Select top 2 CashierId from [Sales] where [CashierId] Like '" + salesdate + "%' order by id desc");
                dr = connection.command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    salesnum = dr[0].ToString();
                    count = int.Parse(salesnum.Substring(8, 4));
                    od.CashierId = salesdate + (count + 1);
                }
                else
                {
                    salesnum = salesdate + "2001";
                    od.CashierId = salesnum;
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, sd.Shopname, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        internal void Add(OrderModel sale)
        {
            throw new NotImplementedException();

        }
        #region Method to Insert Sales

        #endregion
    }
}
