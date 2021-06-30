namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("MEMBER_RENAL_TASK")]
    public partial class MemberRenalTask
    {
        [Key]
        public int member_renal_task_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? member_id { get; set; }

        public int? task_id { get; set; }

        public Guid? assigned_to_system_user_id { get; set; }

        public DateTime? start_action_date { get; set; }

        public DateTime? end_action_date { get; set; }

        public byte? completed { get; set; }

        public DateTime? completed_date { get; set; }

        public Guid? completed_by_system_user_id { get; set; }

        public Guid? entered_by_system_user_id { get; set; }

        public DateTime? date_entered { get; set; }

        [StringLength(255)]
        public string task_note { get; set; }

        public int? taskoutcome_id { get; set; }

        public byte? disabled { get; set; }

        public byte? manager_task_entry { get; set; }
    }
}
