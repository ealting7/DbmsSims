using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class UtilizationOutpatientDayViewModel
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


        //outpatient items
        public string VisitRecurring { get; set; }
        public int? NumberPerPeriodRequest { get; set; }
        public string PeriodRequested { get; set; }
        public int? NumberOfPeriodsRequested { get; set; }
        public int? NumberPerPeriodAuthorized { get; set; }
        public string PeriodAuthorized { get; set; }
        public int? NumberOfPeriodsAuthorized { get; set; }
        public DateTime? AuthorizedStartDate { get; set; }
        public DateTime? AuthorizedEndDate { get; set; }


        //shared by both inpatient and outpatient from the r_utilization_days table
        public int line_number { get; set; }
        [Required(ErrorMessage = "Select A Decision")]
        public int? util_decision_id { get; set; }
        public int? denial_reason_id { get; set; }
        [Required(ErrorMessage = "Select A Decision By Item")]
        public int? review_type_items_id { get; set; }


        //outpatient id and date fields from the r_utilization_days table
        public bool visits_recurring_flag { get; set; }
        [Required(ErrorMessage = "Enter # Periods Requested")]
        public int? visits_num_per_period_requested { get; set; }
        [Required(ErrorMessage = "Enter # Periods Authorized")]
        public int? visits_num_per_period_authorized { get; set; }
        [Required(ErrorMessage = "Enter Period Requested")]
        [StringLength(1)]
        public string visits_period_requested { get; set; }
        [Required(ErrorMessage = "Enter Period Authorized")]
        [StringLength(1)]
        public string visits_period_authorized { get; set; }
        [Required(ErrorMessage = "# Periods Requested")]
        public int? visits_num_periods_requested { get; set; }
        [Required(ErrorMessage = "# Periods Authorized")]
        public int? visits_num_periods_authorized { get; set; }
        [Required(ErrorMessage = "End Date Is Required")]
        public DateTime? visits_authorized_end_date { get; set; }
        [Required(ErrorMessage = "Start Date Is Required")]
        public DateTime? visits_authorized_start_date { get; set; }


        //list of utilization items for referral
        public virtual List<UtilizationOutpatientDayViewModel> OutpatientUtilizationDaysInReferral { get; set; } = new List<UtilizationOutpatientDayViewModel>();

        public virtual List<NotesViewModel> UtilizationNotes { get; set; } = new List<NotesViewModel>();



        [DisplayName("Review Type Items")]
        public virtual List<ReviewTypeItems> ReviewTypeItemsInDbms { get; set; } = new List<ReviewTypeItems>();

        [DisplayName("Utilization Days Decision")]
        public virtual List<rUtilizationDaysDecision> UtilizationDaysDecisionInDbms { get; set; } = new List<rUtilizationDaysDecision>();

        [DisplayName("Denial Reason")]
        public virtual List<rDenialReason> DenialReasonsInDbms { get; set; } = new List<rDenialReason>();



        //outpatient dropdown lists
        [DisplayName("Period Requested")]
        public virtual List<rUtilizationVisitPeriod> VisitPeriodsRequestedItemsInDbms { get; set; } = new List<rUtilizationVisitPeriod>();

        [DisplayName("Period Authorized")]
        public virtual List<rUtilizationVisitPeriod> VisitPeriodsAuthorizedItemsInDbms { get; set; } = new List<rUtilizationVisitPeriod>();


    }
}