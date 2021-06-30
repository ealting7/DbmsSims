namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_LOCATIONPOS")]
    public partial class rLocationPos
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string number { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(500)]
        public string description { get; set; }
    }
}
