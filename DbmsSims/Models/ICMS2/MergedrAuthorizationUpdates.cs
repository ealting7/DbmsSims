namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_AUTHORIZATION_UPDATES")]
    public partial class MergedrAuthorizationUpdates
    {
        [Key]
        public int merged_r_authorization_updates_id { get; set; }

        public int? r_authorization_updates_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(5)]
        public string authorization_type { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }
    }
}
