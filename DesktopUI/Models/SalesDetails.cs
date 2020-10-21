using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    public class SalesDetails
    {
        public int SalesNumber { get; set; }
        public string Customer { get; set; }
        [Display (Name = "Items")]
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal CashierId { get; set; }
        public decimal Total
        {
            get
            {
                return Quantity * Price - Quantity * Price * Discount;
            }
        }
        public DataTable TransactionDetails { get; set; }

    }
}
