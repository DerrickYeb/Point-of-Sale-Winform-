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
    public class SettingsController
    {
         string connect = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        DataConnection connection = new DataConnection();
        #region Insert Settings Details


        public bool Update(SettingsModel s)
        {
            bool Success = false;


            try
            {
                connection = new DataConnection();
                connection.MyConnection();
                connection.SqlQuery("Insert Into [Settings] (Name,Phone,LicensedNumber,DateLicensed,Renewed,Location) Values (@name,@phone,@licenseid,@datelicensed,@dateRenewed,@location)");

                connection.command.Parameters.AddWithValue("@name", s.ShopName);
                connection.command.Parameters.AddWithValue("@phone", s.Phone);
                connection.command.Parameters.AddWithValue("@licenseid", s.LicenseId);
                connection.command.Parameters.AddWithValue("@datelicensed", s.DateLicensed);
                connection.command.Parameters.AddWithValue("@dateRenewed", s.DateRenewed);
                connection.command.Parameters.AddWithValue("@location", s.Location);

                int row = connection.command.ExecuteNonQuery();

                if (row > 0)
                {
                    Success = true;
                }
                else
                {
                    Success = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
            finally
            {

            }
            return Success;
        }
        #endregion
        #region Method to Update In Real time
        public void UpdateNow(SettingsModel model)
        {
            connection.MyConnection();
            connection.SqlQuery("Update Settings SET Name=@name,LicensedNumber=@lnum,DateLicensed=@dlcn,Renewed=@renwd,Phone=@phone,Location=@location where Id like '" + model.ShopName + "' ");
            connection.command.Parameters.AddWithValue("@name",model.ShopName);
            connection.command.Parameters.AddWithValue("@lnum",model.LicenseId);
            connection.command.Parameters.AddWithValue("@dlcn",model.DateLicensed);
            connection.command.Parameters.AddWithValue("@renwd",model.DateRenewed);
            connection.command.Parameters.AddWithValue("@phone",model.Phone);
            connection.command.Parameters.AddWithValue("@location", model.Location);
            connection.command.ExecuteNonQuery();
        }
# endregion

        #region Method To Search
        public async void Search(SettingsModel model)
        {
            bool found;
            string search = "Select * from Settings where Name=@name";


            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand(search, con);
                cmd.Parameters.AddWithValue("@name",model.ShopName);
               await con.OpenAsync();

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    if (found = await dr.ReadAsync())
                    {
                        model.ShopName = dr["Name"].ToString();
                        model.Phone = dr["Phone"].ToString();
                        model.LicenseId = dr["LicensedNumber"].ToString();
                        model.DateLicensed = dr["DateLicensed"].ToString();
                        model.DateRenewed = dr["Renewed"].ToString();
                        dr.Close();
                    }
                    else
                    {
                        MessageBox.Show("Shop Name not Available");
                    }
                    
                }
                con.Close();
            }
        
        }
        #endregion
    }
}


