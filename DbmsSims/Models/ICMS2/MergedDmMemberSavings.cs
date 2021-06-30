namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_DM_MEMBER_SAVINGS")]
    public partial class MergedDmMemberSavings
    {
        [Key]
        public int merged_dm_member_savings_id { get; set; }

        public int? dm_member_savings_id { get; set; }

        public Guid? member_id { get; set; }

        public Guid? care_plan_id { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public int? dm_member_savings_description_id { get; set; }

        [StringLength(500)]
        public string comment { get; set; }

        [Column(TypeName = "money")]
        public decimal? cost_amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? savings_amount { get; set; }

        public byte? savings_period_closed { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }
    }
}
