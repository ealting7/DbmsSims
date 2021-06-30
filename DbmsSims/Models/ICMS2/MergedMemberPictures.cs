namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_PICTURES")]
    public partial class MergedMemberPictures
    {
        [Key]
        public int merged_member_pictures_id { get; set; }

        public Guid member_id { get; set; }

        [StringLength(250)]
        public string image_path { get; set; }
    }
}
