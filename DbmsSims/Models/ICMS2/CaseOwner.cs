namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CASE_OWNER")]
    public partial class CaseOwner
    {
        [Key]
        [Column(Order = 0)]
        public Guid system_user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid member_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime assigned_date { get; set; }

        [StringLength(3)]
        public string case_type_code { get; set; }

        public Guid? transfer_to { get; set; }

        public DateTime? transfer_date { get; set; }

        public DateTime? discharge_date { get; set; }
    }
}
