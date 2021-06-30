namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_MEMBER_REFERRAL_QOC")]
    public partial class rMemberReferralQoc
    {
        [Key]
        public int member_referral_qoc_id { get; set; }

        public int? qoc_reason_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(1)]
        public string inpat_outpat { get; set; }

        [StringLength(512)]
        public string qoc_notes { get; set; }
    }
}
