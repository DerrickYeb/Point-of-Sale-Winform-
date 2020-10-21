using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Models
{
    public class SalesModel
    {
        public string Id { get; set; }
        [Display(Name = "Sales ID")]
        public string SalesNumber { get; set; }
        public string CashierId { get; set; }
        public string Username { get; set; }
        [Display(Name = "Sales Date")]
        public string SalesDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        [Display(Name = "Total Items")]
        public int Totalitems { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public string Status { get; set; }
      
        
    }
}
