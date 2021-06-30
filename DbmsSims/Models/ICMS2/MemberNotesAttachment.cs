namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_NOTES_ATTACHMENT")]
    public partial class MemberNotesAttachment
    {
        [Key]
        [Column(Order = 0)]
        public Guid member_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime record_date { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string file_identifier { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        public bool? internal_patient { get; set; }

        public bool? care_coordination { get; set; }

        public Guid? creation_user_id { get; set; }

        public byte? entered_via_web { get; set; }
    }
}
