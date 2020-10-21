using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DesktopUI.Properties;
using DesktopUI.Models;
using System.Collections.Generic;

namespace DesktopUI.Controller
{
    public partial class Receipt : XtraReport
    {
        public Receipt()
        {
            InitializeComponent();
        }
        //public void InitData(string customer,string amountPaid,string balance,string phone, List<OrderModel> data)
        //{
        //    pShopName.Value = Settings.Default.ShopName;
        //    pTelephone.Value = phone;
        //    pCashierId.Value = Settings.Default.Cashier;
        //    pChange.Value = balance;
        //    pDate.Value = DateTime.Now;
        //    pAmountPaid.Value = amountPaid;
        //    pSalesID.Value = Settings.Default.SalesId;
        //    pCustomer.Value = customer;
        //    bindingSource1.DataSource = data;
        //}
    }
}
