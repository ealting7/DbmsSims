namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CODE_REMOVAL_ITEMS")]
    public partial class CodeRemovalItems
    {
        [Key]
        public int code_removal_item_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(20)]
        public string removal_type { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        public int? lcm_activity_followup_id { get; set; }

        [StringLength(100)]
        public string primary_diagnosis { get; set; }

        [StringLength(100)]
        public string secondary_diagnosis { get; set; }

        [StringLength(100)]
        public string other_diagnosis { get; set; }

        [StringLength(100)]
        public string procedure { get; set; }

        [StringLength(10)]
        public string hcpcs_code { get; set; }

        public double? quantity { get; set; }

        [StringLength(10)]
        public string diagnosis_or_procedure_code { get; set; }

        public bool? is_primary_diagnosis { get; set; }

        public bool? surgical_procedure { get; set; }

        [StringLength(10)]
        public string cpt_code { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        public int? code_removal_reasons_id { get; set; }

        public byte? is_icd_10 { get; set; }
    }
}
