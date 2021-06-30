namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_PROFILE_PICTURE")]
    public partial class MemberProfilePicture
    {
        [Key]
        public int member_profile_picture_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(255)]
        public string picture_file_name { get; set; }

        [StringLength(10)]
        public string content_type { get; set; }

        public byte? sims_profile_picture { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        public DateTime? last_update_date { get; set; }
    }
}
