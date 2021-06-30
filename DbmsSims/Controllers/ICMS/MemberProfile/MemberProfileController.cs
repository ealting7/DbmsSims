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
using System.Web.Script.Serialization;
using System.IO;

namespace DbmsSims.Controllers.ICMS.MemberProfile
{
    public class MemberProfileController : Controller
    {

        // GET: MemberProfile
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult SelectedMemberNavigation()
        {

            string UserId;
            SelectedMemberNavigation nav = new SelectedMemberNavigation();

            UserId = User.Identity.GetUserId();


            if (UserId != null)
            {

                DbmsUserRepository userRepo = new DbmsUserRepository();
                
                userRepo.VerifyDbmsUserHasACurrentlySelectedMember(UserId, nav);                

            }


            return PartialView("MemberSelectedNavigation", nav);

        }






        [Authorize]
        public ActionResult Notes(string type, string id)
        {

            NotesRepository notesRepo = new NotesRepository();
            NotesViewModel notetodisplay = new NotesViewModel();

            notetodisplay.Type = type;
            notetodisplay.billcodes = notesRepo.GetLcmBillingCodes();
            notetodisplay.billminutes = notesRepo.GetBillingMinutes();
            notetodisplay.notes = notesRepo.GetAllMemberNotesByNoteTypeAndMemberId(type, id);

            return View(notetodisplay);

        }


        [Authorize]
        [HttpPost]
        public ActionResult AddNote(NotesViewModel dataFromView)
        {

            if (ModelState.IsValid)
            {


            }


            return View();

        }






        [Authorize]
        public ActionResult ReferralSelect(string id)
        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralViewModel refToDisplay = new ReferralViewModel();

            refToDisplay.MemberId = id;
            refToDisplay.referrals = refRepo.GetAllMemberReferrals(id);

            if (refToDisplay.referrals.Count.CompareTo(0) > 0)
            {
                refRepo.GetReferralDecisionUsingReferralList(ref refToDisplay);
            }            


            return View(refToDisplay);

        }


        [Authorize]
        public ActionResult NewReferral(string MemId)
        {

            try
            {
                return View("ReferralSelect", MemId);
            }
            catch (Exception ex)
            {
                return View("ReferralSelect", MemId);
            }

        }





        [Authorize]
        public ActionResult EditReferralGeneral(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralViewModel refToDisplay = new ReferralViewModel();

            refToDisplay = refRepo.InitializeReferralGeneral(RefNum);

            refRepo.InitializeReferralGeneralControls(ref refToDisplay);


            return View(refToDisplay);

        }

        [Authorize]
        [HttpPost]
        public ActionResult EditReferralGeneral(ReferralViewModel vmFromView)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    vmFromView.ModelUpdateMessage = "";

                    ReferralRepository refRepo = new ReferralRepository();

                    //initialize rMemberReferral model item
                    rMemberReferral referral = refRepo.GetReferralUsingReferralNumber(vmFromView.ReferralNumber);


                    if (referral != null)
                    {

                        referral.type_id = vmFromView.type_id;
                        referral.context_id = vmFromView.context_id;
                        referral.priority_id = vmFromView.priority_id;
                        referral.referral_category = vmFromView.referral_category;

                        using (var db = new ICMS2DbContext())
                        {

                            //change the model (rMemberReferral) state to modified
                            db.Entry(referral).State = EntityState.Modified;

                            //update the model (rMemberReferral) in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {                                
                                vmFromView.ModelUpdateMessage = "General Updated";
                            }

                        }

                    }


                    //repopulate dropdown controls on referral General page
                    refRepo.InitializeReferralGeneralControls(ref vmFromView);

                }


                return View(vmFromView);

            }
            catch(Exception ex)
            {
                return View();
            }

        }






        [Authorize]
        public ActionResult EditReferralActions(string RefNum)

        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralViewModel refToDisplay = new ReferralViewModel();

            refToDisplay = refRepo.InitializeReferralActions(RefNum);

            refRepo.InitializeReferralActionControls(ref refToDisplay);

            return View(refToDisplay);

        }

        [Authorize]
        [HttpPost]
        public ActionResult EditReferralActions(ReferralViewModel vmFromView)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    ReferralRepository refRepo = new ReferralRepository();

                    //initialize rMemberReferral model item
                    rMemberReferral referral = refRepo.GetReferralUsingReferralNumber(vmFromView.ReferralNumber);


                    if (referral != null)
                    {

                        referral.type_id = vmFromView.type_id;
                        referral.context_id = vmFromView.context_id;
                        referral.priority_id = vmFromView.priority_id;
                        referral.referral_category = vmFromView.referral_category;

                        using (var db = new ICMS2DbContext())
                        {

                            //change the model (rMemberReferral) state to modified
                            db.Entry(referral).State = EntityState.Modified;

                            //update the model (rMemberReferral) in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {
                                vmFromView.ModelUpdateMessage = "General Updated";
                            }

                        }

                    }


                    //repopulate dropdown controls on referral General page
                    refRepo.InitializeReferralGeneralControls(ref vmFromView);

                }


                return View(vmFromView);

            }
            catch (Exception ex)
            {
                return View();
            }

        }

        [Authorize]
        public ActionResult LoadReasonForActions(string strCurrentStatusId)
        {

            string result = "";

            try
            {

                ReferralRepository refRepo = new ReferralRepository();
                List<rReferralPendReason> lstReasonsForAction = new List<rReferralPendReason>();


                //get list of 'reasons for action' (for the passed in 'current status id') to be returned to the jquery request
                lstReasonsForAction = refRepo.GetReasonForActionUsingCurrentStatusId(strCurrentStatusId);

                JavaScriptSerializer jvascrserial = new JavaScriptSerializer();

                //put the list of 'reasons for action' into a usable json list
                result = jvascrserial.Serialize(lstReasonsForAction);


                //return the JSON list of 'reasons for action'
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }





        [Authorize]
        public ActionResult EditReferralCodes(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralViewModel refToDisplay = new ReferralViewModel();

            refToDisplay = refRepo.InitializeReferralCodes(RefNum);

            refRepo.InitializeReferralCodesControls(ref refToDisplay);


            return View(refToDisplay);

        }

        [Authorize]
        [HttpPost]
        public ActionResult EditReferralCodes(MedicalCodeSearchViewModel vmFromView)
        {

            ReferralViewModel refToDisplay = new ReferralViewModel();

            try
            {

                ReferralRepository refRepo = new ReferralRepository();


                refToDisplay.ReferralNumber = vmFromView.ReferralNumber;

                refToDisplay = refRepo.InitializeReferralCodes(refToDisplay.ReferralNumber);
                
                refRepo.InitializeReferralCodesControls(ref refToDisplay);


                return View(refToDisplay);

            }
            catch(Exception ex)
            {
                return View(refToDisplay);
            }

        }

        [Authorize]
        public ActionResult MedicalCodeSearch(string strIncomingSearchMethod, string strIncomingSearchText, string strIncomingSearchType, string strReferralNumber)
        {

            string result = "";

            try
            {

                ReferralRepository refRepo = new ReferralRepository();
                List<MedicalCodeSearchViewModel> lstReturnCodes = new List<MedicalCodeSearchViewModel>();
                JavaScriptSerializer jvascrserial = new JavaScriptSerializer();


                if (strIncomingSearchType.Equals("diag"))
                {

                    if (strIncomingSearchMethod.Equals("codesearch"))
                    {
                        lstReturnCodes = refRepo.GetDiagnosisCodesUsingCodeLikeSearchText(strIncomingSearchText, strReferralNumber);
                    }
                    else
                    {
                        lstReturnCodes = refRepo.GetDiagnosisCodesUsingDescriptionLikeSearchText(strIncomingSearchText, strReferralNumber);
                    }

                    //put the list of 'diagnosis codes' into a usable json list
                    result = jvascrserial.Serialize(lstReturnCodes);

                }
                else if (strIncomingSearchType.Equals("cpt"))
                {

                    if (strIncomingSearchMethod.Equals("codesearch"))
                    {
                        lstReturnCodes = refRepo.GetCptCodesLikeSearchText(strIncomingSearchText, strReferralNumber);
                    }
                    else
                    {
                        lstReturnCodes = refRepo.GetCptCodesUsingDescriptionLikeSearchText(strIncomingSearchText, strReferralNumber);
                    }

                    //put the list of 'cpt codes' into a usable json list
                    result = jvascrserial.Serialize(lstReturnCodes);

                }
                else if (strIncomingSearchType.Equals("hcpcs"))
                {

                    if (strIncomingSearchMethod.Equals("codesearch"))
                    {
                        lstReturnCodes = refRepo.GetHcpcsCodesLikeSearchText(strIncomingSearchText, strReferralNumber);
                    }
                    else
                    {
                        lstReturnCodes = refRepo.GetHcpcsCodesUsingDescriptionLikeSearchText(strIncomingSearchText, strReferralNumber);
                    }

                    //put the list of 'hcpcs codes' into a usable json list
                    result = jvascrserial.Serialize(lstReturnCodes);

                }


                //return the JSON list of 'medical codes'
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        public ActionResult AddCodeToReferral(string codetype, string codeid, string refno)
        {

            try
            {

                if (!string.IsNullOrEmpty(codeid) && !string.IsNullOrEmpty(codetype) && !string.IsNullOrEmpty(refno))
                {

                    ReferralRepository refRepo = new ReferralRepository();
                    MedicalCodeSearchViewModel vmCodeToAdd = new MedicalCodeSearchViewModel();

                    if (codetype.Equals("diag"))
                    {
                        vmCodeToAdd.DiagnosisCodeSearch = true;
                    }
                    else if (codetype.Equals("cpt"))
                    {
                        vmCodeToAdd.CptCodeSearch = true;
                    }
                    else if (codetype.Equals("hcpcs"))
                    {
                        vmCodeToAdd.HcpcsCodeSearch = true;
                    }

                    vmCodeToAdd.SelectedSearchItemCodeId = Convert.ToInt32(codeid);
                    vmCodeToAdd.Code = refRepo.GetMedicalCodeUsingCodeTypeAndCodeId(vmCodeToAdd);
                    vmCodeToAdd.ReferralNumber = refno;
                    vmCodeToAdd.MemberId = refRepo.GetReferralMemberIdUsingReferralNumber(refno);
                    vmCodeToAdd.UserId = User.Identity.GetUserId();


                    if (!string.IsNullOrEmpty(vmCodeToAdd.MemberId) && !string.IsNullOrEmpty(vmCodeToAdd.Code))
                    {

                        //add the selected code to the referral
                        if (refRepo.AddReferralMedicalCode(vmCodeToAdd))
                        {

                            ReferralViewModel vmReferralCodes = new ReferralViewModel();

                            vmReferralCodes = refRepo.InitializeReferralCodes(vmCodeToAdd.ReferralNumber);

                            refRepo.InitializeReferralCodesControls(ref vmReferralCodes);

                            return View("EditReferralCodes", vmReferralCodes);

                        }
                        else
                        {
                            return RedirectToAction("EditReferralCodes", "MemberProfile", new { RefNum = refno });
                        }
                    }
                    else
                    {
                        return RedirectToAction("EditReferralCodes", "MemberProfile", new { RefNum = refno });
                    }

                }
                else
                {
                    return RedirectToAction("EditReferralCodes", "MemberProfile ", new { RefNum = refno });
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("EditReferralCodes", "MemberProfile ", new { RefNum = refno });
            }

        }

        [Authorize]
        public ActionResult RemoveCodeFromReferral(string CodeType, int Id, string ReferralNumber)
        {

            try
            {

                if (!string.IsNullOrEmpty(CodeType) && Id.CompareTo(0) > 0)
                {

                    ReferralRepository refRepo = new ReferralRepository();
                    MedicalCodeSearchViewModel vmCodeToAdd = new MedicalCodeSearchViewModel();

                    if (CodeType.Equals("diag"))
                    {
                        vmCodeToAdd.DiagnosisCodeSearch = true;
                    }
                    else if (CodeType.Equals("cpt"))
                    {
                        vmCodeToAdd.CptCodeSearch = true;
                    }
                    else if (CodeType.Equals("hcpcs"))
                    {
                        vmCodeToAdd.HcpcsCodeSearch = true;
                    }

                    vmCodeToAdd.SelectedSearchItemCodeId = Id;
                    vmCodeToAdd.ReferralNumber = ReferralNumber;


                    //remove the selected code from the referral
                    if (refRepo.RemoveReferralMedicalCode(vmCodeToAdd))
                    {

                        ReferralViewModel vmReferralCodes = new ReferralViewModel();

                        vmReferralCodes = refRepo.InitializeReferralCodes(vmCodeToAdd.ReferralNumber);

                        refRepo.InitializeReferralCodesControls(ref vmReferralCodes);

                        return View("EditReferralCodes", vmReferralCodes);

                    }
                    else
                    {
                        return RedirectToAction("EditReferralCodes", "MemberProfile", new { RefNum = ReferralNumber });
                    }


                }
                else
                {
                    return RedirectToAction("EditReferralCodes", "MemberProfile ", new { RefNum = ReferralNumber });
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("EditReferralCodes", "MemberProfile ", new { RefNum = ReferralNumber });
            }

        }






        [Authorize]
        public ActionResult EditReferralUtilization(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();


            string strUtilType = refRepo.GetReferralUtilizationTypeUsingReferralNumber(RefNum);

            if (string.IsNullOrEmpty(strUtilType))
            {
                strUtilType = refRepo.GetReferralUtilizationTypeFromReferralTypeTable(RefNum);
            }


            if (strUtilType.Equals("I"))
            {

                UtilizationInpatientDayViewModel refInpatToDisplay = new UtilizationInpatientDayViewModel();

                refInpatToDisplay = refRepo.InitializeInpatientReferralUtilization(RefNum);

                refRepo.InitializeInpatientReferralUtilizationControls(ref refInpatToDisplay);

                return View("EditReferralUtilizationInpatient", refInpatToDisplay);

            }
            else
            {

                UtilizationOutpatientDayViewModel refOutpatToDisplay = new UtilizationOutpatientDayViewModel();

                refOutpatToDisplay = refRepo.InitializeOutpatientReferralUtilization(RefNum);

                refRepo.InitializeOutpatientReferralUtilizationControls(ref refOutpatToDisplay);

                return View("EditReferralUtilizationOutpatient", refOutpatToDisplay);

            }

        }

        [Authorize]
        public ActionResult AddInpatientUtilization(UtilizationInpatientDayViewModel vmFromUtilization)
        {

            string result = "";

            try
            {

                if (ModelState.IsValid)
                {

                    ReferralRepository refRepo = new ReferralRepository();
                    List<UtilizationInpatientDayViewModel> lstRefViewModel = new List<UtilizationInpatientDayViewModel>();


                    //assign the web portal user as the systemuserid
                    vmFromUtilization.SystemUserId = User.Identity.GetUserId();


                    //add the utilization to the referral
                    lstRefViewModel = refRepo.AddReferralInpatientUtilization(vmFromUtilization);

                    JavaScriptSerializer jvascrserial = new JavaScriptSerializer();

                    //put the returned view model into JSON
                    result = jvascrserial.Serialize(lstRefViewModel);


                    //nothing is done with the returned JSON in EditReferralUtilizationInpatient jquery...$(document).on("click", '#btnAddUtilization', function (e) {
                    return Json(result, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()
                    },
                    JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        public ActionResult AddOutpatientUtilization(UtilizationOutpatientDayViewModel vmFromUtilization)
        {

            string result = "";

            try
            {

                if (ModelState.IsValid)
                {

                    ReferralRepository refRepo = new ReferralRepository();
                    List<UtilizationOutpatientDayViewModel> lstRefViewModel = new List<UtilizationOutpatientDayViewModel>();


                    //assign the web portal user as the systemuserid
                    vmFromUtilization.SystemUserId = User.Identity.GetUserId();


                    //add the utilization to the referral
                    lstRefViewModel = refRepo.AddReferralOutpatientUtilization(vmFromUtilization);

                    JavaScriptSerializer jvascrserial = new JavaScriptSerializer();

                    //put the returned view model into JSON
                    result = jvascrserial.Serialize(lstRefViewModel);


                    //nothing is done with the returned JSON in EditReferralUtilizationInpatient jquery...$(document).on("click", '#btnAddUtilization', function (e) {
                    return Json(result, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()
                    },
                    JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        public ActionResult RemoveInpatientUtilizationFromReferral(string UtilType, int LineNum, string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            UtilizationInpatientDayViewModel refToRemove = new UtilizationInpatientDayViewModel();

            try
            {

                refToRemove.InpatientOutpatientType = UtilType;
                refToRemove.ReferralNumber = RefNum;
                refToRemove.LineNumber = LineNum;
                refToRemove.SystemUserId = User.Identity.GetUserId();

                if (refRepo.RemoveInpatientUtilizationFromReferral(refToRemove))
                {

                    refToRemove = refRepo.InitializeInpatientReferralUtilization(RefNum);

                    refRepo.InitializeInpatientReferralUtilizationControls(ref refToRemove);

                }


                return View("EditReferralUtilizationInpatient", refToRemove);

            }
            catch (Exception ex)
            {
                return RedirectToAction("EditReferralUtilization", "MemberProfile ", new { RefNum = RefNum });
            }

        }

        [Authorize]
        public ActionResult RemoveOutpatientUtilizationFromReferral(string UtilType, int LineNum, string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            UtilizationOutpatientDayViewModel refToRemove = new UtilizationOutpatientDayViewModel();

            try
            {

                refToRemove.InpatientOutpatientType = UtilType;
                refToRemove.ReferralNumber = RefNum;
                refToRemove.LineNumber = LineNum;
                refToRemove.SystemUserId = User.Identity.GetUserId();

                if (refRepo.RemoveOutpatientUtilizationFromReferral(refToRemove))
                {

                    refToRemove = refRepo.InitializeOutpatientReferralUtilization(RefNum);

                    refRepo.InitializeOutpatientReferralUtilizationControls(ref refToRemove);

                }


                return View("EditReferralUtilizationOutpatient", refToRemove);

            }
            catch (Exception ex)
            {
                return RedirectToAction("EditReferralUtilization", "MemberProfile ", new { RefNum = RefNum });
            }

        }

        [Authorize]
        public ActionResult GenerateNewAuthNumber(string RefNum)
        {

            string result = "";

            try
            {

                ReferralRepository refRepo = new ReferralRepository();
                List<ReferralViewModel> lstRefViewModel = new List<ReferralViewModel>();


                //generate the new auth number
                lstRefViewModel = refRepo.GenerateNewAuthNumber(RefNum);

                JavaScriptSerializer jvascrserial = new JavaScriptSerializer();

                //put the list of 'reasons for action' into a usable json list
                result = jvascrserial.Serialize(lstRefViewModel);


                //return the JSON list of 'reasons for action'
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }


        }

        [Authorize]
        public ActionResult SaveInpatientReferralAuthDates(UtilizationInpatientDayViewModel vmFromUtilization)
        {

            string result = "";

            try
            {

                ReferralRepository refRepo = new ReferralRepository();
                List<UtilizationInpatientDayViewModel> lstRefViewModel = new List<UtilizationInpatientDayViewModel>();


                //save the referral auth dates
                lstRefViewModel = refRepo.SaveInpatientReferralAuthDates(vmFromUtilization);

                JavaScriptSerializer jvascrserial = new JavaScriptSerializer();

                //put the list of 'reasons for action' into a usable json list
                result = jvascrserial.Serialize(lstRefViewModel);


                //return the JSON list of 'reasons for action'
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        public ActionResult SaveOutpatientReferralAuthDates(UtilizationOutpatientDayViewModel vmFromUtilization)
        {

            string result = "";

            try
            {

                ReferralRepository refRepo = new ReferralRepository();
                List<UtilizationOutpatientDayViewModel> lstRefViewModel = new List<UtilizationOutpatientDayViewModel>();


                //save the referral auth dates
                lstRefViewModel = refRepo.SaveOutpatientReferralAuthDates(vmFromUtilization);

                JavaScriptSerializer jvascrserial = new JavaScriptSerializer();

                //put the list of 'reasons for action' into a usable json list
                result = jvascrserial.Serialize(lstRefViewModel);


                //return the JSON list of 'reasons for action'
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }






        [Authorize]
        public ActionResult EditReferralLetters(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralLetterViewModel refToDisplay = new ReferralLetterViewModel();

            refToDisplay = refRepo.InitializeReferralLetter(RefNum);

            refRepo.InitializeReferralLetterControls(ref refToDisplay);

            return View(refToDisplay);

        }

        [Authorize]
        public FileContentResult ViewReferralLetter(int Id)
        {

            ReferralLetterViewModel refToDisplay = new ReferralLetterViewModel();
            ReferralRepository refRepo = new ReferralRepository();

            try
            {

                refToDisplay.Id = Id;
                refToDisplay.LetterFile = refRepo.GetUmLetterUsingId(Id);

                Response.AppendHeader("Content-Disposition", "inline; filename=ICMS_UM_Letter.pdf");

                return File(refToDisplay.LetterFile, "application/pdf");

            }
            catch(Exception ex)
            {

                return File(refToDisplay.LetterFile, "application/pdf", "ICMS_UM_Letter.pdf");
            }

        }

        [Authorize]
        public ActionResult GenerateReferralLetter(string MemId, string RefNum)
        {

            ReferralLetterViewModel vmGeneratedLetter = new ReferralLetterViewModel();
            ReferralRepository refRepo = new ReferralRepository();

            try
            {               

                string strReferralDecision = refRepo.GetReferralMostRecentDecisionUsingReferralNumber(RefNum);

                if (strReferralDecision.Length.CompareTo(0) > 0)
                {

                    vmGeneratedLetter.ReferralNumber = RefNum;
                    vmGeneratedLetter.MemberId = MemId;


                    if (strReferralDecision.Equals("Approved"))
                    {
                        vmGeneratedLetter.LetterType = "Approved";

                        return RedirectToAction("ViewLetter", vmGeneratedLetter);
                        //vmGeneratedLetter = refRepo.GenerateReferralApprovalLetter(MemId, RefNum);
                    }
                    else if (strReferralDecision.Equals("Denied"))
                    {
                        vmGeneratedLetter.LetterType = "Denied";

                        return RedirectToAction("ViewLetter", vmGeneratedLetter);
                        //vmGeneratedLetter = refRepo.GenerateReferralApprovalLetter(MemId, RefNum);
                    }
                    else
                    {
                        vmGeneratedLetter.LetterType = "Other";

                        return RedirectToAction("ViewLetter", vmGeneratedLetter);
                        //vmGeneratedLetter = refRepo.GenerateReferralApprovalLetter(MemId, RefNum);
                    }
                    

                }
                else
                {
                    vmGeneratedLetter.ModelMessage = "Letter Not Available.  Please Try Again.";
                    return View("ViewLetter", vmGeneratedLetter);
                }

            }
            catch(Exception ex)
            {

                vmGeneratedLetter.ModelMessage = "Letter Not Available.  Please Try Again.";
                return View("ViewLetter", vmGeneratedLetter);
            }

        }

        [Authorize]
        public ActionResult ViewLetter(ReferralLetterViewModel vmLetterToView)
        {

            if (vmLetterToView.LetterType != null)
            {
                return Redirect("/Reports/DisplayReport.aspx?ltrtype=" + vmLetterToView.LetterType + 
                                                            "&refnum=" + vmLetterToView.ReferralNumber +
                                                            "&memid=" + vmLetterToView.MemberId);
            }
            else
            {
                return View();
            }

        }





        [Authorize]
        public ActionResult EditReferralRefers(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralRefersViewModel refToDisplay = new ReferralRefersViewModel();

            refToDisplay = refRepo.InitializeReferralRefers(RefNum);

            refRepo.InitializeReferralRefersControls(ref refToDisplay);

            return View(refToDisplay);

        }

        [Authorize]
        public ActionResult RemoveReferredByToItemFromReferral(string RefNum, string RemoveType, string RemoveId)
        {

            try
            {

                ReferralRepository refRepo = new ReferralRepository();

                if (refRepo.RemoveReferralReferItem(RefNum, RemoveType, RemoveId))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }

            }
            catch(Exception ex)
            {
                return Json(false);
            }

        }

        [Authorize]
        public ActionResult AddReferredByToItemToReferral(string RefNum, string AddType, string AddId)
        {

            bool Added = false;

            try
            {

                ReferralRepository refRepo = new ReferralRepository();

                switch (AddType)
                {

                    case "ReferredByProvider": case "ReferredToProvider":
                        ProviderSearchViewModel provsrchvmToAdd = new ProviderSearchViewModel();

                        provsrchvmToAdd.ReferralNumber = RefNum;
                        provsrchvmToAdd.AddType = AddType;
                        provsrchvmToAdd.PcpId = AddId;

                        if (refRepo.AddReferralReferProviderItem(provsrchvmToAdd))
                        {
                            Added = true;
                        }

                        break;


                    case "ReferredByFacility": case "ReferredToFacility":
                        FacilitySearchViewModel facsrchvmToAdd = new FacilitySearchViewModel();

                        facsrchvmToAdd.ReferralNumber = RefNum;
                        facsrchvmToAdd.AddType = AddType;
                        facsrchvmToAdd.FacilityId = Convert.ToInt32(AddId);

                        if (refRepo.AddReferralReferFacilityItem(facsrchvmToAdd))
                        {
                            Added = true;
                        }

                        break;



                    case "ReferredToVendor":
                        VendorSearchViewModel vendsrchvmToAdd = new VendorSearchViewModel();

                        vendsrchvmToAdd.ReferralNumber = RefNum;
                        vendsrchvmToAdd.AddType = AddType;
                        vendsrchvmToAdd.VendorId = Convert.ToInt32(AddId);

                        if (refRepo.AddReferralReferVendorItem(vendsrchvmToAdd))
                        {
                            Added = true;
                        }

                        break;


                    case "ReferredByPlaceOfService": case "ReferredToPlaceOfService":

                        if (refRepo.AddReferralReferPlaceOfServiceItem(RefNum, AddType, AddId))
                        {
                            Added = true;
                        }

                        break;
                        

                    case "ReferredByStdOfficeLocation":
                        if (refRepo.AddReferralReferStdOfficeLocationItem(RefNum, AddType, AddId))
                        {
                            Added = true;
                        }

                        break;
                    
                }


                return Json(Added);

            }
            catch(Exception ex)
            {
                return Json(false);
            }            

        }

        [Authorize]
        public ActionResult ReferredByToProviderSearch(string FirstName, string LastName, string City, string State)
        {

            string result = "";

            try
            {

                ReferralRepository refRepo = new ReferralRepository();
                List<ProviderSearchViewModel> lstReturnProviders = new List<ProviderSearchViewModel>();
                JavaScriptSerializer jvascrserial = new JavaScriptSerializer();


                lstReturnProviders = refRepo.GetProviderUsingNameLikeSearchText(FirstName, LastName, City, State);


                //put the list of 'reasons for action' into a usable json list
                result = jvascrserial.Serialize(lstReturnProviders);


                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        public ActionResult ReferredByToFacilitySearch(string Name, string City, string State)
        {

            string result = "";

            try
            {

                ReferralRepository refRepo = new ReferralRepository();
                List<FacilitySearchViewModel> lstReturnFacilities = new List<FacilitySearchViewModel>();
                JavaScriptSerializer jvascrserial = new JavaScriptSerializer();


                lstReturnFacilities = refRepo.GetFacilityUsingNameLikeSearchText(Name, City, State);


                //put the list of 'reasons for action' into a usable json list
                result = jvascrserial.Serialize(lstReturnFacilities);


                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        public ActionResult ReferredByToVendorSearch(string Name, string City, string State)
        {

            string result = "";

            try
            {

                ReferralRepository refRepo = new ReferralRepository();
                List<VendorSearchViewModel> lstReturnVendors = new List<VendorSearchViewModel>();
                JavaScriptSerializer jvascrserial = new JavaScriptSerializer();


                lstReturnVendors = refRepo.GetVendorUsingNameLikeSearchText(Name, City, State);


                //put the list of 'reasons for action' into a usable json list
                result = jvascrserial.Serialize(lstReturnVendors);


                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }





        [Authorize]
        public ActionResult EditReferralRequests(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralRequestViewModel refToDisplay = new ReferralRequestViewModel();

            refToDisplay = refRepo.InitializeReferralRequest(RefNum);

            refRepo.InitializeReferralRequestControls(ref refToDisplay);

            return View(refToDisplay);

        }

        [Authorize]
        public ActionResult ReferralMdRequest(string RefNum, string MemId, string AssignToId, string Request)
        {

            try
            {

                ReferralRepository refRepo = new ReferralRepository();

                string UserId = User.Identity.GetUserId();

                if (refRepo.AddReferralMdReview(RefNum, MemId, AssignToId, Request, UserId))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }

            }
            catch(Exception ex)
            {
                return Json(false);
            }

        }

        [Authorize]
        public ActionResult ReferralRequestReply(string RefNum, int Id, string Answer)
        {

            try
            {

                ReferralRepository refRepo = new ReferralRepository();

                if (refRepo.UpdateReferralReviewAnswerForReferralReviewQuestion(RefNum, Id, Answer))
                {

                    string UserId = User.Identity.GetUserId();

                    refRepo.SendReferralReviewEmail(RefNum, Id, UserId);

                    return Json(true);

                }
                else
                {
                    return Json(false);
                }

            }
            catch(Exception ex)
            {
                return Json(false);
            }

        }






        [Authorize]
        public ActionResult EditReferralNotes(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            NotesViewModel refToDisplay = new NotesViewModel();

            refToDisplay = refRepo.InitializeReferralNotes(RefNum);

            refRepo.InitializeReferralNotesControls(ref refToDisplay);

            return View(refToDisplay);

        }

        [Authorize]
        public ActionResult AddUmNoteToReferral(string RefNum, string MemId, string UtilType, int LineNumber, string Note, string OnLetter)
        {

            try
            {

                if (!string.IsNullOrEmpty(RefNum) && !string.IsNullOrEmpty(MemId) && !string.IsNullOrEmpty(Note))
                {

                    NotesRepository noteRepo = new NotesRepository();
                    NotesViewModel noteToInsert = new NotesViewModel();


                    noteToInsert.ReferralNumber = RefNum;
                    noteToInsert.MemberId = MemId;
                    noteToInsert.UtilizationType = UtilType;
                    noteToInsert.LineNumber = LineNumber;
                    noteToInsert.OnLetter = Convert.ToBoolean(OnLetter);
                    noteToInsert.NoteText = Note;
                    noteToInsert.UserId = new Guid(User.Identity.GetUserId());

                    if (noteRepo.InsertUmNote(noteToInsert))
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }

                }
                else
                {
                    return Json(false);
                }

            }
            catch (Exception ex)
            {
                return Json(false);
            }

        }





        [Authorize]
        public ActionResult EditReferralFaxes(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralViewModel refToDisplay = new ReferralViewModel();

            refToDisplay = refRepo.InitializeReferralGeneral(RefNum);

            return View(refToDisplay);

        }





        [Authorize]
        public ActionResult EditReferralSavings(string RefNum)
        {

            ReferralRepository refRepo = new ReferralRepository();
            ReferralSavingsViewModel refToDisplay = new ReferralSavingsViewModel();

            refToDisplay = refRepo.InitializeReferralSavings(RefNum);

            refRepo.InitializeReferralSavingsControls(ref refToDisplay);

            return View(refToDisplay);

        }

        [Authorize]
        public ActionResult AddSavingsToReferral(string RefNum, string MemId, string UtilType, string LineNumber, string Desc, string Unit,
                                                 string Quantity, string Cost, string Negotiated, string Savings, string DollarPercent, string LineItem,
                                                 string Cpt, string Network)
        {

            try
            {
                ReferralRepository refRepo = new ReferralRepository();

                ReferralSavingsViewModel refsavvmToAdd = new ReferralSavingsViewModel();

                refsavvmToAdd.ReferralNumber = RefNum;
                refsavvmToAdd.MemberId = MemId;
                refsavvmToAdd.UtilizationType = UtilType;
                refsavvmToAdd.LineNumber = Convert.ToInt32(LineNumber);
                refsavvmToAdd.SavingsDescription = Desc;
                refsavvmToAdd.SavingsUnitId = Convert.ToInt32(Unit);
                refsavvmToAdd.SavingsQuantity = Convert.ToInt32(Quantity);
                refsavvmToAdd.SavingsCost = Convert.ToDecimal(Cost);
                refsavvmToAdd.SavingsNegotiatedPerUnit = Convert.ToDecimal(Negotiated);
                refsavvmToAdd.SavingsPerUnit = Convert.ToDecimal(Savings);
                refsavvmToAdd.SavingsDollarOrPercent = DollarPercent;
                refsavvmToAdd.SavingsLineItem = Convert.ToBoolean(LineItem);
                refsavvmToAdd.SavingsCptCode = Cpt;
                refsavvmToAdd.SavingsNetworkId = Convert.ToInt32(Network);
                refsavvmToAdd.UserId = new Guid(User.Identity.GetUserId());

                if (refRepo.AddReferralSavings(refsavvmToAdd))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }

            }
            catch(Exception ex)
            {
                return Json(false);
            }

        }

        //RemoveSavingsFromReferral


    }
}