namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_MEDS_HISTORY")]
    public partial class MergedMemberMedsHistory
    {
        [Key]
        public int merged_member_meds_history_id { get; set; }

        public int? member_meds_id { get; set; }

        public Guid member_id { get; set; }

        public DateTime start_date { get; set; }

        public bool rx_drug { get; set; }

        [StringLength(200)]
        public string drug_class { get; set; }

        [StringLength(100)]
        public string medication_sequence { get; set; }

        [StringLength(100)]
        public string medication_name { get; set; }

        [StringLength(100)]
        public string prescribed_by { get; set; }

        [StringLength(60)]
        public string strength { get; set; }

        [StringLength(40)]
        public string form { get; set; }

        [StringLength(20)]
        public string route { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? quantity { get; set; }

        [StringLength(20)]
        public string frequency { get; set; }

        [StringLength(50)]
        public string source_of_information { get; set; }

        [StringLength(255)]
        public string nurses_note { get; set; }

        public Guid system_user_id { get; set; }

        public bool refill { get; set; }

        public int? number_of_refills { get; set; }

        public bool deleted_flag { get; set; }

        public Guid? user_deleted { get; set; }

        public DateTime? date_deleted { get; set; }

        public DateTime? end_date { get; set; }

        [StringLength(100)]
        public string NDC { get; set; }
    }
}
