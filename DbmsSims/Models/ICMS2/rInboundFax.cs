namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_INBOUND_FAX")]
    public partial class rInboundFax
    {
        public int id { get; set; }

        public int? fax_handle { get; set; }

        public int? fax_docfiles_handle { get; set; }

        public Guid? fax_serverguid { get; set; }

        public int? fax_boardsrv { get; set; }

        public int? fax_notifychannel { get; set; }

        public DateTime? fax_creationtime { get; set; }

        [StringLength(22)]
        public string fax_remoteid { get; set; }

        [StringLength(16)]
        public string fax_uniqueid { get; set; }

        [StringLength(14)]
        public string fax_bodyfilename { get; set; }

        public int? fax_numpages { get; set; }

        [Column(TypeName = "image")]
        public byte[] fax_image { get; set; }

        public bool? ready_flag { get; set; }

        public int? faxqueue_id { get; set; }

        public DateTime? opened_by_date { get; set; }

        public Guid? opened_by_user_id { get; set; }

        public Guid? assigned_to_user_id { get; set; }

        public DateTime? assigned_to_user_date { get; set; }

        public int? priority_level { get; set; }

        public DateTime? assigned_to_user_opened_date { get; set; }

        public DateTime? to_be_completed_date { get; set; }

        public DateTime? completed_date { get; set; }

        [StringLength(50)]
        public string queue_dummy { get; set; }

        public Guid? assigned_by_user_id { get; set; }

        public Guid? completed_by_user_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public bool deleted_flag { get; set; }

        [StringLength(100)]
        public string error_description { get; set; }

        [StringLength(255)]
        public string email_filename { get; set; }

        public int? email_faxhandle { get; set; }

        [StringLength(100)]
        public string inbound_member_name { get; set; }

        public int? fax_type_id { get; set; }

        public DateTime? fax_type_date { get; set; }

        public DateTime? fax_dos_date { get; set; }

        public DateTime? fax_dos { get; set; }
    }
}
