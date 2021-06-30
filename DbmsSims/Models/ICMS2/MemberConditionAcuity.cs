namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_CONDITION_ACUITY")]
    public partial class MemberConditionAcuity
    {
        [Key]
        public int member_condition_acuity_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string alternate_id { get; set; }

        public int? hypertension_first_level_acuity { get; set; }

        public int? hypertension_second_level_acuity { get; set; }

        public int? diabetes_first_level_acuity { get; set; }

        public int? diabetes_second_level_acuity { get; set; }

        public int? hchol_first_level_acuity { get; set; }

        public int? hchol_seconde_level_acuity { get; set; }

        public int? asthma_first_level_acuity { get; set; }

        public int? asthma_second_level_acuity { get; set; }

        public int? cad_first_level_acuity { get; set; }

        public int? cad_second_level_acuity { get; set; }

        public int? system_level_acuity { get; set; }

        public byte? override_acuity { get; set; }

        public int? override_level_acuity { get; set; }

        [StringLength(255)]
        public string override_reason { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }
    }
}
