using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopUI.Handler;

namespace DesktopUI.Views
{
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are sure want to close","Suppliers Dialog Closing",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                new Dashboard().Show();
                Hide();
            }
        }

        private void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            AddSupplier supplier = new AddSupplier();
            supplier.ShowDialog();
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
      
        void LoadData()
        {
            ShopDataContext db = new ShopDataContext();
            var binder = from a in db.Suppliers
                         where a.Id != 0
                         select a;

            List<Supplier> suppliers = binder.ToList();
            suppliersGridView.DataSource = suppliers;
            
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
