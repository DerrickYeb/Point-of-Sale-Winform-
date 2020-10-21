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
    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            var add = new BatchAdd();
            add.Show();
            this.Dispose();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            var update = new UpdateProduct();
            update.Show();
            this.Dispose();
            
        }
    }
}
