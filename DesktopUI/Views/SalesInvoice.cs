using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DesktopUI.Models;
using System.Collections.Generic;

namespace DesktopUI.Controller
{
    public partial class SalesInvoice : XtraReport
    {
        public SalesInvoice()
        {
            InitializeComponent();
        }

        public void InitData(string salesId,string invoiceID,string phone,string customer, List<SalesDetails> data)
        {
            pSalesId.Value = salesId;
            pInvoiceId.Value = invoiceID;
            pCustomerName.Value = customer;
            SalesDetails.DataSource = data;
        }
    }
}
