namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_LCM_FOLLOWUP_SAVINGS")]
    public partial class MergedMemberLcmFollowupSavings
    {
        [Key]
        public int merged_member_lcm_followup_savings_id { get; set; }

        public int? member_lcm_followup_savings_id { get; set; }

        public int? line_number { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        public Guid? member_id { get; set; }

        [Column(TypeName = "money")]
        public decimal? amount { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        public int? member_lcm_followup_savings_type_id { get; set; }
    }
}
