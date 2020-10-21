using DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Models
{
    class AppSettings
    {
        //private readonly ShopDetails sd = new ShopDetails();
        
        public void GetAppSettings(ShopDetails sd)
        {
            try
            {
                DataConnection connection = new DataConnection();
                connection.MyConnection();
                connection.SqlQuery("Select Name,LicensedNumber,Phone,Location from Settings");


                SqlDataReader dr = connection.command.ExecuteReader();
                bool detailsfound;

                if (detailsfound = dr.Read())
                {
                    sd.Shopname = dr["Name"].ToString();
                    sd.LicenseId = dr["LicensedNumber"].ToString();
                    sd.Phone = dr["Phone"].ToString();
                    sd.Location = dr["Location"].ToString();

                    dr.Close();
                }
                else if(!detailsfound)
                {
                    SmallSettings small = new SmallSettings();
                    small.ShowDialog();
                    small.Dispose();
                   
                }

                
            }
            catch (Exception)
            {

               
            }

        }
    }
}
