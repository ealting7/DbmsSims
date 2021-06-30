namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_CARE_COORDINATION_CALL_SAVINGS")]
    public partial class MemberCareCoordinationCallSavings
    {
        [Key]
        public int member_care_coordination_call_savings_id { get; set; }

        public int? member_care_coordination_call_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [Column(TypeName = "money")]
        public decimal? amount { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }
    }
}
