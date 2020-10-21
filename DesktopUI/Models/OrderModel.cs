using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    public class OrderModel
    {
        public string Id { get; set; }
        public string SalesId { get; set; }
        public string Cashier { get; set; }
        public string Username { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
        public string Discount { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }


    }
}
