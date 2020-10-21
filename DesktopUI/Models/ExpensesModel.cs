using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    public class ExpensesModel
    {
        public string Id { get; set; }
        public string DateAdded { get; set; }
        public string Reference { get; set; }
        public string Amount { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string CeatedBy { get; set; }
    }
}
