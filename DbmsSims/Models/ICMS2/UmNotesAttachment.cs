namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UM_NOTES_ATTACHMENT")]
    public partial class UmNotesAttachment
    {
        [Key]
        [Column(Order = 0)]
        public Guid member_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string referral_number { get; set; }

        public DateTime? record_date { get; set; }

        [StringLength(100)]
        public string file_identifier { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        public byte? voicemail_attachment { get; set; }

        public Guid? creation_user_id { get; set; }
    }
}
