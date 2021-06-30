namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_LCM_ACTIVITY")]
    public partial class MemberLcmActivity
    {
        [Key]
        public int lcm_activity_followup_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public int? lcn_case_number { get; set; }

        public byte? current_report { get; set; }

        public int? last_lcm_report_followup_id { get; set; }

        [Column(TypeName = "text")]
        public string activity_report_note { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        [StringLength(255)]
        public string last_update_reason { get; set; }

        public DateTime? next_report_date { get; set; }

        public byte? report_billed { get; set; }

        public DateTime? report_billed_date { get; set; }

        public byte? from_portal { get; set; }
    }
}
