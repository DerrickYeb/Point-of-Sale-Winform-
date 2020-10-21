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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }
        UsersModel users = new UsersModel();
        UserController controller = new UserController();
        private void TxtProductUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            users.FirstName = txtFName.Text;
            users.Surname = txtLastName.Text;
            users.Role = SelectRole();
            users.Username = txtUsername.Text;
            users.Password = txtPassword.Text;

            bool success = controller.Insert(users);



            if (txtPassword.Text == "" || txtConfirmPass.Text == "")
            {
                MessageBox.Show("Please enter values");
                txtPassword.Focus();
                return;
            }
            else if (txtPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Password not matching");
                txtConfirmPass.Focus();
                return;
            }
            else if (success == true)
            {
                MessageBox.Show("User Added");
            }
        }
        private string SelectRole()
        {
            if (radioAdmin.Checked)
            {
                return radioAdmin.Text;
            }
            else
            {
                return radioSalesAgent.Text;
            }
        }
    }
}
