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
    public partial class Expenses : Form
    {
        DataConnection connection = new DataConnection();
        public Expenses()
        {
            InitializeComponent();
            LoadData();
        }
        SqlDataReader dr;
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadData()
        {
            int i = 0;
            ExpensesGridView.Rows.Clear();
            connection = new DataConnection();
            connection.MyConnection();
            connection.SqlQuery("spExpenses");
            dr = connection.command.ExecuteReader();

            while (dr.Read())
            {
                i += 1;
                ExpensesGridView.Rows.Add(i,
                dr["Date"].ToString(),
                dr["Reference"].ToString(),
                dr["Amount"].ToString(),
                dr["Category"].ToString(),
                dr["Description"].ToString(),
                dr["CeatedBy"].ToString()
                 );
            }
            dr.Close();
        }

        private void BtnAddExpenses_Click(object sender, EventArgs e)
        {
            AddExpenses add = new AddExpenses(this);
            add.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are sure want to close", "Expenses Dialog Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                new Dashboard().Show();
                Hide();
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
      
    }
}
