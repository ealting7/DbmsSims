namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_INBOUND_FAX_REFERRAL_REMOVAL")]
    public partial class rInboundFaxReferralRemoval
    {
        [Key]
        public int r_inbound_fax_referral_removal_id { get; set; }

        public int? id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? removed_by_user_id { get; set; }

        public DateTime? removed_date { get; set; }
    }
}
