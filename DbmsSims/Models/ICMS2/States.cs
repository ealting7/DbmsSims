namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STATE")]
    public partial class States
    {
        [Key]
        [StringLength(2)]
        public string state_abbrev { get; set; }

        [Required]
        [StringLength(15)]
        public string state_name { get; set; }

    }
}
