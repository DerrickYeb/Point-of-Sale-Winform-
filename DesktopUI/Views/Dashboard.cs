using DesktopUI.Models;
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
    public partial class Dashboard : Form
    {
        AccountDetails account = new AccountDetails();
        ShopDetails sd = new ShopDetails();
        AppSettings appSettings = new AppSettings();
        public Dashboard()
        {
            InitializeComponent();
            lblShopName.Text = sd.Shopname;
            lblID.Text = sd.LicenseId;
            lblContact.Text = sd.Phone;
            lblLocation.Text = sd.Location;


            appSettings.GetAppSettings(sd);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("DO you want to close form","Closing Application",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void BtnPos_Click(object sender, EventArgs e)
        {
            POS pos = new POS();
            pos.Show();
            this.Hide();
        }

       

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblName.Text = account.Username;
            

            account.Username = Settings.Default.Username;

            lblShopName.Text = sd.Shopname;
            lblID.Text = sd.LicenseId;
            lblContact.Text = sd.Phone;
            lblLocation.Text = sd.Location;
            

            appSettings.GetAppSettings(sd);
            sd.Shopname = Settings.Default.ShopName;
            sd.Phone = Settings.Default.Phone;
            sd.Location = Settings.Default.Location;
            Settings.Default.Save();
        }

        private void BtnLock_Click(object sender, EventArgs e) => new Lock().ShowDialog();

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("You are logging out", "Logout Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                var login = new LoginView();
                login.Show();
                this.Hide();
            }
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
           
            Products products = new Products();
            products.Show();
            this.Hide();
        }

        private void BtnAddProducts_Click(object sender, EventArgs e)
        {
            var select = new Choose();
            select.ShowDialog();
            this.Hide();
            
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            var cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            var sales = new Sales();
            sales.Show();
            Hide();
        }

        private void BtnSalesDetails_Click(object sender, EventArgs e)
        {
            var salesdetails = new SalesDetails();
            salesdetails.ShowDialog();
            Hide();
        }

        private void BtnExpenses_Click(object sender, EventArgs e)
        {
            var expenses = new Expenses();
            expenses.ShowDialog();
            Hide();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            var report = new Report();
            report.ShowDialog();
            Hide();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnSuppliers_Click(object sender, EventArgs e)
        {
            var supplier = new Suppliers();
            supplier.ShowDialog();
            Hide();
           
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            var customers = new Customers();
            customers.ShowDialog();
            Hide();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var seetings = new Setting();
            seetings.Show();
            Hide();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Dashboard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
