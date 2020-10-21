using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    public class ProductsModel
    {
        public string Id { get; set; }
        [Display(Name ="Product Code")]
        public string ProductCode { get; set; }
        [Display(Name="Product Name")]
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        [Display(Name ="Product Unit")]
        public string ProductUnit { get; set; }
        [Display(Name ="Cost Price")]
        public string CostPrice { get; set; }
        [Display(Name ="Retail Price")]
        public string RetailPrice { get; set; }
        public string Supplier { get; set; }
        [Display(Name ="Created Date")]
        public string CreatedDate { get; set; }
       // public string LastModified { get; set; }
    }
}
