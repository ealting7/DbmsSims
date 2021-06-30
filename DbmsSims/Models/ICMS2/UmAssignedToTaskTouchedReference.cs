namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UM_ASSIGNED_TO_TASK_TOUCHED_REFERENCE")]
    public partial class UmAssignedToTaskTouchedReference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int um_assigned_to_task_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public byte? touched { get; set; }

        public DateTime? touched_date { get; set; }

        public DateTime? previous_touched_date { get; set; }

        public byte? disabled { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }
    }
}
