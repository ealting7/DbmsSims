namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_LETTER_REPORT_FAX")]
    public partial class MergedLetterReportFax
    {
        [Key]
        public int merged_letter_report_fax_id { get; set; }

        public int? letter_report_fax_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(50)]
        public string letter_report_name { get; set; }

        public DateTime? fax_date { get; set; }

        public int? fax_handle { get; set; }

        public int? tpa_id { get; set; }

        public int? reinsurer_id { get; set; }

        public int? employer_id { get; set; }

        [StringLength(20)]
        public string tpa_fax_number_used { get; set; }

        [StringLength(20)]
        public string reinsurer_fax_number_used { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        [StringLength(100)]
        public string file_identifier { get; set; }

        public Guid? user_id { get; set; }

        public DateTime? creation_date { get; set; }
    }
}
