namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("VENDOR_ADDRESS")]
    public partial class VendorAddress
    {
        [Key]
        public int vendor_address_id { get; set; }

        public int? id { get; set; }

        public int? address_type_id { get; set; }

        [StringLength(50)]
        public string address_line_one { get; set; }

        [StringLength(50)]
        public string address_line_two { get; set; }

        [StringLength(30)]
        public string city { get; set; }

        [StringLength(2)]
        public string state_abbrev { get; set; }

        [StringLength(18)]
        public string zip_code { get; set; }

        public int? address_county_id { get; set; }

        [StringLength(512)]
        public string address_note { get; set; }
    }
}
