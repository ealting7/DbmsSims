namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_ADMISSION_CAREPLAN_COUNT")]
    public partial class MergedrAdmissionCareplanCount
    {
        [Key]
        public int merged_r_admission_careplan_count_id { get; set; }

        public int? r_admission_careplan_id { get; set; }

        [StringLength(50)]
        public string admission_number { get; set; }

        public Guid? member_id { get; set; }

        public int? rn_count { get; set; }

        public int? physical_therapy_count { get; set; }

        public int? occupational_therapy_count { get; set; }

        public int? language_therapy_count { get; set; }

        public int? psychology_count { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        public int? rn_12_hour_night_count { get; set; }

        public int? rn_6_hours_count { get; set; }

        public int? rn_specific_activities_count { get; set; }

        public int? nutrition_count { get; set; }

        public int? medical_visit_count { get; set; }

        public int? respiratory_therapy_count { get; set; }

        public DateTime? care_plan_start_date { get; set; }

        public DateTime? care_plan_end_date { get; set; }
    }
}
