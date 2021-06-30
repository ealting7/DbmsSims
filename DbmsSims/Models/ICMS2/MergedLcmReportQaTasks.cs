namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_LCM_REPORT_QA_TASKS")]
    public partial class MergedLcmReportQaTasks
    {
        [Key]
        public int merged_lcm_report_qa_tasks_id { get; set; }

        public int? lcm_report_qa_task_id { get; set; }

        public Guid? member_id { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        public DateTime? last_save_and_close_date { get; set; }

        public Guid? last_save_and_close_user_id { get; set; }

        public byte? completed { get; set; }

        public DateTime? completed_date { get; set; }

        public Guid? completed_user_id { get; set; }

        [StringLength(5000)]
        public string qa_notes { get; set; }

        public bool? qa_task_assigned { get; set; }
    }
}
