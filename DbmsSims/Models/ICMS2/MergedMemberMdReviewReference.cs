namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_MD_REVIEW_REFERENCE")]
    public partial class MergedMemberMdReviewReference
    {
        [Key]
        public int merged_member_md_review_reference_id { get; set; }

        public int? member_md_review_reference_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public int? cr_bill_id { get; set; }

        public int? md_review_request_id { get; set; }

        public int? md_review_followup_id { get; set; }

        public Guid? reviewing_md_id { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        [StringLength(50)]
        public string module_review_submitted_from { get; set; }

        public byte? in_review { get; set; }

        public byte? initial_load { get; set; }

        public DateTime? out_of_review_date { get; set; }

        public Guid? out_of_review_user_id { get; set; }
    }
}
