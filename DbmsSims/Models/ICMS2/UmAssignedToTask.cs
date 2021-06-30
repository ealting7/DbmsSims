namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UM_ASSIGNED_TO_TASK")]
    public partial class UmAssignedToTask
    {
        [Key]
        public int um_assigned_to_task_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(125)]
        public string member_name { get; set; }

        public DateTime? member_dob { get; set; }

        public int? employer_id { get; set; }

        public int? tpa_id { get; set; }

        public DateTime? record_date { get; set; }

        public int? task_id { get; set; }

        public int? um_assigned_to_reference_id { get; set; }

        public Guid? workflow_id { get; set; }

        public int? priority { get; set; }

        public int? referral_status { get; set; }

        public Guid? assigned_to_system_user_id { get; set; }

        public Guid? entered_by_system_user_id { get; set; }

        public DateTime? start_action_date { get; set; }

        public DateTime? end_action_date { get; set; }

        public byte? completed { get; set; }

        public DateTime? completed_date { get; set; }

        public Guid? completed_by_system_user_id { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public DateTime? date_entered { get; set; }

        [StringLength(500)]
        public string task_note { get; set; }

        public DateTime? actual_start_action_date { get; set; }

        public DateTime? actual_end_action_date { get; set; }

        public int? taskoutcome_id { get; set; }

        public bool? disabled { get; set; }
    }
}
