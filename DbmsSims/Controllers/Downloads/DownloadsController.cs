using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using DbmsSims.Models;
using DbmsSims.Repository;
using Microsoft.AspNet.Identity;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS2.ViewModels;
using DbmsSims.Models.Downloads.ViewModels;
using System.Web.Script.Serialization;
using System.IO;

namespace DbmsSims.Controllers.Downloads
{
    public class DownloadsController : Controller
    {


        // GET: Downloads
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Downloads()
        {

            DownloadsRepository dwnldsRepo = new DownloadsRepository();
            DownloadsViewModel dwnldsvmToPopulate = new DownloadsViewModel();

            dwnldsRepo.PopulateDownloadItems(ref dwnldsvmToPopulate);


            return View(dwnldsvmToPopulate);

        }




        public ActionResult VerifyFileExistsToDownload(string RptDwnldId)
        {

            try
            {

                DownloadsRepository dwnldsRepo = new DownloadsRepository();
                DownloadsViewModel dwnldsvmToVerify = new DownloadsViewModel();

                dwnldsvmToVerify.RptDownloadId = Convert.ToInt32(RptDwnldId);

                if (dwnldsRepo.VerifyDownloadFileExistsOnFtp(ref dwnldsvmToVerify))
                {

                    return Json(new { FileExists = true, Name = dwnldsvmToVerify.TpaName, Type = dwnldsvmToVerify.DownloadType }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { FileExists = false, Name = "", Type = "" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { FileExists = false, Name = "", Type = "" }, JsonRequestBehavior.AllowGet);
            }

        }




        public ActionResult ParseDownloadFile(string RptDwnldId)
        {
            DownloadsViewModel dwnldsvmToDownload = new DownloadsViewModel();
            DownloadsRepository dwnldsRepo = new DownloadsRepository();

            try
            {
                if (!string.IsNullOrEmpty(RptDwnldId))
                {
                    dwnldsvmToDownload.RptDownloadId = Convert.ToInt32(RptDwnldId);
                    dwnldsvmToDownload.DownloadingUserId = User.Identity.GetUserId();


                    if (!dwnldsRepo.VerifyDownloadNotInProgress(ref dwnldsvmToDownload))
                    {
                        if (dwnldsRepo.ParseDownloadFile(ref dwnldsvmToDownload))
                        {
                            return Json(new { FileParsed=true, ParsedItems=dwnldsvmToDownload}, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { FileParsed=false, ParsedItems=dwnldsvmToDownload }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        dwnldsvmToDownload.DownloadErrorMessage = "Issue: Download Already In Progress";

                        return Json(new { FileParsed=false, ParsedItems=dwnldsvmToDownload }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { FileParsed=false, ParsedItems=dwnldsvmToDownload }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { FileParsed=false, ParsedItems=dwnldsvmToDownload }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DownloadFile(DownloadsViewModel dwnldsvmToProcess)
        {

            DownloadsRepository dwnldsRepo = new DownloadsRepository();

            try
            {

                dwnldsvmToProcess.DownloadingUserId = User.Identity.GetUserId();


                if (dwnldsRepo.DownloadFile(ref dwnldsvmToProcess))
                {
                    return Json(new { FileDownloaded = true, FailedProcessedItems = dwnldsvmToProcess }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { FileDownloaded = false, FailedProcessedItems = dwnldsvmToProcess }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { FileDownloaded = false, FailedProcessedItems = dwnldsvmToProcess}, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult CreateDuplicateMemberFile (DownloadsViewModel dwnldsvmToCreateFile)
        {

            DownloadsRepository dwnldsRepo = new DownloadsRepository();


            try
            {

                dwnldsvmToCreateFile.DownloadingUserId = User.Identity.GetUserId();


                if (dwnldsRepo.CreateDuplicateMemberFile(ref dwnldsvmToCreateFile))
                {
                    return Json(new { DuplicateMemberFileCreated = true, FtpInfoToDuplicatMemberFileItems = dwnldsvmToCreateFile }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { DuplicateMemberFileCreated = false, FtpInfoToDuplicatMemberFileItems = dwnldsvmToCreateFile }, JsonRequestBehavior.AllowGet);
                }

            }
            catch(Exception ex)
            {
                return Json(new { DuplicateMemberFileCreated = false, FtpInfoToDuplicatMemberFileItems = dwnldsvmToCreateFile }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult CreateMemberNoEmployerFile(DownloadsViewModel dwnldsvmToCreateFile)
        {

            DownloadsRepository dwnldsRepo = new DownloadsRepository();


            try
            {
                if (dwnldsRepo.CreateMemberHasNoEmployerFile(ref dwnldsvmToCreateFile))
                {
                    return Json(new { MemberHasNoEmployerFileCreated = true, FtpInfoToDuplicatMemberFileItems = dwnldsvmToCreateFile }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { MemberHasNoEmployerFileCreated = false, FtpInfoToDuplicatMemberFileItems = dwnldsvmToCreateFile }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { MemberHasNoEmployerFileCreated = false, FtpInfoToDuplicatMemberFileItems = dwnldsvmToCreateFile }, JsonRequestBehavior.AllowGet);
            }

        }




        public ActionResult ShowFile(string RptDwnldId)
        {

            try
            {

                DownloadsRepository dwnldsRepo = new DownloadsRepository();
                DownloadsViewModel dwnldsvmToShow = new DownloadsViewModel();


                if (!string.IsNullOrEmpty(RptDwnldId))
                {

                    dwnldsvmToShow.RptDownloadId = Convert.ToInt32(RptDwnldId);


                    if (dwnldsRepo.ShowDownloadFileFtp(ref dwnldsvmToShow))
                    {
                        return Json(new { FileCanBeShown = true,
                                          FtpLocal = dwnldsvmToShow.FilePath,
                                          FleNm = dwnldsvmToShow.FileName,
                                          UsNm = dwnldsvmToShow.FtpUserName,
                                          Pswd = dwnldsvmToShow.FtpPswd
                                         }, 
                                         JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { FileCanBeShown = false, FtpLocal = "", FleNm = "", UsNm = "", Pswd = "" }, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    return Json(new { FileCanBeShown = false, FtpLocal = "", FleNm = "", UsNm = "", Pswd = "" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { FileCanBeShown = false, FtpLocal = "", FleNm = "", UsNm = "", Pswd = "" }, JsonRequestBehavior.AllowGet);
            }
        }





        public ActionResult ResetFile(string ReportDownloadId)
        {
            DownloadsRepository dwnldsRepo = new DownloadsRepository();
            DownloadsViewModel FileToReset = new DownloadsViewModel();

            try
            {
                if (!string.IsNullOrEmpty(ReportDownloadId))
                {
                    int OutReportDownloadId = 0;


                    if (int.TryParse(ReportDownloadId, out OutReportDownloadId))
                    {
                        FileToReset.RptDownloadId = OutReportDownloadId;


                        if (dwnldsRepo.ResetDownloadStatus(ref FileToReset))
                        {
                            return Json(new { FileReset=true }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { FileReset=false }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { FileReset=false }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { FileReset=false}, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { FileReset=false}, JsonRequestBehavior.AllowGet);
            }
        }




    }
}