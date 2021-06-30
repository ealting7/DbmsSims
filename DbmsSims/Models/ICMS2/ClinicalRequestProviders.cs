namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLINICAL_REQUEST_PROVIDERS")]
    public partial class ClinicalRequestProviders
    {
        [Key]
        public int clinical_request_providers_id { get; set; }

        public Guid? member_id { get; set; }

        public Guid? system_role_id { get; set; }

        public Guid? pcp_id { get; set; }

        public int? department_id { get; set; }

        public int? phone_id { get; set; }

        [StringLength(110)]
        public string name { get; set; }

        public byte? use_manual_number { get; set; }

        [StringLength(25)]
        public string fax_number { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(2)]
        public string state { get; set; }

        [StringLength(25)]
        public string zip { get; set; }

        public byte? disabled { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }
    }
}
