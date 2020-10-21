using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class People : Form
    {
        public People()
        {
            InitializeComponent();
            Customers customers = new Customers();
            AddUcControls(customers);
        }

        public void Navigator(Control btn)
        {
            panelSideMover.Left = btn.Left;
            panelSideMover.Width = btn.Width;
        }
        

        private void AddUcControls(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelSwitch.Controls.Clear();
            panelSwitch.Controls.Add(c);
            
        }
        private AdminView admin = new AdminView();

        private void BtnSuppliers_Click(object sender, EventArgs e)
        {

            Navigator(btnSuppliers);
           Suppliers sup = new Suppliers();
            AddUcControls(sup);
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            Navigator(btnCustomers);
            Customers customers = new Customers();
            AddUcControls(customers);
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer customer = new AddCustomer();
            customer.ShowDialog();
        }

        private void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            AddSupplier supplier = new AddSupplier();
            supplier.ShowDialog();
        }
    }
}
