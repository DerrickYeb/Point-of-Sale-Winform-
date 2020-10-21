using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Controller
{
    public class CustomersController
    {
        DataConnection connection = new DataConnection();
        #region Method To Insert Data
        public bool Insert(CustomersModel customers)
        {
            bool success = false;

            try
            {
                connection = new DataConnection();
                connection.MyConnection();
                connection.SqlQuery("Insert into Customers (Name,Phone,Location,Description) Values(@name,@phone,@location,@description)");
                connection.command.Parameters.AddWithValue("@name",customers.Name);
                connection.command.Parameters.AddWithValue("@phone",customers.Phone);
                connection.command.Parameters.AddWithValue("@location",customers.Location);
                connection.command.Parameters.AddWithValue("@location",customers.Description);

            }
            catch (Exception)
            {

                throw;
            }
            
            return success;
        }
        #endregion
    }
}
