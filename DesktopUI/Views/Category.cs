using DesktopUI.Models;
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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
            LoadData();
        }
        DataConnection connection = new DataConnection();
        SqlDataReader dr;

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory category = new AddCategory(this);
            category.ShowDialog();
        }
        public void LoadData()
        {
            int i = 0;
            Categorydata.Rows.Clear();
            connection = new DataConnection();
            connection.MyConnection();
            connection.SqlQuery("Select * from [Category] order by CategoryName");
            dr = connection.command.ExecuteReader();

            while (dr.Read())
            {
                i += 1;
                Categorydata.Rows.Add(i,
              
                dr["CategoryName"].ToString(),
                dr["CeatedAt"].ToString());
            }
            dr.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are sure want to close", "Category Dialog Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                new Dashboard().Show();
                Hide();
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
     
    }
}
