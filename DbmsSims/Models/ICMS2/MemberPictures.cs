namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_PICTURES")]
    public partial class MemberPictures
    {
        [Key]
        public Guid member_id { get; set; }

        [StringLength(250)]
        public string image_path { get; set; }
    }
}
