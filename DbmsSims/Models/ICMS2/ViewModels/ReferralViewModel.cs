using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class ReferralViewModel
    {

        public string MemberId { get; set; }
        public string ReferralNumber { get; set; }
        public string AuthNumber { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Please enter a Date: MM/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? AuthStartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Please enter a Date: MM/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? AuthEndDate { get; set; }

        public string ReferralType { get; set; }
        public string ReferringProviderName { get; set; }
        public string ReferredToProviderName { get; set; }
        public string VendorName { get; set; }
        public string ReferredToDepartmentName { get; set; }
        public string ReferralDecision { get; set; }
        public string InpatientOutpatientType { get; set; }

        public bool Surgery { get; set; }
        public bool SurgeryOnFirstDay { get; set; }
        public int NumberOfDays { get; set; }

        public int? type_id { get; set; }
        public int? context_id { get; set; }
        public int? priority_id { get; set; }
        public int? referral_category { get; set; }
        public int current_status_id { get; set; }
        public string SystemUserId { get; set; }
        public int referral_pend_reason_id { get; set; }


        public string ModelUpdateMessage { get; set; }


        public List<ReferralViewModel> referrals { get; set; }




        [DisplayName("Auth/Referral Types")]
        public virtual List<rReferralType> ReferralTypesInDbms { get; set; } = new List<rReferralType>();
        
        [DisplayName("Context")]
        public virtual List<rReferralContext> ReferralContextsInDbms { get; set; } = new List<rReferralContext>();

        [DisplayName("Priority")]
        public virtual List<rReferralPriority> ReferralPrioritiesInDbms { get; set; } = new List<rReferralPriority>();

        [DisplayName("Category")]
        public virtual List<rReferralCategory> ReferralCategoriesInDbms { get; set; } = new List<rReferralCategory>();

        [DisplayName("Initiate Action")]
        public virtual List<rCurrentStatus> ReferralInitiateActionInDbms { get; set; } = new List<rCurrentStatus>();

        [DisplayName("Action Assigned To")]
        public virtual List<SystemUserViewModel> ReferralActionAssignedToInDbms { get; set; } = new List<SystemUserViewModel>();

        [DisplayName("Reason For Action")]
        public virtual List<rReferralPendReason> ReferralPendReasonInDbms { get; set; } = new List<rReferralPendReason>();

        [DisplayName("Review Requested By")]
        public virtual List<SystemUserViewModel> ReferralReviewRequestedByInDbms { get; set; } = new List<SystemUserViewModel>();

        [DisplayName("ICD 10")]
        public virtual List<MedicalCodeSearchViewModel> ReferralDiagnosisCodesInDbms { get; set; } = new List<MedicalCodeSearchViewModel>();

        [DisplayName("CPT")]
        public virtual List<MedicalCodeSearchViewModel> ReferralCptCodesInDbms { get; set; } = new List<MedicalCodeSearchViewModel>();

        [DisplayName("HCPCS")]
        public virtual List<MedicalCodeSearchViewModel> ReferralHcpcsCodesInDbms { get; set; } = new List<MedicalCodeSearchViewModel>();


    }

}