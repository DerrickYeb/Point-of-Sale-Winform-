using DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Controller
{
    class LoadProducts
    {
        DataConnection connection = new DataConnection();
        public  void ProductsDataLoad()
        {
            connection = new DataConnection();
            connection.MyConnection();
            connection.SqlQuery("spProducts");

        }
    }
}
