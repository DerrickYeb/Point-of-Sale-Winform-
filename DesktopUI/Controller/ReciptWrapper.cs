using DesktopUI.Properties;
using DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports;
using DevExpress.Utils.OAuth;
using DevExpress.XtraReports.UI;

namespace DesktopUI.Controller
{
    public sealed class ReciptWrapper
    {
        private static XtraReport report;
        private static Parameters parameters;
        public static void Init(XtraReport xtraReport, Parameters paraMeters)
        {
            report = xtraReport;
            parameters = paraMeters;
        }
        public static void InitPrint()
        {
            report.Parameters["pAmountPaid"].Value = parameters.Balance;
            report.Parameters["pSalesId"].Value = parameters.AmountPaid;
            report.Parameters["pCashierId"].Value = parameters.Cashier;
            report.Parameters["pChange"].Value = parameters.SalesId;
            report.Parameters["pShopName"].Value = parameters.ShopName;
            //var picBox = report.AllControls<XRPictureBox>().FirstOrDefault();
            //picBox.Image = Image.FromFile(Directory.GetFiles(@"Logo\")[0]);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.PrintingSystem.ShowPrintStatusDialog = false;
            report.RequestParameters = false;
            report.CreateDocument(false);
            printTool.Print();
            printTool.Dispose();
            report.Dispose();
        }
    }
}

