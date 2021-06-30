namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_NOTES_SUMMARY")]
    public partial class MergedMemberNotesSummary
    {
        [Key]
        public int merged_member_notes_summary_id { get; set; }

        public int? member_notes_summary_id { get; set; }

        public Guid? member_id { get; set; }

        public DateTime? record_date { get; set; }

        [Column(TypeName = "text")]
        public string evaluation_text { get; set; }

        public bool? month_closed { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_system_user_id { get; set; }
    }
}
