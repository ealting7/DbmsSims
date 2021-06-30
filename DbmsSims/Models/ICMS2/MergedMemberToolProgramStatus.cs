namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_TOOL_PROGRAM_STATUS")]
    public partial class MergedMemberToolProgramStatus
    {
        [Key]
        public int merged_member_tool_program_stats_id { get; set; }

        public Guid? member_id { get; set; }

        public int? tool_id { get; set; }

        public bool? active_flag { get; set; }

        public Guid? user_updated { get; set; }

        public DateTime? date_updated { get; set; }

        public DateTime? effective_date { get; set; }

        public DateTime? program_effective_date { get; set; }

        public DateTime? program_disenroll_date { get; set; }

        public int? disenroll_reason_id { get; set; }

        public int? member_tool_program_inactive_reason_id { get; set; }
    }
}
