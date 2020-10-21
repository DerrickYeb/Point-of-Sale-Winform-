using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    class AccountDetails
    {
        static string username, userRole,cashier;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string Role
        {
            get
            {
                return userRole;
            }
            set
            {
                userRole = value;
            }
        }
        public string CashierId
        {
            get
            {
                return cashier;
            }
            set
            {
                cashier = value;
            }
        }
    }
}
