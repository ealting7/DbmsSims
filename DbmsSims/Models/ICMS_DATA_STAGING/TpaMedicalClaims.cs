namespace DbmsSims.Models.ICMS_DATA_STAGING
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TPA_MEDICAL_CLAIMS")]
    public partial class TpaMedicalClaims
    {
        public int? TPA_ID { get; set; }

        [StringLength(25)]
        public string GROUPNUM { get; set; }

        [StringLength(50)]
        public string MEM_NAME { get; set; }

        [StringLength(55)]
        public string MEMBERID { get; set; }

        [StringLength(1)]
        public string REL_CD { get; set; }

        public DateTime? BIRTH { get; set; }

        [StringLength(50)]
        public string EMPLOYEE_NAME { get; set; }

        [StringLength(50)]
        public string SUB_ADD1 { get; set; }

        [StringLength(50)]
        public string SUB_ADD2 { get; set; }

        [StringLength(50)]
        public string SUB_ADD3 { get; set; }

        [StringLength(15)]
        public string SUB_ZIP { get; set; }

        [StringLength(25)]
        public string SUB_PHONE { get; set; }

        [StringLength(10)]
        public string DIAG_1 { get; set; }

        [StringLength(10)]
        public string DIAG_2 { get; set; }

        [StringLength(10)]
        public string DIAG_3 { get; set; }

        public bool? MEMBER_IDENTIFIED { get; set; }

        [StringLength(255)]
        public string DX_DESC_1 { get; set; }

        [StringLength(255)]
        public string DX_DESC_2 { get; set; }

        [StringLength(255)]
        public string DX_DESC_3 { get; set; }

        [Column(TypeName = "money")]
        public decimal? CHARGES { get; set; }

        [Column(TypeName = "money")]
        public decimal? TOTAL_PAID { get; set; }

        public DateTime? PAID_DATE { get; set; }

        public DateTime? FILE_DATE { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        public string PLAN_NAME { get; set; }

        [StringLength(25)]
        public string PLAN_CODE { get; set; }

        [StringLength(10)]
        public string CPT_CODE { get; set; }

        [StringLength(50)]
        public string REVENUE_CODE { get; set; }

        [Column(TypeName = "money")]
        public decimal? NET_PAID_AMOUNT { get; set; }

        public DateTime? ADMIT_DOS { get; set; }

        public DateTime? DISCHARGE_DOS { get; set; }

        [StringLength(50)]
        public string PLACE_OF_SERVICE { get; set; }

        [StringLength(50)]
        public string PROVIDER_NAME { get; set; }

        [StringLength(25)]
        public string PROVIDER_PHONE { get; set; }

        [StringLength(25)]
        public string CLAIM_NUMBER { get; set; }

        public byte? needs_net_paid_amount_check { get; set; }

        [StringLength(50)]
        public string patient_id { get; set; }

        [StringLength(10)]
        public string hcpcs_code { get; set; }

        [StringLength(25)]
        public string claim_line_number { get; set; }

        [StringLength(50)]
        public string last_name { get; set; }

        [StringLength(50)]
        public string first_name { get; set; }

        public DateTime? service_date { get; set; }

        public DateTime? check_date { get; set; }

        public DateTime? hospital_in_date { get; set; }

        public DateTime? hospital_out_date { get; set; }

        [Key]
        public int tpa_medical_claims_id { get; set; }

        public DateTime? creation_date { get; set; }

        public DateTime? last_update_date { get; set; }

        public Guid? icms_member_id { get; set; }

        [StringLength(25)]
        public string provider_tin { get; set; }

        [StringLength(10)]
        public string DIAG_4 { get; set; }

        [StringLength(10)]
        public string DIAG_5 { get; set; }

        [StringLength(100)]
        public string group_name { get; set; }

        [StringLength(50)]
        public string pos_name { get; set; }

        [StringLength(50)]
        public string pos_address1 { get; set; }

        [StringLength(50)]
        public string pos_address2 { get; set; }

        [StringLength(32)]
        public string pos_city { get; set; }

        [StringLength(2)]
        public string pos_state { get; set; }

        [StringLength(10)]
        public string pos_zip { get; set; }

        [StringLength(15)]
        public string pos_phone { get; set; }

        [StringLength(25)]
        public string employee_ssn { get; set; }

        [StringLength(25)]
        public string claimant_ssn { get; set; }

        public decimal? claim_paid_amount { get; set; }

        public decimal? claim_bill_amount { get; set; }

        public decimal? claimant_paid_amount { get; set; }

        [StringLength(255)]
        public string diag_desc_1 { get; set; }

        [StringLength(255)]
        public string cpt_desc { get; set; }

        [StringLength(50)]
        public string SUB_CITY { get; set; }

        [StringLength(5)]
        public string SUB_STATE { get; set; }

        [StringLength(10)]
        public string cpt_code2 { get; set; }

        [StringLength(10)]
        public string cpt_code3 { get; set; }

        [StringLength(10)]
        public string cpt_code4 { get; set; }

        [StringLength(10)]
        public string cpt_code5 { get; set; }

        [StringLength(10)]
        public string hcpcs_code2 { get; set; }

        [StringLength(10)]
        public string hcpcs_code3 { get; set; }

        [StringLength(10)]
        public string medicare { get; set; }

        [StringLength(25)]
        public string member_ssn { get; set; }

        [StringLength(50)]
        public string patient_member_id { get; set; }

        [StringLength(20)]
        public string service_start_date { get; set; }

        [StringLength(20)]
        public string service_end_date { get; set; }

        [StringLength(100)]
        public string payee_name { get; set; }

        [StringLength(50)]
        public string provider_fed_tax_id { get; set; }

        [StringLength(25)]
        public string provider_sub_code { get; set; }

        [StringLength(25)]
        public string provider_reference_number { get; set; }

        [StringLength(50)]
        public string service_address1 { get; set; }

        [StringLength(50)]
        public string service_address2 { get; set; }

        [StringLength(35)]
        public string service_city { get; set; }

        [StringLength(5)]
        public string service_state { get; set; }

        [StringLength(20)]
        public string service_zip { get; set; }

        [StringLength(50)]
        public string provider_specialty { get; set; }

        [StringLength(50)]
        public string patient_stay_category { get; set; }

        [StringLength(100)]
        public string service_description { get; set; }

        [StringLength(15)]
        public string type_of_service_code { get; set; }

        [StringLength(25)]
        public string discharge_status { get; set; }

        [StringLength(25)]
        public string drg { get; set; }

        [StringLength(15)]
        public string drg_amount { get; set; }

        [StringLength(25)]
        public string diagnosis_category { get; set; }

        [StringLength(15)]
        public string modifier_1 { get; set; }

        [StringLength(15)]
        public string icd_procedure_1 { get; set; }

        [StringLength(15)]
        public string icd_procedure_2 { get; set; }

        [StringLength(15)]
        public string icd_procedure_3 { get; set; }

        [StringLength(100)]
        public string drug_description { get; set; }

        [StringLength(15)]
        public string drug_identifier { get; set; }

        [StringLength(25)]
        public string drug_class { get; set; }

        [StringLength(25)]
        public string drug_category { get; set; }

        [StringLength(15)]
        public string days_supply { get; set; }

        [StringLength(15)]
        public string daw_code { get; set; }

        [StringLength(25)]
        public string drug_type { get; set; }

        [StringLength(50)]
        public string bi_member_id { get; set; }

        [StringLength(50)]
        public string provider_npi { get; set; }

        [StringLength(20)]
        public string employer_group_id { get; set; }

        [StringLength(50)]
        public string claimant_first_name { get; set; }

        [StringLength(50)]
        public string claimant_last_name { get; set; }
    }
}
