namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_UTILIZATION_DAYS_DECISION")]
    public partial class rUtilizationDaysDecision
    {
        [Key]
        public int util_decision_id { get; set; }

        [StringLength(10)]
        public string code { get; set; }

        [StringLength(50)]
        public string label { get; set; }

        public int? listorder { get; set; }
    }
}
