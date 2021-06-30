namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_MEMBER_REFERRAL_INTERQUAL_REFERENCE")]
    public partial class MergedrMemberReferralInterqualReference
    {
        [Key]
        public int merged_r_member_referral_interqual_reference_id { get; set; }

        public int? r_member_referral_interqual_reference_id { get; set; }

        [StringLength(50)]
        public string review_cid { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? member_id { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }
    }
}
