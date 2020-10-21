using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Controller
{
    public class Operation
    {

        //public void IsBlank(Control.ControlCollection control)
        //{
        //    bool sucess;
        //    foreach (Control controls in control)
        //    {
        //        if (string.IsNullOrEmpty(controls) || !string.IsNullOrWhiteSpace(txt2))
        //    }
           
        //    {
        //        sucess = false;

        //    }
        //    else
        //    {
        //        sucess = true;
        //    }
        //    return;
        //}
        public bool ContainsValidNumbers(string value, string text, string text1)
        {
            int test;
            return int.TryParse(value, out test);
        }
        public void Clear(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                Clear(ctrl.Controls);


            }
        }
    }
}
