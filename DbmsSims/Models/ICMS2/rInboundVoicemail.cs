namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_INBOUND_VOICEMAIL")]
    public partial class rInboundVoicemail
    {
        public int id { get; set; }

        public DateTime? vm_creationtime { get; set; }

        [StringLength(100)]
        public string vm_filename { get; set; }

        [Column(TypeName = "image")]
        public byte[] vm_image { get; set; }

        public int? vm_handle { get; set; }

        public int? priority_level { get; set; }

        public int? vmqueue_id { get; set; }

        [StringLength(50)]
        public string vm_remoteid { get; set; }

        public byte? ready_flag { get; set; }

        public DateTime? opened_by_date { get; set; }

        public Guid? opened_by_user_id { get; set; }

        public Guid? assigned_to_user_id { get; set; }

        public DateTime? assigned_to_user_date { get; set; }

        public DateTime? to_be_completed_date { get; set; }

        public DateTime? completed_date { get; set; }

        [StringLength(50)]
        public string queue_dummy { get; set; }

        public Guid? assigned_by_user_id { get; set; }

        public Guid? completed_by_user_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(100)]
        public string inbound_member_name { get; set; }

        public byte? deleted_flag { get; set; }

        [StringLength(100)]
        public string vm_subject { get; set; }

        public DateTime? assigned_to_user_opened_date { get; set; }

        [StringLength(50)]
        public string content_type { get; set; }

        public byte? test_file { get; set; }

        public byte? need_conversion { get; set; }

        public int? fax_type_id { get; set; }

        public DateTime? fax_type_date { get; set; }

        public DateTime? fax_dos_date { get; set; }

        public DateTime? fax_dos { get; set; }
    }
}
