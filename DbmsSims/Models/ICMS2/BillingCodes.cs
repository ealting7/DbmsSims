namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("LCM_BILLING_CODES")] 
    public partial class BillingCodes
    {
        [Key]
        public int billing_id { get; set; }

        [StringLength(5)]
        public string billing_code { get; set; }

        [StringLength(100)]
        public string billing_description { get; set; }

        public int? billing_time_in_min { get; set; }

        public byte? standard_code { get; set; }

        public int? standard_minutes { get; set; }
    }
}
