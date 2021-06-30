using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS_DATA_STAGING;

namespace DbmsSims.Models.Downloads.ViewModels
{
    public class EligibilityViewModel
    {

        public string Type { get; set; }

        public string MemId { get; set; }
        public string MemFirstName { get; set; }
        public string MemLastName { get; set; }
        public string MemMiddleName { get; set; }
        public string MemAddressLine1 { get; set; }
        public string MemAddressLine2 { get; set; }
        public string MemCity { get; set; }
        public string MemState { get; set; }
        public string MemZipCode { get; set; }
        public string MemGender { get; set; }
        public string MemDob { get; set; }
        public string MemEffDate { get; set; }
        public string MemTermDate { get; set; }
        public string MemSsn { get; set; }
        public string MemInsNumber { get; set; }
        public string MemPhoneNumber { get; set; }
        public string MemMedicarePrim { get; set; }

        public string DepFirstName { get; set; }
        public string DepLastName { get; set; }
        public string DepMiddleName { get; set; }
        public string DepAddressLine1 { get; set; }
        public string DepAddressLine2 { get; set; }
        public string DepCity { get; set; }
        public string DepState { get; set; }
        public string DepZipCode { get; set; }
        public string DepGender { get; set; }
        public string DepDob { get; set; }
        public string DepEffDate { get; set; }
        public string DepTermDate { get; set; }
        public string DepSsn { get; set; }
        public string DepInsNumber { get; set; }
        public string DepPhoneNumber { get; set; }


        public string Relationship { get; set; }
        public string Network { get; set; }
        public string MedicareEffDate { get; set; }

        public int? EmployerId { get; set; }

        public string SystemUserId { get; set; }



        public bool MultipleMembersInSystem { get; set; }
        public bool MemberUpdated { get; set; }
        public bool MemberInserted { get; set; }
        public bool NoEmployer { get; set; }
        public bool EmptyCityInFile { get; set; }
        public bool EmptyEmployerInFile { get; set; }


        public virtual IcmsMember MemberFoundInSystem { get; set; } = new IcmsMember();


        public virtual List<TpaGroupNames> GroupNames { get; set; } = new List<TpaGroupNames>();


    }
}