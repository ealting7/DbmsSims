namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_SIGNATURE_FILE")]
    public partial class MergedMemberSignatureFiles
    {
        [Key]
        public int merged_member_signature_file_id { get; set; }

        public int? member_signature_download_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(255)]
        public string file_name { get; set; }

        [Column(TypeName = "image")]
        public byte[] signature_file { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        [StringLength(10)]
        public string content_type { get; set; }
    }
}
