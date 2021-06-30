namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_MEMBER_REFERRAL_MEDICINE")]
    public partial class MergedrMemberReferralMedicine
    {
        [Key]
        public int merged_r_member_referral_medicine_id { get; set; }

        public int? id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(10)]
        public string medicine_code { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        public int? unit { get; set; }

        [StringLength(25)]
        public string modifier1 { get; set; }

        public int? decision_id { get; set; }

        [Column(TypeName = "money")]
        public decimal? estimated_amount { get; set; }

        public int? system_role_r_service_category_types_id { get; set; }

        public int? line_number { get; set; }

        public byte? entered_via_web { get; set; }
    }
}
