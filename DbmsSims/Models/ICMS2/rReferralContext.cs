namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_REFERRALCONTEXT")]
    public partial class rReferralContext
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(50)]
        public string label { get; set; }

        public int? listorder { get; set; }

        [StringLength(50)]
        public string spanish_name { get; set; }

        public byte? allow_retro_review { get; set; }
    }
}
