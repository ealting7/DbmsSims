namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_RELATIVE_DISEASE_HISTORY")]
    public partial class MergedMemberRelativeDiseaseHistory
    {
        [Key]
        public int merged_member_relative_disease_id { get; set; }

        public int? member_relative_disease_history_id { get; set; }

        public Guid member_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int relative_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int disease_condition_id { get; set; }

        public bool deleted_flag { get; set; }

        public Guid? user_deleted { get; set; }

        public DateTime? date_deleted { get; set; }
    }
}
