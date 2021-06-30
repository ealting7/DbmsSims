namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("PROVIDER_ADDRESS")]
    public partial class ProviderAddress
    {
        [Key]
        public int provider_address_id { get; set; }

        public Guid? pcp_id { get; set; }

        [StringLength(50)]
        public string address_line1 { get; set; }

        [StringLength(50)]
        public string address_line2 { get; set; }

        [StringLength(32)]
        public string city { get; set; }

        [StringLength(2)]
        public string state_abbrev { get; set; }

        [StringLength(18)]
        public string zip_code { get; set; }

        [StringLength(500)]
        public string address_note { get; set; }

        public int? address_county_id { get; set; }

        public int? address_type_id { get; set; }
    }
}
