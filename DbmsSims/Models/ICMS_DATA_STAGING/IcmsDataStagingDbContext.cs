using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DbmsSims.Models.ICMS_DATA_STAGING
{
    public class IcmsDataStagingDbContext : DbContext
    {

        public IcmsDataStagingDbContext(): base(nameOrConnectionString:"Staging")
        {
        }


        public virtual DbSet<TpaGroupNames> DataStagingTpaGroupNames { get; set; }

        public virtual DbSet<TpaMedicalClaims> DataStagingTpaMedicalClaims { get; set; }

        public virtual DbSet<BillingBackup> DbmsBillingBackup { get; set; }
        public virtual DbSet<CrBillingWorktable> DbmsCrBillingWorktable { get; set; }
        public virtual DbSet<LcmBillingWorktable> DbmsLcmBillingWorktable { get; set; }
        public virtual DbSet<StdBillingWorktable> DbmsStdBillingWorktable { get; set; }
        public virtual DbSet<WcBillingWorktable> DbmsWcBillingWorktable { get; set; }


        public virtual DbSet<MergedBillingBackup> DbmsMergedBillingBackup { get; set; }
        public virtual DbSet<MergedCrBillingWorktable> DbmsMergedCrBillingWorktable { get; set; }
        public virtual DbSet<MergedLcmBillingWorktable> DbmsMergedLcmBillingWorktable { get; set; }
        public virtual DbSet<MergedStdBillingWorktable> DbmsMergedStdBillingWorktable { get; set; }
        public virtual DbSet<MergedWcBillingWorktable> DbmsMergedWcBillingWorktable { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TpaGroupNames>()
                .Property(e => e.GROUPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<TpaGroupNames>()
                .Property(e => e.GROUPNAME)
                .IsUnicode(false);

            modelBuilder.Entity<TpaGroupNames>()
                .Property(e => e.TPA_EMPLOYER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TpaGroupNames>()
                .Property(e => e.groupNum2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaGroupNames>()
                .Property(e => e.groupNum3)
                .IsUnicode(false);



            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.GROUPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.MEM_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.MEMBERID)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.REL_CD)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.EMPLOYEE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.SUB_ADD1)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.SUB_ADD2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.SUB_ADD3)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.SUB_ZIP)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.SUB_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.DIAG_1)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.DIAG_2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.DIAG_3)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.DX_DESC_1)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.DX_DESC_2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.DX_DESC_3)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.CHARGES)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.TOTAL_PAID)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.PLAN_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.PLAN_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.CPT_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.REVENUE_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.NET_PAID_AMOUNT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.PLACE_OF_SERVICE)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.PROVIDER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.PROVIDER_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.CLAIM_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.patient_id)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.hcpcs_code)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.claim_line_number)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.provider_tin)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.DIAG_4)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.DIAG_5)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.group_name)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.pos_name)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.pos_address1)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.pos_address2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.pos_city)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.pos_state)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.pos_zip)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.pos_phone)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.employee_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.claimant_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.claim_paid_amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.claimant_paid_amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.diag_desc_1)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.cpt_desc)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.SUB_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.SUB_STATE)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.cpt_code2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.cpt_code3)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.cpt_code4)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.cpt_code5)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.hcpcs_code2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.hcpcs_code3)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.medicare)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.patient_member_id)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.service_start_date)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.service_end_date)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.payee_name)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.provider_fed_tax_id)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.provider_sub_code)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.provider_reference_number)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.service_address1)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.service_address2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.service_city)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.service_state)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.service_zip)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.provider_specialty)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.patient_stay_category)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.service_description)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.type_of_service_code)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.discharge_status)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.drg)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.drg_amount)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.diagnosis_category)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.modifier_1)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.icd_procedure_1)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.icd_procedure_2)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.icd_procedure_3)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.drug_description)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.drug_identifier)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.drug_class)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.drug_category)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.days_supply)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.daw_code)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.drug_type)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.bi_member_id)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.provider_npi)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.employer_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.claimant_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<TpaMedicalClaims>()
                .Property(e => e.claimant_last_name)
                .IsUnicode(false);


            modelBuilder.Entity<BillingBackup>()
                            .Property(e => e.billing_type)
                            .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.backup_period_id)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.patient)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.memberid)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.dob)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.employer)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.tpa)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.case_manager)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.LCM_Invoice_Number)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.member_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.member_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.note_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.bill_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.um_billing_rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.ccm_billing_rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.care_mode)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.case_owner_created_by)
                .IsUnicode(false);

            modelBuilder.Entity<BillingBackup>()
                .Property(e => e.altered_bill_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<CrBillingWorktable>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.member_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.member_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.bill_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<CrBillingWorktable>()
                .Property(e => e.comments)
                .IsUnicode(false);



            modelBuilder.Entity<LcmBillingWorktable>()
                            .Property(e => e.patient)
                            .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.memberid)
                .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.dob)
                .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.employer)
                .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.tpa)
                .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.case_manager)
                .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.LCM_Invoice_Number)
                .IsUnicode(false);

            modelBuilder.Entity<LcmBillingWorktable>()
                .Property(e => e.referral_number)
                .IsUnicode(false);


            modelBuilder.Entity<StdBillingWorktable>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.member_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.member_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.note_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.care_mode)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.case_owner_created_by)
                .IsUnicode(false);

            modelBuilder.Entity<StdBillingWorktable>()
                .Property(e => e.std_office_location)
                .IsUnicode(false);


            modelBuilder.Entity<WcBillingWorktable>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.member_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.member_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.note_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<WcBillingWorktable>()
                .Property(e => e.comments)
                .IsUnicode(false);


            modelBuilder.Entity<MergedBillingBackup>()
                            .Property(e => e.billing_type)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.backup_period_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.patient)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.memberid)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.dob)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.employer)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.tpa)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.case_manager)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.LCM_Invoice_Number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.referral_number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.member_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.member_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.note_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.bill_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.um_billing_rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.ccm_billing_rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.care_mode)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.case_owner_created_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedBillingBackup>()
                .Property(e => e.altered_bill_amount)
                .HasPrecision(19, 4);


            modelBuilder.Entity<MergedCrBillingWorktable>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.member_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.member_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.bill_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedCrBillingWorktable>()
                .Property(e => e.comments)
                .IsUnicode(false);



            modelBuilder.Entity<MergedLcmBillingWorktable>()
                            .Property(e => e.patient)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.memberid)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.dob)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.employer)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.tpa)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.case_manager)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.LCM_Invoice_Number)
                .IsUnicode(false);

            modelBuilder.Entity<MergedLcmBillingWorktable>()
                .Property(e => e.referral_number)
                .IsUnicode(false);


            modelBuilder.Entity<MergedStdBillingWorktable>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.member_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.member_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.note_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.care_mode)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.case_owner_created_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedStdBillingWorktable>()
                .Property(e => e.std_office_location)
                .IsUnicode(false);



            modelBuilder.Entity<MergedWcBillingWorktable>()
                            .Property(e => e.referral_number)
                            .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.member_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.member_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.member_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.member_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.employer_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.tpa_name)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.referral_type)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.note_entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<MergedWcBillingWorktable>()
                .Property(e => e.comments)
                .IsUnicode(false);

        }

    }
}