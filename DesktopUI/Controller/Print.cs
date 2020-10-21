using DesktopUI.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Controller
{
    public class Print
    {
       
        private PrinterSettings ps = new PrinterSettings()
        {

            PrinterName = Settings.Default.PrinterName
        };
        //private PrintLayoutSettings pls = new PrintLayoutSettings()
        //{
        //    Centered = true,
        //    Scaling = PrintLayoutSettings.PrintScaling.Scale
        //};
        //public Print(DataTable datable)
        //{
        //    _dt = datable;
        //}
        //public void PrintOp(string SalesID, string GrandTotal, string AmountPaid, string Balance, string Cashier)
        //{
        //    PageSettings pages = new PageSettings(ps);
        //    using (Receipt receipt = new Receipt())
        //    {
        //        //var path = Directory.GetFiles($@"{Application.StartupPath}\Logo\")[0];
        //        receipt.DataSource = _dt;
        //        receipt.Parameters[]
        //        receipt.SetParameterValue("pGrandTotal", GrandTotal);
        //        receipt.SetParameterValue("pAmount", AmountPaid);
        //        receipt.SetParameterValue("pBalance", Balance);
        //        receipt.SetParameterValue("pSalesID", SalesID);
        //        receipt.SetParameterValue("pCashier", Cashier);
        //        receipt.SetParameterValue("pBranchID", Settings.Default.BranchID);
        //        receipt.SetParameterValue("pContact", Settings.Default.Contact);
        //        receipt.SetParameterValue("pLocation", Settings.Default.Location);
        //        receipt.SetParameterValue("pShopName", Settings.Default.ShopName);
        //        receipt.SetParameterValue("pLogo", path);
        //        receipt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;
        //        receipt.PrintToPrinter(ps, pages, false);
        //    }
        //}
    }
}
