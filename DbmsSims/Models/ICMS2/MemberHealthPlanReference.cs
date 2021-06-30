namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_HEALTH_PLAN_REFERENCE")]
    public partial class MemberHealthPlanReference
    {
        [Key]
        public Guid member_id { get; set; }

        public byte? wishard_health_plan { get; set; }

        public byte? commercial { get; set; }

        public byte? mdwise_hhw { get; set; }

        public byte? mdwise_hip { get; set; }

        public byte? wishard_advantage { get; set; }

        [StringLength(10)]
        public string mco_id_number { get; set; }

        [StringLength(1)]
        public string mco_region_id { get; set; }

        [StringLength(12)]
        public string recipient_id_number { get; set; }

        [StringLength(10)]
        public string primary_medical_provider_number { get; set; }

        [StringLength(10)]
        public string pmp_group_number { get; set; }

        public DateTime? pmp_start_date { get; set; }

        public DateTime? pmp_end_date { get; set; }

        [StringLength(2)]
        public string capitation_category { get; set; }

        [StringLength(2)]
        public string medicaid_eligibility { get; set; }

        [StringLength(10)]
        public string case_number { get; set; }

        [StringLength(6)]
        public string case_worker_number { get; set; }

        [StringLength(1)]
        public string location_code { get; set; }

        [StringLength(2)]
        public string delivery_system { get; set; }

        [StringLength(1)]
        public string auto_assigned_indicator { get; set; }

        [StringLength(1)]
        public string benefit_package_indicator { get; set; }

        public DateTime? benefit_package_date { get; set; }

        public DateTime? first_steps_start_date { get; set; }

        public DateTime? first_steps_end_date { get; set; }

        public Guid? created_user_id { get; set; }

        public DateTime? creation_date { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? update_user_id { get; set; }

        [StringLength(50)]
        public string mrn { get; set; }

        public DateTime? hip_start_date { get; set; }

        public DateTime? hip_end_date { get; set; }

        public byte? right_choice { get; set; }

        [StringLength(50)]
        public string alternate_id { get; set; }

        [StringLength(50)]
        public string network { get; set; }

        [StringLength(50)]
        public string enterprise { get; set; }

        [StringLength(4)]
        public string plan_id { get; set; }

        [StringLength(30)]
        public string plan_description { get; set; }

        public DateTime? pre_existing_eff_date { get; set; }

        public DateTime? pre_existing_term_date { get; set; }

        public byte? cobra { get; set; }

        public byte? is_sands_shpg { get; set; }

        public int? patient_acuity { get; set; }

        public int? patient_status { get; set; }

        [StringLength(50)]
        public string tpa_name { get; set; }

        [StringLength(15)]
        public string cm_program { get; set; }

        [StringLength(25)]
        public string group_id { get; set; }

        [StringLength(10)]
        public string group_location { get; set; }

        public int? primary_number { get; set; }

        public int? secondary_number { get; set; }

        public int? entry_id { get; set; }

        public Guid? user_entry_id { get; set; }

        [StringLength(25)]
        public string id_number { get; set; }
    }
}
