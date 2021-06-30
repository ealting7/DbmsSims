namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_REFERRALTYPE")]
    public partial class rReferralType
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(100)]
        public string label { get; set; }

        public int? listorder { get; set; }

        public byte? disabled { get; set; }

        public byte? allow_discharge { get; set; }

        [StringLength(50)]
        public string spanish_name { get; set; }

        [StringLength(1)]
        public string inpatient_outpatient_type { get; set; }
    }
}
