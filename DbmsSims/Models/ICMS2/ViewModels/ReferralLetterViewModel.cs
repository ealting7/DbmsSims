using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class ReferralLetterViewModel
    {

        public string MemberId { get; set; }
        public string ReferralNumber { get; set; }
        public string AuthNumber { get; set; }
        public string ReferralDecision { get; set; }

        public string LetterType { get; set; }


        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] LetterFile { get; set; }
        public DateTime? LetterCreatedDate { get; set; }
        public string SystemUserId { get; set; }



        public string Url { get; set; }
        public string Title { get; set; }
        public short Height { get; set; }
        public int DialogWidth { get { return Width + 60; } }
        public short Width { get; set; }


        public ReportDocument cryrptLetter { get; set;}

        public string ModelMessage { get; set; }


        //list of letters in referral
        public virtual List<ReferralLetterViewModel> LettersInReferral { get; set; } = new List<ReferralLetterViewModel>();

    }
}