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
    public class UserController
    {
        static string connection = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        //For login

        DataConnection connection1 = new DataConnection();

        #region Method to Select


        public bool loginCheck(UsersModel users)
        {
            bool iSuccess = false;

            SqlConnection conn = new SqlConnection(connection);

            try
            {
                string sql = "SELECT * FROM [User] WHERE Username=@username AND Password=@password AND Role=@role";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("username", users.Username.Trim());
                cmd.Parameters.AddWithValue("password", users.Password.Trim());
                cmd.Parameters.AddWithValue("role", users.Role.Trim());

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
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

        #region Method to Insert
        public bool Insert(UsersModel u)
        {
            bool success = false;

            connection1 = new DataConnection();
            connection1.MyConnection();
            try
            {
                connection1.SqlQuery("Insert into [User] (FirstName,Surname,Username,Role,Password) Values(@fname,@sname,@uname,@role,@password)");
                connection1.command.Parameters.AddWithValue("@fname", u.FirstName);
                connection1.command.Parameters.AddWithValue("@sname", u.Surname);
                connection1.command.Parameters.AddWithValue("@uname", u.Username);
                connection1.command.Parameters.AddWithValue("@role", u.Role);
                connection1.command.Parameters.AddWithValue("@password", u.Password);
                int row = connection1.command.ExecuteNonQuery();

                if (row > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return success;
        }
        #endregion
        User u = new User();
        public bool IsValid(string username, string password, string role)
        {
            ShopDataContext context = new ShopDataContext();
            var q = from p in context.Users
                    where p.Username == u.Username && p.Password == u.Password && p.Role == u.Role
                    select p;


            if (q.FirstOrDefault().Role == u.Role)
            {

                return true;
            }

            else
            {
                return false;
            }
        }
        //Select Users from Database
        public async Task<DataTable> LoadSaleDetails()
        {
            DataTable data = new DataTable();
            using (SqlConnection connect = new SqlConnection(connection))
            {
                string load = "spUser";
                SqlCommand command = new SqlCommand(load, connect);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    await connect.OpenAsync();
                    adapter.Fill(data);
                }
            }
            return data;

        }
    }
}
