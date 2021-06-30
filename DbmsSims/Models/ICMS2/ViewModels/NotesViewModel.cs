using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class NotesViewModel
    {

        public string ReferralNumber { get; set; }
        public string AuthNumber { get; set; }
        public string UtilizationType { get; set; }
        public int LineNumber { get; set; }

        public string BedType { get; set; }

        public string Type { get; set; }
        public string MemberId { get; set; }
        public DateTime RecordDate { get; set; }
        public int SequenceNumber { get; set; }
        public string NoteText { get; set; }
        public int? BillingId { get; set; }
        public int? BillingMinutes { get; set; }
        public bool OnLetter { get; set; }

        public Guid UserId { get; set; }


        public List<NotesViewModel> notes { get; set; }


        public virtual List<BillingCodes> billcodes { get; set; } = new List<BillingCodes>();
        public virtual List<Minutes> billminutes { get; set; } = new List<Minutes>();
        public virtual List<UtilizationInpatientDayViewModel> InpatientUtilizations { get; set; } = new List<UtilizationInpatientDayViewModel>();
        public virtual List<UtilizationOutpatientDayViewModel> OutpatientUtilizations { get; set; } = new List<UtilizationOutpatientDayViewModel>();
        public virtual List<NotesViewModel> UmNotes { get; set; } = new List<NotesViewModel>();

    }
}