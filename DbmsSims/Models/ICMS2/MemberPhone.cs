namespace DbmsSims.Models.ICMS2.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_PHONE")]
    public partial class MemberPhone
    {
        [Key]
        public int member_phone_id { get; set; }

        public Guid member_id { get; set; }

        public int phone_type_id { get; set; }

        [StringLength(20)]
        public string phone_number { get; set; }

        [StringLength(500)]
        public string phone_note { get; set; }
    }
}
