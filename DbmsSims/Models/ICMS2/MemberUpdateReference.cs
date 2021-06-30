namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER_UPDATE_REFERENCE")]
    public partial class MemberUpdateReference
    {
        [Key]
        public int member_update_reference_id { get; set; }

        public Guid? member_id { get; set; }

        public int? original_employer_id { get; set; }

        public int? original_client_id { get; set; }

        public int? original_client_bu_id { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }
    }
}
