namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENT_BU")]
    public partial class ClientBu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int claims_system_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int client_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public int client_bu_id { get; set; }

        [Required]
        [StringLength(50)]
        public string descr { get; set; }

        public bool disable_flag { get; set; }

        public Guid? user_updated { get; set; }

        public DateTime? date_updated { get; set; }
    }
}
