namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_PHONE")]
    public partial class MergedMemberPhone
    {
        [Key]
        public int merged_member_phone_id { get; set; }

        public int? member_phone_id { get; set; }

        public Guid member_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int phone_type_id { get; set; }

        [StringLength(20)]
        public string phone_number { get; set; }

        [StringLength(500)]
        public string phone_note { get; set; }
    }
}
