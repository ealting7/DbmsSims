namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_EPISODES_OF_CARE")]
    public partial class MergedEpisodesOfCare
    {
        [Key]
        public int merged_episodes_of_care_id { get; set; }

        public int? episode_of_care_id { get; set; }

        public Guid? member_id { get; set; }

        public Guid? care_plan_id { get; set; }

        public int? tool_id { get; set; }

        public Guid? tool_instance_id { get; set; }

        [StringLength(255)]
        public string hospital_treatment_dates { get; set; }

        [StringLength(255)]
        public string er_treatment_dates { get; set; }

        [StringLength(255)]
        public string urgent_care_treatement_dates { get; set; }

        [StringLength(255)]
        public string pcp_treatment_dates { get; set; }

        [StringLength(255)]
        public string smoking_cessation_methods { get; set; }

        [StringLength(255)]
        public string smoking_cessation_dates { get; set; }

        [StringLength(10)]
        public string urine_micro_results { get; set; }

        [StringLength(10)]
        public string cholesterol_results { get; set; }

        [StringLength(10)]
        public string ldl_results { get; set; }

        [StringLength(10)]
        public string hdl_results { get; set; }

        [StringLength(10)]
        public string triglyceride_results { get; set; }

        [StringLength(10)]
        public string blood_pressure_results { get; set; }

        [StringLength(10)]
        public string flu_vaccine_results { get; set; }

        [StringLength(10)]
        public string pneumonia_vaccine_results { get; set; }

        [StringLength(10)]
        public string a1c_test_results { get; set; }

        public DateTime? a1c_test_date_last_done { get; set; }

        public DateTime? foot_check_date_last_done { get; set; }

        public DateTime? dialated_eye_date_last_done { get; set; }

        public DateTime? urine_micro_date_last_done { get; set; }

        public DateTime? cholesterol_date_last_done { get; set; }

        public DateTime? ldl_date_last_done { get; set; }

        public DateTime? blood_pressure_date_last_done { get; set; }

        public DateTime? hdl_date_last_done { get; set; }

        public DateTime? triglyceride_date_last_done { get; set; }

        public DateTime? flu_vaccine_date_last_done { get; set; }

        public DateTime? pneumonia_vaccine_date_last_done { get; set; }

        public DateTime? diabetic_education_date_last_done { get; set; }

        public byte? received_diabetic_education_material { get; set; }

        public byte? episode_complete { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_userid { get; set; }

        public DateTime? blood_verified_date { get; set; }

        public DateTime? cholesterol_verified_date { get; set; }

        public DateTime? dilated_eye_exam_verified_date { get; set; }

        public DateTime? er_visits_verified_date { get; set; }

        public DateTime? flu_vaccine_verified_date { get; set; }

        public DateTime? foot_exam_verified_date { get; set; }

        public DateTime? hdl_verified_date { get; set; }

        public DateTime? hgb_a1c_verified_date { get; set; }

        public DateTime? hospitalization_visits_verified_date { get; set; }

        public DateTime? ldl_verified_date { get; set; }

        public DateTime? pcp_verified_date { get; set; }

        public DateTime? pneumonia_vaccine_verified_date { get; set; }

        public DateTime? smoking_cessation_verified_date { get; set; }

        public DateTime? trig_verified_date { get; set; }

        public DateTime? urgent_care_visits_verified_date { get; set; }

        public DateTime? urine_micro_verified_date { get; set; }
    }
}
