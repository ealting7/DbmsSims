namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MERGED_r_MEMBER_REFERRAL_LETTERS")]
    public partial class MergedrMemberReferralLetters
    {
        [Key]
        public int merged_r_member_referral_letters_id { get; set; }

        public int? id { get; set; }

        public Guid member_id { get; set; }

        [StringLength(50)]
        public string referral_number { get; set; }

        [StringLength(100)]
        public string file_identifier { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        public DateTime? letter_created { get; set; }

        public Guid? create_user_id { get; set; }
    }
}
