namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_DENTAL_VISITS")]
    public partial class rDentalVisits
    {
        [Key]
        public int r_dental_visits_id { get; set; }

        public Guid? member_id { get; set; }

        public DateTime? visit_date { get; set; }

        [StringLength(50)]
        public string oral_health_provider { get; set; }

        public int? r_dental_specialty_id { get; set; }

        [StringLength(100)]
        public string provider_address { get; set; }

        [StringLength(25)]
        public string provider_phone { get; set; }

        [StringLength(500)]
        public string oral_note { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        public byte? disabled { get; set; }
    }
}
