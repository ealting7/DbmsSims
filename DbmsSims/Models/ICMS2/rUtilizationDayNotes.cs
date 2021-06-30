namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_UTILIZATION_DAYS_NOTES")] 
    public partial class rUtilizationDayNotes
    {
        [Key]
        [Column(Order = 0)]
        public Guid member_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string referral_number { get; set; }

        [Required]
        [StringLength(1)]
        public string referral_type { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int line_number { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int record_seq_num { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime record_date { get; set; }

        public Guid system_user_id { get; set; }

        [StringLength(512)]
        public string evaluation_text { get; set; }

        public bool? onletter { get; set; }

        public int? RN_notes { get; set; }

        public int? billing_id { get; set; }

        public byte? note_billed { get; set; }

        public DateTime? note_billed_marked_date { get; set; }

        public byte? benefit_disclaimer { get; set; }

        public DateTime? date_lcm_report_generated { get; set; }

        public int? lcn_case_number { get; set; }

        public int? lcm_followup_id { get; set; }

        public Guid? updated_user_id { get; set; }

        public DateTime? updated_date { get; set; }

        public DateTime? date_lcm_activity_report_generated { get; set; }

        public int? lcm_activity_followup_id { get; set; }
    }
}
