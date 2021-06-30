namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_LCN_REPORT_FAX")]
    public partial class MergedLcnReportFax
    {
        [Key]
        public int merged_lcn_report_fax_id { get; set; }

        public int? lcn_report_fax_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        [StringLength(100)]
        public string file_identifier { get; set; }

        public Guid? user_id { get; set; }

        public DateTime? creation_date { get; set; }

        public int? tpa_id { get; set; }

        public int? reinsurer_id { get; set; }

        [StringLength(20)]
        public string tpa_fax_number_used { get; set; }

        [StringLength(20)]
        public string reinsurer_fax_number_used { get; set; }

        public int? fax_handle { get; set; }

        public int? lcm_activity_followup_id { get; set; }
    }
}
