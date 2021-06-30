using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class ReferralRequestViewModel
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

        public Guid SystemUserId { get; set; }
        public string SystemUserFullName { get; set; }



        public int TopLevelMdReviewRequestId { get; set; }
        public int? MdReviewRequestId { get; set; }
        public int? MdReviewQuestionId { get; set; }
        public string RequestType { get; set; }
        [StringLength(500)]
        public string RequestText { get; set; }
        public string AnswerText { get; set; }
        public DateTime? DateEntered { get; set; }



        public List<ReferralRequestViewModel> requests { get; set; }
        public List<ReferralRequestViewModel> questions { get; set; }


        //inpatient dropdown lists
        [DisplayName("MD Requests For")]
        public virtual List<SystemUserViewModel> ReferralMdRequestsFor { get; set; } = new List<SystemUserViewModel>();

    }
}