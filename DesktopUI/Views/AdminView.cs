using DesktopUI.Controller;
using DesktopUI.Models;
using DesktopUI.Properties;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class AdminView : Form
    {
        AccountDetails account = new AccountDetails();
        SettingsModel s = new SettingsModel();
        ShopDetails sd = new ShopDetails();
        AppSettings appSettings = new AppSettings();
        SalesRepository repo = new SalesRepository();
        OrderDetails od = new OrderDetails();

        public AdminView()
        {
            InitializeComponent();
            DailyTime.Start();
            POS pos = new POS();
            pos.TopLevel = false;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(pos);
            pos.BringToFront();
            pos.Show();

            sd.Shopname = lblShopName.Text;
            sd.LicenseId = lblShopLicenseNum.Text;

            appSettings.GetAppSettings(sd);
            lblCashierId.Text = od.CashierId;
            repo.CashieId(od);

        }

        public void AddUcControls(Control c)
        {

            this.Invoke(new MethodInvoker(delegate ()
            {
                c.Dock = DockStyle.Fill;
                panelControl.Controls.Add(c);
                panelControl.Controls.Add(c);
                 c.BringToFront();

            }));





        }

        public async void Navigator(Control btn)
        {
            // WaitFormLoad();
            await Task.Run(() =>
           {
               this.Invoke(new MethodInvoker(delegate ()
               {
                   panelSideMover.Left = btn.Left;
                   panelSideMover.Width = btn.Width;
               }));
           });


        }

        private async void BtnCustomers_Click(object sender, EventArgs e)
        {
            Navigator(BtnCustomers);

            People p = new People();
         
            
            await Task.Run(() =>
            {

                p.TopLevel = false;
                AddUcControls(p);

            });
            p.Show();
        }

        private async void BtnSales_Click(object sender, EventArgs e)
        {
            Navigator(BtnSales);
            WaitFormLoad();
            var sales = new Sales();
            await Task.Run(() =>
            {
                sales.TopLevel = false;
                AddUcControls(sales);

            });
            sales.Show();
        }

        private void LblTime_Click(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }

        private void DailyTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {

        }
        private void WaitFormLoad()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitingFormLoader), true, true, false);
            // SplashScreenManager.Default.SetWaitFormCaption("Please Wait ...");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(20);
            }
            SplashScreenManager.CloseForm();
        }

        private async void BtnProducts_Click(object sender, EventArgs e)
        {

            Navigator(BtnProducts);
            WaitFormLoad();
            Products p = new Products();
            await Task.Run(() =>
            {
                p.TopLevel = false;
                AddUcControls(p);
            });
            p.Show();

            //WaitFormLoad();

        }
        async Task ProductLoad()
        {
            var products = new Products();
            await Task.Run(() =>
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    products.TopLevel = false;
                    panelControl.Controls.Clear();
                    panelControl.Controls.Add(products);
                    products.BringToFront();
                    products.Show();
                }));
            });
            products.Show();
        }

        private async void BtnExpenses_Click(object sender, EventArgs e)
        {
            Navigator(BtnExpenses);
            Expenses expenses = new Expenses();
            await Task.Run(() =>
            {
                expenses.TopLevel = false;
                AddUcControls(expenses);
            });
            expenses.Show();
        }

        private async void BtnCategories_Click(object sender, EventArgs e)
        {

            Category category = new Category();
            await Task.Run(() =>
            {
                Navigator(BtnCategories);
                category.TopLevel = false;
                AddUcControls(category);

            });
            category.Show();

        }

        private async void BtnSettings_Click(object sender, EventArgs e)
        {
            Navigator(BtnSettings);
            Setting settings = new Setting
            {
                TopLevel = false
            };
            await Task.Run(() =>
            {
                AddUcControls(settings);
            });
            settings.Show();

        }

        private async void BtnReport_Click(object sender, EventArgs e)
        {
            Navigator(BtnReport);
            Report report = new Report
            {
                TopLevel = false
            };
            await Task.Run(() =>
            {
                AddUcControls(report);
            });
            report.Show();
        }

        private void PanelTopBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void BtnPOS_Click(object sender, EventArgs e)
        {


            Navigator(BtnPOS);
            POS pos = new POS
            {
                TopLevel = false
            };
            await Task.Run(() =>
            {
                AddUcControls(pos);
            });
            pos.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult iexit;
            iexit = MessageBox.Show($"Are you sure want to exit {lblShopName.Text.ToString()} ", "Closing Application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (iexit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;


        private void AdminView_Load(object sender, EventArgs e)
        {
            lblUsename.Text = account.Username;
            lblRole.Text = account.Role;

            account.Username = Settings.Default.Username;

            lblShopName.Text = sd.Shopname;
            lblShopLicenseNum.Text = sd.LicenseId;

            appSettings.GetAppSettings(sd);
            sd.Shopname = Settings.Default.ShopName;
            Settings.Default.Save();

            lblCashierId.Text = od.CashierId;
            repo.CashieId(od);
            od.CashierId = Settings.Default.Cashier;
            Settings.Default.Save();
        }



        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Logout ?", "Logout Warning !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                new LoginView().Show();
                Hide();
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void LblRole_Click(object sender, EventArgs e)
        {

        }

        private void LblCashierId_Click(object sender, EventArgs e)
        {

        }

        private void BtnLock_Click(object sender, EventArgs e) => new Lock().ShowDialog();


        private void AdminView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
