using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class AddMemberViewModel
    {

        public string MemberId { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        [StringLength(50, ErrorMessage = "Please limit the First Name to 50 characters")]
        public string MemberFirstName { get; set; }

        [StringLength(50, ErrorMessage = "Please limit the Middle Name to 50 characters")]
        public string MemberMiddleName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [StringLength(50, ErrorMessage = "Please limit the Last Name to 50 characters")]
        public string MemberLastName { get; set; }

        [Required(ErrorMessage = "Please enter a Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a date value for the Date of Birth")]
        public DateTime? MemberBirth { get; set; }

        [Required(ErrorMessage = "Please enter a SSN")]
        [StringLength(50, ErrorMessage = "Please enter a 9 digit SSN (no dashes)")]
        public string MemberSsn { get; set; }



        [Required(ErrorMessage = "Please select an Employer")]
        public int? EmployerId { get; set; }

        public string EmployerName { get; set; }

        public int ClientId { get; set; }
        public int ClientBuId { get; set; }
        public int ClaimsSystemId { get; set; }

        [Required(ErrorMessage = "Please enter a Member ID")]
        public string ClaimsId {get; set;}

        public string ClaimsEnrollmentId { get; set; }
        public string Relationship { get; set; }



        public string Gender { get; set; }


        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public int? DisenrollReasonId { get; set; }



        public string MedicareNumber { get; set; }
        public string MedicaidNumber { get; set; }
        public string Netork { get; set; }
        public byte? MedicarePrimary { get; set; }
        public DateTime? MedicareEffDate { get; set; }




        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string StateAbbrev { get; set; }
        public string ZipCode { get; set; }




        [StringLength(20, ErrorMessage = "The Day Phone number cannot exceed 20 characters")]
        public string DayPhone { get; set; }
        [StringLength(20, ErrorMessage = "The Evening Phone number cannot exceed 20 characters")]
        public string EveningPhone { get; set; }


        public string SystemUserId { get; set; }



        [DisplayName("Employers")]
        public virtual List<Employer> EmployersInDbms { get; set; } = new List<Employer>();


        [DisplayName("State")]
        public virtual List<States> StatesInUsa { get; set; } = new List<States>();
    }
}