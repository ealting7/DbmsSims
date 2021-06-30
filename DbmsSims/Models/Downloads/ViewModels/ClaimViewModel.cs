using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS_DATA_STAGING;

namespace DbmsSims.Models.Downloads.ViewModels
{
    public class ClaimViewModel
    {

        public string Type { get; set; }

        public string GroupNum { get; set; }
        public string GroupName { get; set; }
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeSsn { get; set; }
        public string Birth { get; set; }
        public string ClaimantSsn { get; set; }
        public string ClaimantBirth { get; set; }
        public string SubAdd1 { get; set; }
        public string SubAdd2 { get; set; }
        public string SubCity { get; set; }
        public string SubState { get; set; }
        public string SubZip { get; set; }
        public string SubPhone { get; set; }
        public string Diag1 { get; set; }
        public string Diag2 { get; set; }
        public string Diag3 { get; set; }
        public string Diag4 { get; set; }
        public string Diag5 { get; set; }
        public string CptCode { get; set; }
        public string ServiceFromDate { get; set; }
        public string ServiceToDate { get; set; }
        public string CheckDate { get; set; }
        public string ProvNpi { get; set; }
        public string ProvName { get; set; }
        public string PosName { get; set; }
        public string PosAddress1 { get; set; }
        public string PosAddress2 { get; set; }
        public string PosCity { get; set; }
        public string PosState { get; set; }        
        public string PosZip { get; set; }

        //[StringLength(15, ErrorMessage = "The POS Phone value cannot exceed 15 characters. ")]
        public string PosPhone { get; set; }

        public string HospitalInDate { get; set; }
        public string HospitalOutDate { get; set; }
        public string ClaimNumber { get; set; }
        public string ClaimLineNumber { get; set; }
        public string ClaimPaidAmount { get; set; }
        public string ClaimBillAmount { get; set; }
        public string ClaimantPaidAmount { get; set; }
        public string MemFirstName { get; set; }
        public string MemLastName { get; set; }


        public int TpaId { get; set; }
        public int? EmployerId { get; set; }

        public string SystemUserId { get; set; }

        public bool EmployerNotInSystem { get; set; }
        public bool MemberNotInSystem { get; set; }
        public bool ClaimInSystem { get; set; }



        public virtual TpaMedicalClaims ClaimToUpdate { get; set; } = new TpaMedicalClaims();


        public virtual IcmsMember MemberFoundInSystem { get; set; } = new IcmsMember();


        public virtual List<TpaGroupNames> GroupNames { get; set; } = new List<TpaGroupNames>();
    }
}