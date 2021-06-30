namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [Table("DBMS_ICMS_SIMS_USER_SEARCH")]
    public partial class DbmsIcmsSimsUserSearch 
    {
        [Key]
        public Guid user_id { get; set; }

	    public Guid member_id { get; set; }
		public int search_count { get; set; }
        public DateTime creation_date { get; set; }
        public bool current_member { get; set; }

    }

}
