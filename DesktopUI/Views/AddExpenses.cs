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
    public partial class AddExpenses : Form
    {
        Expenses Expenses;
        public AddExpenses(Expenses exp)
        {
            InitializeComponent();
            Expenses = exp;
        }
        ExpensesModel exp = new ExpensesModel();
        ExpensesController excon = new ExpensesController();

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {

            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void TxtReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {

            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            exp.DateAdded = expensesDate.Text;
            exp.Category = CategorySelect.Text;
            exp.Amount = txtAmount.Text;
            exp.Description = expensesDescription.Text;
            exp.Reference = txtReference.Text;
            exp.CeatedBy = txtCeatedBy.Text;

            bool success = excon.Insert(exp);
            DialogResult confirm;
            confirm = MessageBox.Show("Are sure want to save ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if ((exp.Amount == "" || exp.Reference == "") && exp.Description == "")
            {
                MessageBox.Show("Empty fields cannot be submitted");

            }
           

            else if (confirm == DialogResult.Yes)
            {
                MessageBox.Show("Added Succesfully");
            }
            else if (confirm == DialogResult.No)
            {
                MessageBox.Show("Something went wrong at your end");
            }
            else if (success == true)
            {
                MessageBox.Show("Expenses Added");
            }
        }
    }
}
