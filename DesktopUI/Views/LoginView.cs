using DesktopUI.Controller;
using DesktopUI.Handler;
using DesktopUI.Models;
using DesktopUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Views
{
    public partial class LoginView : Form
    {
        public string result;
        public string username;
        public string role;

        UsersModel users = new UsersModel();
        UserController controller = new UserController();
        AccountDetails account = new AccountDetails();
        

        public LoginView()
        {
            
            InitializeComponent();
           
        }
        public void startForm()
        {
            //Application.Run(new LoadingScreen());
        }
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            users.Username = TxtUsername.Text.Trim();
            users.Password = TxtPassword.Text.Trim();
            users.Role = usertypeCombo.Text.Trim();


            bool success = controller.loginCheck(users);

            if (success == true)
            {
                MessageBox.Show("Login Successfully");

                switch (users.Role)
                {
                    case "Admin":
                        {
                            Hide();
                            Settings.Default.Username = TxtUsername.Text;
                            Settings.Default.Save();
                            account.Role = usertypeCombo.Text;
                            Settings.Default.Role = usertypeCombo.Text;
                            Settings.Default.Save();
                            account.Username = TxtUsername.Text;
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                        }
                        break;
                    case "Sales Agent":
                        {
                            Hide();
                            Settings.Default.Username = TxtUsername.Text;
                            Settings.Default.Save();
                            account.Role = usertypeCombo.Text;
                            Settings.Default.Role = usertypeCombo.Text;
                            Settings.Default.Save();
                            account.Username = TxtUsername.Text;
                            Cashier agent = new Cashier();
                            agent.Show();

                        }
                        break;

                    default:
                        MessageBox.Show("Select Usertype");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Login failed");
            }


        }

        private void LoginView_Load(object sender, EventArgs e)
        {
           
            //using (ShopDataContext db = new ShopDataContext())
            //{
            //    usertypeCombo.Items.Clear();
            //    //usertypeCombo.DataSource = db.Users.ToList();
            //    usertypeCombo.DisplayMember = "Role";
            //    usertypeCombo.ValueMember = "Id";
            //    usertypeCombo.SelectedValue = "";
            //}
        }
    }
}
