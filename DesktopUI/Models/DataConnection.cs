using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    class DataConnection
    {
        public SqlConnection sqlconnection = new SqlConnection();
        public SqlCommand command = new SqlCommand();
        public void MyConnection()
        {
           
          sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

            if (sqlconnection.State == ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
        }

        public void SqlQuery(string query)
        {
            command = new SqlCommand(query, sqlconnection);
        }

        public DataTable GetDataTable()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            return data;

        }

        public void NonExecuteQuery()
        {
            command.ExecuteNonQuery();
        }

    }

    
}
