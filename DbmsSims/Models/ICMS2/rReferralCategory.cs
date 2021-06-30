namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_REFERRALCATEGORY")]
    public partial class rReferralCategory
    {
        [Key]
        public int referral_category { get; set; }

        [StringLength(20)]
        public string code { get; set; }

        [StringLength(50)]
        public string label { get; set; }

        [StringLength(50)]
        public string spanish_name { get; set; }
    }
}
