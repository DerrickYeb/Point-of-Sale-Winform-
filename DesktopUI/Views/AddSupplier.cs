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
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Clear()
        {
            txtLocation.Text = "";
            txtPhone.Text = "";
            txtProdt.Text = "";
            txtSupplier.Text = "";
        }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ShopDataContext db = new ShopDataContext();
                db.Suppliers.InsertOnSubmit(new Supplier
                {
                    Name = txtSupplier.Text,
                    Product = txtProdt.Text,
                    Phone = txtPhone.Text,
                    Location = txtLocation.Text,
                    CeatedBy = Settings.Default.Username,
                    CeatedAt = DateTime.UtcNow
                });
                db.SubmitChanges();
                MessageBox.Show("Inserted Succesfully");
                Clear();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
