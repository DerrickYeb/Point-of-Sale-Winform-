using DesktopUI.Controller;
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
    public partial class SalesDetails : Form
    {
        ShopRepository shop = new ShopRepository();
        public SalesDetails()
        {
            InitializeComponent();
        }
       
        private async void BtnLoad_Click(object sender, EventArgs e)
        {
            DataTable x = await shop.LoadSaleDetails();
            salesdetailsControl.DataSource = x;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to close form","Sales Details Form Closing",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                new Dashboard().Show();
                Close();
            }
        }

        private async void btnLoadSales_Click(object sender, EventArgs e)
        {
            DataTable x = await shop.LoadSaleDetails();
            salesdetailsControl.DataSource = x;
        }
    }
}
