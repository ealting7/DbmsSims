using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class MedicalCodeSearchViewModel
    {

        public string SearchText { get; set; }
        public bool DiagnosisCodeSearch { get; set; }
        public bool CptCodeSearch { get; set; }
        public bool HcpcsCodeSearch { get; set; }

        public int SearchReturnCodeId { get; set; }
        public string SearchReturnCode { get; set; }
        public string SearchReturnLongDescription { get; set; }
        public string SearchReturnShortDescription { get; set; }

        public bool SearchSuccess { get; set; }
        public int SelectedSearchItemCodeId { get; set; }  
        
        public string Code { get; set; }

        public string ReferralNumber { get; set; }
        public string MemberId { get; set; }
        public string UserId { get; set; }

        public string ModelReturnMessage { get; set; }

        public virtual List<MedicalCodeSearchViewModel> ReturnedSearchCodes { get; set; } = new List<MedicalCodeSearchViewModel>();

    }
}