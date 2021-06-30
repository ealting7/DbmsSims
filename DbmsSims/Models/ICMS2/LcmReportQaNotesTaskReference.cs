namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LCM_REPORT_QA_NOTES_TASK_REFERENCE")]
    public partial class LcmReportQaNotesTaskReference
    {
        [Key]
        public int lcm_report_qa_notes_task_id { get; set; }

        public DateTime? record_date { get; set; }

        public int? lcm_report_qa_task_id { get; set; }

        public Guid? member_id { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        public int? task_id { get; set; }

        public Guid? assigned_to_system_user_id { get; set; }

        public DateTime? start_action_date { get; set; }

        public DateTime? end_action_date { get; set; }

        public byte? completed { get; set; }

        public Guid? completed_by_system_user_id { get; set; }

        public DateTime? actual_start_action_date { get; set; }

        public DateTime? actual_end_action_date { get; set; }

        public Guid? entered_by_system_user_id { get; set; }

        public int? taskoutcome_id { get; set; }

        public DateTime? date_entered { get; set; }

        [StringLength(500)]
        public string task_note { get; set; }

        public byte? disabled { get; set; }

        public DateTime? creation_date { get; set; }
    }
}
