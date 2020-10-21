using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Controller
{
    public class CategoryController
    {
        DataConnection connection = new DataConnection();
        #region Method to Insert
        public bool Insert(CategoryModel category)
        {
            bool success = false;

            try
            {
                connection = new DataConnection();
                connection.MyConnection();
                connection.SqlQuery("Insert Into Category (CategoryName) Values(@name)");
                connection.command.Parameters.AddWithValue("@name",category.Category);
                int row = connection.command.ExecuteNonQuery();

                if (row>0)
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
    }
}
