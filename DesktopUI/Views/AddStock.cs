using DesktopUI.Controller;
using DesktopUI.Models;
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
    public partial class AddStock : Form
    {
        public AddStock()
        {
            InitializeComponent();
        }
        StockModel model = new StockModel();
        StockController controller = new StockController();

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            model.Id = txtProductId.Text;
            model.ProductCode = txtProductCode.Text;
            model.PurchasePrice = txtPrice.Text;
            model.Quantity = txtQty.Text;
            model.PurchaseDate = purchaseDate.Text;

            bool success = controller.Insert(model);

            if (model != null)
            {
                
                if (MessageBox.Show("Are you sure you want to add", "Adding Stock!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    MessageBox.Show("Added");
                }
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
