namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_MEDS_HIGH_DOLLAR_TASK")]
    public partial class MergedMemberMedsHighDollarTask
    {
        [Key]
        public int merged_member_meds_high_dollar_task_id { get; set; }

        public int? member_meds_high_dollar_task_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(100)]
        public string medication_sequence { get; set; }

        public int? member_meds_id { get; set; }

        [StringLength(100)]
        public string drug_name { get; set; }

        public Guid? entered_by_system_user_id { get; set; }

        public DateTime? entered_date { get; set; }

        public Guid? assigned_to_system_user_id { get; set; }

        public DateTime? start_action_date { get; set; }

        public DateTime? end_action_date { get; set; }

        public byte? completed { get; set; }

        public Guid? completed_by_system_user_id { get; set; }

        public DateTime? completed_date { get; set; }

        public DateTime? actual_start_action_date { get; set; }

        public DateTime? actual_end_action_date { get; set; }

        public byte? disabled { get; set; }

        public byte? task_assigned_via_portal { get; set; }

        public Guid? last_update_user_id { get; set; }

        public DateTime? last_update_date { get; set; }
    }
}
