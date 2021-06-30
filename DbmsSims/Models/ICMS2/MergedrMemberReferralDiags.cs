namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_MEMBER_REFERRAL_DIAGS")]
    public partial class MergedrMemberReferralDiags
    {
        [Key]
        public int merged_r_member_referral_diags_id { get; set; }

        public int? id { get; set; }

        public Guid member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(10)]
        public string diagnosis_or_procedure_code { get; set; }

        public bool? primary_diagnosis { get; set; }

        public bool? surgical_procedure { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? lastupdate_user_id { get; set; }

        [Column(TypeName = "money")]
        public decimal? estimated_amount { get; set; }

        public byte? entered_via_web { get; set; }

        public DateTime? diagnosis_date { get; set; }

        public byte? new_diagnosis { get; set; }

        public byte? is_icd_10 { get; set; }
    }
}
