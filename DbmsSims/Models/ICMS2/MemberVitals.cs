namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("MEMBER_VITALS")]
    public partial class MemberVitals
    {
        [Key]
        public int member_vitals_id { get; set; }

        public Guid member_id { get; set; }

        public DateTime date_measured { get; set; }

        public int? seated_blood_pressure_systolic { get; set; }

        public int? seated_blood_pressure_diastolic { get; set; }

        public int? standing_blood_pressure_systolic { get; set; }

        public int? standing_blood_pressure_diastolic { get; set; }

        public int? pulse_per_minute { get; set; }

        public bool pulse_is_regular { get; set; }

        public int? respiration_per_minute { get; set; }

        public bool respiration_is_regular { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? height_in_inches { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? weight_in_pounds { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? temperature_in_fahrenheit { get; set; }

        public bool deleted_flag { get; set; }

        public Guid? user_deleted { get; set; }

        public DateTime? date_deleted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bmi { get; set; }

        public bool physician_reported_flag { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? body_fat_percent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? waist_girth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? hip_girth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? waist_hip_ratio { get; set; }

        [StringLength(25)]
        public string bp_method { get; set; }

        [StringLength(25)]
        public string sp02 { get; set; }

        [StringLength(25)]
        public string heart_rate { get; set; }

        public byte? heart_is_regular { get; set; }

        [StringLength(50)]
        public string richmond_rass_scale { get; set; }

        [StringLength(50)]
        public string ramsay_scale { get; set; }

        [StringLength(50)]
        public string neuro_scale { get; set; }

        public int? r_member_admission_id { get; set; }

        public Guid? web_user_id { get; set; }

        public int? glasgow_motor_response { get; set; }

        public int? glasgow_verbal_response { get; set; }

        public int? glasgow_eye_opening { get; set; }

        [StringLength(5)]
        public string visual_scale { get; set; }

        [StringLength(25)]
        public string cof { get; set; }

        [StringLength(10)]
        public string height_type { get; set; }

        [StringLength(10)]
        public string weight_type { get; set; }

        [StringLength(10)]
        public string temperature_type { get; set; }

        [StringLength(8000)]
        public string note { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }
    }
}
