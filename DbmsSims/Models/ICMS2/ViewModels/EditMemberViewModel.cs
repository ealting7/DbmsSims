using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbmsSims.Models.ICMS2;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DbmsSims.Models.ICMS2
{

    public class EditMemberViewModel
    {

        [Required]
        public string MemberId { get; set; }

        [Required (ErrorMessage ="Please enter a First Name")]
        public string MemberFirstName { get; set; }

        public string MemberMiddleName { get; set; }

        [Required (ErrorMessage ="Please enter a Last Name")]
        public string MemberLastName { get; set; }

        [Required(ErrorMessage = "Please enter a Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? MemberBirth { get; set; }

        [Required (ErrorMessage = "Please enter a SSN")]
        public string MemberSsn { get; set; }       



        [Required (ErrorMessage = "Please select an Employer")]
        public int? EmployerId { get; set; }

        public string EmployerName { get; set; }



        public string Gender { get; set; }



        [Required(ErrorMessage = "Please enter a Member ID")]
        public string ClaimsId { get; set; }
        public string MedicareNumber { get; set; }
        public string MedicaidNumber { get; set; }




        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string StateAbbrev { get; set; }
        public string state_abbrev { get; set; }
        public string ZipCode { get; set; }        




        public string DayPhone { get; set; }
        public string EveningPhone { get; set; }      




        public virtual List<EditMemberViewModel> MemberSearchResultList { get; set; } = new List<EditMemberViewModel>();


        [DisplayName("Employers")]
        public virtual List<Employer> EmployersInDbms { get; set; } = new List<Employer>();


        [DisplayName("State")]
        public virtual List<States> StatesInUsa { get; set; } = new List<States>();

    }

}