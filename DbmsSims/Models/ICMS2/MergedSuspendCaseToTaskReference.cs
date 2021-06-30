namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_SUSPEND_CASE_TO_TASK_REFERENCE")]
    public partial class MergedSuspendCaseToTaskReference
    {
        [Key]
        public int merged_suspend_case_to_task_reference_id { get; set; }

        public int? suspend_case_to_task_reference_id { get; set; }

        public int? task_id { get; set; }

        public int? member_task_id { get; set; }

        public Guid? member_id { get; set; }

        public DateTime? move_to_date { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        [StringLength(50)]
        public string referral_type { get; set; }

        public byte? completed { get; set; }

        public DateTime? completed_date { get; set; }

        public Guid? completed_user_id { get; set; }

        [StringLength(1000)]
        public string comment { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }
    }
}
