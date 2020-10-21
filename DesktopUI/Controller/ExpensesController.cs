using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Controller
{
    public class ExpensesController
    {
        #region Method to Insert Expenses

        public bool Insert(ExpensesModel e)
        {
            bool success = false;
            DataConnection con = new DataConnection();
            try
            {
                con = new DataConnection();
                con.MyConnection();
                con.SqlQuery("Insert Into [Expenses] (Date,Reference,Amount,Category,Description,CeatedBy) Values(@date,@reference,@amount,@category,@description,@ceatedby)");
                con.command.Parameters.AddWithValue("@date",e.DateAdded);
                con.command.Parameters.AddWithValue("@reference",e.Reference);
                con.command.Parameters.AddWithValue("@amount", e.Amount);
                con.command.Parameters.AddWithValue("@category",e.Category); 
                con.command.Parameters.AddWithValue("@description", e.Description);
                con.command.Parameters.AddWithValue("@ceatedby",e.CeatedBy);
                int row = con.command.ExecuteNonQuery();

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
