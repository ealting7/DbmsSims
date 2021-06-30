using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DbmsSims.Models.ICMS2.ViewModels
{
    public class ReferralSavingsViewModel
    {

        //referral items
        public string MemberId { get; set; }
        public string ReferralNumber { get; set; }
        public string AuthNumber { get; set; }
        public string UtilizationType { get; set; }
        public int? LineNumber { get; set; }

        public string BedType { get; set; }



        public Guid SavingsId { get; set; }
        public int? SavingsLineNumber { get; set; }
        public string SavingsDescription { get; set; }
        public string SavingsUnit { get; set; }
        public int? SavingsUnitId  { get; set; }
        public decimal? SavingsQuantity { get; set; }
        public decimal? SavingsCost { get; set; }
        public decimal? SavingsNegotiatedPerUnit { get; set; }
        public decimal? SavingsPerUnit { get; set; }
        public string SavingsDollarOrPercent { get; set; }
        public bool? SavingsLineItem { get; set; }
        public string SavingsCptCode { get; set; }
        public string SavingsNetwork { get; set; }
        public int? SavingsNetworkId { get; set; }
        public string SavingsNotes { get; set; }

        public Guid UserId { get; set; }


        public int saving_units_id { get; set; }
        public int network_id { get; set; }




        public virtual List<ReferralSavingsViewModel> ReferralSavings { get; set; } = new List<ReferralSavingsViewModel>();

        public virtual List<rSavingsUnits> Units { get; set; } = new List<rSavingsUnits>();
        public virtual List<Networks> Networks { get; set; } = new List<Networks>();

        public virtual List<UtilizationInpatientDayViewModel> InpatientUtilizations { get; set; } = new List<UtilizationInpatientDayViewModel>();
        public virtual List<UtilizationOutpatientDayViewModel> OutpatientUtilizations { get; set; } = new List<UtilizationOutpatientDayViewModel>();

    }
}