namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_UTILIZATION_REVIEWS")]
    public partial class rUtilizationReviews
    {
        [Key]
        public int r_utilization_reviews_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public int line_number { get; set; }

        public int? review_type_items_id { get; set; }

        public int? denial_reason_id { get; set; }

        public int? util_decision_id { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? created_user_id { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? last_update_user_id { get; set; }
    }
}
