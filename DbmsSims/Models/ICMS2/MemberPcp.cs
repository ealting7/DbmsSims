namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_PCP")]
    public partial class MemberPcp
    {
        [Key]
        [Column(Order = 0)]
        public Guid member_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid pcp_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime pcp_eff_date { get; set; }

        public DateTime? pcp_term_date { get; set; }
    }
}
