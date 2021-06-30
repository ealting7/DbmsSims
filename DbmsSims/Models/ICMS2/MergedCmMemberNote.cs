namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_CM_MEMBER_NOTE")]
    public partial class MergedCmMemberNote
    {
        [Key]
        public int merged_cm_member_note_id { get; set; }

        public Guid member_id { get; set; }

        public DateTime? record_date { get; set; }

        [Column(TypeName = "text")]
        public string evaluation_text { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }
    }
}
