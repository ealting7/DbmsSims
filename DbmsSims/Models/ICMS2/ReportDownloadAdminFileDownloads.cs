namespace DbmsSims.Models.ICMS2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("REPORT_DOWNLOAD_ADMIN_FILE_DOWNLOADS")]
    public partial class ReportDownloadAdminFileDownloads
    {
        [Key]
        public int report_download_admin_file_downloads_id { get; set; }

        public int? rpt_download_id { get; set; }

        public DateTime? download_start_date { get; set; }

        public DateTime? download_end_date { get; set; }

        public Guid? download_user_id { get; set; }

        public bool? download_complete { get; set; }

        public bool? download_successful { get; set; }

        public string note { get; set; }
    }
}
