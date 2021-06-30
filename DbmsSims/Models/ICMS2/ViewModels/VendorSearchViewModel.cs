using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class VendorSearchViewModel
    {

        public string ReferralNumber { get; set; }
        public string AddType { get; set; }

        public int VendorId { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}