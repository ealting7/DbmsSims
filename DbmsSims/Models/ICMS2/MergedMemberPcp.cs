namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_PCP")]
    public partial class MergedMemberPcp
    {
        [Key]
        public int merged_member_pcp_id { get; set; }

        public Guid member_id { get; set; }

        public Guid pcp_id { get; set; }

        public DateTime pcp_eff_date { get; set; }

        public DateTime? pcp_term_date { get; set; }
    }
}
