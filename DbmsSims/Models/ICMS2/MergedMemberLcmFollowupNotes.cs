namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_LCM_FOLLOWUP_NOTES")]
    public partial class MergedMemberLcmFollowupNotes
    {
        [Key]
        public int merged_member_lcm_followup_notes_id { get; set; }

        public int? member_lcm_followup_notes_id { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        public Guid? member_id { get; set; }

        [Column(TypeName = "text")]
        public string current_treatments { get; set; }

        public byte? current_treatment_added { get; set; }

        [Column(TypeName = "text")]
        public string previous_treatments { get; set; }

        public byte? previous_treatment_added { get; set; }

        [Column(TypeName = "text")]
        public string future_treatments { get; set; }

        public byte? future_treatment_added { get; set; }

        [Column(TypeName = "text")]
        public string psycho_social_summary { get; set; }

        public byte? psycho_social_added { get; set; }

        [Column(TypeName = "text")]
        public string nurse_summary { get; set; }

        public byte? nurse_added { get; set; }

        [Column(TypeName = "text")]
        public string physician_prognosis { get; set; }

        public byte? physician_added { get; set; }

        public byte? current_note { get; set; }

        public byte? moved_to_previous_treatment { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public byte? mass_update { get; set; }

        public DateTime? mass_update_date { get; set; }

        [Column(TypeName = "text")]
        public string newly_identified_cm { get; set; }

        public byte? newly_identified_cm_added { get; set; }

        public byte? override_used { get; set; }
    }
}
