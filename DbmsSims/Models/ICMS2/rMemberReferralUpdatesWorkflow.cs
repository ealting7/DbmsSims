namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_MEMBER_REFERRAL_UPDATES_WORKFLOW")]
    public partial class rMemberReferralUpdatesWorkflow
    {
        [Key]
        public int r_member_referral_updates_workflow_id { get; set; }

        public int? eventtype_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? created_by_user_id { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string description { get; set; }
    }
}
