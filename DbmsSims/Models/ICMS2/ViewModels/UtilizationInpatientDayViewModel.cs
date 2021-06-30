using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class UtilizationInpatientDayViewModel
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
        public string InpatientOutpatientType { get; set; }
        public string UtilizationType { get; set; }


        //shared by both inpatient and outpatient
        public int LineNumber { get; set; }
        public string DecisionBy { get; set; }
        public int? DecisionById { get; set; }
        public string Decision { get; set; }
        public int? UtilDecisionId { get; set; }
        public string DenialReason { get; set; }
        public int? DenialReasonId { get; set; }
        public bool? Removed { get; set; }
        public DateTime? RemovedDate { get; set; }
        public Guid? RemovedUserId { get; set; }
        public string SystemUserId { get; set; }


        //inpatient items
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? NextReviewDate { get; set; }
        public string BedType { get; set; }
        public int? BedTypeId { get; set; }
        public bool Surgery { get; set; }
        public bool SurgeryOnFirstDay { get; set; }
        public string SurgeryText { get; set; }
        public string SurgeryOnFirstDayText { get; set; }


        //shared by both inpatient and outpatient from the r_utilization_days table
        public int line_number { get; set; }
        [Required(ErrorMessage = "Select A Decision")]
        public int? util_decision_id { get; set; }
        public int? denial_reason_id { get; set; }
        [Required(ErrorMessage = "Select A Decision By Item")]
        public int? review_type_items_id { get; set; }



        //inpatient id and date fields from the r_utilization_days table
        [Required(ErrorMessage = "Select A Bed Type")]
        public int? bed_type_id { get; set; }
        public bool surgery_flag { get; set; }
        public bool surgery_on_first_day_flag { get; set; }
        [Required(ErrorMessage = "Start Date Is Required")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a Date: MM/dd/yyyy")]
        [DisplayName("Start Date")]
        public DateTime? start_date { get; set; }
        [Required(ErrorMessage = "Next Review Date Is Required")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a Date: MM/dd/yyyy")]
        [DisplayName("Next Review Date")]
        public DateTime? next_review_date { get; set; }
        public int? number_of_days { get; set; }


        //list of utilization items for referral
        public virtual List<UtilizationInpatientDayViewModel> InpatientUtilizationDaysInReferral { get; set; } = new List<UtilizationInpatientDayViewModel>();

        public virtual List<NotesViewModel> UtilizationNotes { get; set; } = new List<NotesViewModel>();



        //inpatient dropdown lists
        [DisplayName("Bed Types")]
        public virtual List<rBedDayType> ReferralBedTypesInDbms { get; set; } = new List<rBedDayType>();

        [DisplayName("Review Type Items")]
        public virtual List<ReviewTypeItems> ReviewTypeItemsInDbms { get; set; } = new List<ReviewTypeItems>();

        [DisplayName("Utilization Days Decision")]
        public virtual List<rUtilizationDaysDecision> UtilizationDaysDecisionInDbms { get; set; } = new List<rUtilizationDaysDecision>();

        [DisplayName("Denial Reason")]
        public virtual List<rDenialReason> DenialReasonsInDbms { get; set; } = new List<rDenialReason>();

    }
}