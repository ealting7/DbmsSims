namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNTS_RECEIVABLE_PAYMENTS")]
    public partial class AccountsReceivablePayments
    {
        [Key]
        public int accounts_receivable_payment_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string invoice_id { get; set; }

        [StringLength(10)]
        public string bill_type { get; set; }

        [Column(TypeName = "money")]
        public decimal? bill_total { get; set; }

        [StringLength(50)]
        public string check_number { get; set; }

        public DateTime? payment_date { get; set; }

        [Column(TypeName = "money")]
        public decimal? payment_amount { get; set; }

        public DateTime? credit_date { get; set; }

        [Column(TypeName = "money")]
        public decimal? credit_amount { get; set; }

        public DateTime? balance_outstanding_date { get; set; }

        [Column(TypeName = "money")]
        public decimal? balance_outstanding { get; set; }

        public Guid? payment_user_id { get; set; }

        [StringLength(1000)]
        public string comment { get; set; }

        public byte? bill_paid_off { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? um_record_id { get; set; }

        public DateTime? received_date { get; set; }

        public Guid? ccm_record_id { get; set; }

        [Column(TypeName = "money")]
        public decimal? debit_amount { get; set; }

        public DateTime? debit_date { get; set; }
    }
}
