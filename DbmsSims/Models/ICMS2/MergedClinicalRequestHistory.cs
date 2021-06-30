namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_CLINICAL_REQUEST_HISTORY")]
    public partial class MergedClinicalRequestHistory
    {
        [Key]
        public int merged_clinical_request_history_id { get; set; }

        public int? clinical_request_history_id { get; set; }

        public int? clinical_request_providers_id { get; set; }

        public Guid? member_id { get; set; }

        public DateTime? sent_date { get; set; }

        public Guid? sent_by_user_id { get; set; }

        [StringLength(30)]
        public string sent_to { get; set; }

        [StringLength(110)]
        public string sent_to_name { get; set; }

        public byte? mail_request { get; set; }

        [StringLength(100)]
        public string file_identifier { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }
    }
}
