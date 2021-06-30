namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_CUSTOMER_SERVICE_ALERT")]
    public partial class MemberCustomerServiceAlert
    {
        [Key]
        public int member_customer_service_alert_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(800)]
        public string alert_text { get; set; }
    }
}
