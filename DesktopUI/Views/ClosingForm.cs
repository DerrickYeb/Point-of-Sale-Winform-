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
    public partial class ClosingForm : Form
    {
        public ClosingForm()
        {
            InitializeComponent();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Dispose();
            new LoginView().Show();
            Hide();
           
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {

            Close();

        }
    }
}
