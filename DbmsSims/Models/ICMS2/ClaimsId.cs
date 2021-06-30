namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLAIMS_ID")]
    public partial class ClaimsId
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int claims_system_id { get; set; }

        [Key]
        [Column("claims_id", Order = 1)]
        [StringLength(70)]
        public string claims_id1 { get; set; }

        public DateTime original_effective_date { get; set; }

        public DateTime? final_term_date { get; set; }
    }
}
