using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS_DATA_STAGING;

namespace DbmsSims.Models.Downloads.ViewModels
{
    public class DownloadsViewModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPswd { get; set; }
        public string DownloadingUserId { get; set; }
        public string DownloadErrorMessage { get; set; }
        public bool SkipFirstRow { get; set; }
        public bool DownloadCompleted { get; set; }
        public bool DownloadSuccessful { get; set; }


        public int RptDownloadId { get; set; }
        public string TpaName { get; set; }
        public int TpaId { get; set; }
        public string DownloadType { get; set; }
        public string SystemUserId { get; set; }


        public string DuplicateMemberFileName { get; set; }
        public string DuplicateMemberFileWorksheetName { get; set; }
        public int DuplicateMemberFileWorksheetColumnCount { get; set; }
        public string DeleteDuplicateMemberFileName { get; set; }
        public string LocalFullDuplicateMemberFilePath { get; set; }

        public string MemberHasNoEmployerFileName { get; set; }
        public string MemberHasNoEmployerFileWorksheetName { get; set; }
        public int MemberHasNoEmployerFileWorksheetColumnCount { get; set; }
        public string DeleteMemberHasNoEmployerFileName { get; set; }
        public string LocalFullMemberHasNoEmployerFilePath { get; set; }

        public string MemberEmptyCityFileName { get; set; }
        public string MemberEmptyCityFileWorksheetName { get; set; }
        public int MemberEmptyCityFileWorksheetColumnCount { get; set; }
        public string DeleteMemberEmptyCityFileName { get; set; }
        public string LocalFullMemberEmptyCityFilePath { get; set; }

        public string ClaimMemberNotInSystemFileName { get; set; }
        public string ClaimMemberNotInSystemFileWorksheetName { get; set; }
        public int ClaimMemberNotInSystemFileWorksheetColumnCount { get; set; }
        public string DeleteClaimMemberNotInSystemFileName { get; set; }
        public string LocalFullClaimMemberNotInSystemFilePath { get; set; }

        public string ClaimEmployerNotInSystemFileName { get; set; }
        public string ClaimEmployerNotInSystemFileWorksheetName { get; set; }
        public int ClaimEmployerNotInSystemFileWorksheetColumnCount { get; set; }
        public string DeleteClaimEmployerNotInSystemFileName { get; set; }
        public string LocalFullClaimEmployerNotInSystemFilePath { get; set; }

        public string ClaimClaimInSystemFileName { get; set; }
        public string ClaimClaimInSystemFileWorksheetName { get; set; }
        public int ClaimClaimInSystemFileWorksheetColumnCount { get; set; }
        public string DeleteClaimClaimInSystemFileName { get; set; }
        public string LocalFullClaimClaimInSystemFilePath { get; set; }


        public string FtpHost { get; set; }
        public string FtpFilePath { get; set; }
        public string FtpFullFilePath { get; set; }
        public string FtpFullArchivePath { get; set; }


        public virtual List<DownloadsViewModel> ReportDownloadAdminItems { get; set; } = new List<DownloadsViewModel>();

        public virtual ReportDownloadAdmin DownloadItem { get; set; } = new ReportDownloadAdmin();



        public virtual List<EligibilityViewModel> EligbilityDownloadItems { get; set; } = new List<EligibilityViewModel>();


        public bool EligibilityDownload_CreateDuplicateMemberFile { get; set; }
        public virtual List<EligibilityViewModel> DuplicateMembersToMerge { get; set; } = new List<EligibilityViewModel>();

        public bool EligibilityDownload_CreateMemberHasNoEmployerFile { get; set; }
        public virtual List<EligibilityViewModel> MemberHasNoEmployer { get; set; } = new List<EligibilityViewModel>();

        public bool EligibilityDownload_CreateMemberEmptyCityFile { get; set; }
        public virtual List<EligibilityViewModel> MemberEmptyCity { get; set; } = new List<EligibilityViewModel>();

        public bool EligibilityDownload_CreateMemberEmptyEmployerFile { get; set; }
        public virtual List<EligibilityViewModel> MemberEmptyEmployer { get; set; } = new List<EligibilityViewModel>();




        public virtual List<ClaimViewModel> ClaimDownloadItems { get; set; } = new List<ClaimViewModel>();


        public bool ClaimDownload_CreateEmployerNotInSystemFile { get; set; }
        public virtual List<ClaimViewModel> ClaimEmployerNotInSystem { get; set; } = new List<ClaimViewModel>();

        public bool ClaimDownload_CreateMemberNotInSystemFile { get; set; }
        public virtual List<ClaimViewModel> ClaimMemberNotInSystem { get; set; } = new List<ClaimViewModel>();

        public bool ClaimDownload_CreateClaimInSystemFile { get; set; }
        public virtual List<ClaimViewModel> ClaimInSystem { get; set; } = new List<ClaimViewModel>();




        public virtual List<TpaGroupNames> GroupNames { get; set; } = new List<TpaGroupNames>();       
    }
}