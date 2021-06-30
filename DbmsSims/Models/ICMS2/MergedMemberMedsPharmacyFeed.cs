namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_MEDS_PHARMACY_FEED")]
    public partial class MergedMemberMedsPharmacyFeed
    {
        [Key]
        public int merged_member_meds_pharmacy_feed_id { get; set; }

        public int? member_meds_pharmacy_feed_id { get; set; }

        public Guid member_id { get; set; }

        public DateTime filled_date { get; set; }

        [StringLength(100)]
        public string medication_name { get; set; }

        [StringLength(100)]
        public string prescribed_by { get; set; }

        [StringLength(50)]
        public string quantity { get; set; }

        public bool refill { get; set; }

        public int? current_refill_counter { get; set; }

        public int? max_refills_authorized { get; set; }

        [StringLength(20)]
        public string ndc { get; set; }

        [StringLength(50)]
        public string drug_type { get; set; }

        [Column(TypeName = "money")]
        public decimal? amount_billed { get; set; }

        [StringLength(18)]
        public string relationship_code { get; set; }

        [StringLength(15)]
        public string group_number { get; set; }

        public DateTime? prescription_date_written { get; set; }

        [StringLength(100)]
        public string dispense_as_written { get; set; }

        [StringLength(50)]
        public string member_location { get; set; }

        [StringLength(25)]
        public string unit_dose_indicator { get; set; }

        [StringLength(50)]
        public string drug_supply_days { get; set; }

        [Column(TypeName = "money")]
        public decimal? ingredient_cost { get; set; }

        [Column(TypeName = "money")]
        public decimal? co_pay_amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? postage_amount_claimed { get; set; }

        [Column(TypeName = "money")]
        public decimal? other_payor_amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? dispensing_fee_submitted { get; set; }

        [StringLength(40)]
        public string drug_class { get; set; }

        public bool? is_wishard { get; set; }

        [StringLength(50)]
        public string wishard_claim_id { get; set; }

        public DateTime? date_updated { get; set; }
    }
}
