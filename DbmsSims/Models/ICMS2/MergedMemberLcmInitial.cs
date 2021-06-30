namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_LCM_INITIAL")]
    public partial class MergedMemberLcmInitial
    {
        [Key]
        public int merged_member_lcm_initial_id { get; set; }

        public int? lcn_case_number { get; set; }

        public Guid? member_id { get; set; }

        public DateTime lcm_open_date { get; set; }

        public DateTime? lcm_close_date { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(3)]
        public string cancer_related { get; set; }

        [StringLength(50)]
        public string staging { get; set; }

        [StringLength(50)]
        public string staging_status { get; set; }

        [StringLength(3)]
        public string hospitalized { get; set; }

        [StringLength(3)]
        public string hospital_five_days { get; set; }

        public int? facility_id { get; set; }

        [StringLength(50)]
        public string facility_type { get; set; }

        public DateTime? next_report_date { get; set; }

        public Guid? system_user_id { get; set; }

        public bool? senttoadmin { get; set; }

        public bool? senttorein { get; set; }

        public bool? report_complete { get; set; }

        public bool? um_flag { get; set; }

        public bool? cm_flag { get; set; }

        public bool? lcm_flag { get; set; }

        public bool? trigger_flag { get; set; }

        [StringLength(2)]
        public string report_type { get; set; }

        [StringLength(100)]
        public string primary_diagnosis { get; set; }

        [StringLength(100)]
        public string secondary_diagnosis { get; set; }

        [StringLength(100)]
        public string other_diagnosis { get; set; }

        [StringLength(100)]
        public string procedure { get; set; }

        [StringLength(50)]
        public string auth_number { get; set; }

        [Column("fixed")]
        public byte? _fixed { get; set; }

        [StringLength(255)]
        public string tpa_name { get; set; }

        [StringLength(50)]
        public string reinsurer_name { get; set; }

        public byte? report_billed { get; set; }

        public DateTime? report_billed_date { get; set; }

        public byte? generated_via_cm_dashboard { get; set; }
    }
}
