namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_ADMISSION")]
    public partial class MergedAdmission
    {
        [Key]
        public int merged_admission_id { get; set; }

        public Guid admission_id { get; set; }

        public Guid member_id { get; set; }

        public DateTime admission_start { get; set; }

        public DateTime? admission_discharge { get; set; }

        public Guid? checked_out_by { get; set; }
    }
}
