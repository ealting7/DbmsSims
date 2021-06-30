namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_BILLING_UPDATE_HISTORY_LOG")]
    public partial class MergedBillingUpdateHistoryLog
    {
        [Key]
        public int merged_billing_update_history_log_id { get; set; }

        public int? billing_update_history_log_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? lcm_record_id { get; set; }

        public DateTime? original_record_date { get; set; }

        public int? original_billing_id { get; set; }

        [StringLength(5)]
        public string original_billing_code { get; set; }

        [StringLength(100)]
        public string original_billing_description { get; set; }

        public int? original_minutes { get; set; }

        [StringLength(150)]
        public string original_entered_by_user { get; set; }

        public Guid? update_user_id { get; set; }

        public DateTime? update_date { get; set; }

        public int? update_billing_id { get; set; }

        [StringLength(5)]
        public string update_billing_code { get; set; }

        [StringLength(100)]
        public string update_billing_description { get; set; }

        public int? update_minutes { get; set; }

        [StringLength(500)]
        public string update_reason { get; set; }

        [StringLength(25)]
        public string update_screen { get; set; }
    }
}
