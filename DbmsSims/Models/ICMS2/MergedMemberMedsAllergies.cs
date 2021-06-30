namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_MEDS_ALLERGIES")]
    public partial class MergedMemberMedsAllergies
    {
        [Key]
        public int merged_member_meds_allergies_id { get; set; }

        public int? member_meds_allergies_id { get; set; }

        public Guid member_id { get; set; }

        [StringLength(255)]
        public string descr { get; set; }

        public bool deleted_flag { get; set; }

        public Guid? user_deleted { get; set; }

        public DateTime? date_deleted { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public byte? added_via_portal { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }

        public byte? updated_via_portal { get; set; }
    }
}
