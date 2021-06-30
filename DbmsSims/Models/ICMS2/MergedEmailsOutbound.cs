namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_EMAILS_OUTBOUND")]
    public partial class MergedEmailsOutbound
    {
        [Key]
        public int merged_emails_outbound_id { get; set; }

        public int? email_outbound_id { get; set; }

        public Guid? user_id { get; set; }

        public DateTime? creation_date { get; set; }

        [StringLength(255)]
        public string email_to { get; set; }

        [StringLength(255)]
        public string email_subject { get; set; }

        [StringLength(255)]
        public string email_address { get; set; }

        [StringLength(1000)]
        public string email_message { get; set; }

        public int? email_type_id { get; set; }

        public bool? email_sent { get; set; }

        public DateTime? email_sent_date { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        [StringLength(500)]
        public string file_identifier { get; set; }

        [StringLength(15)]
        public string zip_file_password { get; set; }

        [StringLength(500)]
        public string zip_file_name { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        [StringLength(255)]
        public string email_cc_list { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(25)]
        public string notice_type { get; set; }
    }
}
