using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DbmsSims.Models.ICMS2.ViewModels;

namespace DbmsSims.Models.ICMS2
{
    public class ICMS2DbContext : DbContext
    {

        public ICMS2DbContext(): base(nameOrConnectionString:"Main")
        {
        }



        public virtual DbSet<DbmsIcmsSimsUserSearch> DbmsUserMemberSearches { get; set; }


        public virtual DbSet<IcmsMember> DbmsMembers { get; set; }
        public virtual DbSet<MemberEnrollment> DbmsMemberEnrollment { get; set; }
        public virtual DbSet<MemberAddress> DbmsMemberAddresses { get; set; }
        public virtual DbSet<MemberPhone> DbmsMemberPhone { get; set; }
        public virtual DbSet<MemberNotes> DbmsMemberNotes { get; set; }
        public virtual DbSet<rQualityCareNotes> DbmsQualityCareNotes { get; set; }
        public virtual DbSet<rUtilizationDayNotes> DbmsUtilizationDayNotes { get; set; }
        public virtual DbSet<MemberAddressDmAlternate> DbmsMemberAddressDmAlternate { get; set; }
        public virtual DbSet<MemberMedsAllergies> DbmsMemberMedsAllergies { get; set; }
        public virtual DbSet<MemberVitals> DbmsMemberVitals { get; set; }
        public virtual DbSet<MemberLab> DbmsMemberLab { get; set; }
        public virtual DbSet<MemberStratLevel> DbmsMemberStratLevel { get; set; }
        public virtual DbSet<MemberTask> DbmsMemberTask { get; set; }
        public virtual DbSet<MemberHealthPlanReference> DbmsMemberHealthPlanReference { get; set; }
        public virtual DbSet<MemberCustomerServiceAlert> DbmsMemberCustomerServiceAlert { get; set; }
        public virtual DbSet<CaseOwner> DbmsCaseOwner { get; set; }
        public virtual DbSet<ClinicalReviewBills> DbmsClinicalReviewBills { get; set; }
        public virtual DbSet<EpisodesOfCare> DbmsEpisodesOfCare { get; set; }
        public virtual DbSet<LcmReportNeededForBillingTask> DbmsLcmReportNeededForBillingTask { get; set; }
        public virtual DbSet<LcmReportQaNotesTaskReference> DbmsLcmReportQaNotesTaskReference { get; set; }
        public virtual DbSet<LcmReportQaTasks> DbmsLcmReportQaTasks { get; set; }
        public virtual DbSet<LcnReportFax> DbmsLcnReportFax { get; set; }
        public virtual DbSet<MdReviewDetermination> DbmsMdReviewDetermination { get; set; }
        public virtual DbSet<MemberMedsPharmacyFeed> DbmsMemberMedsPharmacyFeed { get; set; }
        public virtual DbSet<MemberPcp> DbmsMemberPcp { get; set; }
        public virtual DbSet<MemberNotesSummary> DbmsMemberNotesSummary { get; set; }
        public virtual DbSet<AccountsReceivablePayments> DbmsAccountsReceivablePayments { get; set; }
        public virtual DbSet<BillingUpdateHistoryLog> DbmsBillingUpdateHistoryLog { get; set; }
        public virtual DbSet<CarePlanNotesAttachment> DbmsCarePlanNotesAttachment { get; set; }
        public virtual DbSet<ClinicalRequestHistory> DbmsClinicalRequestHistory { get; set; }
        public virtual DbSet<ClinicalRequestProviders> DbmsClinicalRequestProviders { get; set; }
        public virtual DbSet<CmMemberNote> DbmsCmMemberNote { get; set; }
        public virtual DbSet<CodeRemovalItems> DbmsCodeRemovalItems { get; set; }
        public virtual DbSet<DependentMemberUpdateReference> DbmsDependentMemberUpdateReference { get; set; }
        public virtual DbSet<DiseaseManagementNotesAttachment> DbmsDiseaseManagementNotesAttachment { get; set; }
        public virtual DbSet<DmMemberSavings> DbmsDmMemberSavings { get; set; }
        public virtual DbSet<LcmReportQaNotes> DbmsLcmReportQaNotes { get; set; }
        public virtual DbSet<LetterReportFax> DbmsLetterReportFax { get; set; }
        public virtual DbSet<MdReviewFollowup> DbmsMdReviewFollowup { get; set; }
        public virtual DbSet<MemberCareCoordinationCall> DbmsMemberCareCoordinationCall { get; set; }
        public virtual DbSet<MemberCareCoordinationCallSavings> DbmsMemberCareCoordinationCallSavings { get; set; }
        public virtual DbSet<MemberClaimsDiagnosis> DbmsMemberClaimsDiagnosis { get; set; }
        public virtual DbSet<MemberConditionAcuity> DbmsMemberConditionAcuity { get; set; }
        public virtual DbSet<MemberLcmFollowupNotes> DbmsMemberLcmFollowupNotes { get; set; }
        public virtual DbSet<MemberMeds> DbmsMemberMeds { get; set; }
        public virtual DbSet<MemberMedsHighDollarTask> DbmsMemberMedsHighDollarTask { get; set; }
        public virtual DbSet<MemberMedsHistory> DbmsMemberMedsHistory { get; set; }
        public virtual DbSet<MemberPictures> DbmsMemberPictures { get; set; }
        public virtual DbSet<MemberProfilePicture> DbmsMemberProfilePicture { get; set; }
        public virtual DbSet<MemberProgram> DbmsMemberProgram { get; set; }
        public virtual DbSet<MemberRelativeDiseaseHistory> DbmsMemberRelativeDiseaseHistory { get; set; }
        public virtual DbSet<MemberRenalTask> DbmsMemberRenalTask { get; set; }
        public virtual DbSet<MemberReturnedLetters> DbmsMemberReturnedLetters { get; set; }
        public virtual DbSet<MemberSignatureFile> DbmsMemberSignatureFile { get; set; }
        public virtual DbSet<MonthlyLcmManagementQa> DbmsMonthlyLcmManagementQa { get; set; }
        public virtual DbSet<MonthlyUtilizationManagement> DbmsMonthlyUtilizationManagement { get; set; }
        public virtual DbSet<rAdmissionCareplanCount> DbmsAdmissionCareplanCount { get; set; }
        public virtual DbSet<rAuthorizationUpdates> DbmsAuthorizationUpdates { get; set; }
        public virtual DbSet<rDentalVisits> DbmsDentalVisits { get; set; }
        public virtual DbSet<rDepartmentBedVacancy> DbmsDepartmentBedVacancy { get; set; }
        public virtual DbSet<rInboundFaxHistory> DbmsInboundFaxHistory { get; set; }
        public virtual DbSet<rInboundFaxReferralRemoval> DbmsInboundFaxReferralRemoval { get; set; }
        public virtual DbSet<rInboundVoicemail> DbmsInboundVoicemail { get; set; }
        public virtual DbSet<rMemberReferralMedicine> DbmsMemberReferralMedicine { get; set; }
        public virtual DbSet<rMemberReferralQoc> DbmsMemberReferralQoc { get; set; }
        public virtual DbSet<rMemberReferralUpdatesWorkflow> DbmsMemberReferralUpdatesWorkflow { get; set; }
        public virtual DbSet<rUtilizationDischargeNote> DbmsUtilizationDischargeNote { get; set; }
        public virtual DbSet<SuspendCaseToTaskReference> DbmsSuspendCaseToTaskReference { get; set; }
        public virtual DbSet<SuspendedNotes> DbmsSuspendedNotes { get; set; }
        public virtual DbSet<SuspendedNotesOverride> DbmsSuspendedNotesOverride { get; set; }
        public virtual DbSet<TelephoneNotesAttachment> DbmsTelephoneNotesAttachment { get; set; }
        public virtual DbSet<TransitionalCareReference> DbmsTransitionalCareReference { get; set; }
        public virtual DbSet<UmAssignedToTask> DbmsUmAssignedToTask { get; set; }
        public virtual DbSet<UmAssignedToTaskTouchedReference> DbmsUmAssignedToTaskTouchedReference { get; set; }
        public virtual DbSet<UmAutoApprovedDiagnosisTask> DbmsUmAutoApprovedDiagnosisTask { get; set; }
        public virtual DbSet<UtilizationReviewNoteTask> DbmsUtilizationReviewNoteTask { get; set; }
        public virtual DbSet<WebClientNoteTask> DbmsWebClientNoteTask { get; set; }
        public virtual DbSet<WebOnlinePrecertTask> DbmsWebOnlinePrecertTask { get; set; }
        public virtual DbSet<MergedMemberReference> DbmsMergedMemberReference { get; set; }

        public virtual DbSet<MergedrMemberReferralCpts> DbmsMergedMemberReferralCpts { get; set; }
        public virtual DbSet<MergedrMemberReferralDiags> DbmsMergedMemberReferralDiags { get; set; }
        public virtual DbSet<MergedrMemberReferralHcpcs> DbmsMergedMemberReferralHcpcs { get; set; }
        public virtual DbSet<MergedrMemberReferralInterqualReference> DbmsMergedrMemberReferralInterqualReference { get; set; }
        public virtual DbSet<MergedrMemberReferralLetters> DbmsMergedMemberReferralLetters { get; set; }
        public virtual DbSet<MergerMemberReferral> DbmsMergeMemberReferral { get; set; }
        public virtual DbSet<MergedrReferralMissingReferTo> DbmsMergedReferralMissingReferTo { get; set; }
        public virtual DbSet<MergedrMemberReferralWorkflow> DbmsMergedMemberReferralWorkflow { get; set; }
        public virtual DbSet<MergedMemberAddressDmAlternate> DbmsMergedMemberAddressDmAlternate { get; set; }
        public virtual DbSet<MergedMemberAddress> DbmsMergedMemberAddress { get; set; }
        public virtual DbSet<MergedMemberCareCoordinationCall> DbmsMergedMemberCareCoordinationCall { get; set; }
        public virtual DbSet<MergedMemberCareCoordinationCallSavings> DbmsMergedMemberCareCoordinationCallSavings { get; set; }
        public virtual DbSet<MergedMemberClaimsDiagnosis> DbmsMergeMemberClaimsDiagnosis { get; set; }
        public virtual DbSet<MergedMemberConditionAcuity> DbmsMergedMemberConditionAcuity { get; set; }
        public virtual DbSet<MergedMemberCustomerServiceAlert> DbmsMergedMemberCustomerServiceAlert { get; set; }
        public virtual DbSet<MergedrInboundFax> DbmsMergedrInboundFax { get; set; }
        public virtual DbSet<MergedMemberHealthPlanReference> DbmsMergedMemberHealthPlanReference { get; set; }
        public virtual DbSet<MergedMemberLab> DbmsMergedMemberLab { get; set; }
        public virtual DbSet<MergedMemberLcmFollowupNotes> DbmsMergedMemberLcmFollowupNotes { get; set; }
        public virtual DbSet<MergedMemberMdReviewReference> DbmsMergedMemberMdReviewReference { get; set; }
        public virtual DbSet<MergedMemberMedsAllergies> DbmsMergedMemberMedsAllergies { get; set; }
        public virtual DbSet<MergedMemberMeds> DbmsMergedMemberMeds { get; set; }
        public virtual DbSet<MergedMemberMedsHighDollarTask> DbmsMergedMemberMedsHighDollarTask { get; set; }
        public virtual DbSet<MergedMemberMedsHistory> DbmsMergedMemberMedsHistory { get; set; }
        public virtual DbSet<MergedMemberMedsPharmacyFeed> DbmsMergedMemberMedsPharmacyFeed { get; set; }
        public virtual DbSet<MergedMemberNotesAttachment> DbmsMergedMemberNotesAttachment { get; set; }
        public virtual DbSet<MergedMemberNotes> DbmsMergedMemberNotes { get; set; }
        public virtual DbSet<MergedMemberNotesSummary> DbmsMergedMemberNotesSummary { get; set; }
        public virtual DbSet<MergedMemberPcp> DbmsMergedMemberPcp { get; set; }
        public virtual DbSet<MergedMemberPhone> DbmsMergedMemberPhone { get; set; }
        public virtual DbSet<MergedMemberPictures> DbmsMergedMemberPictures { get; set; }
        public virtual DbSet<MergedMemberProfilePicture> DbmsMergedMemberProfilePicture { get; set; }
        public virtual DbSet<MergedMemberProgram> DbmsMergedMemberProgram { get; set; }
        public virtual DbSet<MergedrQualityCareNotes> DbmsMergedrQualityCareNotes { get; set; }
        public virtual DbSet<MergedrMemberReferralMedicine> DbmsMergedrMemberReferralMedicine { get; set; }
        public virtual DbSet<MergedrMemberReferralQoc> DbmsMergedrMemberReferralQoc { get; set; }
        public virtual DbSet<MergedrMemberReferralUpdatesWorkflow> DbmsMergedrMemberReferralUpdatesWorkflow { get; set; }
        public virtual DbSet<MergedMemberRelativeDiseaseHistory> DbmsMergedMemberRelativeDiseaseHistory { get; set; }
        public virtual DbSet<MergedMemberRenalTask> DbmsMergedMemberRenalTask { get; set; }
        public virtual DbSet<MergedMemberReturnedLetters> DbmsMergedMemberReturnedLetters { get; set; }
        public virtual DbSet<MergedMemberSignatureFiles> DbmsMergedMemberSignatureFile { get; set; }
        public virtual DbSet<MergedMemberStratLevel> DbmsMergedMemberStratLevel { get; set; }
        public virtual DbSet<MergedMemberTask> DbmsMergedMemberTask { get; set; }
        public virtual DbSet<MergedMemberToolProgramStatus> DbmsMergedMemberToolProgramStatus { get; set; }
        public virtual DbSet<MergedMemberUpdateReference> DbmsMergedMemberUpdateReference { get; set; }
        public virtual DbSet<MergedMemberVitals> DbmsMergedMemberVitals { get; set; }
        public virtual DbSet<MergedrUtilizationDaysNotes> DbmsMergedrUtilizationDaysNotes { get; set; }
        public virtual DbSet<MergedrUtilizationDays> DbmsMergedrUtilizationDays { get; set; }
        public virtual DbSet<MergedrUtilizationDischargeNote> DbmsMergedrUtilizationDischargeNote { get; set; }
        public virtual DbSet<MergedrUtilizationReviews> DbmsMergedrUtilizationReviews { get; set; }
        public virtual DbSet<MergedrUtilizationSavings> DbmsMergedrUtilizationSavings { get; set; }
        public virtual DbSet<MergedAccountsReceivablePayments> DbmsMergedAccountsReceivablePayments { get; set; }
        public virtual DbSet<MergedrAdmissionCareplanCount> DbmsMergedAdmissionCareplanCount { get; set; }
        public virtual DbSet<MergedAdmission> DbmsMergedAdmission { get; set; }
        public virtual DbSet<MergedrAuthorizationUpdates> DbmsMergedAuthorizationUpdates { get; set; }
        public virtual DbSet<MergedBillingUpdateHistoryLog> DbmsMergedBillingUpdateHistoryLog { get; set; }
        public virtual DbSet<MergedCarePlanNotesAttachment> DbmsMergedCarePlanNotesAttachment { get; set; }
        public virtual DbSet<MergedCaseOwner> DbmsMergedCaseOwner { get; set; }
        public virtual DbSet<MergedClinicalRequestHistory> DbmsMergedClinicalRequestHistory { get; set; }
        public virtual DbSet<MergedClinicalRequestProviders> DbmsMergedClinicalRequestProviders { get; set; }
        public virtual DbSet<MergedCmMemberNote> DbmsMergedCmMemberNote { get; set; }
        public virtual DbSet<MergedClinicalReviewBills> DbmsMergedClinicalReviewBills { get; set; }
        public virtual DbSet<MergedCodeRemovalItems> DbmsMergedCodeRemovalItems { get; set; }
        public virtual DbSet<MergedrDentalVisits> DbmsMergedrDentalVisits { get; set; }
        public virtual DbSet<MergedrDepartmentBedVacancy> DbmsMergedrDepartmentBedVacancy { get; set; }
        public virtual DbSet<MergedDependentMemberUpdateReference> DbmsMergedDependentMemberUpdateReference { get; set; }
        public virtual DbSet<MergedDiseaseManagementNotesAttachment> DbmsMergedDiseaseManagementNotesAttachment { get; set; }
        public virtual DbSet<MergedDmMemberSavings> DbmsMergedDmMemberSavings { get; set; }
        public virtual DbSet<MergedEmailsOutbound> DbmsMergedEmailsOutbound { get; set; }
        public virtual DbSet<MergedEpisodesOfCare> DbmsMergedEpisodesOfCare { get; set; }
        public virtual DbSet<MergedrInboundFaxReferralRemoval> DbmsMergedInboundFaxReferralRemoval { get; set; }
        public virtual DbSet<MergedrInboundVoicemail> DbmsMergedInboundVoicemail { get; set; }
        public virtual DbSet<MergedMemberLcmInitial> DbmsMergedMemberLcmInitial { get; set; }
        public virtual DbSet<MergedMemberLcmActivity> DbmsMergedMemberLcmActivity { get; set; }
        public virtual DbSet<MergedMemberLcmFollowupSavings> DbmsMergedMemberLcmFollowupSavings { get; set; }
        public virtual DbSet<MergedLcmReportNeededForBillingTask> DbmsMergedLcmReportNeededForBillingTask { get; set; }
        public virtual DbSet<MergedLcmReportQaNotes> DbmsMergedLcmReportQaNotes { get; set; }
        public virtual DbSet<MergedLcmReportQaTasks> DbmsMergedLcmReportQaTasks { get; set; }
        public virtual DbSet<MergedLcmReportQaNotesTaskReference> DbmsMergedLcmReportQaNotesTaskReference { get; set; }
        public virtual DbSet<MergedLcnReportFax> DbmsMergedLcnReportFax { get; set; }
        public virtual DbSet<MergedLetterReportFax> DbmsMergedLetterReportFax { get; set; }
        public virtual DbSet<MergedMdReviewDetermination> DbmsMergedMdReviewDetermination { get; set; }
        public virtual DbSet<MergedMdReviewFollowup> DbmsMergedMdReviewFollowup { get; set; }
        public virtual DbSet<MergedMdReviewQuestion> DbmsMergedMdReviewQuestion { get; set; }
        public virtual DbSet<MergedMdReviewRequest> DbmsMergedMdReviewRequest { get; set; }
        public virtual DbSet<MergedMonthlyLcmManagementQa> DbmsMergedMonthlyLcmManagementQa { get; set; }
        public virtual DbSet<MergedMonthlyUtilizationManagement> DbmsMergedMonthlyUtilizationManagement { get; set; }
        public virtual DbSet<MergedSuspendCaseToTaskReference> DbmsMergedSuspendCaseToTaskReference { get; set; }
        public virtual DbSet<MergedSuspendedNotes> DbmsMergedSuspendedNotes { get; set; }
        public virtual DbSet<MergedSuspendedNotesOverride> DbmsMergedSuspendedNotesOverride { get; set; }
        public virtual DbSet<MergedTelephoneNotesAttachment> DbmsMergedTelephoneNotesAttachment { get; set; }
        public virtual DbSet<MergedTransitionalCareReference> DbmsMergedTransitionalCareReference { get; set; }
        public virtual DbSet<MergedUmAssignedToTask> DbmsMergedUmAssignedToTask { get; set; }
        public virtual DbSet<MergedUmAssignedToTaskTouchedReference> DbmsMergedUmAssignedToTaskTouchedReference { get; set; }
        public virtual DbSet<MergedUmAutoApprovedDiagnosisTask> DbmsMergedUmAutoApprovedDiagnosisTask { get; set; }
        public virtual DbSet<MergedUtilizationReviewNoteTask> DbmsMergedUtilizationReviewNoteTask { get; set; }
        public virtual DbSet<MergedWebClientNoteTask> DbmsMergedWebClientNoteTask { get; set; }
        public virtual DbSet<MergedWebOnlinePrecertTask> DbmsMergedWebOnlinePrecertTask { get; set; }

        public virtual DbSet<Employer> DbmsEmployers { get; set; }
        public virtual DbSet<Tpas> DbmsTpas { get; set; }
        public virtual DbSet<TpaEmployer> DbmsTpaEmployer { get; set; }
        public virtual DbSet<ClientBuEmployer> DbmsClientBuEmployer { get; set; }
        public virtual DbSet<ClientBu> DbmsClientBu { get; set; }
        public virtual DbSet<ClaimsId> DbmsClaimsId { get; set; }


        public virtual DbSet<States> DbmsStates { get; set; }

        public virtual DbSet<BillingCodes> DbmsLcmBillingCodes { get; set; }


        public virtual DbSet<rMemberReferral> DbmsMemberReferrals { get; set; }
        public virtual DbSet<rMemberReferralDiags> DbmsMemberReferralDiags { get; set; }
        public virtual DbSet<rMemberReferralCpts> DbmsMemberReferralCpts { get; set; }
        public virtual DbSet<rMemberReferralHcpcs> DbmsMemberReferralHcpcs { get; set; }
        public virtual DbSet<rUtilizationDays> DbmsUtilizationDays { get; set; }
        public virtual DbSet<rUtilizationReviews> DbmsUtilizationReviews { get; set; }
        public virtual DbSet<rMemberReferralLetters> DbmsMemberReferralLetters { get; set; }                
        public virtual DbSet<rReferralDecisions> DbmsReferralDecisions { get; set; }
        public virtual DbSet<rReferralType> DbmsReferralTypes { get; set; }
        public virtual DbSet<rReferralContext> DbmsReferralContext { get; set; }
        public virtual DbSet<rReferralPriority> DbmsReferralPriority { get; set; }
        public virtual DbSet<rReferralCategory> DbmsReferralCategory { get; set; }
        public virtual DbSet<rLocationPos> DbmsLocationPos { get; set; }
        public virtual DbSet<rMemberReferralWorkflow> DbmsMemberReferralWorkflows { get; set; }
        public virtual DbSet<rCurrentStatus> DbmsCurrentStatus { get; set; }
        public virtual DbSet<rReferralPendReason> DbmsReferralPendReasons { get; set; }
        public virtual DbSet<rBedDayType> DbmsBedDayType { get; set; }
        public virtual DbSet<ReviewTypeItems> DbmsReviewTypeItems { get; set; }
        public virtual DbSet<rUtilizationDaysDecision> DbmsUtilizationDaysDecision { get; set; }
        public virtual DbSet<rDenialReason> DbmsDenialReason { get; set; }
        public virtual DbSet<rUtilizationVisitPeriod> DbmsUtilizationVisitPeriod { get; set; }
        public virtual DbSet<MdReviewRequest> DbmsMdReviewRequest { get; set; }
        public virtual DbSet<MdReviewQuestion> DbmsMdReviewQuestion { get; set; }
        public virtual DbSet<rUtilizationSavings> DbmsUtilizationSavings { get; set; }
        public virtual DbSet<rMemberReferralInterqualReference> DbmsMemberReferralInterqualReference { get; set; }
        public virtual DbSet<MemberMdReviewReference> DbmsMemberMdReviewReference { get; set; }
        public virtual DbSet<rReferralMissingReferTo> DbmsrReferralMissingReferTo { get; set; }


        public virtual DbSet<rInboundFax> DbmsInboundFax { get; set; }


        public virtual DbSet<MemberNotesAttachment> DbmsMemberNotesAttachment { get; set; }
        public virtual DbSet<UmNotesAttachment> DbmsUmNotesAttachment { get; set; }


        public virtual DbSet<MemberLcmInitial> DbmsMemberLcmInitial { get; set; }
        public virtual DbSet<MemberLcmFollowup> DbmsMemberLcmFollowup { get; set; }
        public virtual DbSet<MemberLcmActivity> DbmsMemberLcmActivity { get; set; }
        public virtual DbSet<MemberLcmFollowupSavings> DbmsMemberLcmFollowupSavings { get; set; }


        public virtual DbSet<SystemUser> DbmsSystemUsers { get; set; }
        public virtual DbSet<SystemUserRole> DbmsSystemUserRoles { get; set; }

        public virtual DbSet<DiagnosisCodes10> DbmsDiagnoisiCodes10 { get; set; }
        public virtual DbSet<CptCodes2015> DbmsCptCodes2015 { get; set; }
        public virtual DbSet<HcpcsCodes2015> DbmsHcpcsCodes2015 { get; set; }

        public virtual DbSet<PcpTable> DbmsPcpProviders { get; set; }
        public virtual DbSet<ProviderAddress> DbmsProviderAddress { get; set; }

        public virtual DbSet<rDepartment> DbmsDepartments { get; set; }
        public virtual DbSet<FacilityAddress> DbmsFacilityAddress { get; set; }

        public virtual DbSet<rVendor> DbmsVendors { get; set; }
        public virtual DbSet<VendorAddress> DbmsVendorAddress { get; set; }

        public virtual DbSet<rSavingsUnits> DbmsrSavingsUnits { get; set; }

        public virtual DbSet<Networks> DbmsNetworks { get; set; }

        public virtual DbSet<ReportDownloadAdmin> DbmsReportDownloadAdmin { get; set; }
        public virtual DbSet<ReportDownloadAdminFileDownloads> DbmsReportDownloadAdminFileDownloads { get; set; }

        public virtual DbSet<MemberUpdateReference> DbmsMemberUpdateReference { get; set; }


        public virtual DbSet<EmailsOutbound> DbmsEmailsOutbound { get; set; }


        public virtual DbSet<Admission> DbmsAdmission { get; set; }

        public virtual DbSet<MemberToolProgramStatus> DbmsMemberToolProgramStatus { get; set; }


        //Viewmodels
        public virtual DbSet<EditMemberViewModel> DbmsEditMemberViewModels { get; set; }







        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.ftp_directory_to_scan)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.file_extension_to_look_for)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.DTSPackageID)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.dts_package_filename_to_use)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.dts_tabln_name)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.ftp_actual_directory)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.ftp_filename_on_ftp_directory)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.zip_file_password)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.zip_file_name)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.excel_spreadsheet_workbook_name)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.PGPHexKey)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.PGPPubRing)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.PGPPrivKey)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ReportDownloadAdmin>()
                .Property(e => e.update_comment)
                .IsUnicode(false);




            modelBuilder.Entity<Networks>()
                .Property(e => e.network_name)
                .IsUnicode(false);




            modelBuilder.Entity<rSavingsUnits>()
                .Property(e => e.units_code)
                .IsUnicode(false);

            modelBuilder.Entity<rSavingsUnits>()
                .Property(e => e.units_label)
                .IsUnicode(false);




            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.referral_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.item_description)
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.quantity)
                .HasPrecision(12, 2);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.cost)
                .HasPrecision(12, 2);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.negotiated)
                .HasPrecision(12, 2);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.savings)
                .HasPrecision(12, 2);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.dollar_or_percent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.cpt_code)
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationSavings>()
                .Property(e => e.notes)
                .IsUnicode(false);





            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.address_line_one)
                .IsUnicode(false);

            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.address_line_two)
                .IsUnicode(false);

            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.state_abbrev)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.address_note)
                .IsUnicode(false);




            modelBuilder.Entity<FacilityAddress>()
                .Property(e => e.address_line_one)
                .IsUnicode(false);

            modelBuilder.Entity<FacilityAddress>()
                .Property(e => e.address_line_two)
                .IsUnicode(false);

            modelBuilder.Entity<FacilityAddress>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<FacilityAddress>()
                .Property(e => e.state_abbrev)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FacilityAddress>()
                .Property(e => e.zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<FacilityAddress>()
                .Property(e => e.address_note)
                .IsUnicode(false);

            modelBuilder.Entity<FacilityAddress>()
                .Property(e => e.zip_code_plus_4)
                .IsUnicode(false);



            modelBuilder.Entity<ProviderAddress>()
                .Property(e => e.address_line1)
                .IsUnicode(false);

            modelBuilder.Entity<ProviderAddress>()
                .Property(e => e.address_line2)
                .IsUnicode(false);

            modelBuilder.Entity<ProviderAddress>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<ProviderAddress>()
                .Property(e => e.state_abbrev)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProviderAddress>()
                .Property(e => e.zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<ProviderAddress>()
                .Property(e => e.address_note)
                .IsUnicode(false);




            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.email_to)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.email_subject)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.email_address)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.email_message)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.zip_file_password)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.zip_file_name)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.email_cc_list)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<EmailsOutbound>()
                .Property(e => e.notice_type)
                .IsUnicode(false);



            modelBuilder.Entity<MdReviewQuestion>()
                .Property(e => e.task_note)
                .IsUnicode(false);

            modelBuilder.Entity<MdReviewQuestion>()
                .Property(e => e.md_question_note)
                .IsUnicode(false);

            modelBuilder.Entity<MdReviewQuestion>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MdReviewQuestion>()
                .Property(e => e.md_answer_note)
                .IsUnicode(false);



            modelBuilder.Entity<MdReviewRequest>()
                .Property(e => e.task_note)
                .IsUnicode(false);

            modelBuilder.Entity<MdReviewRequest>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MdReviewRequest>()
                .Property(e => e.md_review_appeal_note)
                .IsUnicode(false);



            modelBuilder.Entity<rMemberReferralLetters>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralLetters>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);



            modelBuilder.Entity<rUtilizationVisitPeriod>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationVisitPeriod>()
                .Property(e => e.visit_period_abbrev)
                .IsUnicode(false);



            modelBuilder.Entity<rUtilizationReviews>()
                .Property(e => e.referral_number)
                .IsUnicode(false);



            modelBuilder.Entity<rUtilizationDays>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationDays>()
                .Property(e => e.referral_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationDays>()
                .Property(e => e.visits_period_requested)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationDays>()
                .Property(e => e.visits_period_authorized)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationDays>()
                .Property(e => e.ICM_Units)
                .IsUnicode(false);


            modelBuilder.Entity<rUtilizationDays>()
                .Property(e => e.removed)
                .HasColumnName("removed");

            modelBuilder.Entity<rUtilizationDays>()
                .Property(e => e.removed_date)
                .HasColumnName("removed_date");

            modelBuilder.Entity<rUtilizationDays>()
                .Property(e => e.removed_user_id)
                .HasColumnName("removed_user_id");





            modelBuilder.Entity<rDenialReason>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rDenialReason>()
                .Property(e => e.label)
                .IsUnicode(false);




            modelBuilder.Entity<rUtilizationDaysDecision>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationDaysDecision>()
                .Property(e => e.label)
                .IsUnicode(false);



            modelBuilder.Entity<ReviewTypeItems>()
                .Property(e => e.name)
                .IsUnicode(false);



            modelBuilder.Entity<rBedDayType>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rBedDayType>()
                .Property(e => e.label)
                .IsUnicode(false);



            modelBuilder.Entity<HcpcsCodes2015>()
                .Property(e => e.hcp_code)
                .IsUnicode(false);

            modelBuilder.Entity<HcpcsCodes2015>()
                .Property(e => e.hcpcs_short)
                .IsUnicode(false);

            modelBuilder.Entity<HcpcsCodes2015>()
                .Property(e => e.hcpcs_full)
                .IsUnicode(false);

            modelBuilder.Entity<HcpcsCodes2015>()
                .Property(e => e.hcpcs_coverage)
                .IsUnicode(false);



            modelBuilder.Entity<rMemberReferralHcpcs>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralHcpcs>()
                .Property(e => e.hcpcs_code)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralHcpcs>()
                .Property(e => e.modifier1)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralHcpcs>()
                .Property(e => e.estimated_amount)
                .HasPrecision(19, 4);




            modelBuilder.Entity<CptCodes2015>()
                .Property(e => e.cpt_code)
                .IsUnicode(false);

            modelBuilder.Entity<CptCodes2015>()
                .Property(e => e.cpt_descr)
                .IsUnicode(false);

            modelBuilder.Entity<CptCodes2015>()
                .Property(e => e.short_descr)
                .IsUnicode(false);

            modelBuilder.Entity<CptCodes2015>()
                .Property(e => e.medium_descr)
                .IsUnicode(false);

            modelBuilder.Entity<CptCodes2015>()
                .Property(e => e.cpt_group_description)
                .IsUnicode(false);



            modelBuilder.Entity<rMemberReferralCpts>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralCpts>()
                .Property(e => e.cpt_code)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralCpts>()
                .Property(e => e.modifier1)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralCpts>()
                .Property(e => e.estimated_amount)
                .HasPrecision(19, 4);



            modelBuilder.Entity<rMemberReferralDiags>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralDiags>()
                .Property(e => e.diagnosis_or_procedure_code)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralDiags>()
                .Property(e => e.estimated_amount)
                .HasPrecision(19, 4);



            modelBuilder.Entity<DiagnosisCodes10>()
                .Property(e => e.diagnosis_code)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosisCodes10>()
                .Property(e => e.short_description)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosisCodes10>()
                .Property(e => e.medium_description)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosisCodes10>()
                .Property(e => e.long_description)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosisCodes10>()
                .Property(e => e.icd10_group_description)
                .IsUnicode(false);



            modelBuilder.Entity<rReferralPendReason>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralPendReason>()
                .Property(e => e.label)
                .IsUnicode(false);



            modelBuilder.Entity<rCurrentStatus>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rCurrentStatus>()
                .Property(e => e.label)
                .IsUnicode(false);



            modelBuilder.Entity<rMemberReferralWorkflow>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralWorkflow>()
                .Property(e => e.referral_workflow_description)
                .IsUnicode(false);




            modelBuilder.Entity<rReferralCategory>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralCategory>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralCategory>()
                .Property(e => e.spanish_name)
                .IsUnicode(false);



            modelBuilder.Entity<rReferralPriority>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralPriority>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralPriority>()
                .Property(e => e.spanish_name)
                .IsUnicode(false);



            modelBuilder.Entity<rLocationPos>()
                .Property(e => e.number)
                .IsUnicode(false);

            modelBuilder.Entity<rLocationPos>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<rLocationPos>()
                .Property(e => e.description)
                .IsUnicode(false);




            modelBuilder.Entity<rReferralContext>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralContext>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralContext>()
                .Property(e => e.spanish_name)
                .IsUnicode(false);



            modelBuilder.Entity<rReferralType>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralType>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralType>()
                .Property(e => e.spanish_name)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralType>()
                .Property(e => e.inpatient_outpatient_type)
                .IsUnicode(false);



            modelBuilder.Entity<rReferralDecisions>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rReferralDecisions>()
                .Property(e => e.label)
                .IsUnicode(false);



            modelBuilder.Entity<rDepartment>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.specialty)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.tax_id)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.npi)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.facility_notes)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.ihcp)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.location_id)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.billing_ihcp)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.billing_npi)
                .IsUnicode(false);

            modelBuilder.Entity<rDepartment>()
                .Property(e => e.shpg_facility_id)
                .IsUnicode(false);




            modelBuilder.Entity<rVendor>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<rVendor>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<rVendor>()
                .Property(e => e.tax_id)
                .IsUnicode(false);

            modelBuilder.Entity<rVendor>()
                .Property(e => e.npi)
                .IsUnicode(false);

            modelBuilder.Entity<rVendor>()
                .Property(e => e.vendor_notes)
                .IsUnicode(false);

            modelBuilder.Entity<rVendor>()
                .Property(e => e.ihcp)
                .IsUnicode(false);

            modelBuilder.Entity<rVendor>()
                .Property(e => e.location_id)
                .IsUnicode(false);

            modelBuilder.Entity<rVendor>()
                .Property(e => e.billing_ihcp)
                .IsUnicode(false);

            modelBuilder.Entity<rVendor>()
                .Property(e => e.billing_npi)
                .IsUnicode(false);


            modelBuilder.Entity<PcpTable>()
                .Property(e => e.provider_num)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.provider_group_name)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.prov_type)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.provider_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.provider_middle_name)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.provider_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.provider_tin)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.npi)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.ihcp)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.medicaid_number)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.wishard_physician_id)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.location_id)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.billing_ihcp)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.billing_npi)
                .IsUnicode(false);

            modelBuilder.Entity<PcpTable>()
                .Property(e => e.shpg_provider_id)
                .IsUnicode(false);



            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.auth_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.claim_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.po_number)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.revenue_code)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.discharge_plan_required)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.auth_provider_type)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.forced_authorization_type)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferral>()
                .Property(e => e.std_office_location)
                .IsUnicode(false);




            modelBuilder.Entity<rUtilizationDayNotes>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationDayNotes>()
                .Property(e => e.referral_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rUtilizationDayNotes>()
                .Property(e => e.evaluation_text)
                .IsUnicode(false);




            modelBuilder.Entity<BillingCodes>()
                .Property(e => e.billing_code)
                .IsUnicode(false);

            modelBuilder.Entity<BillingCodes>()
                .Property(e => e.billing_description)
                .IsUnicode(false);




            modelBuilder.Entity<ClaimsId>()
                .Property(e => e.claims_id1)
                .IsUnicode(false);





            modelBuilder.Entity<MemberAddress>()
                .Property(e => e.address_line1)
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddress>()
                .Property(e => e.address_line2)
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddress>()
                .Property(e => e.apartment_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddress>()
                .Property(e => e.state_abbrev)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddress>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddress>()
                .Property(e => e.zip_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddress>()
                .Property(e => e.address_note)
                .IsUnicode(false);






            modelBuilder.Entity<MemberPhone>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberPhone>()
                .Property(e => e.phone_note)
                .IsUnicode(false);






            modelBuilder.Entity<MemberNotes>()
                .Property(e => e.evaluation_text)
                .IsUnicode(false);





            modelBuilder.Entity<MemberEnrollment>()
                .Property(e => e.claims_id)
                .IsUnicode(false);

            modelBuilder.Entity<MemberEnrollment>()
                .Property(e => e.member_type_code)
                .IsUnicode(false);

            modelBuilder.Entity<MemberEnrollment>()
                .Property(e => e.claims_enrollment_id)
                .IsUnicode(false);

            modelBuilder.Entity<MemberEnrollment>()
                .Property(e => e.DEP_Number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberEnrollment>()
                .Property(e => e.columbia_employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<MemberEnrollment>()
                .Property(e => e.egp_member_id)
                .IsUnicode(false);




            modelBuilder.Entity<Tpas>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.tpa_dba)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.tpa_code)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.tpa_work_comp)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.tpa_tax_id)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.precert_folder)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.precert_ftp_url)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.precert_ftp_username)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.precert_ftp_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.precert_ftp_remote)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.precert_pgpkey_name)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.tpa_notes)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.PGPHexKey)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.PGPPubRing)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.PGPPrivKey)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.auto_report_folder)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.auto_report_ftp_directory)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.tpa_email)
                .IsUnicode(false);

            modelBuilder.Entity<Tpas>()
                .Property(e => e.quickconnect_portal_email_address)
                .IsUnicode(false);


            // ignore a type that is not mapped to a database table
            modelBuilder.Ignore<EditMemberViewModel>();




            modelBuilder.Entity<MemberLcmInitial>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.cancer_related)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.staging)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.staging_status)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.hospitalized)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.hospital_five_days)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.facility_type)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.report_type)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.primary_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.secondary_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.other_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.procedure)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.auth_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmInitial>()
                .Property(e => e.reinsurer_name)
                .IsUnicode(false);




            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.primary_dx)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.secondary_dx)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.other_dx)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.cancer_related)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.staging)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.staging_status)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.hospitalized)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.hospital_five_days)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.facility_type)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.acuity)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.acuity_changed)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.current_treatments)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.future_treatments)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.psycho_social_summary)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.nurse_summary)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.physician_prognosis)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.previous_treatments)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.Procedure)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.last_update_reason)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.prognosis_report)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.plan_of_care)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowup>()
                .Property(e => e.newly_identified_cm_summary)
                .IsUnicode(false);



            modelBuilder.Entity<rMemberReferralInterqualReference>()
                .Property(e => e.review_cid)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralInterqualReference>()
                .Property(e => e.referral_number)
                .IsUnicode(false);



            modelBuilder.Entity<rInboundFax>()
    .Property(e => e.fax_remoteid)
    .IsUnicode(false);

            modelBuilder.Entity<rInboundFax>()
                .Property(e => e.fax_uniqueid)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFax>()
                .Property(e => e.fax_bodyfilename)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFax>()
                .Property(e => e.queue_dummy)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFax>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFax>()
                .Property(e => e.error_description)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFax>()
                .Property(e => e.email_filename)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFax>()
                .Property(e => e.inbound_member_name)
                .IsUnicode(false);


            modelBuilder.Entity<UmNotesAttachment>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<UmNotesAttachment>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);



            modelBuilder.Entity<MemberNotesAttachment>()
                            .Property(e => e.file_identifier)
                            .IsUnicode(false);



            modelBuilder.Entity<MemberLcmActivity>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberLcmActivity>()
                .Property(e => e.activity_report_note)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmActivity>()
                .Property(e => e.last_update_reason)
                .IsUnicode(false);



            modelBuilder.Entity<MemberLcmFollowupSavings>()
               .Property(e => e.amount)
               .HasPrecision(19, 4);

            modelBuilder.Entity<MemberLcmFollowupSavings>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowupSavings>()
                .Property(e => e.note)
                .IsUnicode(false);



            modelBuilder.Entity<MemberMdReviewReference>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberMdReviewReference>()
                .Property(e => e.module_review_submitted_from)
                .IsUnicode(false);




            modelBuilder.Entity<MemberAddressDmAlternate>()
                            .Property(e => e.address_line1)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberAddressDmAlternate>()
                .Property(e => e.address_line2)
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddressDmAlternate>()
                .Property(e => e.state_abbrev)
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddressDmAlternate>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<MemberAddressDmAlternate>()
                .Property(e => e.zip_code)
                .IsUnicode(false);



            modelBuilder.Entity<MemberMedsAllergies>()
                .Property(e => e.descr)
                .IsUnicode(false);



            modelBuilder.Entity<rQualityCareNotes>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rQualityCareNotes>()
                .Property(e => e.evaluation_text)
                .IsUnicode(false);



            modelBuilder.Entity<rReferralMissingReferTo>()
                .Property(e => e.referral_number)
                .IsUnicode(false);



            modelBuilder.Entity<MemberVitals>()
                            .Property(e => e.height_in_inches)
                            .HasPrecision(9, 2);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.weight_in_pounds)
                .HasPrecision(9, 2);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.temperature_in_fahrenheit)
                .HasPrecision(9, 2);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.bmi)
                .HasPrecision(9, 2);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.body_fat_percent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.waist_girth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.hip_girth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.waist_hip_ratio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.bp_method)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.sp02)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.heart_rate)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.richmond_rass_scale)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.ramsay_scale)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.neuro_scale)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.visual_scale)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.cof)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.height_type)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.weight_type)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.temperature_type)
                .IsUnicode(false);

            modelBuilder.Entity<MemberVitals>()
                .Property(e => e.note)
                .IsUnicode(false);


            modelBuilder.Entity<MemberLab>()
                            .Property(e => e.reading)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberLab>()
                .Property(e => e.lab_note)
                .IsUnicode(false);


            modelBuilder.Entity<MemberStratLevel>()
                           .Property(e => e.override_reason)
                           .IsUnicode(false);



            modelBuilder.Entity<MemberTask>()
                            .Property(e => e.task_note)
                            .IsUnicode(false);



            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.mco_id_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.mco_region_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.recipient_id_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.primary_medical_provider_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.pmp_group_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.capitation_category)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.medicaid_eligibility)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.case_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.case_worker_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.location_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.delivery_system)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.auto_assigned_indicator)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.benefit_package_indicator)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.mrn)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.alternate_id)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.network)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.enterprise)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.plan_id)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.plan_description)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.cm_program)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.group_id)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.group_location)
                .IsUnicode(false);

            modelBuilder.Entity<MemberHealthPlanReference>()
                .Property(e => e.id_number)
                .IsUnicode(false);



            modelBuilder.Entity<MemberCustomerServiceAlert>()
                           .Property(e => e.alert_text)
                           .IsUnicode(false);



            modelBuilder.Entity<CaseOwner>()
                            .Property(e => e.case_type_code)
                            .IsUnicode(false);



            modelBuilder.Entity<ClinicalReviewBills>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<ClinicalReviewBills>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<ClinicalReviewBills>()
                .Property(e => e.type_of_review)
                .IsUnicode(false);

            modelBuilder.Entity<ClinicalReviewBills>()
                .Property(e => e.other_type_of_review)
                .IsUnicode(false);

            modelBuilder.Entity<ClinicalReviewBills>()
                .Property(e => e.review_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ClinicalReviewBills>()
                .Property(e => e.other_review_cost)
                .HasPrecision(19, 4);




            modelBuilder.Entity<EpisodesOfCare>()
                           .Property(e => e.hospital_treatment_dates)
                           .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.er_treatment_dates)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.urgent_care_treatement_dates)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.pcp_treatment_dates)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.smoking_cessation_methods)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.smoking_cessation_dates)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.urine_micro_results)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.cholesterol_results)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.ldl_results)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.hdl_results)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.triglyceride_results)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.blood_pressure_results)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.flu_vaccine_results)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.pneumonia_vaccine_results)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.a1c_test_results)
                .IsUnicode(false);



            modelBuilder.Entity<LcmReportNeededForBillingTask>()
                           .Property(e => e.member_name)
                           .IsUnicode(false);

            modelBuilder.Entity<LcmReportNeededForBillingTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);



            modelBuilder.Entity<LcmReportQaNotesTaskReference>()
                           .Property(e => e.task_note)
                           .IsUnicode(false);


            modelBuilder.Entity<LcmReportQaTasks>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<LcmReportQaTasks>()
                .Property(e => e.qa_notes)
                .IsUnicode(false);


            modelBuilder.Entity<LcnReportFax>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<LcnReportFax>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);

            modelBuilder.Entity<LcnReportFax>()
                .Property(e => e.tpa_fax_number_used)
                .IsUnicode(false);

            modelBuilder.Entity<LcnReportFax>()
                .Property(e => e.reinsurer_fax_number_used)
                .IsUnicode(false);



            modelBuilder.Entity<MdReviewDetermination>()
                            .Property(e => e.task_note)
                            .IsUnicode(false);

            modelBuilder.Entity<MdReviewDetermination>()
                .Property(e => e.md_review_determination_note)
                .IsUnicode(false);

            modelBuilder.Entity<MdReviewDetermination>()
                .Property(e => e.referral_number)
                .IsUnicode(false);



            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                            .Property(e => e.medication_name)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.prescribed_by)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.quantity)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.ndc)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.drug_type)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.amount_billed)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.relationship_code)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.group_number)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.dispense_as_written)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.member_location)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.unit_dose_indicator)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.drug_supply_days)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.ingredient_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.co_pay_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.postage_amount_claimed)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.other_payor_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.dispensing_fee_submitted)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.drug_class)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsPharmacyFeed>()
                .Property(e => e.wishard_claim_id)
                .IsUnicode(false);



            modelBuilder.Entity<MemberNotesSummary>()
                            .Property(e => e.evaluation_text)
                            .IsUnicode(false);


            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.bill_type)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.bill_total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.check_number)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.payment_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.credit_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.balance_outstanding)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsReceivablePayments>()
                .Property(e => e.debit_amount)
                .HasPrecision(19, 4);



            modelBuilder.Entity<BillingUpdateHistoryLog>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<BillingUpdateHistoryLog>()
                .Property(e => e.original_billing_code)
                .IsUnicode(false);

            modelBuilder.Entity<BillingUpdateHistoryLog>()
                .Property(e => e.original_billing_description)
                .IsUnicode(false);

            modelBuilder.Entity<BillingUpdateHistoryLog>()
                .Property(e => e.original_entered_by_user)
                .IsUnicode(false);

            modelBuilder.Entity<BillingUpdateHistoryLog>()
                .Property(e => e.update_billing_code)
                .IsUnicode(false);

            modelBuilder.Entity<BillingUpdateHistoryLog>()
                .Property(e => e.update_billing_description)
                .IsUnicode(false);

            modelBuilder.Entity<BillingUpdateHistoryLog>()
                .Property(e => e.update_reason)
                .IsUnicode(false);

            modelBuilder.Entity<BillingUpdateHistoryLog>()
                .Property(e => e.update_screen)
                .IsUnicode(false);


            modelBuilder.Entity<CarePlanNotesAttachment>()
                           .Property(e => e.file_identifier)
                           .IsUnicode(false);


            modelBuilder.Entity<ClinicalRequestHistory>()
                            .Property(e => e.sent_to)
                            .IsUnicode(false);

            modelBuilder.Entity<ClinicalRequestHistory>()
                .Property(e => e.sent_to_name)
                .IsUnicode(false);

            modelBuilder.Entity<ClinicalRequestHistory>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);



            modelBuilder.Entity<ClinicalRequestProviders>()
                           .Property(e => e.name)
                           .IsUnicode(false);

            modelBuilder.Entity<ClinicalRequestProviders>()
                .Property(e => e.fax_number)
                .IsUnicode(false);

            modelBuilder.Entity<ClinicalRequestProviders>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<ClinicalRequestProviders>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<ClinicalRequestProviders>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<ClinicalRequestProviders>()
                .Property(e => e.zip)
                .IsUnicode(false);


            modelBuilder.Entity<CmMemberNote>()
                            .Property(e => e.evaluation_text)
                            .IsUnicode(false);



            modelBuilder.Entity<CodeRemovalItems>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<CodeRemovalItems>()
                .Property(e => e.removal_type)
                .IsUnicode(false);

            modelBuilder.Entity<CodeRemovalItems>()
                .Property(e => e.primary_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<CodeRemovalItems>()
                .Property(e => e.secondary_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<CodeRemovalItems>()
                .Property(e => e.other_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<CodeRemovalItems>()
                .Property(e => e.procedure)
                .IsUnicode(false);

            modelBuilder.Entity<CodeRemovalItems>()
                .Property(e => e.hcpcs_code)
                .IsUnicode(false);

            modelBuilder.Entity<CodeRemovalItems>()
                .Property(e => e.diagnosis_or_procedure_code)
                .IsUnicode(false);

            modelBuilder.Entity<CodeRemovalItems>()
                .Property(e => e.cpt_code)
                .IsUnicode(false);



            modelBuilder.Entity<DiseaseManagementNotesAttachment>()
                            .Property(e => e.file_identifier)
                            .IsUnicode(false);


            modelBuilder.Entity<DmMemberSavings>()
                            .Property(e => e.comment)
                            .IsUnicode(false);

            modelBuilder.Entity<DmMemberSavings>()
                .Property(e => e.cost_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DmMemberSavings>()
                .Property(e => e.savings_amount)
                .HasPrecision(19, 4);



            modelBuilder.Entity<LcmReportQaNotes>()
                           .Property(e => e.qa_notes)
                           .IsUnicode(false);


            modelBuilder.Entity<LetterReportFax>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<LetterReportFax>()
                .Property(e => e.letter_report_name)
                .IsUnicode(false);

            modelBuilder.Entity<LetterReportFax>()
                .Property(e => e.tpa_fax_number_used)
                .IsUnicode(false);

            modelBuilder.Entity<LetterReportFax>()
                .Property(e => e.reinsurer_fax_number_used)
                .IsUnicode(false);

            modelBuilder.Entity<LetterReportFax>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);


            modelBuilder.Entity<MdReviewFollowup>()
                            .Property(e => e.task_note)
                            .IsUnicode(false);

            modelBuilder.Entity<MdReviewFollowup>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MdReviewFollowup>()
                .Property(e => e.md_review_appeal_note)
                .IsUnicode(false);


            modelBuilder.Entity<MemberCareCoordinationCall>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberCareCoordinationCall>()
                .Property(e => e.call_note)
                .IsUnicode(false);


            modelBuilder.Entity<MemberCareCoordinationCallSavings>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberCareCoordinationCallSavings>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberCareCoordinationCallSavings>()
                .Property(e => e.description)
                .IsUnicode(false);


            modelBuilder.Entity<MemberClaimsDiagnosis>()
                            .Property(e => e.diagnosis_or_procedure_code)
                            .IsUnicode(false);


            modelBuilder.Entity<MemberConditionAcuity>()
                           .Property(e => e.alternate_id)
                           .IsUnicode(false);

            modelBuilder.Entity<MemberConditionAcuity>()
                .Property(e => e.override_reason)
                .IsUnicode(false);


            modelBuilder.Entity<MemberLcmFollowupNotes>()
                            .Property(e => e.current_treatments)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowupNotes>()
                .Property(e => e.previous_treatments)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowupNotes>()
                .Property(e => e.future_treatments)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowupNotes>()
                .Property(e => e.psycho_social_summary)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowupNotes>()
                .Property(e => e.nurse_summary)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowupNotes>()
                .Property(e => e.physician_prognosis)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLcmFollowupNotes>()
                .Property(e => e.newly_identified_cm)
                .IsUnicode(false);


            modelBuilder.Entity<MemberMeds>()
                           .Property(e => e.drug_class)
                           .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.medication_sequence)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.medication_name)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.prescribed_by)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.strength)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.form)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.route)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.quantity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.source_of_information)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.nurses_note)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMeds>()
                .Property(e => e.NDC)
                .IsUnicode(false);


            modelBuilder.Entity<MemberMedsHighDollarTask>()
                            .Property(e => e.medication_sequence)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHighDollarTask>()
                .Property(e => e.drug_name)
                .IsUnicode(false);


            modelBuilder.Entity<MemberMedsHistory>()
                           .Property(e => e.drug_class)
                           .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.medication_sequence)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.medication_name)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.prescribed_by)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.strength)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.form)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.route)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.quantity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.source_of_information)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.nurses_note)
                .IsUnicode(false);

            modelBuilder.Entity<MemberMedsHistory>()
                .Property(e => e.NDC)
                .IsUnicode(false);


            modelBuilder.Entity<MemberPictures>()
                           .Property(e => e.image_path)
                           .IsUnicode(false);


            modelBuilder.Entity<MemberProfilePicture>()
                            .Property(e => e.picture_file_name)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberProfilePicture>()
                .Property(e => e.content_type)
                .IsUnicode(false);


            modelBuilder.Entity<MemberRenalTask>()
                          .Property(e => e.referral_number)
                          .IsUnicode(false);

            modelBuilder.Entity<MemberRenalTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);


            modelBuilder.Entity<MemberReturnedLetters>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberReturnedLetters>()
                .Property(e => e.note_type)
                .IsUnicode(false);


            modelBuilder.Entity<MemberSignatureFile>()
                            .Property(e => e.file_name)
                            .IsUnicode(false);

            modelBuilder.Entity<MemberSignatureFile>()
                .Property(e => e.content_type)
                .IsUnicode(false);


            modelBuilder.Entity<MonthlyLcmManagementQa>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);


            modelBuilder.Entity<MonthlyUtilizationManagement>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);


            modelBuilder.Entity<rAdmissionCareplanCount>()
                           .Property(e => e.admission_number)
                           .IsUnicode(false);


            modelBuilder.Entity<rAuthorizationUpdates>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<rAuthorizationUpdates>()
                .Property(e => e.authorization_type)
                .IsUnicode(false);


            modelBuilder.Entity<rDentalVisits>()
                            .Property(e => e.oral_health_provider)
                            .IsUnicode(false);

            modelBuilder.Entity<rDentalVisits>()
                .Property(e => e.provider_address)
                .IsUnicode(false);

            modelBuilder.Entity<rDentalVisits>()
                .Property(e => e.provider_phone)
                .IsUnicode(false);

            modelBuilder.Entity<rDentalVisits>()
                .Property(e => e.oral_note)
                .IsUnicode(false);


            modelBuilder.Entity<rDepartmentBedVacancy>()
                            .Property(e => e.admission_number)
                            .IsUnicode(false);

            modelBuilder.Entity<rDepartmentBedVacancy>()
                .Property(e => e.room_number)
                .IsUnicode(false);


            modelBuilder.Entity<rInboundFaxHistory>()
                            .Property(e => e.fax_remoteid)
                            .IsUnicode(false);

            modelBuilder.Entity<rInboundFaxHistory>()
                .Property(e => e.fax_uniqueid)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFaxHistory>()
                .Property(e => e.fax_bodyfilename)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFaxHistory>()
                .Property(e => e.queue_dummy)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFaxHistory>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFaxHistory>()
                .Property(e => e.error_description)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFaxHistory>()
                .Property(e => e.email_filename)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundFaxHistory>()
                .Property(e => e.inbound_member_name)
                .IsUnicode(false);


            modelBuilder.Entity<rInboundFaxReferralRemoval>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);


            modelBuilder.Entity<rInboundVoicemail>()
                            .Property(e => e.vm_filename)
                            .IsUnicode(false);

            modelBuilder.Entity<rInboundVoicemail>()
                .Property(e => e.vm_remoteid)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundVoicemail>()
                .Property(e => e.queue_dummy)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundVoicemail>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundVoicemail>()
                .Property(e => e.inbound_member_name)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundVoicemail>()
                .Property(e => e.vm_subject)
                .IsUnicode(false);

            modelBuilder.Entity<rInboundVoicemail>()
                .Property(e => e.content_type)
                .IsUnicode(false);


            modelBuilder.Entity<rMemberReferralMedicine>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralMedicine>()
                .Property(e => e.medicine_code)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralMedicine>()
                .Property(e => e.modifier1)
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralMedicine>()
                .Property(e => e.estimated_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<rMemberReferralQoc>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralQoc>()
                .Property(e => e.inpat_outpat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralQoc>()
                .Property(e => e.qoc_notes)
                .IsUnicode(false);


            modelBuilder.Entity<rMemberReferralUpdatesWorkflow>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<rMemberReferralUpdatesWorkflow>()
                .Property(e => e.description)
                .IsUnicode(false);


            modelBuilder.Entity<rUtilizationDischargeNote>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<rUtilizationDischargeNote>()
                .Property(e => e.discharge_note)
                .IsUnicode(false);


            modelBuilder.Entity<SuspendCaseToTaskReference>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<SuspendCaseToTaskReference>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<SuspendCaseToTaskReference>()
                .Property(e => e.comment)
                .IsUnicode(false);


            modelBuilder.Entity<SuspendedNotes>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<SuspendedNotes>()
                .Property(e => e.note_type)
                .IsUnicode(false);

            modelBuilder.Entity<SuspendedNotes>()
                .Property(e => e.note_text)
                .IsUnicode(false);


            modelBuilder.Entity<SuspendedNotesOverride>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<SuspendedNotesOverride>()
                .Property(e => e.note_type)
                .IsUnicode(false);

            modelBuilder.Entity<SuspendedNotesOverride>()
                .Property(e => e.note_text)
                .IsUnicode(false);


            modelBuilder.Entity<TelephoneNotesAttachment>()
                            .Property(e => e.file_identifier)
                            .IsUnicode(false);


            modelBuilder.Entity<TransitionalCareReference>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.primary_care_giver)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.contact_name)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.contact_phone)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.contact_email)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.rn_requency)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.pt_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.st_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.ot_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.rt_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.other_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<TransitionalCareReference>()
                .Property(e => e.note)
                .IsUnicode(false);


            modelBuilder.Entity<UmAssignedToTask>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<UmAssignedToTask>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<UmAssignedToTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);


            modelBuilder.Entity<UmAssignedToTaskTouchedReference>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);


            modelBuilder.Entity<UmAutoApprovedDiagnosisTask>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<UmAutoApprovedDiagnosisTask>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<UmAutoApprovedDiagnosisTask>()
                .Property(e => e.diagnosis_code)
                .IsUnicode(false);

            modelBuilder.Entity<UmAutoApprovedDiagnosisTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);


            modelBuilder.Entity<UtilizationReviewNoteTask>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<UtilizationReviewNoteTask>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<UtilizationReviewNoteTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);


            modelBuilder.Entity<WebClientNoteTask>()
                            .Property(e => e.task_note)
                            .IsUnicode(false);


            modelBuilder.Entity<WebOnlinePrecertTask>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<WebOnlinePrecertTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);



            modelBuilder.Entity<MergedrMemberReferralCpts>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralCpts>()
                .Property(e => e.cpt_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralCpts>()
                .Property(e => e.modifier1)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralCpts>()
                .Property(e => e.estimated_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<MergedrMemberReferralDiags>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralDiags>()
                .Property(e => e.diagnosis_or_procedure_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralDiags>()
                .Property(e => e.estimated_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<MergedrMemberReferralHcpcs>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralHcpcs>()
                .Property(e => e.hcpcs_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralHcpcs>()
                .Property(e => e.modifier1)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralHcpcs>()
                .Property(e => e.estimated_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<MergedrMemberReferralInterqualReference>()
                .Property(e => e.review_cid)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralInterqualReference>()
                .Property(e => e.referral_number)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrMemberReferralLetters>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralLetters>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);


            modelBuilder.Entity<MergerMemberReferral>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergerMemberReferral>()
                .Property(e => e.auth_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergerMemberReferral>()
                .Property(e => e.claim_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergerMemberReferral>()
                .Property(e => e.po_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergerMemberReferral>()
                .Property(e => e.revenue_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergerMemberReferral>()
                .Property(e => e.discharge_plan_required)
                .IsUnicode(false);

            modelBuilder.Entity<MergerMemberReferral>()
                .Property(e => e.auth_provider_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergerMemberReferral>()
                .Property(e => e.forced_authorization_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergerMemberReferral>()
                .Property(e => e.std_office_location)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrReferralMissingReferTo>()
                .Property(e => e.referral_number)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrMemberReferralWorkflow>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralWorkflow>()
                .Property(e => e.referral_workflow_description)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberAddressDmAlternate>()
                            .Property(e => e.address_line1)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddressDmAlternate>()
                .Property(e => e.address_line2)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddressDmAlternate>()
                .Property(e => e.state_abbrev)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddressDmAlternate>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddressDmAlternate>()
                .Property(e => e.zip_code)
                .IsUnicode(false);



            modelBuilder.Entity<MergedMemberAddress>()
                            .Property(e => e.address_line1)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddress>()
                .Property(e => e.address_line2)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddress>()
                .Property(e => e.apartment_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddress>()
                .Property(e => e.state_abbrev)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddress>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddress>()
                .Property(e => e.zip_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberAddress>()
                .Property(e => e.address_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberCareCoordinationCall>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMemberCareCoordinationCall>()
                .Property(e => e.call_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberCareCoordinationCallSavings>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberCareCoordinationCallSavings>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberCareCoordinationCallSavings>()
                .Property(e => e.description)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberClaimsDiagnosis>()
                           .Property(e => e.diagnosis_or_procedure_code)
                           .IsUnicode(false);


            modelBuilder.Entity<MergedMemberConditionAcuity>()
                .Property(e => e.alternate_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberConditionAcuity>()
                .Property(e => e.override_reason)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberCustomerServiceAlert>()
                .Property(e => e.alert_text)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrInboundFax>()
                            .Property(e => e.fax_remoteid)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundFax>()
                .Property(e => e.fax_uniqueid)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundFax>()
                .Property(e => e.fax_bodyfilename)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundFax>()
                .Property(e => e.queue_dummy)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundFax>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundFax>()
                .Property(e => e.error_description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundFax>()
                .Property(e => e.email_filename)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundFax>()
                .Property(e => e.inbound_member_name)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                            .Property(e => e.mco_id_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.mco_region_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.recipient_id_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.primary_medical_provider_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.pmp_group_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.capitation_category)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.medicaid_eligibility)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.case_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.case_worker_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.location_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.delivery_system)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.auto_assigned_indicator)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.benefit_package_indicator)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.mrn)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.alternate_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.network)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.enterprise)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.plan_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.plan_description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.cm_program)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.group_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.group_location)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberHealthPlanReference>()
                .Property(e => e.id_number)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberLab>()
                .Property(e => e.reading)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLab>()
                .Property(e => e.lab_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberLcmFollowupNotes>()
                            .Property(e => e.current_treatments)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmFollowupNotes>()
                .Property(e => e.previous_treatments)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmFollowupNotes>()
                .Property(e => e.future_treatments)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmFollowupNotes>()
                .Property(e => e.psycho_social_summary)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmFollowupNotes>()
                .Property(e => e.nurse_summary)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmFollowupNotes>()
                .Property(e => e.physician_prognosis)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmFollowupNotes>()
                .Property(e => e.newly_identified_cm)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberMdReviewReference>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMdReviewReference>()
                .Property(e => e.module_review_submitted_from)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberMedsAllergies>()
                        .Property(e => e.descr)
                        .IsUnicode(false);


            modelBuilder.Entity<MergedMemberMeds>()
                           .Property(e => e.drug_class)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.medication_sequence)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.medication_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.prescribed_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.strength)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.form)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.route)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.quantity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.source_of_information)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.nurses_note)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMeds>()
                .Property(e => e.NDC)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberMedsHighDollarTask>()
                .Property(e => e.medication_sequence)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHighDollarTask>()
                .Property(e => e.drug_name)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberMedsHistory>()
                            .Property(e => e.drug_class)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.medication_sequence)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.medication_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.prescribed_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.strength)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.form)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.route)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.quantity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.source_of_information)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.nurses_note)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsHistory>()
                .Property(e => e.NDC)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                           .Property(e => e.medication_name)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.prescribed_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.quantity)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.ndc)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.drug_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.amount_billed)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.relationship_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.group_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.dispense_as_written)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.member_location)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.unit_dose_indicator)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.drug_supply_days)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.ingredient_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.co_pay_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.postage_amount_claimed)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.other_payor_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.dispensing_fee_submitted)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.drug_class)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberMedsPharmacyFeed>()
                .Property(e => e.wishard_claim_id)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberNotesAttachment>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberNotes>()
                .Property(e => e.evaluation_text)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberNotesSummary>()
                .Property(e => e.evaluation_text)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberPhone>()
                           .Property(e => e.phone_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedMemberPhone>()
                .Property(e => e.phone_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberPictures>()
                .Property(e => e.image_path)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberProfilePicture>()
                .Property(e => e.picture_file_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberProfilePicture>()
                .Property(e => e.content_type)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrQualityCareNotes>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrQualityCareNotes>()
                .Property(e => e.evaluation_text)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrMemberReferralMedicine>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralMedicine>()
                .Property(e => e.medicine_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralMedicine>()
                .Property(e => e.modifier1)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralMedicine>()
                .Property(e => e.estimated_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<MergedrMemberReferralQoc>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralQoc>()
                .Property(e => e.inpat_outpat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralQoc>()
                .Property(e => e.qoc_notes)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrMemberReferralUpdatesWorkflow>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrMemberReferralUpdatesWorkflow>()
                .Property(e => e.description)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberRenalTask>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberRenalTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberReturnedLetters>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberReturnedLetters>()
                .Property(e => e.note_type)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberSignatureFiles>()
                            .Property(e => e.file_name)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMemberSignatureFiles>()
                .Property(e => e.content_type)
                .IsUnicode(false);



            modelBuilder.Entity<MergedMemberStratLevel>()
                            .Property(e => e.override_reason)
                            .IsUnicode(false);



            modelBuilder.Entity<MergedMemberTask>()
                            .Property(e => e.task_note)
                            .IsUnicode(false);


            modelBuilder.Entity<MergedMemberVitals>()
                           .Property(e => e.height_in_inches)
                           .HasPrecision(9, 2);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.weight_in_pounds)
                .HasPrecision(9, 2);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.temperature_in_fahrenheit)
                .HasPrecision(9, 2);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.bmi)
                .HasPrecision(9, 2);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.body_fat_percent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.waist_girth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.hip_girth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.waist_hip_ratio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.bp_method)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.sp02)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.heart_rate)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.richmond_rass_scale)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.ramsay_scale)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.neuro_scale)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.visual_scale)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.cof)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.height_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.weight_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.temperature_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberVitals>()
                .Property(e => e.note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrUtilizationDaysNotes>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationDaysNotes>()
                .Property(e => e.referral_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationDaysNotes>()
                .Property(e => e.evaluation_text)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrUtilizationDays>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationDays>()
                .Property(e => e.referral_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationDays>()
                .Property(e => e.visits_period_requested)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationDays>()
                .Property(e => e.visits_period_authorized)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationDays>()
                .Property(e => e.ICM_Units)
                .IsUnicode(false);



            modelBuilder.Entity<MergedrUtilizationDischargeNote>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationDischargeNote>()
                .Property(e => e.discharge_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrUtilizationReviews>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);


            modelBuilder.Entity<MergedrUtilizationSavings>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.referral_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.item_description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.quantity)
                .HasPrecision(12, 2);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.cost)
                .HasPrecision(12, 2);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.negotiated)
                .HasPrecision(12, 2);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.savings)
                .HasPrecision(12, 2);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.dollar_or_percent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.cpt_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrUtilizationSavings>()
                .Property(e => e.notes)
                .IsUnicode(false);



            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.bill_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.bill_total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.check_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.payment_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.credit_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.balance_outstanding)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<MergedAccountsReceivablePayments>()
                .Property(e => e.debit_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<MergedrAdmissionCareplanCount>()
                        .Property(e => e.admission_number)
                        .IsUnicode(false);



            modelBuilder.Entity<MergedrAuthorizationUpdates>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedrAuthorizationUpdates>()
                .Property(e => e.authorization_type)
                .IsUnicode(false);


            modelBuilder.Entity<MergedBillingUpdateHistoryLog>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedBillingUpdateHistoryLog>()
                .Property(e => e.original_billing_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingUpdateHistoryLog>()
                .Property(e => e.original_billing_description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingUpdateHistoryLog>()
                .Property(e => e.original_entered_by_user)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingUpdateHistoryLog>()
                .Property(e => e.update_billing_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingUpdateHistoryLog>()
                .Property(e => e.update_billing_description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingUpdateHistoryLog>()
                .Property(e => e.update_reason)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingUpdateHistoryLog>()
                .Property(e => e.update_screen)
                .IsUnicode(false);



            modelBuilder.Entity<MergedCarePlanNotesAttachment>()
                           .Property(e => e.file_identifier)
                           .IsUnicode(false);


            modelBuilder.Entity<MergedCaseOwner>()
                .Property(e => e.case_type_code)
                .IsUnicode(false);


            modelBuilder.Entity<MergedClinicalRequestHistory>()
                            .Property(e => e.sent_to)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalRequestHistory>()
                .Property(e => e.sent_to_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalRequestHistory>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);


            modelBuilder.Entity<MergedClinicalRequestProviders>()
                        .Property(e => e.name)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalRequestProviders>()
                .Property(e => e.fax_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalRequestProviders>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalRequestProviders>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalRequestProviders>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalRequestProviders>()
                .Property(e => e.zip)
                .IsUnicode(false);


            modelBuilder.Entity<MergedCmMemberNote>()
                        .Property(e => e.evaluation_text)
                        .IsUnicode(false);


            modelBuilder.Entity<MergedClinicalReviewBills>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalReviewBills>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalReviewBills>()
                .Property(e => e.type_of_review)
                .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalReviewBills>()
                .Property(e => e.other_type_of_review)
                .IsUnicode(false);

            modelBuilder.Entity<MergedClinicalReviewBills>()
                .Property(e => e.review_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedClinicalReviewBills>()
                .Property(e => e.other_review_cost)
                .HasPrecision(19, 4);



            modelBuilder.Entity<MergedCodeRemovalItems>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedCodeRemovalItems>()
                .Property(e => e.removal_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCodeRemovalItems>()
                .Property(e => e.primary_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCodeRemovalItems>()
                .Property(e => e.secondary_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCodeRemovalItems>()
                .Property(e => e.other_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCodeRemovalItems>()
                .Property(e => e.procedure)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCodeRemovalItems>()
                .Property(e => e.hcpcs_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCodeRemovalItems>()
                .Property(e => e.diagnosis_or_procedure_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCodeRemovalItems>()
                .Property(e => e.cpt_code)
                .IsUnicode(false);



            modelBuilder.Entity<MergedrDentalVisits>()
                        .Property(e => e.oral_health_provider)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedrDentalVisits>()
                .Property(e => e.provider_address)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrDentalVisits>()
                .Property(e => e.provider_phone)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrDentalVisits>()
                .Property(e => e.oral_note)
                .IsUnicode(false);



            modelBuilder.Entity<MergedrDepartmentBedVacancy>()
                        .Property(e => e.admission_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedrDepartmentBedVacancy>()
                .Property(e => e.room_number)
                .IsUnicode(false);


            modelBuilder.Entity<MergedDiseaseManagementNotesAttachment>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);


            modelBuilder.Entity<MergedDmMemberSavings>()
                            .Property(e => e.comment)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedDmMemberSavings>()
                .Property(e => e.cost_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedDmMemberSavings>()
                .Property(e => e.savings_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<MergedEmailsOutbound>()
                           .Property(e => e.email_to)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.email_subject)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.email_address)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.email_message)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.zip_file_password)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.zip_file_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.email_cc_list)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEmailsOutbound>()
                .Property(e => e.notice_type)
                .IsUnicode(false);


            modelBuilder.Entity<MergedEpisodesOfCare>()
                            .Property(e => e.hospital_treatment_dates)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.er_treatment_dates)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.urgent_care_treatement_dates)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.pcp_treatment_dates)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.smoking_cessation_methods)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.smoking_cessation_dates)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.urine_micro_results)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.cholesterol_results)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.ldl_results)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.hdl_results)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.triglyceride_results)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.blood_pressure_results)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.flu_vaccine_results)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.pneumonia_vaccine_results)
                .IsUnicode(false);

            modelBuilder.Entity<MergedEpisodesOfCare>()
                .Property(e => e.a1c_test_results)
                .IsUnicode(false);




            modelBuilder.Entity<MergedrInboundFaxReferralRemoval>()
                .Property(e => e.referral_number)
                .IsUnicode(false);


            modelBuilder.Entity<MergedrInboundVoicemail>()
                        .Property(e => e.vm_filename)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundVoicemail>()
                .Property(e => e.vm_remoteid)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundVoicemail>()
                .Property(e => e.queue_dummy)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundVoicemail>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundVoicemail>()
                .Property(e => e.inbound_member_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundVoicemail>()
                .Property(e => e.vm_subject)
                .IsUnicode(false);

            modelBuilder.Entity<MergedrInboundVoicemail>()
                .Property(e => e.content_type)
                .IsUnicode(false);



            modelBuilder.Entity<MergedMemberLcmInitial>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.cancer_related)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.staging)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.staging_status)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.hospitalized)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.hospital_five_days)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.facility_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.report_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.primary_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.secondary_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.other_diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.procedure)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.auth_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmInitial>()
                .Property(e => e.reinsurer_name)
                .IsUnicode(false);



            modelBuilder.Entity<MergedMemberLcmActivity>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmActivity>()
                .Property(e => e.activity_report_note)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmActivity>()
                .Property(e => e.last_update_reason)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMemberLcmFollowupSavings>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedMemberLcmFollowupSavings>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMemberLcmFollowupSavings>()
                .Property(e => e.note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedLcmReportNeededForBillingTask>()
                        .Property(e => e.member_name)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedLcmReportNeededForBillingTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedLcmReportQaNotes>()
                            .Property(e => e.qa_notes)
                            .IsUnicode(false);


            modelBuilder.Entity<MergedLcmReportQaTasks>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmReportQaTasks>()
                .Property(e => e.qa_notes)
                .IsUnicode(false);


            modelBuilder.Entity<MergedLcmReportQaNotesTaskReference>()
                .Property(e => e.task_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedLcnReportFax>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcnReportFax>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcnReportFax>()
                .Property(e => e.tpa_fax_number_used)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcnReportFax>()
                .Property(e => e.reinsurer_fax_number_used)
                .IsUnicode(false);


            modelBuilder.Entity<MergedLetterReportFax>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedLetterReportFax>()
                .Property(e => e.letter_report_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLetterReportFax>()
                .Property(e => e.tpa_fax_number_used)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLetterReportFax>()
                .Property(e => e.reinsurer_fax_number_used)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLetterReportFax>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMdReviewDetermination>()
                .Property(e => e.task_note)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewDetermination>()
                .Property(e => e.md_review_determination_note)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewDetermination>()
                .Property(e => e.referral_number)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMdReviewFollowup>()
                .Property(e => e.task_note)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewFollowup>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewFollowup>()
                .Property(e => e.md_review_appeal_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMdReviewQuestion>()
                            .Property(e => e.task_note)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewQuestion>()
                .Property(e => e.md_question_note)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewQuestion>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewQuestion>()
                .Property(e => e.md_answer_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMdReviewRequest>()
                        .Property(e => e.task_note)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewRequest>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedMdReviewRequest>()
                .Property(e => e.md_review_appeal_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedMonthlyLcmManagementQa>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);


            modelBuilder.Entity<MergedMonthlyUtilizationManagement>()
                .Property(e => e.referral_number)
                .IsUnicode(false);


            modelBuilder.Entity<MergedSuspendCaseToTaskReference>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedSuspendCaseToTaskReference>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedSuspendCaseToTaskReference>()
                .Property(e => e.comment)
                .IsUnicode(false);


            modelBuilder.Entity<MergedSuspendedNotes>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedSuspendedNotes>()
                .Property(e => e.note_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedSuspendedNotes>()
                .Property(e => e.note_text)
                .IsUnicode(false);


            modelBuilder.Entity<MergedSuspendedNotesOverride>()
                           .Property(e => e.referral_number)
                           .IsUnicode(false);

            modelBuilder.Entity<MergedSuspendedNotesOverride>()
                .Property(e => e.note_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedSuspendedNotesOverride>()
                .Property(e => e.note_text)
                .IsUnicode(false);


            modelBuilder.Entity<MergedTelephoneNotesAttachment>()
                .Property(e => e.file_identifier)
                .IsUnicode(false);


            modelBuilder.Entity<MergedTransitionalCareReference>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.primary_care_giver)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.contact_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.contact_phone)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.contact_email)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.rn_requency)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.pt_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.st_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.ot_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.rt_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.other_frequency)
                .IsUnicode(false);

            modelBuilder.Entity<MergedTransitionalCareReference>()
                .Property(e => e.note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedUmAssignedToTask>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedUmAssignedToTask>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedUmAssignedToTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);


            modelBuilder.Entity<MergedUmAssignedToTaskTouchedReference>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);


            modelBuilder.Entity<MergedUmAutoApprovedDiagnosisTask>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedUmAutoApprovedDiagnosisTask>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedUmAutoApprovedDiagnosisTask>()
                .Property(e => e.diagnosis_code)
                .IsUnicode(false);

            modelBuilder.Entity<MergedUmAutoApprovedDiagnosisTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);



            modelBuilder.Entity<MergedUtilizationReviewNoteTask>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedUtilizationReviewNoteTask>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedUtilizationReviewNoteTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);



            modelBuilder.Entity<MergedWebClientNoteTask>()
                        .Property(e => e.task_note)
                        .IsUnicode(false);


            modelBuilder.Entity<MergedWebOnlinePrecertTask>()
                        .Property(e => e.referral_number)
                        .IsUnicode(false);

            modelBuilder.Entity<MergedWebOnlinePrecertTask>()
                .Property(e => e.task_note)
                .IsUnicode(false);

        }


    }
}