namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_LCM_REPORT_QA_NOTES")]
    public partial class MergedLcmReportQaNotes
    {
        [Key]
        public int merged_lcm_report_qa_notes_id { get; set; }

        public int? lcm_report_qa_notes_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lcm_report_qa_task_id { get; set; }

        public Guid? member_id { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        [StringLength(5000)]
        public string qa_notes { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        public Guid? assigned_to_user_id { get; set; }

        public DateTime? assigned_date { get; set; }

        public byte? completed { get; set; }

        public DateTime? completed_date { get; set; }

        public Guid? completed_user_id { get; set; }

        public Guid? update_user_id { get; set; }

        public DateTime? updated_date { get; set; }
    }
}
