using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class ReferralRefersViewModel
    {

        //referral items
        public string MemberId { get; set; }
        public string ReferralNumber { get; set; }
        public string AuthNumber { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Please enter a Date: MM/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? AuthStartDate { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Please enter a Date: MM/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? AuthEndDate { get; set; }



        public string ReferredByProviderPcpId { get; set; }
        public int? ReferredByFacilityId { get; set; }
        public int? ReferredByPlaceOfServiceId { get; set; }

        public string ReferredByProviderName { get; set; }
        public string ReferredByFacilityName { get; set; }
        public string ReferredByPlaceOfServiceName { get; set; }
        public string ReferredByStdOfficeLocationName { get; set; }



        public string ReferredToProviderPcpId { get; set; }
        public int? ReferredToFacilityId { get; set; }
        public int? ReferredToVendorId { get; set; }
        public int? ReferredToPlaceOfServiceId { get; set; }
        public int ReferredToStdOfficeLocationId { get; set; }

        public string ReferredToProviderName { get; set; }
        public string ReferredToFacilityName { get; set; }
        public string ReferredToVendorName { get; set; }
        public string ReferredToPlaceOfServiceName { get; set; }



        public string state_abbrev { get; set; }
        public virtual List<States> StatesInUsa { get; set; } = new List<States>();

        public int pos_id { get; set; }
        public virtual List<rLocationPos> PlaceOfServices { get; set; } = new List<rLocationPos>();
    }
}