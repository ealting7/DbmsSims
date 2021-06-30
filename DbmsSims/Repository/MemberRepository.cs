using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS2.ViewModels;
using DbmsSims.Models.Downloads.ViewModels;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace DbmsSims.Repository
{
    public class MemberRepository
    {


        private ICMS2DbContext _IcmsDb = new ICMS2DbContext();




        public List<EditMemberViewModel> GetAllMembersUsingFirstAndLastName(string FirstName, string LastName)
        {

            var members = new List<EditMemberViewModel>();


            using (var db = new ICMS2DbContext())
            {

                members = (from mem in db.DbmsMembers
                           join memenroll in db.DbmsMemberEnrollment on mem.member_id equals memenroll.member_id
                           join emply in db.DbmsEmployers on memenroll.employer_id equals emply.employer_id
                           where mem.member_first_name.StartsWith(FirstName) && mem.member_last_name.StartsWith(LastName)
                           orderby mem.member_last_name, mem.member_first_name
                           select new EditMemberViewModel
                           {
                               MemberId = mem.member_id.ToString(),
                               MemberFirstName = mem.member_first_name,
                               MemberMiddleName = mem.member_middle_name,
                               MemberLastName = mem.member_last_name,
                               MemberBirth = mem.member_birth,
                               MemberSsn = mem.member_ssn,
                               ClaimsId = memenroll.claims_enrollment_id,
                               EmployerId = memenroll.employer_id,
                               EmployerName = emply.employer_name
                           }).ToList();

            }


            return (members);

        }

        public EditMemberViewModel GetEditMemberUsingMemberId(string MemberId)
        {

            var memberselected = new EditMemberViewModel();


            using (var db = new ICMS2DbContext())
            {

                memberselected = (from mem in db.DbmsMembers
                                  join memEnroll in db.DbmsMemberEnrollment on mem.member_id equals memEnroll.member_id
                                  join emply in db.DbmsEmployers on memEnroll.employer_id equals emply.employer_id
                                  where mem.member_id == new Guid(MemberId)
                                  select new EditMemberViewModel
                                  {
                                      MemberId = mem.member_id.ToString(),
                                      MemberFirstName = mem.member_first_name,
                                      MemberMiddleName = mem.member_middle_name,
                                      MemberLastName = mem.member_last_name,
                                      MemberBirth = mem.member_birth,
                                      MemberSsn = mem.member_ssn,
                                      Gender = mem.gender_code,
                                      MedicaidNumber = mem.member_medicaid_num,
                                      MedicareNumber = mem.member_medicare_num,
                                      EmployerId = memEnroll.employer_id,
                                      EmployerName = emply.employer_name,
                                      ClaimsId = memEnroll.claims_id
                                  }).Single();

            }


            return (memberselected);

        }

        public IcmsMember GetMemberUsingMemberId(string MemberId)
        {

            IcmsMember memberselected = new IcmsMember();


            using (var db = new ICMS2DbContext())
            {

                memberselected = (from mem in db.DbmsMembers
                                  join memenroll in db.DbmsMemberEnrollment on mem.member_id equals memenroll.member_id
                                  join emply in db.DbmsEmployers on memenroll.employer_id equals emply.employer_id
                                  where mem.member_id == new Guid(MemberId)
                                  orderby mem.member_last_name, mem.member_first_name
                                  select mem).Single();

            }


            return (memberselected);

        }



        public MemberEnrollment GetMemberEnrollmentUserMemberId(string MemberId)
        {

            MemberEnrollment memenrollselected = new MemberEnrollment();


            using (var db = new ICMS2DbContext())
            {

                memenrollselected = (from memenroll in db.DbmsMemberEnrollment
                                     where memenroll.member_id == new Guid(MemberId)
                                     select memenroll).Single();

            }


            return (memenrollselected);

        }

        public bool GetMembersEmployerClientAndClientBu(AddMemberViewModel assignToViewmodel)
        {

            bool RetrievedClientAndClientBu = false;


            if (assignToViewmodel.EmployerId.Value.CompareTo(0) > 0)
            {

                EmployerRepository emply = new EmployerRepository();

                ClientBuEmployer clntbuemply = emply.GetEmployerClient(assignToViewmodel.EmployerId.Value);


                if (clntbuemply != null)
                {

                    if (clntbuemply.client_id.CompareTo(0) > 0 && clntbuemply.client_bu_id.CompareTo(0) > 0)
                    {

                        assignToViewmodel.ClientId = clntbuemply.client_id;
                        assignToViewmodel.ClientBuId = clntbuemply.client_bu_id;

                        RetrievedClientAndClientBu = true;

                    }

                }


            }


            return RetrievedClientAndClientBu;

        }

        public bool GetMemberClientBuClaimSystemId(AddMemberViewModel assignToViewmodel)
        {

            bool RetrievedClaimSystemId = false;


            if (assignToViewmodel.ClientBuId.CompareTo(0) > 0)
            {

                EmployerRepository emply = new EmployerRepository();

                ClientBu clntbu = emply.GetClientBuClaimSystemId(assignToViewmodel.ClientBuId);


                if (clntbu != null)
                {

                    if (clntbu.claims_system_id.CompareTo(0) > 0)
                    {

                        assignToViewmodel.ClaimsSystemId = clntbu.claims_system_id;

                        RetrievedClaimSystemId = true;

                    }

                }


            }


            return RetrievedClaimSystemId;

        }



        public MemberAddress GetMemberAddressNotAlternateUsingMemberId(string strMemberId)
        {

            MemberAddress memAddrToReturn = new MemberAddress();


            try
            {

                using (var db = new ICMS2DbContext())
                {

                    memAddrToReturn = (from memAddr in db.DbmsMemberAddresses
                                       where memAddr.member_id == new Guid(strMemberId)
                                       && (memAddr.is_alternate == null || memAddr.is_alternate == false)
                                       select memAddr).Single();

                }

                return (memAddrToReturn);

            }
            catch (Exception ex)
            {
                return (memAddrToReturn);
            }

        }

        public void GetEditMemberAddressUsingMemberId(ref EditMemberViewModel memEditVwModel)
        {

            try
            {

                MemberAddress memAddr = GetMemberAddressNotAlternateUsingMemberId(memEditVwModel.MemberId);

                if (memAddr != null)
                {
                    memEditVwModel.Address1 = memAddr.address_line1;
                    memEditVwModel.Address2 = memAddr.address_line2;
                    memEditVwModel.City = memAddr.city;
                    memEditVwModel.StateAbbrev = memAddr.state_abbrev;
                    memEditVwModel.state_abbrev = memEditVwModel.StateAbbrev;
                    memEditVwModel.ZipCode = memAddr.zip_code;
                }

            }
            catch (Exception ex)
            {

            }

        }



        public MemberPhone GetMemberDayPhoneUsingMemberId(string strMemberId)
        {

            MemberPhone memDayPhoneToReturn = new MemberPhone();


            using (var db = new ICMS2DbContext())
            {

                memDayPhoneToReturn = (from memAddr in db.DbmsMemberPhone
                                       where memAddr.member_id == new Guid(strMemberId)
                                       && memAddr.phone_type_id == 1
                                       select memAddr).Single();

            }


            return (memDayPhoneToReturn);

        }

        public MemberPhone GetMemberEveningPhoneUsingMemberId(string strMemberId)
        {

            MemberPhone memEveningPhoneToReturn = new MemberPhone();


            using (var db = new ICMS2DbContext())
            {

                memEveningPhoneToReturn = (from memAddr in db.DbmsMemberPhone
                                           where memAddr.member_id == new Guid(strMemberId)
                                           && memAddr.phone_type_id == 2
                                           select memAddr).Single();

            }


            return (memEveningPhoneToReturn);

        }

        public void GetEditMemberDayPhoneUsingMemberId(ref EditMemberViewModel memEditVwModel)
        {

            try
            {

                MemberPhone memPhone = GetMemberDayPhoneUsingMemberId(memEditVwModel.MemberId);

                if (memPhone != null)
                {
                    memEditVwModel.DayPhone = memPhone.phone_number;
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void GetEditMemberEveningPhoneUsingMemberId(ref EditMemberViewModel memEditVwModel)
        {

            try
            {

                MemberPhone memPhone = GetMemberEveningPhoneUsingMemberId(memEditVwModel.MemberId);

                if (memPhone != null)
                {
                    memEditVwModel.EveningPhone = memPhone.phone_number;
                }

            }
            catch (Exception ex)
            {

            }

        }




        public bool LoadDuplicateMembers(ref DownloadsViewModel Duplicates)
        {
            bool Loaded = false;

            try
            {
                Duplicates.DuplicateMembersToMerge = new List<EligibilityViewModel>();

                if (Duplicates != null)
                {
                    if (Duplicates.TpaId > 0)
                    {
                        List<IcmsMember> MembersToCheck = new List<IcmsMember>();
                        MembersToCheck = LoadAllMembersForTpa(Duplicates.TpaId);

                        if (MembersToCheck != null)
                        {
                            if (MembersToCheck.Count > 0)
                            {
                                FindDuplicateMembersInList(ref Duplicates, MembersToCheck);
                            }
                        }
                    }
                }

                if (Duplicates.DuplicateMembersToMerge.Count > 0)
                {
                    CreateDuplicateMemberList(Duplicates);
                    AddDuplicateMembersToFile(Duplicates);
                    Loaded = true;
                }

                return Loaded;
            }
            catch (Exception ex)
            {
                return Loaded;
            }
        }

        public bool LoadDuplicateDependents(ref DownloadsViewModel Duplicates)
        {
            bool Loaded = false;

            try
            {
                Duplicates.DuplicateMembersToMerge = new List<EligibilityViewModel>();

                if (Duplicates != null)
                {
                    if (Duplicates.TpaId > 0)
                    {
                        List<IcmsMember> MembersToCheck = new List<IcmsMember>();
                        MembersToCheck = LoadAllDependentsForTpa(Duplicates.TpaId);

                        if (MembersToCheck != null)
                        {
                            if (MembersToCheck.Count > 0)
                            {
                                FindDuplicateDependentsInList(ref Duplicates, MembersToCheck);
                            }
                        }
                    }
                }

                if (Duplicates.DuplicateMembersToMerge.Count > 0)
                {
                    CreateDuplicateMemberList(Duplicates);
                    AddDuplicateMembersToFile(Duplicates);
                    Loaded = true;
                }

                return Loaded;
            }
            catch (Exception ex)
            {
                return Loaded;
            }
        }

        public List<IcmsMember> LoadAllMembersForTpa(int TpaId)
        {
            List<IcmsMember> MembersToReturn = new List<IcmsMember>();

            try
            {

                if (TpaId > 0)
                {
                    using (var db = new ICMS2DbContext())
                    {
                        MembersToReturn = (from mem in db.DbmsMembers

                                           join memenroll in db.DbmsMemberEnrollment
                                           on mem.member_id equals memenroll.member_id

                                           join tpaemply in db.DbmsTpaEmployer
                                           on memenroll.employer_id equals tpaemply.employer_id

                                           where tpaemply.tpa_id == TpaId
                                           && mem.relationship_id == 1
                                           && mem.member_active_flag == false
                                           orderby mem.member_last_name, mem.member_first_name, mem.member_birth
                                           select mem).ToList();
                    }
                }

                return MembersToReturn;
            }
            catch (Exception ex)
            {
                return MembersToReturn;
            }
        }

        public List<IcmsMember> LoadAllDependentsForTpa(int TpaId)
        {
            List<IcmsMember> MembersToReturn = new List<IcmsMember>();

            try
            {

                if (TpaId > 0)
                {
                    using (var db = new ICMS2DbContext())
                    {
                        MembersToReturn = (from mem in db.DbmsMembers

                                           join memenroll in db.DbmsMemberEnrollment
                                           on mem.member_id equals memenroll.member_id

                                           join tpaemply in db.DbmsTpaEmployer
                                           on memenroll.employer_id equals tpaemply.employer_id

                                           where tpaemply.tpa_id == TpaId
                                           && mem.relationship_id > 1
                                           && mem.member_active_flag == false
                                           orderby mem.member_last_name, mem.member_first_name, mem.member_birth
                                           select mem).ToList();
                    }
                }

                return MembersToReturn;
            }
            catch (Exception ex)
            {
                return MembersToReturn;
            }
        }

        private void FindDuplicateMembersInList(ref DownloadsViewModel Duplicates, List<IcmsMember> MembersToCheck)
        {
            try
            {
                string CityToCheck = "";
                string MemberId = "";
                string FirstName = "";
                string LastName = "";
                string Dob = "";

                foreach (IcmsMember member in MembersToCheck)
                {
                    bool MemberDuplicate = false;

                    using (var db = new ICMS2DbContext())
                    {
                        int TpaId = Duplicates.TpaId;

                        List<IcmsMember> DupeMembers = (from mem in db.DbmsMembers

                                                        join memenroll in db.DbmsMemberEnrollment
                                                        on mem.member_id equals memenroll.member_id

                                                        join tpaemply in db.DbmsTpaEmployer
                                                        on memenroll.employer_id equals tpaemply.employer_id

                                                        where mem.member_last_name == member.member_last_name
                                                        && mem.member_first_name == member.member_first_name
                                                        && mem.member_birth == member.member_birth
                                                        //&& mem.relationship_id == 1
                                                        && mem.member_active_flag == false
                                                        && tpaemply.tpa_id == TpaId
                                                        orderby mem.member_updated descending, mem.creaion_date descending
                                                        select mem).ToList();

                        if (DupeMembers.Count > 1)
                        {
                            CityToCheck = FindDuplicateMemberCity(DupeMembers);

                            if (!string.IsNullOrEmpty(CityToCheck))
                            {
                                if (DuplicateMemberAddresses(ref DupeMembers, CityToCheck))
                                {
                                    MemberId = member.member_id.ToString();
                                    FirstName = member.member_first_name;
                                    LastName = member.member_last_name;
                                    Dob = member.member_birth.ToString();

                                    MemberDuplicate = true;
                                }
                            }
                        }
                    }


                    if (MemberDuplicate)
                    {

                        EligibilityViewModel MemberToMerge = new EligibilityViewModel();

                        MemberToMerge.SystemUserId = Duplicates.SystemUserId;
                        MemberToMerge.DepCity = CityToCheck;
                        MemberToMerge.MemId = MemberId;
                        MemberToMerge.DepFirstName = FirstName;
                        MemberToMerge.DepLastName = LastName;
                        MemberToMerge.DepDob = Dob;

                        if (DuplicateNotInList(MemberToMerge, Duplicates))
                        {
                            Duplicates.DuplicateMembersToMerge.Add(MemberToMerge);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void FindDuplicateDependentsInList(ref DownloadsViewModel Duplicates, List<IcmsMember> MembersToCheck)
        {
            try
            {
                string CityToCheck = "";
                string MemberId = "";
                string FirstName = "";
                string LastName = "";
                string Dob = "";

                foreach (IcmsMember member in MembersToCheck)
                {
                    bool MemberDuplicate = false;

                    using (var db = new ICMS2DbContext())
                    {
                        List<IcmsMember> DupeMembers = (from mem in db.DbmsMembers
                                                        where mem.member_last_name == member.member_last_name
                                                        && mem.member_first_name == member.member_first_name
                                                        && mem.member_birth == member.member_birth
                                                        && mem.relationship_id > 1
                                                        && mem.member_active_flag == false
                                                        orderby mem.member_updated descending, mem.creaion_date descending
                                                        select mem).ToList();

                        if (DupeMembers.Count > 1)
                        {
                            CityToCheck = FindDuplicateMemberCity(DupeMembers);

                            if (!string.IsNullOrEmpty(CityToCheck))
                            {
                                if (DuplicateMemberAddresses(ref DupeMembers, CityToCheck))
                                {
                                    MemberId = member.member_id.ToString();
                                    FirstName = member.member_first_name;
                                    LastName = member.member_last_name;
                                    Dob = member.member_birth.ToString();

                                    MemberDuplicate = true;
                                }
                            }
                        }
                    }


                    if (MemberDuplicate)
                    {

                        EligibilityViewModel MemberToMerge = new EligibilityViewModel();

                        MemberToMerge.SystemUserId = Duplicates.SystemUserId;
                        MemberToMerge.DepCity = CityToCheck;
                        MemberToMerge.MemId = MemberId;
                        MemberToMerge.DepFirstName = FirstName;
                        MemberToMerge.DepLastName = LastName;
                        MemberToMerge.DepDob = Dob;

                        if (DuplicateNotInList(MemberToMerge, Duplicates))
                        {
                            Duplicates.DuplicateMembersToMerge.Add(MemberToMerge);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void CreateDuplicateMemberList(DownloadsViewModel Duplicates)
        {
            try
            {

                //Create COM Objects (Excel): application
                Excel.Application excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false;

                //Create COM Objects (Excel): workbook
                Excel.Workbook excelWrkbook = excelApp.Workbooks.Add(Type.Missing);

                //Create COM Objects (Excel): worksheet
                Excel.Worksheet xlWorksheet;


                xlWorksheet = (Excel.Worksheet)excelWrkbook.ActiveSheet;
                xlWorksheet.Name = "Duplicates";


                //create the excel file on the ftp
                excelWrkbook.SaveAs("C:\\ICMS Letter Templates\\temp\\duplicate_egp_dependents.xls");


                GC.Collect();
                GC.WaitForPendingFinalizers();


                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                excelWrkbook.Close(0);
                Marshal.ReleaseComObject(excelWrkbook);


                //quit and release
                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);

                excelApp = null;

            }
            catch(Exception ex)
            {

            }
        }

        private void AddDuplicateMembersToFile(DownloadsViewModel Duplicates)
        {
            try
            {
                //Create COM Objects (Excel): application
                Excel.Application excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false;
                excelApp.Visible = false;

                //Open the file
                Excel.Workbook excelWrkbook = excelApp.Workbooks.Open("C:\\ICMS Letter Templates\\temp\\duplicate_egp_dependents.xls",
                                                                      0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                //Get all the sheets in the workbook
                Excel.Sheets mWorkSheets = excelWrkbook.Worksheets;

                //Get the worksheet that will be modified
                Excel.Worksheet xlWorksheet = (Excel.Worksheet)mWorkSheets.get_Item("Duplicates");


                //Create COM Objects (Excel): range
                Excel.Range xlRange = xlWorksheet.UsedRange;

                //the starting row in the worksheet
                int intWrkSheetRowCnt = 1;


                foreach (EligibilityViewModel duplicatemember in Duplicates.DuplicateMembersToMerge)
                {
                    xlWorksheet.Cells[intWrkSheetRowCnt, 1] = duplicatemember.DepFirstName;
                    xlWorksheet.Cells[intWrkSheetRowCnt, 2] = duplicatemember.DepLastName;
                    xlWorksheet.Cells[intWrkSheetRowCnt, 3] = duplicatemember.DepDob;

                     intWrkSheetRowCnt++;
                }

                //Save the file
                excelWrkbook.SaveAs("C:\\ICMS Letter Templates\\temp\\duplicate_egp_dependents.xls",
                                    Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing);

                GC.Collect();
                GC.WaitForPendingFinalizers();


                Marshal.ReleaseComObject(xlWorksheet);
                xlWorksheet = null;

                //close and release
                excelWrkbook.Close(Type.Missing, Type.Missing, Type.Missing);
                Marshal.ReleaseComObject(excelWrkbook);
                excelWrkbook = null;

                //quit and release
                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);
                excelApp = null;
            }
            catch(Exception ex)
            {

            }
        }


        private string FindDuplicateMemberCity(List<IcmsMember> DupeMembers)
        {
            string CityToReturn = "";

            try
            {
                if (DupeMembers.Count > 1)
                {
                    IcmsMember member = DupeMembers.ElementAt(0);

                    using (var db = new ICMS2DbContext())
                    {
                        CityToReturn = (from address in db.DbmsMemberAddresses
                                        where address.member_id == member.member_id
                                        && address.address_type_id == 1
                                        && (address.is_alternate == false || address.is_alternate == null)
                                        orderby address.member_address_id
                                        select address.city).FirstOrDefault();


                        if (CityToReturn == null)
                        {
                            member = DupeMembers.ElementAt(1);

                            CityToReturn = (from address in db.DbmsMemberAddresses
                                            where address.member_id == member.member_id
                                            && address.address_type_id == 1
                                            && (address.is_alternate == false || address.is_alternate == null)
                                            orderby address.member_address_id
                                            select address.city).FirstOrDefault();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(CityToReturn))
                            {
                                member = DupeMembers.ElementAt(1);

                                CityToReturn = (from address in db.DbmsMemberAddresses
                                                where address.member_id == member.member_id
                                                && address.address_type_id == 1
                                                && (address.is_alternate == false || address.is_alternate == null)
                                                orderby address.member_address_id
                                                select address.city).FirstOrDefault();
                            }
                        }
                    }
                }

                return CityToReturn;
            }
            catch(Exception ex)
            {
                return CityToReturn;
            }
        }

        private bool DuplicateMemberAddresses(ref List<IcmsMember> DupeMembers, string CityToCheck)
        {
            bool Duplicate = false;

            try
            {
                int intRemoveItem = 0;
                List<int> lstRemoveIndex = new List<int>();

                foreach (IcmsMember member in DupeMembers)
                {
                    using (var db = new ICMS2DbContext())
                    {
                        string membercity = "";

                        //search MEMBER_ADRESS table
                        membercity = (from address in db.DbmsMemberAddresses
                                      where address.member_id == member.member_id
                                      && address.address_type_id == 1
                                      && (address.is_alternate == false || address.is_alternate == null)
                                      orderby address.member_address_id
                                      select address.city).FirstOrDefault();

                        if (membercity != null)
                        {
                            if (!string.IsNullOrEmpty(membercity))
                            {
                                if (!membercity.ToLower().Equals(CityToCheck.ToLower()))
                                {
                                    lstRemoveIndex.Add(intRemoveItem);
                                }
                            }
                        }
                    }

                    intRemoveItem++;
                }


                if (lstRemoveIndex.Count > 0)
                {
                    foreach (var RemoveItem in lstRemoveIndex)
                    {
                        if (DupeMembers.Count.Equals(RemoveItem))
                        {
                            DupeMembers.RemoveAt(RemoveItem - 1);
                        }
                        else
                        {
                            DupeMembers.RemoveAt(RemoveItem);
                        }
                    }
                }

                if (DupeMembers != null)
                {
                    if (DupeMembers.Count > 1)
                    {
                        Duplicate = true;
                    }
                }

                return Duplicate;
            }
            catch(Exception ex)
            {
                return Duplicate;
            }
        }

        private bool DuplicateNotInList(EligibilityViewModel PotentialMemberToMerge, DownloadsViewModel Duplicates)
        {
            bool NotInList = true;

            try
            {
                if (Duplicates.DuplicateMembersToMerge != null)
                {
                    if (Duplicates.DuplicateMembersToMerge.Count > 0)
                    {
                        foreach (EligibilityViewModel checkmember in Duplicates.DuplicateMembersToMerge)
                        {
                            if (checkmember.DepLastName.Equals(PotentialMemberToMerge.DepLastName))
                            {
                                if (checkmember.DepFirstName.Equals(PotentialMemberToMerge.DepFirstName))
                                {
                                    if (checkmember.DepDob.Equals(PotentialMemberToMerge.DepDob))
                                    {
                                        if (checkmember.DepCity.Equals(PotentialMemberToMerge.DepCity))
                                        {
                                            NotInList = false;
                                            return NotInList;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return NotInList;
            }
            catch(Exception ex)
            {
                return NotInList;
            }
        }

        public void MergeDuplicateMembers(DownloadsViewModel Duplicates)
        {
            int Count = 1;

            try
            {
                DownloadsRepository DownloadRepo = new DownloadsRepository();

                Guid SystemUserId = Guid.Empty;

                if (!string.IsNullOrEmpty(Duplicates.SystemUserId))
                {
                    SystemUserId = new Guid(Duplicates.SystemUserId);
                }
                else
                {
                    SystemUserId = new Guid("8C4AA16B-75FE-11D3-A7EE-00500499C350");
                }

                foreach (EligibilityViewModel DuplicateMember in Duplicates.DuplicateMembersToMerge)
                {
                    DownloadRepo.MergeDuplicateMember(DuplicateMember, SystemUserId);
                    Count++;
                }
            }
            catch(Exception ex)
            {

            }
        }









        public bool VerifyMemberExists(AddMemberViewModel memberToVerify)
        {

            bool blnExists = false;
            IcmsMember memberInDb = new IcmsMember();


            memberInDb = (from mem in _IcmsDb.DbmsMembers
                          join memenroll in _IcmsDb.DbmsMemberEnrollment on mem.member_id equals memenroll.member_id
                          where mem.member_first_name == memberToVerify.MemberFirstName
                          && mem.member_last_name == memberToVerify.MemberLastName
                          && mem.member_birth == memberToVerify.MemberBirth
                          && memenroll.employer_id == memberToVerify.EmployerId
                          select mem).SingleOrDefault();


            if (memberInDb != null)
            {
                if (memberInDb.member_id != null)
                {
                    blnExists = true;
                }
            }


            return blnExists;

        }





        public bool UpdateMember(ref EditMemberViewModel vmMemberToUpdate)
        {

            bool blnUpdated = false;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    //initialize the IcmsMember and MemberEnrollment model items
                    IcmsMember memToEdit = GetMemberUsingMemberId(vmMemberToUpdate.MemberId);
                    MemberEnrollment memEnrollToEdit = GetMemberEnrollmentUserMemberId(vmMemberToUpdate.MemberId);
                    MemberAddress memAddrsToEdit = GetMemberAddressNotAlternateUsingMemberId(vmMemberToUpdate.MemberId);
                    MemberPhone memDayPhoneToEdit = GetMemberDayPhoneUsingMemberId(vmMemberToUpdate.MemberId);
                    MemberPhone memEveningPhoneToEdit = GetMemberEveningPhoneUsingMemberId(vmMemberToUpdate.MemberId);


                    //member found...update it
                    if (memToEdit != null)
                    {

                        //assign the viewmodel (EditMemberViewModel) values to the model (IcmsMember) item
                        memToEdit.member_first_name = vmMemberToUpdate.MemberFirstName;
                        memToEdit.member_middle_name = vmMemberToUpdate.MemberMiddleName;
                        memToEdit.member_last_name = vmMemberToUpdate.MemberLastName;
                        memToEdit.member_birth = Convert.ToDateTime(vmMemberToUpdate.MemberBirth);
                        memToEdit.member_ssn = vmMemberToUpdate.MemberSsn;
                        memToEdit.member_medicaid_num = vmMemberToUpdate.MedicaidNumber;
                        memToEdit.member_medicare_num = vmMemberToUpdate.MedicareNumber;


                        //change the model (Member) state to modified
                        db.Entry(memToEdit).State = EntityState.Modified;


                        //member enrollment found...update it
                        if (memEnrollToEdit != null)
                        {

                            //assign the viewmodel (EditMemberViewModel) value (EmployerId) to the model (MemberEnrollment) item
                            memEnrollToEdit.employer_id = vmMemberToUpdate.EmployerId;
                            memEnrollToEdit.claims_id = vmMemberToUpdate.ClaimsId;

                            //change the model (MemberEnrollment) state to modified
                            db.Entry(memEnrollToEdit).State = EntityState.Modified;

                        }



                        //member address found...update it
                        if (memAddrsToEdit != null)
                        {

                            memAddrsToEdit.address_line1 = vmMemberToUpdate.Address1;
                            memAddrsToEdit.address_line2 = vmMemberToUpdate.Address2;
                            memAddrsToEdit.city = vmMemberToUpdate.City;
                            memAddrsToEdit.state_abbrev = vmMemberToUpdate.StateAbbrev;
                            memAddrsToEdit.zip_code = vmMemberToUpdate.ZipCode;

                            db.Entry(memAddrsToEdit).State = EntityState.Modified;

                        }
                        else
                        {

                            //member address does NOT exist but the user added it...create it
                            if (vmMemberToUpdate.Address1.Length.CompareTo(0) > 0 || 
                                vmMemberToUpdate.City.Length.CompareTo(0) > 0 ||
                                vmMemberToUpdate.StateAbbrev.Length.CompareTo(0) > 0 ||
                                vmMemberToUpdate.ZipCode.Length.CompareTo(0) > 0)
                            {
                                
                                MemberAddress memAddrsToAdd = new MemberAddress();

                                memAddrsToAdd.member_id = new Guid(vmMemberToUpdate.MemberId);
                                memAddrsToAdd.address_line1 = vmMemberToUpdate.Address1;
                                memAddrsToAdd.address_line2 = vmMemberToUpdate.Address2;
                                memAddrsToAdd.city = vmMemberToUpdate.City;
                                memAddrsToAdd.state_abbrev = vmMemberToUpdate.StateAbbrev;
                                memAddrsToAdd.zip_code = vmMemberToUpdate.ZipCode;

                                db.Entry(memAddrsToAdd).State = EntityState.Added;

                            }

                        }



                        //member day phone found...update it
                        if (memDayPhoneToEdit != null)
                        {

                            memDayPhoneToEdit.phone_number = vmMemberToUpdate.DayPhone;

                            db.Entry(memDayPhoneToEdit).State = EntityState.Modified;

                        }
                        else
                        {

                            //member day phone does NOT exist but the user added it...create it
                            if (vmMemberToUpdate.DayPhone.Length.CompareTo(0) > 0)
                            {
                                
                                MemberPhone memDayPhoneToAdd = new MemberPhone();

                                memDayPhoneToAdd.phone_type_id = 1;
                                memDayPhoneToAdd.phone_number = vmMemberToUpdate.DayPhone;

                                db.Entry(memDayPhoneToAdd).State = EntityState.Added;

                            }

                        }



                        //member evening phone found...update it
                        if (memEveningPhoneToEdit != null)
                        {

                            memEveningPhoneToEdit.phone_number = vmMemberToUpdate.EveningPhone;

                            db.Entry(memEveningPhoneToEdit).State = EntityState.Modified;

                        }
                        else
                        {

                            //member evening phone does NOT exist but the user added it...create it
                            if (vmMemberToUpdate.EveningPhone.Length.CompareTo(0) > 0)
                            {

                                MemberPhone memEveningPhoneToAdd = new MemberPhone();

                                memEveningPhoneToAdd.phone_type_id = 2;
                                memEveningPhoneToAdd.phone_number = vmMemberToUpdate.EveningPhone;

                                db.Entry(memEveningPhoneToAdd).State = EntityState.Added;

                            }

                        }



                        //update the model (IcmsMember) in the database
                        int updatesreturned = db.SaveChanges();


                        //repopulate the Employer dropdown
                        EmployerRepository allEmployers = new EmployerRepository();
                        vmMemberToUpdate.EmployersInDbms = allEmployers.GetAllEmployersThatAreActive();


                        //the update was a success if updatesreturned is greater than 0
                        if (updatesreturned > 0)
                        {
                            blnUpdated = true;
                        }

                    }

                }

                 return blnUpdated;

            }
            catch(Exception ex)
            {
                return blnUpdated;
            }

        }







        public bool InsertMember(AddMemberViewModel dataFromViewmodel)
        {

            bool Inserted = false;

            try
            {

                IcmsMember memberToInsert = new IcmsMember();

                memberToInsert.member_id = Guid.NewGuid();


                if (memberToInsert.member_id.ToString().Length.CompareTo(0) > 0 &&
                    memberToInsert.member_id.ToString() != "{00000000-0000-0000-0000-000000000000}")
                {

                    memberToInsert.member_first_name = dataFromViewmodel.MemberFirstName;
                    memberToInsert.member_middle_name = dataFromViewmodel.MemberMiddleName;
                    memberToInsert.member_last_name = dataFromViewmodel.MemberLastName;
                    memberToInsert.member_ssn = dataFromViewmodel.MemberSsn;
                    memberToInsert.medicare_primary = dataFromViewmodel.MedicarePrimary;
                    memberToInsert.relationship_id = (!string.IsNullOrEmpty(dataFromViewmodel.Relationship)) ? Convert.ToInt32(dataFromViewmodel.Relationship) : 1;
                    memberToInsert.creaion_date = DateTime.Now;

                    if (dataFromViewmodel.MemberBirth.HasValue)
                    {
                        memberToInsert.member_birth = dataFromViewmodel.MemberBirth;
                    }

                    if (!string.IsNullOrEmpty(dataFromViewmodel.Gender))
                    {
                        memberToInsert.gender_code = dataFromViewmodel.Gender;
                    }

                    if (!string.IsNullOrEmpty(dataFromViewmodel.Netork))
                    {
                        memberToInsert.network = dataFromViewmodel.Netork;
                    }

                    if (dataFromViewmodel.MedicareEffDate.HasValue)
                    {
                        memberToInsert.medicare_effective_date = dataFromViewmodel.MedicareEffDate;
                    }

                    if (dataFromViewmodel.EffectiveDate != DateTime.MinValue)
                    {
                        memberToInsert.member_effective_date = dataFromViewmodel.EffectiveDate;
                    }

                    if (dataFromViewmodel.TerminationDate != DateTime.MinValue)
                    {
                        memberToInsert.member_disenroll_date = dataFromViewmodel.TerminationDate;
                    }

                    if (!string.IsNullOrEmpty(dataFromViewmodel.SystemUserId))
                    {
                        memberToInsert.creation_user_id = new Guid(dataFromViewmodel.SystemUserId);
                        memberToInsert.last_update_user_id = new Guid(dataFromViewmodel.SystemUserId);
                    }
                    else
                    {
                        memberToInsert.creation_user_id = new Guid("{8C4AA16B-75FE-11D3-A7EE-00500499C350}");
                        memberToInsert.last_update_user_id = new Guid("{8C4AA16B-75FE-11D3-A7EE-00500499C350}");
                    }


                    using (var db = new ICMS2DbContext())
                    {

                        db.DbmsMembers.Add(memberToInsert);

                        int InsertResults = db.SaveChanges();


                        if (InsertResults.CompareTo(0) > 0)
                        {
                            //because a Member was inserted into the database assign the member_id to the 
                            //passed in AddMemberViewModel variable for use elsewhere in the MemberController
                            dataFromViewmodel.MemberId = memberToInsert.member_id.ToString();

                            if (dataFromViewmodel.MemberId.Length.CompareTo(0) > 0)
                            {
                                Inserted = true;
                            }

                        }

                    }

                }


                return Inserted;
            }
            catch(Exception ex)
            {
                return Inserted;
            }

        }


        public bool InsertMemberEnrollment(AddMemberViewModel dataFromViewmodel)
        {

            bool Inserted = false;

            try
            {

                if (!string.IsNullOrEmpty(dataFromViewmodel.MemberId))
                {

                    MemberEnrollment memberenrollmentToInsert = new MemberEnrollment();

                    memberenrollmentToInsert.member_id = new Guid(dataFromViewmodel.MemberId);
                    memberenrollmentToInsert.employer_id = dataFromViewmodel.EmployerId;
                    memberenrollmentToInsert.claims_id = dataFromViewmodel.ClaimsId;


                    //client_id and client_bu_id are non-nullable fields in MEMBER_ENROLLMENT...retrieve and assign them
                    if (dataFromViewmodel.ClientId.CompareTo(0) == 0 || dataFromViewmodel.ClientBuId.CompareTo(0) == 0)
                    {

                        if (GetMembersEmployerClientAndClientBu(dataFromViewmodel))
                        {
                            GetMemberClientBuClaimSystemId(dataFromViewmodel);
                        }

                    }


                    //assign the retrieved client_id and client_bu_id
                    memberenrollmentToInsert.client_id = dataFromViewmodel.ClientId;
                    memberenrollmentToInsert.client_bu_id = dataFromViewmodel.ClientBuId;

                    //assign the retrieved claims_system_id
                    memberenrollmentToInsert.claims_system_id = dataFromViewmodel.ClaimsSystemId;


                    if (!string.IsNullOrEmpty(dataFromViewmodel.ClaimsEnrollmentId))
                    {
                        memberenrollmentToInsert.claims_enrollment_id = dataFromViewmodel.ClaimsEnrollmentId;
                    }

                    if (!string.IsNullOrEmpty(dataFromViewmodel.Relationship))
                    {
                        memberenrollmentToInsert.DEP_Number = dataFromViewmodel.Relationship;
                    }


                    if (dataFromViewmodel.EffectiveDate != DateTime.MinValue)
                    {
                        memberenrollmentToInsert.member_effective_date = dataFromViewmodel.EffectiveDate;
                    }

                    if (dataFromViewmodel.TerminationDate != DateTime.MinValue)
                    {

                        memberenrollmentToInsert.member_disenroll_date = dataFromViewmodel.TerminationDate;

                        if (dataFromViewmodel.DisenrollReasonId.Value.CompareTo(0) > 0)
                        {
                            memberenrollmentToInsert.disenroll_reason_id = dataFromViewmodel.DisenrollReasonId;
                        }
                        else
                        {
                            memberenrollmentToInsert.disenroll_reason_id = 14;
                        }

                    }


                    memberenrollmentToInsert.date_updated = DateTime.Now;

                    if (!string.IsNullOrEmpty(dataFromViewmodel.SystemUserId))
                    {
                        memberenrollmentToInsert.user_updated = new Guid(dataFromViewmodel.SystemUserId);
                    }
                    else
                    {
                        memberenrollmentToInsert.user_updated = new Guid("{8C4AA16B-75FE-11D3-A7EE-00500499C350}");
                    }


                    using (var db = new ICMS2DbContext())
                    {

                        db.DbmsMemberEnrollment.Add(memberenrollmentToInsert);

                        int InsertResults = db.SaveChanges();


                        if (InsertResults.CompareTo(0) > 0)
                        {
                            Inserted = true;
                        }

                    }

                }


                return Inserted;
            }
            catch(Exception ex)
            {
                return Inserted;
            }

        }


        public bool InsertMemberAddress(AddMemberViewModel dataFromViewmodel)
        {

            bool Inserted = false;

            try
            {

                if (!string.IsNullOrEmpty(dataFromViewmodel.MemberId))
                {

                    if (dataFromViewmodel.Address1.Length.CompareTo(0) > 0 ||
                        dataFromViewmodel.City.Length.CompareTo(0) > 0 ||
                        dataFromViewmodel.StateAbbrev.Length.CompareTo(0) > 0 ||
                        dataFromViewmodel.ZipCode.Length.CompareTo(0) > 0)
                    {

                        MemberAddress memberAddressToInsert = new MemberAddress();

                        memberAddressToInsert.member_id = new Guid(dataFromViewmodel.MemberId);
                        memberAddressToInsert.address_type_id = 1; //Home

                        memberAddressToInsert.address_line1 = dataFromViewmodel.Address1;
                        memberAddressToInsert.address_line2 = dataFromViewmodel.Address2;
                        memberAddressToInsert.city = dataFromViewmodel.City;
                        memberAddressToInsert.state_abbrev = dataFromViewmodel.StateAbbrev;
                        memberAddressToInsert.zip_code = dataFromViewmodel.ZipCode;


                        using (var db = new ICMS2DbContext())
                        {

                            db.DbmsMemberAddresses.Add(memberAddressToInsert);

                            int InsertResults = db.SaveChanges();


                            if (InsertResults.CompareTo(0) > 0)
                            {
                                Inserted = true;
                            }

                        }

                    }

                }

                return Inserted;
            }
            catch(Exception ex)
            {
                return Inserted;
            }

        }


        public bool InsertMemberPhone(AddMemberViewModel dataFromViewmodel)
        {

            bool Inserted = false;

            try
            {

                if (!string.IsNullOrEmpty(dataFromViewmodel.MemberId))
                {
                    if (!string.IsNullOrEmpty(dataFromViewmodel.DayPhone) || !string.IsNullOrEmpty(dataFromViewmodel.EveningPhone))
                    {
                        if (!string.IsNullOrEmpty(dataFromViewmodel.DayPhone))
                        {
                            if (dataFromViewmodel.DayPhone.Length.CompareTo(0) > 0)
                            {
                                //insert Day Phone Number
                                if (dataFromViewmodel.DayPhone.Length.CompareTo(0) > 0)
                                {

                                    MemberPhone memberDayPhoneToInsert = new MemberPhone();

                                    memberDayPhoneToInsert.member_id = new Guid(dataFromViewmodel.MemberId);
                                    memberDayPhoneToInsert.phone_type_id = 1; //Day Phone
                                    memberDayPhoneToInsert.phone_number = dataFromViewmodel.DayPhone;


                                    using (var dbDay = new ICMS2DbContext())
                                    {

                                        dbDay.DbmsMemberPhone.Add(memberDayPhoneToInsert);

                                        int InsertDayResults = dbDay.SaveChanges();


                                        if (InsertDayResults.CompareTo(0) > 0)
                                        {
                                            Inserted = true;
                                        }
                                    }
                                }
                            }
                        }


                        if (!string.IsNullOrEmpty(dataFromViewmodel.EveningPhone))
                        {
                            //insert Evening Phone Number
                            if (dataFromViewmodel.EveningPhone.Length.CompareTo(0) > 0)
                            {

                                MemberPhone memberEveningPhoneToInsert = new MemberPhone();


                                memberEveningPhoneToInsert.member_id = new Guid(dataFromViewmodel.MemberId);
                                memberEveningPhoneToInsert.phone_type_id = 2; //Evening Phone
                                memberEveningPhoneToInsert.phone_number = dataFromViewmodel.EveningPhone;


                                using (var dbDay = new ICMS2DbContext())
                                {

                                    dbDay.DbmsMemberPhone.Add(memberEveningPhoneToInsert);

                                    int InsertEveningResults = dbDay.SaveChanges();


                                    if (Inserted == false && InsertEveningResults.CompareTo(0) > 0)
                                    {
                                        Inserted = true;
                                    }

                                }

                            }
                        }
                    }

                }

                return Inserted;
            }
            catch(Exception ex)
            {
                return Inserted;
            }
        }


        public bool InsertClaimsId(AddMemberViewModel dataFromViewmodel)
        {

            bool Inserted = false;

            try
            {

                if (GetMembersEmployerClientAndClientBu(dataFromViewmodel))
                {
                    GetMemberClientBuClaimSystemId(dataFromViewmodel);
                }


                if (dataFromViewmodel.ClaimsId.Length.CompareTo(0) > 0 &&
                    dataFromViewmodel.ClaimsSystemId.CompareTo(0) > 0)
                {

                    ClaimsId claimidToInsert = new ClaimsId();

                    claimidToInsert.claims_id1 = dataFromViewmodel.ClaimsId;
                    claimidToInsert.claims_system_id = dataFromViewmodel.ClaimsSystemId;
                    claimidToInsert.original_effective_date = DateTime.Now;


                    using (var db = new ICMS2DbContext())
                    {

                        db.DbmsClaimsId.Add(claimidToInsert);

                        int InsertResults = db.SaveChanges();


                        if (InsertResults.CompareTo(0) > 0)
                        {
                            Inserted = true;
                        }

                    }

                }


                return Inserted;
            }
            catch(Exception ex)
            {
                return Inserted;
            }
        }


    }

}