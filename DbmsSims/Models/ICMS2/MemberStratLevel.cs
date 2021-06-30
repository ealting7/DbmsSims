namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_STRAT_LEVEL")]
    public partial class MemberStratLevel
    {
        [Key]
        public int member_strat_level_id { get; set; }

        public Guid member_id { get; set; }

        public Guid tool_instance_id { get; set; }

        public int tool_id { get; set; }

        public int calcstrat_level_id { get; set; }

        public DateTime calc_date { get; set; }

        public int? overridestrat_level_id { get; set; }

        public DateTime? override_date { get; set; }

        public Guid? override_system_user_id { get; set; }

        [StringLength(255)]
        public string override_reason { get; set; }

        public int? master_override_acuity_level_id { get; set; }
    }
}
