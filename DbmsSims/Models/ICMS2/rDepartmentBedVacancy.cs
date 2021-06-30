namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_DEPARTMENT_BED_VACANCY")]
    public partial class rDepartmentBedVacancy
    {
        [Key]
        public int r_department_bed_vacancy_id { get; set; }

        public int? tpa_id { get; set; }

        public int? transfer_department_id { get; set; }

        [StringLength(50)]
        public string admission_number { get; set; }

        [StringLength(15)]
        public string room_number { get; set; }

        public Guid? member_id { get; set; }

        public DateTime? admit_date { get; set; }

        public Guid? admit_user_id { get; set; }

        public DateTime? discharge_date { get; set; }

        public Guid? discharge_user_id { get; set; }

        public byte? completed { get; set; }

        public DateTime? completed_date { get; set; }

        public Guid? completed_user_id { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public byte? bed_changed { get; set; }

        public DateTime? bed_changed_date { get; set; }

        public Guid? bed_changed_user_id { get; set; }

        public int? r_member_admission_transfer_id { get; set; }

        public byte? currently_in_room { get; set; }
    }
}
