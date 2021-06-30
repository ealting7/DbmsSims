namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("r_MEMBER_REFERRAL_LETTERS")]
    public partial class rMemberReferralLetters
    {
        public int id { get; set; }

        public Guid member_id { get; set; }

        [Required]
        [StringLength(50)]
        public string referral_number { get; set; }

        [Required]
        [StringLength(100)]
        public string file_identifier { get; set; }

        [Column(TypeName = "image")]
        public byte[] file_blob { get; set; }

        public DateTime? letter_created { get; set; }

        public Guid? create_user_id { get; set; }
    }
}
