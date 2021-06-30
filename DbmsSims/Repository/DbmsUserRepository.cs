using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DbmsSims.Models;
using DbmsSims.Models.ICMS2;

namespace DbmsSims.Repository
{
    public class DbmsUserRepository
    {


        private ICMS2DbContext _IcmsDb = new ICMS2DbContext();


        public bool ClearUserMemberSearchesForDbmsUser(string UserId)
        {

            bool Removed = false;


            try
            {

                using (var db = new ICMS2DbContext())
                {

                    List<DbmsIcmsSimsUserSearch> removeNavList = new List<DbmsIcmsSimsUserSearch>();


                    removeNavList = (from DbmsSearch in db.DbmsUserMemberSearches
                                     where DbmsSearch.user_id == new Guid(UserId)
                                     select DbmsSearch).ToList();


                    if (removeNavList != null)
                    {

                        foreach (DbmsIcmsSimsUserSearch removeNav in removeNavList)
                        {
                            db.DbmsUserMemberSearches.Remove(removeNav);
                        }


                        db.SaveChanges();



                        Removed = true;

                    }
                    else
                    {
                        Removed = true;
                    }

                }


                return Removed;

            }
            catch(Exception ex)
            {
                return Removed;
            }

        }


        public bool InsertSelectedMemberForDbmsUser(string UserId, string memberid)
        {

            bool Inserted = false;

            using (var db = new ICMS2DbContext())
            {

                //flag older searches as not current member by updating the current_member field in DB
                UpdatePreviousSelectedMemberAsNonCurrentMemberForDbmsUser(UserId);


                DbmsIcmsSimsUserSearch searchInsert = new DbmsIcmsSimsUserSearch();

                searchInsert.user_id = new Guid(UserId);
                searchInsert.member_id = new Guid(memberid);


                searchInsert.search_count = (from Dbmsuser in db.DbmsUserMemberSearches
                                             where Dbmsuser.user_id == new Guid(UserId)
                                             select Dbmsuser.search_count == 0 ? 1 :
                                                    Dbmsuser.search_count + 1)
                                             .FirstOrDefault();
         
                if (searchInsert.search_count == 0)
                {
                    searchInsert.search_count = 1;
                }


                searchInsert.creation_date = DateTime.Now;
                searchInsert.current_member = true;


                db.DbmsUserMemberSearches.Add(searchInsert);

                int InsertResults = db.SaveChanges();


                if (InsertResults.CompareTo(0) > 0)
                {
                    Inserted = true;
                }

            }

            return Inserted;

        }


        public void UpdatePreviousSelectedMemberAsNonCurrentMemberForDbmsUser(string UserId)
        {

            using (var db = new ICMS2DbContext())
            {

                List<DbmsIcmsSimsUserSearch> updatesearches = new List<DbmsIcmsSimsUserSearch>();

                //get all the previous member searches for this user
                updatesearches = (from dbmsusersearch in db.DbmsUserMemberSearches
                                  where dbmsusersearch.user_id == new Guid(UserId)
                                  select dbmsusersearch).ToList();


                if (updatesearches != null)
                {

                    foreach (DbmsIcmsSimsUserSearch removeNav in updatesearches)
                    {

                        //set this entry in the DB as not the current user
                        removeNav.current_member = false;

                        db.DbmsUserMemberSearches.Attach(removeNav);
                        db.Entry(removeNav).State = EntityState.Modified;

                    }


                    db.SaveChanges();

                }

            }

        }


        public bool VerifyDbmsUserHasACurrentlySelectedMember(string UserId, SelectedMemberNavigation navigation)
        {

            bool Selected = false;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    var hassearched = (from dbmsusersearch in db.DbmsUserMemberSearches
                                       join mem in db.DbmsMembers on dbmsusersearch.member_id equals mem.member_id
                                       where dbmsusersearch.user_id == new Guid(UserId)
                                       && dbmsusersearch.current_member == true
                                       select new
                                       {
                                           CurrentlySelectedMemberId = dbmsusersearch.member_id,
                                           FirstName = mem.member_first_name,
                                           LastName = mem.member_last_name,
                                           DateOfBirth = mem.member_birth,
                                       }).FirstOrDefault();

                    if (hassearched != null)
                    {

                        if (hassearched.CurrentlySelectedMemberId.ToString().Length.CompareTo(0) > 0)
                        {

                            navigation.MemberSelected = true;
                            navigation.CurrentlySelectedMemberId = hassearched.CurrentlySelectedMemberId.ToString();
                            navigation.FirstName = hassearched.FirstName;
                            navigation.LastName = hassearched.LastName;
                            navigation.DateOfBirth = hassearched.DateOfBirth.Value.ToShortDateString();

                            Selected = true;
                        }

                    }

                }


                return Selected;

            }
            catch(Exception ex)
            {
                return Selected;
            }

        }


    }
}