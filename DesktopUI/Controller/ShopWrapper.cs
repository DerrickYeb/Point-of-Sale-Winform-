using DesktopUI.Models;
using DesktopUI.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Controller
{
    public class ShopWrapper
    {
        private DataGridView _gridView;

        OrderDetails order = new OrderDetails();
        private Settings settings;
        DataConnection connection = new DataConnection();

        public void ReceiptSource(DataGridView shoppingCart)
        {
           _gridView = shoppingCart;
        }

        public void SaveShoppingCartDetails(DataGridView gridView)
        {
           

            connection.MyConnection();
            connection.SqlQuery("Insert into Sales (Id,SalesNumber,CashierId,Salesdate,Subtotal,Discount,Total,Totalitems,CustomerName,Status) values(@id,@salesid,@cashier,@salesdate,@subtotal,@discount,@total,@totalitems,@customer,@status)");
            connection.command.Parameters.AddWithValue("@id", SqlDbType.Int);
            connection.command.Parameters.AddWithValue("@salesid", order.SalesId);
            connection.command.Parameters.AddWithValue("@cashier", order.CashierId);
            connection.command.Parameters.AddWithValue("@salesdate", order.SalesDate);
            connection.command.Parameters.AddWithValue("@subtotal", order.SubTotal);
            connection.command.Parameters.AddWithValue("@discount", order.Discount);
            connection.command.Parameters.AddWithValue("@customer", order.Customer);
            connection.command.Parameters.AddWithValue("@username", settings.Username);
            connection.command.Parameters.AddWithValue("@totalitems", order.Quantity);
            connection.command.Parameters.AddWithValue("@status", order.Status);
            connection.command.ExecuteNonQuery();

            
            

        }
    }
}
