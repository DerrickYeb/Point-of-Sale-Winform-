using DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    class ShopDetails
    {
        static string name,location, licenseId, phone, datelicensed, renewed;
       // private readonly POS p = new POS();
        
        public string Shopname
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string LicenseId
        {
            get
            {
                return licenseId;
            }
            set
            {
                licenseId = value;
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        public string DateLicensed
        {
            get
            {
                return datelicensed;
            }
            set
            {
                datelicensed = value;
            }
        }
        public string Renewed
        {
            get
            {
                return renewed;
            }
            set
            {
                renewed = value;
            }
        }
        [DataMemberAttribute]
        public string SalesNumber { get; set; }
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
    }
}
