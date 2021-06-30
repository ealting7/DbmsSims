namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TPA_EMPLOYER")]
    public partial class TpaEmployer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employer_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tpa_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime effective_date { get; set; }

        public DateTime? termination_date { get; set; }

        public bool? disabled { get; set; }
    }
}
