namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_CARE_COORDINATION_CALL")]
    public partial class MergedMemberCareCoordinationCall
    {
        [Key]
        public int merged_member_care_coordnination_call_id { get; set; }

        public int? member_care_coordination_call_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public DateTime? call_date { get; set; }

        [StringLength(255)]
        public string call_note { get; set; }

        public Guid? call_entered_by_system_user_id { get; set; }

        public DateTime? creation_date { get; set; }
    }
}
