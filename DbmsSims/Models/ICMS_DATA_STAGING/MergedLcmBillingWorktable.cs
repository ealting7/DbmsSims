namespace DbmsSims.Models.ICMS_DATA_STAGING
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_LCM_BILLING_WORKTABLE")]
    public partial class MergedLcmBillingWorktable
    {
        [Key]
        [Column(Order = 0)]
        public int merged_lcm_billing_worktable_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid lcm_record_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool print_lcm { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(200)]
        public string patient { get; set; }

        [StringLength(50)]
        public string memberid { get; set; }

        [StringLength(12)]
        public string dob { get; set; }

        [StringLength(250)]
        public string employer { get; set; }

        [StringLength(250)]
        public string tpa { get; set; }

        [StringLength(100)]
        public string case_manager { get; set; }

        public DateTime? record_date { get; set; }

        [Column(TypeName = "text")]
        public string notes { get; set; }

        public int? time_code { get; set; }

        public double? time_length { get; set; }

        public double? lcm_rate { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime date_updated { get; set; }

        public Guid? user_updated { get; set; }

        public bool? disable_flag { get; set; }

        [StringLength(1024)]
        public string comments { get; set; }

        [StringLength(50)]
        public string LCM_Invoice_Number { get; set; }

        public bool? refreshed { get; set; }

        public DateTime? refreshed_date { get; set; }

        public Guid? refreshed_user_id { get; set; }

        public bool? keep_in_billing { get; set; }

        public Guid? updated_user_id { get; set; }

        public DateTime? updated_date { get; set; }

        public DateTime? bill_due_date { get; set; }

        public byte? sending_item { get; set; }

        public DateTime? sending_date { get; set; }

        public byte? sent_item { get; set; }

        public DateTime? sent_date { get; set; }

        public byte? um_note { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public byte? has_activity_report { get; set; }

        public int? lcm_activity_followup_id { get; set; }

        public bool? line_item_qa { get; set; }

        public Guid? line_item_qa_user_id { get; set; }

        public DateTime? line_item_qa_date { get; set; }
    }
}
