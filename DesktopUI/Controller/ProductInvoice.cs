using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DesktopUI.Models;
using System.Collections.Generic;

namespace DesktopUI.Controller
{
    public partial class ProductInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public ProductInvoice()
        {
            InitializeComponent();
        }
        public void InitData(List<ProductDetails> data)
        {
            //pSalesId.Value = salesId;
            //pInvoiceId.Value = invoiceID;
            //pCustomerName.Value = customer;
            objectDataSource2.DataSource = data;
        }

    }
}
