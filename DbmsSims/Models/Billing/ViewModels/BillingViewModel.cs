using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS_DATA_STAGING;

namespace DbmsSims.Models.Billing.ViewModels
{
    public class BillingViewModel
    {
        public string BillingType { get; set; }

        public Guid? MemberId { get; set; }
        public string AlternateMemberId { get; set; }
        public string Dob { get; set; }
        [StringLength(200)]
        public string PatientName { get; set; }
        [StringLength(250)]
        public string EmployerName { get; set; }
        [StringLength(250)]
        public string TpaName { get; set; }
        [StringLength(100)]
        public string CaseManagerName { get; set; }

        public DateTime? RecordDate { get; set; }
        [Column(TypeName = "text")]
        public string Notes { get; set; }
        public int? TimeCode { get; set; }
        public double? TimeLength { get; set; }
        public double? BillRate { get; set; }

        public Guid BillingRecordId { get; set; }
        public bool PrintBilling { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateUserId { get; set; }
        public bool? Disabled { get; set; }
        [StringLength(1024)]
        public string Comments { get; set; }
        [StringLength(50)]
        public string InvoiceNumber { get; set; }
        public bool? Refreshed { get; set; }
        public DateTime? RefreshDate { get; set; }
        public Guid? RefreshedUserId { get; set; }
        public bool? KeepInBilling { get; set; }
        public DateTime? BillDueDate { get; set; }
        public byte? SendingItem { get; set; }
        public DateTime? SendingDate { get; set; }
        public byte? SentItem { get; set; }
        public DateTime? SentDate { get; set; }
        public byte? UmNote { get; set; }
        [StringLength(50)]
        public string ReferralNumber { get; set; }
        public byte? HasActivityReport { get; set; }
        public int? LcmActivityFollowupId { get; set; }
        public bool? LienItemQa { get; set; }
        public Guid? LineItemQaUserId { get; set; }
        public DateTime? LineItemQaDate { get; set; }

    }
}