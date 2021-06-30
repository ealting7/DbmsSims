namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_QUALTITY_CARE_NOTES")]
    public partial class MergedrQualityCareNotes
    {
        [Key]
        public int merged_r_quality_care_notes_id { get; set; }

        public Guid member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public DateTime record_date { get; set; }

        public int? quality_care_type_id { get; set; }

        public int? qoc_reason_id { get; set; }

        public int? record_seq_num { get; set; }

        public Guid? system_user_id { get; set; }

        [StringLength(512)]
        public string evaluation_text { get; set; }
    }
}
