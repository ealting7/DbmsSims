namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_ENROLLMENT")]
    public partial class MemberEnrollment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int claims_system_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int member_enrollment_id { get; set; }

        public Guid member_id { get; set; }

        [Required]
        [StringLength(70)]
        public string claims_id { get; set; }

        public DateTime member_effective_date { get; set; }

        public int client_id { get; set; }

        public int client_bu_id { get; set; }

        public DateTime? member_disenroll_date { get; set; }

        public int? disenroll_reason_id { get; set; }

        [StringLength(3)]
        public string member_type_code { get; set; }

        public bool manual_entry_flag { get; set; }

        public Guid? user_updated { get; set; }

        public DateTime? date_updated { get; set; }

        [StringLength(50)]
        public string claims_enrollment_id { get; set; }

        public int? employer_id { get; set; }

        public int? employer_division_id { get; set; }

        [StringLength(2)]
        public string DEP_Number { get; set; }

        public int? JUST_ADDED { get; set; }

        public int? hospital_id { get; set; }

        public int? old_employer_id { get; set; }

        public int? eps_id { get; set; }

        [StringLength(50)]
        public string columbia_employer_name { get; set; }

        [StringLength(50)]
        public string egp_member_id { get; set; }





        public MemberEnrollment()
        {

            this.claims_system_id = 0;            
            this.member_id = new Guid("{00000000-0000-0000-0000-000000000000}");
            this.claims_id = "";
            this.member_effective_date = DateTime.Now;
            this.client_id = 0;
            this.client_bu_id = 0;

        }



    }
}
