namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TELEPHONE_NOTES_ATTACHMENT")]
    public partial class TelephoneNotesAttachment
    {
        [Key]
        public Guid member_id { get; set; }

        public DateTime? record_date { get; set; }

        [StringLength(100)]
        public string file_identifier { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        public bool? internal_patient { get; set; }

        public Guid? creation_user_id { get; set; }
    }
}
