namespace DbmsSims.Models.ICMS_DATA_STAGING
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CR_BILLING_WORKTABLE")]
    public partial class CrBillingWorktable
    {
        [Key]
        public Guid cr_record_id { get; set; }

        public bool? print_cr { get; set; }

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

        [StringLength(255)]
        public string description { get; set; }

        public double? cr_rate { get; set; }

        [StringLength(50)]
        public string invoice_id { get; set; }

        [StringLength(110)]
        public string bill_entered_by { get; set; }

        public DateTime? search_start_date { get; set; }

        public DateTime? search_end_date { get; set; }

        public DateTime? date_updated { get; set; }

        public Guid? user_updated { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? user_created { get; set; }

        public bool? disable_flag { get; set; }

        [StringLength(1024)]
        public string comments { get; set; }

        public bool? refreshed { get; set; }

        public DateTime? refreshed_date { get; set; }

        public Guid? refreshed_user_id { get; set; }

        public DateTime? bill_due_date { get; set; }

        public Guid? updated_user_id { get; set; }

        public DateTime? updated_date { get; set; }

        public byte? sending_item { get; set; }

        public DateTime? sending_date { get; set; }

        public byte? sent_item { get; set; }

        public DateTime? sent_date { get; set; }
    }
}
