using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Controller
{
    class ReportWorker
    {
        DataConnection connection = new DataConnection();
        #region Method to Select Total Number of Customers
        public void TotalCustomers(ReportParameters parameters)
        {
            connection.MyConnection();
            connection.SqlQuery("Select Count(ProductName) from [Product]");
            parameters.TotalCustomers = connection.command.ExecuteScalar().ToString();

        }
        #endregion
        #region Method to Get Sum Total Of Sales
        public void SalesTotal(ReportParameters parameters)
        {
            connection.MyConnection();
            connection.SqlQuery("Select Sum(CostPrice) from Product");
            SqlDataReader dr = connection.command.ExecuteReader();

            int count = 0;
            while (dr.Read())
            {
                count++;
            }
            parameters.TotalSales = count.ToString();

        }
        #endregion
        #region Total Products in Stock
        public void TotalProducts(ReportParameters parameters)
        {
            connection.MyConnection();
            connection.SqlQuery("Select Count(ProductName) from Product");
            parameters.TotalProducts = connection.command.ExecuteScalar().ToString();
        }
        #endregion
        #region Method To Populate ComboBox in report for client
        public async Task ComboPopulateForClients(ReportParameters p)
        {
            var das = new DataSet();
            await Task.Run(() =>
            {
                connection.MyConnection();
                connection.SqlQuery("Select CustomerName from Sales");
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlDataReader dr = connection.command.ExecuteReader();
                adapter.SelectCommand = connection.command;
                adapter.Fill(das);
                


            });
        }
        #endregion
    }
}
