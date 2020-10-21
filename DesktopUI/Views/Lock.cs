using DesktopUI.Models;
using DesktopUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class Lock : Form
    {
        DataConnection connection = new DataConnection();
        public Lock()
        {
            InitializeComponent();
        }

        private void BtnUnlock_Click(object sender, EventArgs e)
        {
            connection.MyConnection();
            connection.SqlQuery("SELECT Password FROM [User] WHERE Username = '" + Settings.Default.Username + "' and Password = '" + txtLocker.Text + "'");
            SqlDataReader dr = connection.command.ExecuteReader();

            bool Found;

            if (Found = dr.Read())
            {
                //AdminView admin = new AdminView();
                //admin.ShowDialog();
                this.Close();

                dr.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
        }
    }
}
