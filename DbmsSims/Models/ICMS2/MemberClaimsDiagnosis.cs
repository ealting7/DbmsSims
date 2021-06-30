namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_CLAIMS_DIAGNOSIS")]
    public partial class MemberClaimsDiagnosis
    {
        [Key]
        public int member_claims_diagnosis_id { get; set; }

        public Guid member_id { get; set; }

        public int? claims_system_id { get; set; }

        [Required]
        [StringLength(10)]
        public string diagnosis_or_procedure_code { get; set; }

        public bool primary_diagnosis { get; set; }

        public bool surgical_procedure { get; set; }

        public bool deleted_flag { get; set; }

        public Guid? user_deleted { get; set; }

        public DateTime? date_deleted { get; set; }
    }
}
