namespace DbmsSims.Models.ICMS_DATA_STAGING
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("TPA_GROUP_NAMES")]
    public partial class TpaGroupNames
    {

        [Key]
        public int tpa_group_names_id { get; set; }


        public int? TPA_ID { get; set; }

        [StringLength(35)]
        public string GROUPNUM { get; set; }

        [StringLength(100)]
        public string GROUPNAME { get; set; }

        public DateTime? EFFDATE { get; set; }

        public DateTime? TERMDATE { get; set; }

        public int? ICM_EMPLOYER_ID { get; set; }

        [StringLength(100)]
        public string TPA_EMPLOYER_NAME { get; set; }

        [StringLength(35)]
        public string groupNum2 { get; set; }

        [StringLength(50)]
        public string groupNum3 { get; set; }

    }
}
