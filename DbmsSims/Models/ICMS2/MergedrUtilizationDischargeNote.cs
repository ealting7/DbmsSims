namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_UTILIZATION_DISCHARGE_NOTE")]
    public partial class MergedrUtilizationDischargeNote
    {
        [Key]
        public int merged_r_utilization_discharge_note_id { get; set; }

        public int? r_utilization_discharge_note_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public Guid? member_id { get; set; }

        [Column(TypeName = "text")]
        public string discharge_note { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }
    }
}
