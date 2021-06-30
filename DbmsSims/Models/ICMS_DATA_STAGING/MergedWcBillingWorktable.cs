namespace DbmsSims.Models.ICMS_DATA_STAGING
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_WC_BILLING_WORKTABLE")]
    public partial class MergedWcBillingWorktable
    {
        [Key]
        public int merged_wc_billing_worktable_id { get; set; }

        public Guid? wc_record_id { get; set; }

        public bool? print_wc { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(9)]
        public string member_ssn { get; set; }

        public DateTime? member_dob { get; set; }

        [StringLength(110)]
        public string member_name { get; set; }

        [StringLength(50)]
        public string member_last_name { get; set; }

        [StringLength(50)]
        public string member_first_name { get; set; }

        [StringLength(50)]
        public string employer_name { get; set; }

        [StringLength(255)]
        public string tpa_name { get; set; }

        public DateTime? auth_start_date { get; set; }

        [StringLength(50)]
        public string referral_type { get; set; }

        public DateTime? record_date { get; set; }

        [Column(TypeName = "text")]
        public string notes { get; set; }

        public double? time_code { get; set; }

        public double? time_length { get; set; }

        public double? wc_rate { get; set; }

        [StringLength(50)]
        public string invoice_id { get; set; }

        [StringLength(110)]
        public string note_entered_by { get; set; }

        public DateTime? search_start_date { get; set; }

        public DateTime? search_end_date { get; set; }

        public DateTime? date_updated { get; set; }

        public Guid? user_updated { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? user_created { get; set; }

        public bool? disable_flag { get; set; }

        [StringLength(1024)]
        public string comments { get; set; }
    }
}
