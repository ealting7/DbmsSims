using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS2.ViewModels;
using DbmsSims.Repository;
using Microsoft.AspNet.Identity;
using DbmsSims.Models.Downloads.ViewModels;

namespace DbmsSims.Controllers.ICMS
{
    public class MemberController : Controller
    {


        private ICMS2DbContext IcmsDb = new ICMS2DbContext();



        // Member/
        public ActionResult Index()
        {

            return View();
        }




        public ActionResult MemberSearch()
        {            

            return View();
        }




        // /Member/MemberSearchResults
        [HttpPost]
        public ActionResult MemberSearchResults(string member_first_name, string member_last_name)
        {          

            MemberRepository memberSearch = new MemberRepository();
            EditMemberViewModel membersfound = new EditMemberViewModel();

            if (member_first_name.Length.CompareTo(2) > 0 && member_last_name.Length.CompareTo(2) > 0)
            {
                //use the MemberRepository to populate the viewmodel (EditMemberViewModel) for the list of searchresult members
                membersfound.MemberSearchResultList = memberSearch.GetAllMembersUsingFirstAndLastName(member_first_name, member_last_name);


                if (membersfound == null)
                {
                    IcmsIssue issue = new IcmsIssue();
                    issue.Issue = "Member(s) Not Found";

                    return View("IcmsIssue", issue);
                }
                else if (membersfound.MemberSearchResultList.Count == 0)
                {                    
                    IcmsIssue issue = new IcmsIssue();
                    issue.Issue = "Member(s) Not Found";

                    return View("IcmsIssue", issue);
                }

            }
            else
            {
                IcmsIssue issue = new IcmsIssue();
                issue.Issue = "Search Using 2 Characters For First And Last Names";

                return View("IcmsIssue", issue);
            }


            return View(membersfound);



        }







        // /Member/EditMember
        public ActionResult EditMember(string memberid)
        {


            MemberRepository memRepo = new MemberRepository();

            //get the member and populate the viewmodel (EditMemberViewModel)
            EditMemberViewModel memEditVwModel = memRepo.GetEditMemberUsingMemberId(memberid);


            if (memEditVwModel != null)
            {


                memRepo.GetEditMemberAddressUsingMemberId(ref memEditVwModel);
                memRepo.GetEditMemberDayPhoneUsingMemberId(ref memEditVwModel);
                memRepo.GetEditMemberEveningPhoneUsingMemberId(ref memEditVwModel);


                //get all employers (using EmployerRepository class)
                EmployerRepository allEmployers = new EmployerRepository();
                memEditVwModel.EmployersInDbms = allEmployers.GetAllEmployersThatAreActive();


                //get all states
                StatesRepository statesinusa = new StatesRepository();
                memEditVwModel.StatesInUsa = statesinusa.GetAllStates();


                //add selected member to users list of selected members
                DbmsUserRepository userRepo = new DbmsUserRepository();
                userRepo.InsertSelectedMemberForDbmsUser(User.Identity.GetUserId(), memberid);


                return View(memEditVwModel);

            }
            else
            {
                return RedirectToAction("MemberSearch");
            }


        }



        // /Member/EditMember
        [HttpPost]
        public ActionResult EditMember(EditMemberViewModel viewmodelFromView)
        {


            if (ModelState.IsValid)
            {

                try
                {

                    MemberRepository memRepo = new MemberRepository();

                    if (memRepo.UpdateMember(ref viewmodelFromView))
                    {                   

                            ViewData["Message"] = "Member Updated";

                            return View(viewmodelFromView);

                    }
                    else
                    {
                        ViewData["Message"] = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
                    }


                }
                catch
                {
                    ViewData["Message"] = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
                }


            }
            else
            {


            }


            return View(viewmodelFromView);

        }







        // /Member/AddMember
        public ActionResult AddMember()
        {
            
            AddMemberViewModel listsToPopulate = new AddMemberViewModel();

            //repopulate the Employer dropdown
            EmployerRepository allEmployers = new EmployerRepository();
            listsToPopulate.EmployersInDbms = allEmployers.GetAllEmployersThatAreActive();


            //populate State dropdown
            StatesRepository statesinusa = new StatesRepository();
            listsToPopulate.StatesInUsa = statesinusa.GetAllStates();


            return View(listsToPopulate);


        }


        // /Member/AddMember
        [HttpPost]
        public ActionResult AddMember(AddMemberViewModel dataFromViewmodel)
        {

            AddMemberViewModel returnViewModel = new AddMemberViewModel();


            if (ModelState.IsValid)
            { 

                MemberRepository memRepo = new MemberRepository();


                //verify if the member is already in the database
                if (memRepo.VerifyMemberExists(dataFromViewmodel) == false)
                {

                    //insert the member into the database
                    bool MemberInserted = memRepo.InsertMember(dataFromViewmodel);


                    //verify that the member was sucessfully inserted into the database
                    if (MemberInserted)
                    {

                        memRepo.InsertMemberAddress(dataFromViewmodel);

                        memRepo.InsertMemberPhone(dataFromViewmodel);

                        memRepo.InsertClaimsId(dataFromViewmodel);

                        memRepo.InsertMemberEnrollment(dataFromViewmodel);                        

                        ViewData["Message"] = "Member Added";
                    }
                


                }

            }


            //repopulate the Employer dropdown
            EmployerRepository allEmployers = new EmployerRepository();
            returnViewModel.EmployersInDbms = allEmployers.GetAllEmployersThatAreActive();
             

            return View(returnViewModel);

        }


        [Authorize]
        public ActionResult MemberSearchHistory()
        {

            string UserId = User.Identity.GetUserId();

            DbmsUserRepository userRepo = new DbmsUserRepository();
            //userRepo.GetUserSearchHistory(UserId);

            return View();

        }



        [Authorize]
        [HttpPost]
        public ActionResult MergeDuplicateMembers()
        {
            try
            {
                DownloadsViewModel Duplicates = new DownloadsViewModel();
                Duplicates.TpaId = 439;
                Duplicates.SystemUserId = User.Identity.GetUserId();

                MemberRepository FindDuplicates = new MemberRepository();

                if (FindDuplicates.LoadDuplicateMembers(ref Duplicates))
                {
                    FindDuplicates.MergeDuplicateMembers(Duplicates);
                }

                if (FindDuplicates.LoadDuplicateDependents(ref Duplicates))
                {
                    FindDuplicates.MergeDuplicateMembers(Duplicates);
                }

                return RedirectToAction("Downloads", "Downloads");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Downloads", "Downloads");
            }
        }






    }
}
