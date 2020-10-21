using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    public class StockModel
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Quantity { get; set; }
        public string PurchasePrice { get; set; }
        public string PurchaseDate { get; set; }

    }
}
