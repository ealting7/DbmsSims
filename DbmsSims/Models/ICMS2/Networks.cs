namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NETWORKS")]
    public partial class Networks
    {
        [Key]
        public int network_id { get; set; }

        [StringLength(50)]
        public string network_name { get; set; }

        public bool? disable_flag { get; set; }

        public DateTime? date_updated { get; set; }

        public Guid? user_updated { get; set; }
    }
}
