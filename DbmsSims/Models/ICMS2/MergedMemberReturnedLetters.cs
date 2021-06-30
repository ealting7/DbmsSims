namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_MEMBER_RETURNED_LETTERS")]
    public partial class MergedMemberReturnedLetters
    {
        [Key]
        public int merged_member_returned_letters_id { get; set; }

        public int? member_returned_letters_id { get; set; }

        public Guid? member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        public DateTime? note_record_date { get; set; }

        [StringLength(15)]
        public string note_type { get; set; }

        public int? r_member_referral_letters_id { get; set; }

        public DateTime? returned_letter_date { get; set; }

        public DateTime? creation_date { get; set; }

        public Guid? creation_user_id { get; set; }

        public DateTime? no_response_date { get; set; }

        public Guid? no_response_update_user_id { get; set; }

        public DateTime? no_response_update_date { get; set; }

        public DateTime? last_contact_date { get; set; }

        public Guid? last_contact_update_user_id { get; set; }

        public DateTime? last_contact_update_date { get; set; }
    }
}
