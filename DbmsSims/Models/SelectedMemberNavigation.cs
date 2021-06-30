using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbmsSims.Models
{
    public class SelectedMemberNavigation
    {

        public string CurrentlySelectedMemberId { get; set; }
        public bool MemberSelected { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string DateOfBirth { get; set; }

        public string DayPhone { get; set; }

    }
}