namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_CLINICAL_REVIEW_BILLS")]
    public partial class MergedClinicalReviewBills
    {
        [Key]
        public int merged_clinical_review_bills_id { get; set; }

        public int? cr_bill_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(50)]
        public string type_of_review { get; set; }

        [StringLength(255)]
        public string other_type_of_review { get; set; }

        [Column(TypeName = "money")]
        public decimal? review_cost { get; set; }

        [Column(TypeName = "money")]
        public decimal? other_review_cost { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_user_id { get; set; }

        public byte? is_physician_review { get; set; }

        public byte? is_nurse_review { get; set; }

        public byte? is_other_review { get; set; }

        public byte? is_hospital_plan_bill { get; set; }

        public Guid? system_role_id { get; set; }
    }
}
