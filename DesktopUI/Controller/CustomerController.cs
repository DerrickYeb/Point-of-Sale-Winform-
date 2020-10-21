using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Controller
{
    public class CustomerController
    {
        #region Method to Get Customer Details
        public bool GetDetails()
        {
            bool Isget = false;

            DataConnection connection = new  DataConnection();

            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
               
                connection = new DataConnection();
                connection.MyConnection();
                connection.SqlQuery("");
   
            }
            catch (Exception)
            {

                throw;
            }
            return Isget;
        }
        #endregion
    }
}
