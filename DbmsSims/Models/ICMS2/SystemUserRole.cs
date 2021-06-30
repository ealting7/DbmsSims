namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("SYSTEM_USER_ROLE")]
    public partial class SystemUserRole
    {
        [Key]
        [Column(Order = 0)]
        public Guid system_role_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid system_user_id { get; set; }

        public DateTime date_updated { get; set; }

        public Guid? user_update { get; set; }
    }
}
