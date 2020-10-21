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
    public partial class AddCategory : Form
    {
        Category mycat = new Category();
        public AddCategory(Category category)
        {
            InitializeComponent();
            mycat = category;

        }
        CategoryController controller = new CategoryController();
        CategoryModel model = new CategoryModel();

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            model.Category = txtCatName.Text;

            bool success = controller.Insert(model);

            if (success == true)
            {
                MessageBox.Show("Added Successfully");
            }
            else
            {
                MessageBox.Show("Failed to add");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
