using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Controller
{
    public class StockController
    {
        DataConnection connection = new DataConnection();
        #region Method to Insert
        public bool Insert(StockModel stock)
        {
            bool success = false;
            connection = new DataConnection();
            try
            {

                connection.MyConnection();
                connection.SqlQuery("Insert Into Stock (ProductId,ProductCode,Quantity,PurchasePrice,PurchaseDate) Values(@id,@prdtcode,@qty,@purchasePrice,@purchaseDate)");
                connection.command.Parameters.AddWithValue("@id",stock.Id);
                connection.command.Parameters.AddWithValue("@prdtcode",stock.ProductCode);
                connection.command.Parameters.AddWithValue("@qty",stock.Quantity);
                connection.command.Parameters.AddWithValue("@purchasePrice",stock.PurchasePrice);
                connection.command.Parameters.AddWithValue("@purchaseDate",stock.PurchaseDate);

               int row = connection.command.ExecuteNonQuery();

                if (row > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return success;
        }
        #endregion
    }
}
