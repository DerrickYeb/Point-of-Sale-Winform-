using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    public class OrderDetails
    {
        public string SalesId { get; set; }
        public string Customer { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime SalesDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ChangeAmnt { get; set; }
        public string CashierId { get; set; }
        public decimal SubTotal { get; set; }
        

    }
}
