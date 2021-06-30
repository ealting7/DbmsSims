namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_REFERENCE")]
    public partial class MergedMemberReference
    {
        [Key]
        public int merged_member_reference_id { get; set; }

        public Guid? correct_member_id { get; set; }

        public Guid? incorrect_member_id { get; set; }

        public DateTime? merged_date { get; set; }

        public Guid? merged_user_id { get; set; }

        public int? merge_step { get; set; }
    }
}
