namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_LAB")]
    public partial class MemberLab
    {
        [Key]
        public int member_lab_id { get; set; }

        public Guid member_id { get; set; }

        public int lab_type_id { get; set; }

        public int lab_type_measurement_id { get; set; }

        public DateTime lab_date { get; set; }

        [StringLength(75)]
        public string reading { get; set; }

        public bool deleted_flag { get; set; }

        public Guid? user_deleted { get; set; }

        public DateTime? date_deleted { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        [StringLength(255)]
        public string lab_note { get; set; }
    }
}
