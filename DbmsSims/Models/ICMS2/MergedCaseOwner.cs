namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_CASE_OWNER")]
    public partial class MergedCaseOwner
    {
        [Key]
        public int merged_case_owner_id { get; set; }

        public Guid system_user_id { get; set; }

        public Guid member_id { get; set; }

        public DateTime assigned_date { get; set; }

        [StringLength(3)]
        public string case_type_code { get; set; }

        public Guid? transfer_to { get; set; }

        public DateTime? transfer_date { get; set; }

        public DateTime? discharge_date { get; set; }
    }
}
