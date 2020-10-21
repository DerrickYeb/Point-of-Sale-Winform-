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
    public partial class SmallSettings : Form
    {
        SettingsModel s = new SettingsModel();
        SettingsController scontroller = new SettingsController();
        public SmallSettings()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {

            s.ShopName = txtShopName.Text;
            s.Phone = txtShopPhone.Text;
            s.LicenseId = txtLicensedNum.Text;
            s.DateLicensed = txtLIcensedDt.Text;
            s.DateRenewed = txtRenewed.Text;
            s.Location = txtlocation.Text;

            bool success = scontroller.Update(s);

            if (txtShopName.Text != "")
            {

                if (success == true)
                {
                    MessageBox.Show("Added successfully");
                    Dashboard admin = new Dashboard();
                    admin.ShowDialog();

                    this.Dispose();
                }

            }
            else
            {
                MessageBox.Show("Failed to add");
            }
        }
    }
}
