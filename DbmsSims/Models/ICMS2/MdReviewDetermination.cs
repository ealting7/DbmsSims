namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MD_REVIEW_DETERMINATION")]
    public partial class MdReviewDetermination
    {
        [Key]
        public int md_review_determination_id { get; set; }

        public DateTime? record_date { get; set; }

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

        public DateTime? creation_date { get; set; }

        [StringLength(2000)]
        public string md_review_determination_note { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? member_id { get; set; }

        public byte? task_viewed { get; set; }

        public DateTime? task_viewed_date { get; set; }

        public Guid? task_viewed_user_id { get; set; }

        public byte? user_verified { get; set; }

        public DateTime? date_verified { get; set; }

        public int? md_review_request_id { get; set; }

        public byte? cm_request { get; set; }

        public DateTime? cm_request_date { get; set; }
    }
}
