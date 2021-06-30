namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MONTHLY_LCM_MANAGEMENT_QA")]
    public partial class MergedMonthlyLcmManagementQa
    {
        [Key]
        public int merged_monthly_lcm_management_qa_id { get; set; }

        public int? monthly_lcm_management_qa { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public byte? assigned { get; set; }

        public DateTime? assigned_date { get; set; }

        public Guid? assigned_to_user_id { get; set; }

        public Guid? assigned_by_user_id { get; set; }

        public byte? referral_qa { get; set; }

        public DateTime? referral_qa_date { get; set; }

        public Guid? referral_qa_user_id { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }
    }
}
