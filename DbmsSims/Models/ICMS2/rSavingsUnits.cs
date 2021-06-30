namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_SAVINGS_UNITS")]
    public partial class rSavingsUnits
    {
        [Key]
        public int saving_units_id { get; set; }

        [StringLength(10)]
        public string units_code { get; set; }

        [StringLength(50)]
        public string units_label { get; set; }
    }
}
