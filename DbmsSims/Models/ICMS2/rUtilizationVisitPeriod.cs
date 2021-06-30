namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_UTILIZATION_VISIT_PERIOD")]
    public partial class rUtilizationVisitPeriod
    {
        [Key]
        public int r_utilization_visit_period_id { get; set; }

        [StringLength(50)]
        public string label { get; set; }

        [StringLength(1)]
        public string visit_period_abbrev { get; set; }
    }
}
