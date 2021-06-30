namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_UTILIZATION_DAYS")]
    public partial class MergedrUtilizationDays
    {
        [Key]
        public int merged_r_utilization_days_id { get; set; }

        public Guid member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(1)]
        public string referral_type { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int line_number { get; set; }

        public int? type_id { get; set; }

        public bool surgery_flag { get; set; }

        public bool surgery_on_first_day_flag { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public int? util_decision_id { get; set; }

        public DateTime? next_review_date { get; set; }

        public int? number_of_days { get; set; }

        public bool visits_recurring_flag { get; set; }

        public int? visits_num_per_period_requested { get; set; }

        public int? visits_num_per_period_authorized { get; set; }

        [StringLength(1)]
        public string visits_period_requested { get; set; }

        [StringLength(1)]
        public string visits_period_authorized { get; set; }

        public int? visits_num_periods_requested { get; set; }

        public int? visits_num_periods_authorized { get; set; }

        public DateTime? visits_authorized_end_date { get; set; }

        public DateTime? visits_authorized_start_date { get; set; }

        public int? denial_reason_id { get; set; }

        public DateTime? DateUpdated { get; set; }

        [StringLength(20)]
        public string ICM_Units { get; set; }

        public int? PatCaseActID { get; set; }

        public DateTime? Date_Created { get; set; }

        public int? sands_referral_status_code_id { get; set; }

        public byte? std_billed { get; set; }

        public DateTime? std_billed_date { get; set; }

        public bool? removed { get; set; }

        public DateTime? removed_date { get; set; }

        public Guid? removed_user_id { get; set; }
    }
}
