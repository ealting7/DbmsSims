namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_TRANSITIONAL_CARE_REFERENCE")]
    public partial class MergedTransitionalCareReference
    {
        [Key]
        public int merged_transitional_care_reference_id { get; set; }

        public int? transitional_care_reference_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? member_id { get; set; }

        public DateTime? admit_date { get; set; }

        public DateTime? discharge_date { get; set; }

        public Guid? tc_nurse_system_user_id { get; set; }

        public Guid? home_pcp_id { get; set; }

        public Guid? dme_pcp_id { get; set; }

        [StringLength(25)]
        public string primary_care_giver { get; set; }

        [StringLength(100)]
        public string contact_name { get; set; }

        [StringLength(20)]
        public string contact_phone { get; set; }

        [StringLength(100)]
        public string contact_email { get; set; }

        public byte? home_care_services_requested { get; set; }

        public byte? has_rn { get; set; }

        public byte? has_pt { get; set; }

        public byte? has_st { get; set; }

        public byte? has_ot { get; set; }

        public byte? has_rt { get; set; }

        public byte? has_other { get; set; }

        [StringLength(25)]
        public string rn_requency { get; set; }

        [StringLength(25)]
        public string pt_frequency { get; set; }

        [StringLength(25)]
        public string st_frequency { get; set; }

        [StringLength(25)]
        public string ot_frequency { get; set; }

        [StringLength(25)]
        public string rt_frequency { get; set; }

        [StringLength(50)]
        public string other_frequency { get; set; }

        [Column(TypeName = "text")]
        public string note { get; set; }
    }
}
