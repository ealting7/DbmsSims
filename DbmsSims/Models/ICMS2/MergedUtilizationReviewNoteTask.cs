namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_UTILIZATION_REVIEW_NOTE_TASK")]
    public partial class MergedUtilizationReviewNoteTask
    {
        [Key]
        public int merged_utilization_review_note_task_id { get; set; }

        public int? utilization_review_note_task_id { get; set; }

        public DateTime? record_date { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public int? line_number { get; set; }

        [StringLength(125)]
        public string member_name { get; set; }

        public int? employer_id { get; set; }

        public int? tpa_id { get; set; }

        public DateTime? auth_start_date { get; set; }

        public DateTime? auth_end_date { get; set; }

        public int? task_id { get; set; }

        public Guid? assigned_to_system_user_id { get; set; }

        public Guid? entered_by_system_user_id { get; set; }

        public DateTime? start_action_date { get; set; }

        public DateTime? end_action_date { get; set; }

        [StringLength(500)]
        public string task_note { get; set; }

        public byte? completed { get; set; }

        public DateTime? completed_date { get; set; }

        public Guid? completed_by_system_user_id { get; set; }

        public DateTime? actual_start_action_date { get; set; }

        public DateTime? actual_end_action_date { get; set; }

        public int? taskoutcome_id { get; set; }

        public byte? disabled { get; set; }

        public DateTime? date_entered { get; set; }

        public byte? user_verified { get; set; }

        public DateTime? date_verified { get; set; }
    }
}
