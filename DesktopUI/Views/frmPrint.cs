using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DesktopUI.Controller;
using DesktopUI.Models;

namespace DesktopUI.Views
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmPrint()
        {
            InitializeComponent();
        }
        public void PrintInvoice(SalesModel sales, List<SalesDetails> data)
        {
            SalesInvoice invoice = new SalesInvoice();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in invoice.Parameters)
                p.Visible = false;
           // invoice.InitData(sales.SalesNumber.ToString(), sales.CustomerName, sales.Id.ToString(), sales.SalesDate,data);
            documentViewer1.DocumentSource = invoice;
            invoice.CreateDocument();
           
        }

        public void PrintProductInvoice(ProductsModel products, List<ProductDetails> details)
        {
            ProductInvoice pinvoice = new ProductInvoice();
            //foreach (DevExpress.XtraReports.Parameters.Parameter p2 in pinvoice.Parameters)
            //    p2.Visible = false;
            pinvoice.InitData(details);
            documentViewer1.DocumentSource = pinvoice;
            pinvoice.CreateDocument();
        }
    }
}