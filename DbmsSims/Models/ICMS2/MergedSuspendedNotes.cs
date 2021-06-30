namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_SUSPENDED_NOTES")]
    public partial class MergedSuspendedNotes
    {
        [Key]
        public int merged_suspended_notes_id { get; set; }

        public int? suspended_note_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(50)]
        public string note_type { get; set; }

        [Column(TypeName = "text")]
        public string note_text { get; set; }

        public int? RN_notes { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public byte? mid_month_suspend { get; set; }

        public DateTime? mid_month_allow_save_date { get; set; }

        public int? billing_id { get; set; }
    }
}
