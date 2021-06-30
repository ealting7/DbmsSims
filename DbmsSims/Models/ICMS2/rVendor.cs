namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_VENDOR")]
    public partial class rVendor
    {
        public int id { get; set; }

        [StringLength(10)]
        public string code { get; set; }

        [StringLength(150)]
        public string label { get; set; }

        [StringLength(16)]
        public string tax_id { get; set; }

        [StringLength(10)]
        public string npi { get; set; }

        [StringLength(3500)]
        public string vendor_notes { get; set; }

        public bool? disable_flag { get; set; }

        public DateTime? date_updated { get; set; }

        public Guid? user_updated { get; set; }

        [StringLength(9)]
        public string ihcp { get; set; }

        [StringLength(1)]
        public string location_id { get; set; }

        [StringLength(9)]
        public string billing_ihcp { get; set; }

        [StringLength(10)]
        public string billing_npi { get; set; }

        public byte? wishard_file_load { get; set; }
    }
}
