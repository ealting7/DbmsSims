namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Report_Download_Admin")]
    public partial class ReportDownloadAdmin
    {
        [Key]
        [Column(Order = 0)]
        public int rpt_download_id { get; set; }

        public bool? is_elgibility_file { get; set; }

        public bool? is_claim_file { get; set; }

        public bool? is_rx_file { get; set; }

        public int? employer_id { get; set; }

        public int? reinsurer_id { get; set; }

        public int? tpa_id { get; set; }

        [StringLength(255)]
        public string ftp_directory_to_scan { get; set; }

        [StringLength(10)]
        public string file_extension_to_look_for { get; set; }

        public bool? email_client { get; set; }

        public bool? email_it_icms { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime creation_date { get; set; }

        public Guid? created_userid { get; set; }

        public DateTime? lastupdate_date { get; set; }

        public Guid? lastupdate_userid { get; set; }

        [StringLength(50)]
        public string DTSPackageID { get; set; }

        [StringLength(255)]
        public string dts_package_filename_to_use { get; set; }

        [StringLength(255)]
        public string dts_tabln_name { get; set; }

        public byte? use_ftp_directory { get; set; }

        [StringLength(255)]
        public string ftp_actual_directory { get; set; }

        [StringLength(255)]
        public string ftp_filename_on_ftp_directory { get; set; }

        public byte? use_zip_files { get; set; }

        [StringLength(50)]
        public string zip_file_password { get; set; }

        [StringLength(255)]
        public string zip_file_name { get; set; }

        public byte? is_health_plan_download { get; set; }

        public byte? is_wishard_download { get; set; }

        public byte? is_hip_download { get; set; }

        public byte? is_hhw_download { get; set; }

        public byte? is_wishard_advantage_download { get; set; }

        public byte? is_provider_download { get; set; }

        public byte? is_behavioral_provider { get; set; }

        public byte? use_pgp_files { get; set; }

        public byte? use_excel_spreadsheet { get; set; }

        [StringLength(50)]
        public string excel_spreadsheet_workbook_name { get; set; }

        public byte? is_sands_download { get; set; }

        public byte? is_shpg_download { get; set; }

        public byte? UsePGP { get; set; }

        [StringLength(50)]
        public string PGPHexKey { get; set; }

        [StringLength(255)]
        public string PGPPubRing { get; set; }

        [StringLength(255)]
        public string PGPPrivKey { get; set; }

        [StringLength(15)]
        public string UserName { get; set; }

        [StringLength(15)]
        public string Password { get; set; }

        public byte? is_forja_download { get; set; }

        public byte? ftp_filename_uses_wildcards { get; set; }

        public byte? disabled { get; set; }

        [StringLength(500)]
        public string update_comment { get; set; }

        public bool? skip_first_row { get; set; }

        [StringLength(50)]
        public string ftp_host { get; set; }

        [StringLength(50)]
        public string ftp_file_path { get; set; }
    }
}
