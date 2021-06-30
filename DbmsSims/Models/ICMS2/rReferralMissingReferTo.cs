namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_REFERRAL_MISSING_REFER_TO")]
    public partial class rReferralMissingReferTo
    {
        [Key]
        public int r_referral_missing_refer_to_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? entered_by_id { get; set; }

        public DateTime? date_entered { get; set; }

        public int? referred_to_department_id { get; set; }

        public Guid? referred_to_pcp_id { get; set; }

        public byte? missing_npi { get; set; }

        public byte? missing_billing_npi { get; set; }

        public byte? missing_ihcp { get; set; }

        public byte? missing_billing_ihcp { get; set; }

        public byte? no_longer_missing { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_userid { get; set; }

        public DateTime? no_longer_missing_date { get; set; }

        public Guid? no_longer_missing_userid { get; set; }
    }
}
