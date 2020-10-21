using DesktopUI.Handler;
using DesktopUI.Properties;
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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            ShopDataContext db = new ShopDataContext();
            db.Customers.InsertOnSubmit(new Customer
            {
                Id = new Random(5).Next(0,9),
                Name = txtCatName.Text,
                Phone = txtPhone.Text,
                Description = txtdescription.Text,
                CeatedBy = Settings.Default.Username
            }) ;
            db.SubmitChanges();
            MessageBox.Show("Customer Added");
        }
    }
}
