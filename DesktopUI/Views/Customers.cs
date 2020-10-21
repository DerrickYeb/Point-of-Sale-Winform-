using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are sure want to close", "Customers Dialog Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                new Dashboard().Show();
                Hide();
            }
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            var addcustomer = new AddCustomer();
            addcustomer.ShowDialog();
        }
    }
}

