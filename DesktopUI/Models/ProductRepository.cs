using DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Models
{
    class ProductRepository 
    {
        internal static ProductRepository instance;

        //private readonly ProductsModel p = new ProductsModel();
        
        #region GetAutocompleteData
       

        internal void UpdateQuantity(object productName, object quantity)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}