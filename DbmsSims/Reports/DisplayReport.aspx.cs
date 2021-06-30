using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DbmsSims.Reports
{
    public partial class DisplayReport : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            string strLetterType = Request.QueryString["ltrtype"];

            if (!string.IsNullOrEmpty(strLetterType))
            {

                string strRefNum = Request.QueryString["refnum"];
                string strMemId = Request.QueryString["memid"];


                if (!string.IsNullOrEmpty(strRefNum) && !string.IsNullOrEmpty(strMemId))
                {

                    hideLetterType.Value = strLetterType;
                    hideReferralNumber.Value = strRefNum;
                    hideMemberId.Value = strMemId;

                    DisplayLetters(strLetterType, strRefNum, strMemId);

                }

            }

        }





        protected void btnSaveLetters_Click(object sender, EventArgs e)
        {

            try
            {

                if (!string.IsNullOrEmpty(hideLetterType.Value) && !string.IsNullOrEmpty(hideReferralNumber.Value) && 
                    !string.IsNullOrEmpty(hideMemberId.Value))
                {

                    if (hideLetterType.Value.Equals("Approved"))
                    {

                        if (ExportApproveLettersToPdf(hideReferralNumber.Value, hideMemberId.Value))
                        {
                            if (SaveApproveLetters(hideReferralNumber.Value, hideMemberId.Value))
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                            }
                        }

                    }
                    else if (hideLetterType.Value.Equals("Denied"))
                    {

                        if (ExportDeniedLettersToPdf(hideReferralNumber.Value, hideMemberId.Value))
                        {
                            if (SaveDeniedLetters(hideReferralNumber.Value, hideMemberId.Value))
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                            }
                        }

                    }
                    else
                    {

                        if (ExportPartialLettersToPdf(hideReferralNumber.Value, hideMemberId.Value))
                        {
                            if (SavePartialLetters(hideReferralNumber.Value, hideMemberId.Value))
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                            }

                        }

                    }

                }

            }
            catch(Exception ex)
            {

            }

        }

        protected void btnCloseWindow_Click(object sender, EventArgs e)
        {

            try
            {
                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
            }
            catch(Exception ex)
            {

            }

        }






        private void DisplayLetters(string strLetterType, string strReferralNumber, string strMemberId)
        {

            if (strLetterType.Equals("Approved"))
            {

                if (CreateApprovalMemberLetter(strReferralNumber, strMemberId))
                {

                    CreateApprovalTpaLetter(strReferralNumber, strMemberId);

                    CreateApprovalFacilityLetter(strReferralNumber, strMemberId);

                    CreateApprovalReferringProviderLetter(strReferralNumber, strMemberId);

                    CreateApprovalReferredToProviderLetter(strReferralNumber, strMemberId);

                    btnSaveLetters.Visible = true;
                    btnSaveLetters2.Visible = true;

                }
                
            }
            else if (strLetterType.Equals("Denied"))
            {

                if (CreateDeniedMemberLetter(strReferralNumber, strMemberId))
                {

                    CreateDeniedTpaLetter(strReferralNumber, strMemberId);

                    CreateDeniedFacilityLetter(strReferralNumber, strMemberId);

                    CreateDeniedReferringProviderLetter(strReferralNumber, strMemberId);

                    CreateDeniedReferredToProviderLetter(strReferralNumber, strMemberId);

                    btnSaveLetters.Visible = true;
                    btnSaveLetters2.Visible = true;

                }

            }
            else
            {

                if (CreatePartialMemberLetter(strReferralNumber, strMemberId))
                {
                    btnSaveLetters.Visible = true;
                    btnSaveLetters2.Visible = true;
                }

            }

        }





        
        //Approval Letters - Generate in Crystal Viewer
        public bool CreateApprovalMemberLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {

                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportApprovalLetter("ApprovalMemberLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwMember.ReportSource = rdLetter;
                    cryrptvwMember.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwMember.Visible = false;
                }


                return Created;

            }
            catch(Exception ex)
            {
                cryrptvwMember.Visible = false;
                return Created;
            }

        }

        public bool CreateApprovalTpaLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {

                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportApprovalLetter("ApprovalTpaLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwTpa.ReportSource = rdLetter;
                    cryrptvwTpa.Visible = true;
                    pnlTpaLetter.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwTpa.Visible = false;
                    pnlTpaLetter.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwTpa.Visible = false;
                pnlTpaLetter.Visible = false;
                return Created;
            }

        }

        public bool CreateApprovalFacilityLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {



                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportApprovalLetter("ApprovalFacilityLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwFacility.ReportSource = rdLetter;
                    cryrptvwFacility.Visible = true;
                    pnlFacilityLetter.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwFacility.Visible = false;
                    pnlFacilityLetter.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {                
                cryrptvwFacility.Visible = false;
                pnlFacilityLetter.Visible = false;
                return Created;
            }

        }

        public bool CreateApprovalReferringProviderLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {



                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportApprovalLetter("ApprovalReferringProviderLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwReferringProvider.ReportSource = rdLetter;
                    cryrptvwReferringProvider.Visible = true;
                    pnlReferringProvider.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwReferringProvider.Visible = false;
                    pnlReferringProvider.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwReferringProvider.Visible = false;
                pnlReferringProvider.Visible = false;
                return Created;
            }

        }

        public bool CreateApprovalReferredToProviderLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {



                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportApprovalLetter("ApprovalReferredToProviderLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {
                    
                    cryrptvwReferredToProvider.ReportSource = rdLetter;
                    cryrptvwReferredToProvider.Visible = true;
                    pnlReferredToProvider.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwReferredToProvider.Visible = false;
                    pnlReferredToProvider.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwReferredToProvider.Visible = false;
                pnlReferredToProvider.Visible = false;
                return Created;
            }

        }



        //Denied Letters - Generate in Crystal Viewer
        public bool CreateDeniedMemberLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {

                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportDeniedLetter("DeniedMemberLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwMember.ReportSource = rdLetter;
                    cryrptvwMember.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwMember.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwMember.Visible = false;
                return Created;
            }

        }

        public bool CreateDeniedTpaLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {

                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportDeniedLetter("DeniedTpaLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwTpa.ReportSource = rdLetter;
                    cryrptvwTpa.Visible = true;
                    pnlTpaLetter.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwTpa.Visible = false;
                    pnlTpaLetter.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwTpa.Visible = false;
                pnlTpaLetter.Visible = false;
                return Created;
            }

        }

        public bool CreateDeniedFacilityLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {



                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportDeniedLetter("DeniedFacilityLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwFacility.ReportSource = rdLetter;
                    cryrptvwFacility.Visible = true;
                    pnlFacilityLetter.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwFacility.Visible = false;
                    pnlFacilityLetter.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwFacility.Visible = false;
                pnlFacilityLetter.Visible = false;
                return Created;
            }

        }

        public bool CreateDeniedReferringProviderLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {



                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportDeniedLetter("DeniedReferringProviderLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwReferringProvider.ReportSource = rdLetter;
                    cryrptvwReferringProvider.Visible = true;
                    pnlReferringProvider.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwReferringProvider.Visible = false;
                    pnlReferringProvider.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwReferringProvider.Visible = false;
                pnlReferringProvider.Visible = false;
                return Created;
            }

        }

        public bool CreateDeniedReferredToProviderLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {



                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportDeniedLetter("DeniedReferredToProviderLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwReferredToProvider.ReportSource = rdLetter;
                    cryrptvwReferredToProvider.Visible = true;
                    pnlReferredToProvider.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwReferredToProvider.Visible = false;
                    pnlReferredToProvider.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwReferredToProvider.Visible = false;
                pnlReferredToProvider.Visible = false;
                return Created;
            }

        }



        //Partial Letters - Generate in Crystal Viewer
        public bool CreatePartialMemberLetter(string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {

                ReportDocument rdLetter = new ReportDocument();


                if (GenerateUmCrystalReportPartialLetter("PartialMemberLetter.rpt", rdLetter, strReferralNumber, strMemberId))
                {

                    cryrptvwMember.ReportSource = rdLetter;
                    cryrptvwMember.Visible = true;

                    Created = true;

                }
                else
                {
                    cryrptvwMember.Visible = false;
                }


                return Created;

            }
            catch (Exception ex)
            {
                cryrptvwMember.Visible = false;
                return Created;
            }

        }





        public bool GenerateUmCrystalReportApprovalLetter(string strLetterName, ReportDocument rdLetter, string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {

                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

                connectionInfo.UserID = ConfigurationManager.AppSettings["CrystalLogInUserID"];
                connectionInfo.Password = ConfigurationManager.AppSettings["CrystalLogInPassword"];
                connectionInfo.ServerName = ConfigurationManager.AppSettings["CrystalLogInServerName"];
                connectionInfo.DatabaseName = ConfigurationManager.AppSettings["CrystalLogInDatabaseName"];


                Database crDatabase;
                CrystalDecisions.CrystalReports.Engine.Tables crTables;
                CrystalDecisions.CrystalReports.Engine.Table crTable;
                Sections sections;
                ReportDocument subrpt = new ReportDocument();
                SubreportObject subrptobj;
                ReportObjects rptobjs;
                TableLogOnInfo crTableLogInfo;



                // FOR TESTING
                string strLoadPath = HttpContext.Current.Server.MapPath("~/Reports/UM/" + strLetterName);

                rdLetter.Load(strLoadPath);



                crDatabase = rdLetter.Database;
                crTables = crDatabase.Tables;


                //log into the main report table
                for (int i = 0; i < crTables.Count; i++)
                {
                    crTable = crTables[i];
                    crTableLogInfo = crTable.LogOnInfo;
                    crTableLogInfo.ConnectionInfo = connectionInfo;
                    crTable.ApplyLogOnInfo(crTableLogInfo);
                }


                rdLetter.SetParameterValue("@callerid", "8C4AA16B-75FE-11D3-A7EE-00500499C350");
                rdLetter.SetParameterValue("@memberid", strMemberId);
                rdLetter.SetParameterValue("@refNum", strReferralNumber);




                //log into the sub report tables
                sections = rdLetter.ReportDefinition.Sections;

                foreach (CrystalDecisions.CrystalReports.Engine.Section section in sections)
                {
                    rptobjs = section.ReportObjects;

                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject rptobj in rptobjs)
                    {
                        if (rptobj.Kind == ReportObjectKind.SubreportObject)
                        {
                            subrptobj = (SubreportObject)rptobj;

                            subrpt = subrptobj.OpenSubreport(subrptobj.SubreportName);

                            crDatabase = subrpt.Database;
                            crTables = crDatabase.Tables;

                            foreach (CrystalDecisions.CrystalReports.Engine.Table subtable in crTables)
                            {
                                crTableLogInfo = subtable.LogOnInfo;
                                crTableLogInfo.ConnectionInfo = connectionInfo;
                                subtable.ApplyLogOnInfo(crTableLogInfo);

                            }
                        }
                    }
                }



                rdLetter.SetParameterValue("@memberid", strMemberId, "ReferralVisits");
                rdLetter.SetParameterValue("@refNum", strReferralNumber, "ReferralVisits");


                Created = true;

                return Created;

            }
            catch (Exception ex)
            {
                return Created;
            }

        }

        public bool GenerateUmCrystalReportDeniedLetter(string strLetterName, ReportDocument rdLetter, string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {

                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

                connectionInfo.UserID = ConfigurationManager.AppSettings["CrystalLogInUserID"];
                connectionInfo.Password = ConfigurationManager.AppSettings["CrystalLogInPassword"];
                connectionInfo.ServerName = ConfigurationManager.AppSettings["CrystalLogInServerName"];
                connectionInfo.DatabaseName = ConfigurationManager.AppSettings["CrystalLogInDatabaseName"];


                Database crDatabase;
                CrystalDecisions.CrystalReports.Engine.Tables crTables;
                CrystalDecisions.CrystalReports.Engine.Table crTable;
                Sections sections;
                ReportDocument subrpt = new ReportDocument();
                SubreportObject subrptobj;
                ReportObjects rptobjs;
                TableLogOnInfo crTableLogInfo;



                // FOR TESTING
                string strLoadPath = HttpContext.Current.Server.MapPath("~/Reports/UM/" + strLetterName);

                rdLetter.Load(strLoadPath);



                crDatabase = rdLetter.Database;
                crTables = crDatabase.Tables;


                //log into the main report table
                for (int i = 0; i < crTables.Count; i++)
                {
                    crTable = crTables[i];
                    crTableLogInfo = crTable.LogOnInfo;
                    crTableLogInfo.ConnectionInfo = connectionInfo;
                    crTable.ApplyLogOnInfo(crTableLogInfo);
                }


                rdLetter.SetParameterValue("@callerid", "8C4AA16B-75FE-11D3-A7EE-00500499C350");
                rdLetter.SetParameterValue("@memberid", strMemberId);
                rdLetter.SetParameterValue("@refNum", strReferralNumber);




                //log into the sub report tables
                sections = rdLetter.ReportDefinition.Sections;

                foreach (CrystalDecisions.CrystalReports.Engine.Section section in sections)
                {
                    rptobjs = section.ReportObjects;

                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject rptobj in rptobjs)
                    {
                        if (rptobj.Kind == ReportObjectKind.SubreportObject)
                        {
                            subrptobj = (SubreportObject)rptobj;

                            subrpt = subrptobj.OpenSubreport(subrptobj.SubreportName);

                            crDatabase = subrpt.Database;
                            crTables = crDatabase.Tables;

                            foreach (CrystalDecisions.CrystalReports.Engine.Table subtable in crTables)
                            {
                                crTableLogInfo = subtable.LogOnInfo;
                                crTableLogInfo.ConnectionInfo = connectionInfo;
                                subtable.ApplyLogOnInfo(crTableLogInfo);

                            }
                        }
                    }
                }



                if (strLetterName.Equals("DeniedTpaLetter.rpt"))
                {
                    rdLetter.SetParameterValue("@memberid", strMemberId, "DeniedLines");
                    rdLetter.SetParameterValue("@refNum", strReferralNumber, "DeniedLines");
                }


                Created = true;

                return Created;

            }
            catch (Exception ex)
            {
                return Created;
            }

        }

        public bool GenerateUmCrystalReportPartialLetter(string strLetterName, ReportDocument rdLetter, string strReferralNumber, string strMemberId)
        {

            bool Created = false;

            try
            {

                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

                connectionInfo.UserID = ConfigurationManager.AppSettings["CrystalLogInUserID"];
                connectionInfo.Password = ConfigurationManager.AppSettings["CrystalLogInPassword"];
                connectionInfo.ServerName = ConfigurationManager.AppSettings["CrystalLogInServerName"];
                connectionInfo.DatabaseName = ConfigurationManager.AppSettings["CrystalLogInDatabaseName"];


                Database crDatabase;
                CrystalDecisions.CrystalReports.Engine.Tables crTables;
                CrystalDecisions.CrystalReports.Engine.Table crTable;
                Sections sections;
                ReportDocument subrpt = new ReportDocument();
                SubreportObject subrptobj;
                ReportObjects rptobjs;
                TableLogOnInfo crTableLogInfo;



                // FOR TESTING
                string strLoadPath = HttpContext.Current.Server.MapPath("~/Reports/UM/" + strLetterName);

                rdLetter.Load(strLoadPath);



                crDatabase = rdLetter.Database;
                crTables = crDatabase.Tables;


                //log into the main report table
                for (int i = 0; i < crTables.Count; i++)
                {
                    crTable = crTables[i];
                    crTableLogInfo = crTable.LogOnInfo;
                    crTableLogInfo.ConnectionInfo = connectionInfo;
                    crTable.ApplyLogOnInfo(crTableLogInfo);
                }


                rdLetter.SetParameterValue("@callerid", "8C4AA16B-75FE-11D3-A7EE-00500499C350");
                rdLetter.SetParameterValue("@memberid", strMemberId);
                rdLetter.SetParameterValue("@refNum", strReferralNumber);




                //log into the sub report tables
                sections = rdLetter.ReportDefinition.Sections;

                foreach (CrystalDecisions.CrystalReports.Engine.Section section in sections)
                {
                    rptobjs = section.ReportObjects;

                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject rptobj in rptobjs)
                    {
                        if (rptobj.Kind == ReportObjectKind.SubreportObject)
                        {
                            subrptobj = (SubreportObject)rptobj;

                            subrpt = subrptobj.OpenSubreport(subrptobj.SubreportName);

                            crDatabase = subrpt.Database;
                            crTables = crDatabase.Tables;

                            foreach (CrystalDecisions.CrystalReports.Engine.Table subtable in crTables)
                            {
                                crTableLogInfo = subtable.LogOnInfo;
                                crTableLogInfo.ConnectionInfo = connectionInfo;
                                subtable.ApplyLogOnInfo(crTableLogInfo);

                            }
                        }
                    }
                }
               
                    
                rdLetter.SetParameterValue("@memberid", strMemberId, "ApprovedVisits");
                rdLetter.SetParameterValue("@refNum", strReferralNumber, "ApprovedVisits");

                rdLetter.SetParameterValue("@memberid", strMemberId, "DeniedVisits");
                rdLetter.SetParameterValue("@refNum", strReferralNumber, "DeniedVisits");


                Created = true;

                return Created;

            }
            catch (Exception ex)
            {
                return Created;
            }

        }
        








        //Approval Letters - Export to PDF
        public bool ExportApproveLettersToPdf(string strReferralNumber, string strMemberId)
        {

            bool Exported = false;

            try
            {

                if (GenerateUmPdfAprrovalLetter("ApprovalMemberLetter", strReferralNumber, strMemberId))
                {

                    GenerateUmPdfAprrovalLetter("ApprovalTpaLetter", strReferralNumber, strMemberId);
                    GenerateUmPdfAprrovalLetter("ApprovalFacilityLetter", strReferralNumber, strMemberId);
                    GenerateUmPdfAprrovalLetter("ApprovalReferringProviderLetter", strReferralNumber, strMemberId);
                    GenerateUmPdfAprrovalLetter("ApprovalReferredToProviderLetter", strReferralNumber, strMemberId);

                    Exported = true;

                }


                return Exported;

            }
            catch(Exception ex)
            {
                return Exported;
            }

        }

        //Denied Letters - Export to PDF
        public bool ExportDeniedLettersToPdf(string strReferralNumber, string strMemberId)
        {

            bool Exported = false;

            try
            {

                if (GenerateUmPdfDeniedLetter("DeniedMemberLetter", strReferralNumber, strMemberId))
                {

                    GenerateUmPdfDeniedLetter("DeniedTpaLetter", strReferralNumber, strMemberId);
                    GenerateUmPdfDeniedLetter("DeniedFacilityLetter", strReferralNumber, strMemberId);
                    GenerateUmPdfDeniedLetter("DeniedReferringProviderLetter", strReferralNumber, strMemberId);
                    GenerateUmPdfDeniedLetter("DeniedReferredToProviderLetter", strReferralNumber, strMemberId);

                    Exported = true;

                }


                return Exported;

            }
            catch (Exception ex)
            {
                return Exported;
            }

        }

        //Partial Letters - Export to PDF
        public bool ExportPartialLettersToPdf(string strReferralNumber, string strMemberId)
        {

            bool Exported = false;

            try
            {

                if (GenerateUmPdfPartialLetter("PartialMemberLetter", strReferralNumber, strMemberId))
                {
                    Exported = true;
                }


                return Exported;

            }
            catch (Exception ex)
            {
                return Exported;
            }

        }





        public bool GenerateUmPdfAprrovalLetter(string strLetterName, string strReferralNumber, string strMemberId)
        {

            bool Exported = false;

            try
            {

                ReportDocument rptdocLetter = new ReportDocument();

                string strPdfFile = "C:\\ICMS Letter Templates\\" + strLetterName + ".pdf";

                DeleteUmPdfLetterIfExists(strPdfFile);


                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

                connectionInfo.UserID = ConfigurationManager.AppSettings["CrystalLogInUserID"];
                connectionInfo.Password = ConfigurationManager.AppSettings["CrystalLogInPassword"];
                connectionInfo.ServerName = ConfigurationManager.AppSettings["CrystalLogInServerName"];
                connectionInfo.DatabaseName = ConfigurationManager.AppSettings["CrystalLogInDatabaseName"];


                Database crDatabase;
                CrystalDecisions.CrystalReports.Engine.Tables crTables;
                CrystalDecisions.CrystalReports.Engine.Table crTable;
                Sections sections;
                ReportDocument subrpt = new ReportDocument();
                SubreportObject subrptobj;
                ReportObjects rptobjs;
                TableLogOnInfo crTableLogInfo;


                // FOR TESTING
                rptdocLetter.Load(HttpContext.Current.Server.MapPath("~/Reports/UM/" + strLetterName + ".rpt"));


                crDatabase = rptdocLetter.Database;
                crTables = crDatabase.Tables;


                //log into the main report table
                for (int i = 0; i < crTables.Count; i++)
                {
                    crTable = crTables[i];
                    crTableLogInfo = crTable.LogOnInfo;
                    crTableLogInfo.ConnectionInfo = connectionInfo;
                    crTable.ApplyLogOnInfo(crTableLogInfo);
                }


                rptdocLetter.SetParameterValue("@callerid", "8C4AA16B-75FE-11D3-A7EE-00500499C350");
                rptdocLetter.SetParameterValue("@memberid", strMemberId);
                rptdocLetter.SetParameterValue("@refNum", strReferralNumber);




                //log into the sub report tables
                sections = rptdocLetter.ReportDefinition.Sections;

                foreach (CrystalDecisions.CrystalReports.Engine.Section section in sections)
                {
                    rptobjs = section.ReportObjects;

                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject rptobj in rptobjs)
                    {
                        if (rptobj.Kind == ReportObjectKind.SubreportObject)
                        {
                            subrptobj = (SubreportObject)rptobj;

                            subrpt = subrptobj.OpenSubreport(subrptobj.SubreportName);

                            crDatabase = subrpt.Database;
                            crTables = crDatabase.Tables;

                            foreach (CrystalDecisions.CrystalReports.Engine.Table subtable in crTables)
                            {
                                crTableLogInfo = subtable.LogOnInfo;
                                crTableLogInfo.ConnectionInfo = connectionInfo;
                                subtable.ApplyLogOnInfo(crTableLogInfo);

                            }
                        }
                    }
                }



                rptdocLetter.SetParameterValue("@memberid", strMemberId, "ReferralVisits");
                rptdocLetter.SetParameterValue("@refNum", strReferralNumber, "ReferralVisits");
                
                

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();

                CrDiskFileDestinationOptions.DiskFileName = strPdfFile;

                CrExportOptions = rptdocLetter.ExportOptions;

                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;

                CrExportOptions.FormatOptions = CrFormatTypeOptions;

                rptdocLetter.Export();

                

                if (System.IO.File.Exists(strPdfFile))
                {
                    Exported = true;
                }

                return Exported;

            }
            catch (Exception ex)
            {
                return Exported;
            }

        }

        public bool GenerateUmPdfDeniedLetter(string strLetterName, string strReferralNumber, string strMemberId)
        {

            bool Exported = false;

            try
            {

                ReportDocument rptdocLetter = new ReportDocument();

                string strPdfFile = "C:\\ICMS Letter Templates\\" + strLetterName + ".pdf";

                DeleteUmPdfLetterIfExists(strPdfFile);


                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

                connectionInfo.UserID = ConfigurationManager.AppSettings["CrystalLogInUserID"];
                connectionInfo.Password = ConfigurationManager.AppSettings["CrystalLogInPassword"];
                connectionInfo.ServerName = ConfigurationManager.AppSettings["CrystalLogInServerName"];
                connectionInfo.DatabaseName = ConfigurationManager.AppSettings["CrystalLogInDatabaseName"];


                Database crDatabase;
                CrystalDecisions.CrystalReports.Engine.Tables crTables;
                CrystalDecisions.CrystalReports.Engine.Table crTable;
                Sections sections;
                ReportDocument subrpt = new ReportDocument();
                SubreportObject subrptobj;
                ReportObjects rptobjs;
                TableLogOnInfo crTableLogInfo;


                // FOR TESTING
                rptdocLetter.Load(HttpContext.Current.Server.MapPath("~/Reports/UM/" + strLetterName + ".rpt"));


                crDatabase = rptdocLetter.Database;
                crTables = crDatabase.Tables;


                //log into the main report table
                for (int i = 0; i < crTables.Count; i++)
                {
                    crTable = crTables[i];
                    crTableLogInfo = crTable.LogOnInfo;
                    crTableLogInfo.ConnectionInfo = connectionInfo;
                    crTable.ApplyLogOnInfo(crTableLogInfo);
                }


                rptdocLetter.SetParameterValue("@callerid", "8C4AA16B-75FE-11D3-A7EE-00500499C350");
                rptdocLetter.SetParameterValue("@memberid", strMemberId);
                rptdocLetter.SetParameterValue("@refNum", strReferralNumber);




                //log into the sub report tables
                sections = rptdocLetter.ReportDefinition.Sections;

                foreach (CrystalDecisions.CrystalReports.Engine.Section section in sections)
                {
                    rptobjs = section.ReportObjects;

                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject rptobj in rptobjs)
                    {
                        if (rptobj.Kind == ReportObjectKind.SubreportObject)
                        {
                            subrptobj = (SubreportObject)rptobj;

                            subrpt = subrptobj.OpenSubreport(subrptobj.SubreportName);

                            crDatabase = subrpt.Database;
                            crTables = crDatabase.Tables;

                            foreach (CrystalDecisions.CrystalReports.Engine.Table subtable in crTables)
                            {
                                crTableLogInfo = subtable.LogOnInfo;
                                crTableLogInfo.ConnectionInfo = connectionInfo;
                                subtable.ApplyLogOnInfo(crTableLogInfo);

                            }
                        }
                    }
                }



                if (strLetterName.Equals("DeniedTpaLetter"))
                {
                    rptdocLetter.SetParameterValue("@memberid", strMemberId, "DeniedLines");
                    rptdocLetter.SetParameterValue("@refNum", strReferralNumber, "DeniedLines");
                }



                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();

                CrDiskFileDestinationOptions.DiskFileName = strPdfFile;

                CrExportOptions = rptdocLetter.ExportOptions;

                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;

                CrExportOptions.FormatOptions = CrFormatTypeOptions;

                rptdocLetter.Export();



                if (System.IO.File.Exists(strPdfFile))
                {
                    Exported = true;
                }

                return Exported;

            }
            catch (Exception ex)
            {
                return Exported;
            }

        }

        public bool GenerateUmPdfPartialLetter(string strLetterName, string strReferralNumber, string strMemberId)
        {

            bool Exported = false;

            try
            {

                ReportDocument rptdocLetter = new ReportDocument();

                string strPdfFile = "C:\\ICMS Letter Templates\\" + strLetterName + ".pdf";

                DeleteUmPdfLetterIfExists(strPdfFile);


                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

                connectionInfo.UserID = ConfigurationManager.AppSettings["CrystalLogInUserID"];
                connectionInfo.Password = ConfigurationManager.AppSettings["CrystalLogInPassword"];
                connectionInfo.ServerName = ConfigurationManager.AppSettings["CrystalLogInServerName"];
                connectionInfo.DatabaseName = ConfigurationManager.AppSettings["CrystalLogInDatabaseName"];


                Database crDatabase;
                CrystalDecisions.CrystalReports.Engine.Tables crTables;
                CrystalDecisions.CrystalReports.Engine.Table crTable;
                Sections sections;
                ReportDocument subrpt = new ReportDocument();
                SubreportObject subrptobj;
                ReportObjects rptobjs;
                TableLogOnInfo crTableLogInfo;


                // FOR TESTING
                rptdocLetter.Load(HttpContext.Current.Server.MapPath("~/Reports/UM/" + strLetterName + ".rpt"));


                crDatabase = rptdocLetter.Database;
                crTables = crDatabase.Tables;


                //log into the main report table
                for (int i = 0; i < crTables.Count; i++)
                {
                    crTable = crTables[i];
                    crTableLogInfo = crTable.LogOnInfo;
                    crTableLogInfo.ConnectionInfo = connectionInfo;
                    crTable.ApplyLogOnInfo(crTableLogInfo);
                }


                rptdocLetter.SetParameterValue("@callerid", "8C4AA16B-75FE-11D3-A7EE-00500499C350");
                rptdocLetter.SetParameterValue("@memberid", strMemberId);
                rptdocLetter.SetParameterValue("@refNum", strReferralNumber);




                //log into the sub report tables
                sections = rptdocLetter.ReportDefinition.Sections;

                foreach (CrystalDecisions.CrystalReports.Engine.Section section in sections)
                {
                    rptobjs = section.ReportObjects;

                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject rptobj in rptobjs)
                    {
                        if (rptobj.Kind == ReportObjectKind.SubreportObject)
                        {
                            subrptobj = (SubreportObject)rptobj;

                            subrpt = subrptobj.OpenSubreport(subrptobj.SubreportName);

                            crDatabase = subrpt.Database;
                            crTables = crDatabase.Tables;

                            foreach (CrystalDecisions.CrystalReports.Engine.Table subtable in crTables)
                            {
                                crTableLogInfo = subtable.LogOnInfo;
                                crTableLogInfo.ConnectionInfo = connectionInfo;
                                subtable.ApplyLogOnInfo(crTableLogInfo);

                            }
                        }
                    }
                }



                rptdocLetter.SetParameterValue("@memberid", strMemberId, "ApprovedVisits");
                rptdocLetter.SetParameterValue("@refNum", strReferralNumber, "ApprovedVisits");

                rptdocLetter.SetParameterValue("@memberid", strMemberId, "DeniedVisits");
                rptdocLetter.SetParameterValue("@refNum", strReferralNumber, "DeniedVisits");



                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();

                CrDiskFileDestinationOptions.DiskFileName = strPdfFile;

                CrExportOptions = rptdocLetter.ExportOptions;

                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;

                CrExportOptions.FormatOptions = CrFormatTypeOptions;

                rptdocLetter.Export();



                if (System.IO.File.Exists(strPdfFile))
                {
                    Exported = true;
                }

                return Exported;

            }
            catch (Exception ex)
            {
                return Exported;
            }

        }

        public void DeleteUmPdfLetterIfExists(string strPdfFile)
        {

            try
            {

                if (System.IO.File.Exists(strPdfFile))
                {
                    System.IO.File.Delete(strPdfFile);
                }

            }
            catch(Exception ex)
            {

            }

        }








        //Approval Letters - Save to Database
        public bool SaveApproveLetters(string strReferralNumber, string strMemberId)
        {

            bool Saved = false;

            try
            {

                if (SaveUmPdfLetter("ApprovalMemberLetter", strReferralNumber, strMemberId))
                {

                    SaveUmPdfLetter("ApprovalTpaLetter", strReferralNumber, strMemberId);
                    SaveUmPdfLetter("ApprovalFacilityLetter", strReferralNumber, strMemberId);
                    SaveUmPdfLetter("ApprovalReferringProviderLetter", strReferralNumber, strMemberId);
                    SaveUmPdfLetter("ApprovalReferredToProviderLetter", strReferralNumber, strMemberId);


                    Saved = true;

                }


                return Saved;

            }
            catch(Exception ex)
            {
                return Saved;
            }

        }

        //Denied Letters - Save to Database
        public bool SaveDeniedLetters(string strReferralNumber, string strMemberId)
        {

            bool Saved = false;

            try
            {

                if (SaveUmPdfLetter("DeniedMemberLetter", strReferralNumber, strMemberId))
                {

                    SaveUmPdfLetter("DeniedTpaLetter", strReferralNumber, strMemberId);
                    SaveUmPdfLetter("DeniedFacilityLetter", strReferralNumber, strMemberId);
                    SaveUmPdfLetter("DeniedReferringProviderLetter", strReferralNumber, strMemberId);
                    SaveUmPdfLetter("DeniedReferredToProviderLetter", strReferralNumber, strMemberId);


                    Saved = true;

                }


                return Saved;

            }
            catch (Exception ex)
            {
                return Saved;
            }

        }

        //Partial Letters - Save to Database
        public bool SavePartialLetters(string strReferralNumber, string strMemberId)
        {

            bool Saved = false;

            try
            {

                if (SaveUmPdfLetter("PartialMemberLetter", strReferralNumber, strMemberId))
                {
                    Saved = true;
                }


                return Saved;

            }
            catch (Exception ex)
            {
                return Saved;
            }

        }





        public bool SaveUmPdfLetter(string strLetterName, string strReferralNumber, string strMemberId)
        {

            bool Saved = false;

            try
            {

                string strPdfFile = "C:\\ICMS Letter Templates\\" + strLetterName + ".pdf";


                if (System.IO.File.Exists(strPdfFile))
                {


                    byte[] bytImageToLoad = System.IO.File.ReadAllBytes(strPdfFile);
                    DateTime dteNow = DateTime.Now;                   


                    SqlConnection sqlConFile = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);

                    SqlCommand command = new SqlCommand(
                                                        "INSERT INTO r_MEMBER_REFERRAL_LETTERS" +
                                                        " (member_id, referral_number, file_identifier, file_blob, letter_created)" +
                                                        " VALUES" +
                                                        " (@MemberId, @ReferralNumber, @FileIdentifier, @FileBlob, @CreationDate)", 
                                                        sqlConFile);


                    Guid guidMemberId = new Guid(strMemberId);

                    command.Parameters.Add("@MemberId", SqlDbType.UniqueIdentifier).Value = guidMemberId;
                    command.Parameters.Add("@ReferralNumber", SqlDbType.VarChar).Value = strReferralNumber;
                    command.Parameters.Add("@FileIdentifier", SqlDbType.VarChar, 255).Value = strPdfFile + ".pdf";
                    command.Parameters.Add("@FileBlob", SqlDbType.Image, bytImageToLoad.Length).Value = bytImageToLoad;
                    command.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = dteNow;


                    sqlConFile.Open();
                    command.ExecuteNonQuery();


                    Saved = true;

                }


                return Saved;

            }
            catch(Exception ex)
            {
                return Saved;
            }


        }


    }
    

}