namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_UTILIZATION_SAVINGS")]
    public partial class rUtilizationSavings
    {
        [Key]
        public Guid utilization_savings_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(1)]
        public string referral_type { get; set; }

        public int? line_number { get; set; }

        public int? savings_line { get; set; }

        [StringLength(100)]
        public string item_description { get; set; }

        public int? saving_units_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cost { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? negotiated { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? savings { get; set; }

        [StringLength(1)]
        public string dollar_or_percent { get; set; }

        public bool? line_item { get; set; }

        [StringLength(10)]
        public string cpt_code { get; set; }

        public int? network_id { get; set; }

        [StringLength(512)]
        public string notes { get; set; }

        public Guid? system_user_id { get; set; }

        public DateTime? date_updated { get; set; }

        public bool? delete_flag { get; set; }
    }
}
