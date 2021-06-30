namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_DEPENDENT_MEMBER_UPDATE_REFERENCE")]
    public partial class MergedDependentMemberUpdateReference
    {
        [Key]
        public int merged_dependent_member_update_reference_id { get; set; }

        public int? dependent_update_reference_id { get; set; }

        public Guid? member_id { get; set; }

        public Guid? original_member_parent_id { get; set; }

        public Guid? updated_member_parent_id { get; set; }

        public int? original_relationship_id { get; set; }

        public int? updated_relationship_id { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }
    }
}
