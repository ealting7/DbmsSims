using DbmsSims.Models.ICMS2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace DbmsSims.Repository
{
    public class UmLetterRepository
    {


        public ReferralLetterViewModel GenerateUmApprovalLetter(string strMemberId, string strReferralNumber)
        {

            ReferralLetterViewModel vmRefLettToReturn = new ReferralLetterViewModel();

            try
            {

                vmRefLettToReturn.MemberId = strMemberId;
                vmRefLettToReturn.ReferralNumber = strReferralNumber;


                if (CreateUmApprovalLetter(ref vmRefLettToReturn))
                {                    
                    
                    vmRefLettToReturn.Width = 800;
                    vmRefLettToReturn.Height = 960;
                    vmRefLettToReturn.Title = "UM Approval Letter";

                }


                return vmRefLettToReturn;
            }
            catch(Exception ex)
            {
                return vmRefLettToReturn;
            }

        }



        public bool CreateUmApprovalLetter(ref ReferralLetterViewModel vmRefLettToReturn)
        {

            bool blnCreated = false;

            try
            {

                ReportDocument rdLetter = new ReportDocument();


                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

                connectionInfo.UserID = ConfigurationManager.AppSettings["CrystalLogInUserID"];
                connectionInfo.Password = ConfigurationManager.AppSettings["CrystalLogInPassword"];
                connectionInfo.ServerName = ConfigurationManager.AppSettings["CrystalLogInServerName"];
                connectionInfo.DatabaseName = ConfigurationManager.AppSettings["CrystalLogInDatabaseName"];


                Database crDatabase;
                Tables crTables;
                Table crTable;
                Sections sections;
                ReportDocument subrpt = new ReportDocument();
                SubreportObject subrptobj;
                ReportObjects rptobjs;
                TableLogOnInfo crTableLogInfo;



                // FOR TESTING
                string strLoadPath = "C:\\Projects\\DbmsSims\\DbmsSims\\Reports\\UM\\FacilityApprovalLetter.rpt";

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
                rdLetter.SetParameterValue("@memberid", vmRefLettToReturn.MemberId);
                rdLetter.SetParameterValue("@refNum", vmRefLettToReturn.ReferralNumber);




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



                rdLetter.SetParameterValue("@memberid", vmRefLettToReturn.MemberId, "ReferralVisits");
                rdLetter.SetParameterValue("@refNum", vmRefLettToReturn.ReferralNumber, "ReferralVisits");



                vmRefLettToReturn.cryrptLetter = rdLetter;
                vmRefLettToReturn.Url = strLoadPath;



                blnCreated = true;


                return blnCreated;

            }
            catch(Exception ex)
            {
                return blnCreated;
            }

        }



    }
}