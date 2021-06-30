namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WEB_CLIENT_NOTE_TASK")]
    public partial class WebClientNoteTask
    {
        [Key]
        public int web_client_note_id { get; set; }

        public DateTime? record_date { get; set; }

        public Guid? member_id { get; set; }

        public int? task_id { get; set; }

        public Guid? assigned_to_system_user_id { get; set; }

        public DateTime? start_action_date { get; set; }

        public DateTime? end_action_date { get; set; }

        public bool? completed { get; set; }

        public Guid? entered_by_system_user_id { get; set; }

        public DateTime? date_entered { get; set; }

        [StringLength(500)]
        public string task_note { get; set; }

        public DateTime? completed_date { get; set; }

        public Guid? completed_by_system_user_id { get; set; }

        public DateTime? actual_start_action_date { get; set; }

        public DateTime? actual_end_action_date { get; set; }

        public int? taskoutcome_id { get; set; }

        public bool? disabled { get; set; }

        public byte? user_verified { get; set; }

        public DateTime? date_verified { get; set; }
    }
}
