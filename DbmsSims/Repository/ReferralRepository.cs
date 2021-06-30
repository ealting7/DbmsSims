using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS2.ViewModels;
using System.Text;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DbmsSims.Repository
{
    public class ReferralRepository
    {


        public List<ReferralViewModel> GetAllMemberReferrals(string id)
        {

            var refsToReturn = new List<ReferralViewModel>();


            using (var db = new ICMS2DbContext())
            {

                refsToReturn = (from refs in db.DbmsMemberReferrals

                                //left outer join
                                join reftype in db.DbmsReferralTypes 
                                on refs.type_id equals reftype.id 
                                into reftypejoin from reftype in reftypejoin.DefaultIfEmpty()

                                //left outer join
                                join pcpreferTo in db.DbmsPcpProviders 
                                on refs.referred_to_pcp_id equals pcpreferTo.pcp_id 
                                into pcpreferTojoin from pcpreferTo in pcpreferTojoin.DefaultIfEmpty()

                                //left outer join
                                join deptreferto in db.DbmsDepartments 
                                on refs.referred_to_department_id equals deptreferto.id 
                                into deptrefertojoin from deptreferto in deptrefertojoin.DefaultIfEmpty()

                                where refs.member_id == new Guid(id)
                                orderby refs.created_date descending 
                                select new ReferralViewModel
                                {
                                    MemberId = id,
                                    ReferralNumber = refs.referral_number,
                                    AuthNumber = refs.auth_number,
                                    ReferralType = reftype.label,
                                    AuthStartDate = refs.auth_start_date,
                                    AuthEndDate = refs.auth_end_date,
                                    ReferredToProviderName = pcpreferTo.provider_first_name + " " + pcpreferTo.provider_last_name,
                                    ReferredToDepartmentName = deptreferto.label
                                })
                                .ToList();

            }


            return (refsToReturn);

        }        

        public rMemberReferral GetReferralUsingReferralNumber(string strReferralNumber)
        {

            rMemberReferral rMemRef = new rMemberReferral();

            using (var db = new ICMS2DbContext())
            {

                rMemRef = (from memref in db.DbmsMemberReferrals
                           where memref.referral_number == strReferralNumber
                           select memref).Single();

            }

            return (rMemRef);

        }

        public string GetReferralMemberIdUsingReferralNumber(string strReferralNumber)
        {

            string strMemberId = "";

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    strMemberId = (from refs in db.DbmsMemberReferrals
                                   where refs.referral_number == strReferralNumber
                                   select refs.member_id.ToString())
                                   .SingleOrDefault();
                }

                return strMemberId;

            }
            catch(Exception ex)
            {
                return strMemberId;
            }

        }

        public void GetReferralDecisionUsingReferralList(ref ReferralViewModel refvmReferrals)
        {

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    foreach (ReferralViewModel refer in refvmReferrals.referrals)
                    {
                        refer.ReferralDecision = (from utilizationDay in db.DbmsUtilizationDays
                                                  //inner joinvv
                                                  join utilizationDecision in db.DbmsUtilizationDaysDecision on utilizationDay.util_decision_id 
                                                  equals utilizationDecision.util_decision_id
                                                  //inner join ^^
                                                  where utilizationDay.referral_number == refer.ReferralNumber
                                                  && (utilizationDay.removed == false || utilizationDay.removed == null)
                                                  orderby utilizationDay.line_number descending
                                                  select utilizationDecision.label)
                                                 .FirstOrDefault();
                    }

                }

            }
            catch(Exception ex)
            {

            }

        }






        public string GetReferralUtilizationTypeUsingReferralNumber(string strReferralNumber)
        {

            string strUtilType = "";

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    strUtilType = (from memref in db.DbmsMemberReferrals
                                   join refutils in db.DbmsUtilizationDays on memref.referral_number equals refutils.referral_number
                                   where memref.referral_number == strReferralNumber
                                   && (refutils.removed == false || refutils.removed == null)
                                   orderby refutils.Date_Created descending
                                   select refutils.referral_type)
                                   .First();
                }


                return strUtilType;

            }
            catch(Exception ex)
            {
                return strUtilType;
            }

        }

        public string GetReferralUtilizationTypeFromReferralTypeTable(string strReferralNumber)
        {

            string strUtilType = "";
            int? intTypeId = 0;


            try
            {

                using (var db = new ICMS2DbContext())
                {

                    intTypeId = (from memref in db.DbmsMemberReferrals
                                 where memref.referral_number == strReferralNumber
                                 select memref.type_id).SingleOrDefault();


                    if (intTypeId.Value.CompareTo(0) > 0)
                    {

                        strUtilType = (from reftype in db.DbmsReferralTypes
                                       where reftype.id == intTypeId
                                       select reftype.inpatient_outpatient_type).SingleOrDefault();
                    }

                }


                return strUtilType;

            }
            catch (Exception ex)
            {
                return strUtilType;
            }

        }

        public List<UtilizationInpatientDayViewModel> GetReferralInpatientUtilizationDaysUsingReferralNumber(string strReferralNumber)

        {

            var utildaysToReturn = new List<UtilizationInpatientDayViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    utildaysToReturn = (from refutils in db.DbmsUtilizationDays

                                            //left outer join reviews
                                        join utilreview in db.DbmsUtilizationReviews
                                        on new { a = refutils.referral_number, b = refutils.line_number } equals new { a = utilreview.referral_number, b = utilreview.line_number }


                                        //left outer join reviews type items
                                        join revitms in db.DbmsReviewTypeItems
                                        on utilreview.review_type_items_id equals revitms.review_type_items_id
                                        into revitmsToJoin
                                        from revitms in revitmsToJoin.DefaultIfEmpty()

                                            //left outer join bed types
                                        join bedtyps in db.DbmsBedDayType
                                        on refutils.type_id equals bedtyps.id
                                        into bedtypsToJoin
                                        from bedtyps in bedtypsToJoin.DefaultIfEmpty()

                                            //left outer join utilization day decision
                                        join utildec in db.DbmsUtilizationDaysDecision
                                        on refutils.util_decision_id equals utildec.util_decision_id
                                        into utildecToJoin
                                        from utildec in utildecToJoin.DefaultIfEmpty()

                                            //left outer join denial reason
                                        join denreas in db.DbmsDenialReason
                                        on refutils.denial_reason_id equals denreas.id
                                        into denreasToJoin
                                        from denreas in denreasToJoin.DefaultIfEmpty()


                                        where refutils.referral_number == strReferralNumber
                                        && (refutils.removed == false || refutils.removed == null)
                                        orderby refutils.line_number descending
                                        select new UtilizationInpatientDayViewModel
                                        {
                                            MemberId = refutils.member_id.ToString(),
                                            ReferralNumber = refutils.referral_number,
                                            UtilizationType = refutils.referral_type,
                                            LineNumber = refutils.line_number,
                                            StartDate = refutils.start_date,
                                            NextReviewDate = refutils.next_review_date,
                                            BedType = bedtyps.label,
                                            BedTypeId = refutils.type_id,
                                            SurgeryText = (refutils.surgery_flag ? "Yes" : "No"),
                                            SurgeryOnFirstDayText = (refutils.surgery_on_first_day_flag ? "Yes" : "No"),
                                            DecisionById = utilreview.review_type_items_id,
                                            DecisionBy = revitms.name,
                                            UtilDecisionId = refutils.util_decision_id,
                                            Decision = utildec.label,
                                            DenialReason = denreas.label,
                                            DenialReasonId = refutils.denial_reason_id
                                        })
                                        .ToList();
                }


                return (utildaysToReturn);

            }
            catch (Exception ex)
            {
                return (utildaysToReturn);
            }

        }

        public List<UtilizationOutpatientDayViewModel> GetReferralOutpatientUtilizationDaysUsingReferralNumber(string strReferralNumber)

        {

            var utildaysToReturn = new List<UtilizationOutpatientDayViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    utildaysToReturn = (from refutils in db.DbmsUtilizationDays

                                            //left outer join reviews
                                        join utilreview in db.DbmsUtilizationReviews
                                        on new { a = refutils.referral_number, b = refutils.line_number } equals
                                           new { a = utilreview.referral_number, b = utilreview.line_number }


                                           //left outer join reviews type items
                                        join revitms in db.DbmsReviewTypeItems
                                        on utilreview.review_type_items_id equals revitms.review_type_items_id
                                        into revitmsToJoin
                                        from revitms in revitmsToJoin.DefaultIfEmpty()

                                            //left outer join utilization visit period...requested
                                        join peridreq in db.DbmsUtilizationVisitPeriod
                                        on refutils.visits_period_requested equals peridreq.visit_period_abbrev
                                        into peridreqToJoin
                                        from peridreq in peridreqToJoin.DefaultIfEmpty()

                                            //left outer join utilization visit period...authorized
                                        join peridauth in db.DbmsUtilizationVisitPeriod
                                        on refutils.visits_period_authorized equals peridauth.visit_period_abbrev
                                        into peridauthToJoin
                                        from peridauth in peridauthToJoin.DefaultIfEmpty()

                                            //left outer join utilization day decision
                                        join utildec in db.DbmsUtilizationDaysDecision
                                        on refutils.util_decision_id equals utildec.util_decision_id
                                        into utildecToJoin
                                        from utildec in utildecToJoin.DefaultIfEmpty()

                                            //left outer join denial reason
                                        join denreas in db.DbmsDenialReason
                                        on refutils.denial_reason_id equals denreas.id
                                        into denreasToJoin
                                        from denreas in denreasToJoin.DefaultIfEmpty()


                                        where refutils.referral_number == strReferralNumber
                                        && (refutils.removed == false || refutils.removed == null)
                                        orderby refutils.line_number descending
                                        select new UtilizationOutpatientDayViewModel
                                        {
                                            MemberId = refutils.member_id.ToString(),
                                            ReferralNumber = refutils.referral_number,
                                            UtilizationType = refutils.referral_type,
                                            LineNumber = refutils.line_number,
                                            VisitRecurring = (refutils.visits_recurring_flag ? "Yes" : "No"),
                                            NumberPerPeriodRequest = refutils.visits_num_per_period_requested,
                                            PeriodRequested = peridreq.label,
                                            NumberOfPeriodsRequested = refutils.visits_num_periods_requested,
                                            NumberPerPeriodAuthorized = refutils.visits_num_per_period_authorized,
                                            PeriodAuthorized = peridauth.label,
                                            NumberOfPeriodsAuthorized = refutils.visits_num_periods_authorized,
                                            AuthorizedStartDate = refutils.visits_authorized_start_date,
                                            AuthorizedEndDate = refutils.visits_authorized_end_date,
                                            DecisionById = utilreview.review_type_items_id,
                                            DecisionBy = revitms.name,
                                            UtilDecisionId = refutils.util_decision_id,
                                            Decision = utildec.label,
                                            DenialReason = denreas.label,
                                            DenialReasonId = refutils.denial_reason_id
                                        })
                                        .ToList();
                }


                return (utildaysToReturn);

            }
            catch (Exception ex)
            {
                return (utildaysToReturn);
            }

        }

        public int GetInpatientReferralUtilizationNextLineNumber(UtilizationInpatientDayViewModel vmNeedsLineNumber)
        {

            int intReturnLineNumber = 1;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    intReturnLineNumber = (from refutils in db.DbmsUtilizationDays
                                           where refutils.referral_number == vmNeedsLineNumber.ReferralNumber
                                           orderby refutils.line_number descending
                                           select refutils.line_number)
                                           .First();

                    intReturnLineNumber += 1;

                }


                return intReturnLineNumber;

            }
            catch(Exception ex)
            {
                return intReturnLineNumber;
            }

        }

        public int GetOutpatientReferralUtilizationNextLineNumber(UtilizationOutpatientDayViewModel vmNeedsLineNumber)
        {
            
            int intReturnLineNumber = 1;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    intReturnLineNumber = (from refutils in db.DbmsUtilizationDays
                                           where refutils.referral_number == vmNeedsLineNumber.ReferralNumber
                                           orderby refutils.line_number descending
                                           select refutils.line_number)
                                           .First();

                    intReturnLineNumber += 1;

                }


                return intReturnLineNumber;

            }
            catch (Exception ex)
            {
                return intReturnLineNumber;
            }

        }

        public string GetReferralMostRecentDecisionUsingReferralNumber(string strReferralNumber)
        {
            string strDecisionToReturn = "";

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rUtilizationDays utilDays = (from utilizationDay in db.DbmsUtilizationDays
                                                 where utilizationDay.referral_number == strReferralNumber
                                                 && (utilizationDay.removed == false || utilizationDay.removed == null)
                                                 orderby utilizationDay.line_number descending
                                                 select utilizationDay)
                                                 .FirstOrDefault();


                    if (utilDays != null)
                    {

                        if (utilDays.util_decision_id != null)
                        {

                            rUtilizationDaysDecision utilDecision = (from utilizationDecision in db.DbmsUtilizationDaysDecision
                                                                     where utilizationDecision.util_decision_id == utilDays.util_decision_id
                                                                     select utilizationDecision)
                                                                     .SingleOrDefault();

                            if (utilDecision != null)
                            {
                                strDecisionToReturn = utilDecision.label;
                            }

                        }
                        else
                        {

                            utilDays.util_decision_id = GetReferralLastDecisionUsingReferralNumber(strReferralNumber);


                            if (utilDays.util_decision_id.Value.CompareTo(0) > 0)
                            {

                                rUtilizationDaysDecision utilDecision = (from utilizationDecision in db.DbmsUtilizationDaysDecision
                                                                         where utilizationDecision.util_decision_id == utilDays.util_decision_id
                                                                         select utilizationDecision)
                                                                         .SingleOrDefault();

                                if (utilDecision != null)
                                {
                                    strDecisionToReturn = utilDecision.label;
                                }

                            }

                        }

                    }

                }

                return strDecisionToReturn;

            }
            catch(Exception ex)
            {
                return strDecisionToReturn;
            }

        }

        public int GetReferralLastDecisionUsingReferralNumber(string strReferralNumber)
        {

            int intUtilDecisionToReturn = 0;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rUtilizationDays utilDays = (from utilizationDay in db.DbmsUtilizationDays
                                                 where utilizationDay.referral_number == strReferralNumber
                                                 && utilizationDay.util_decision_id > 0
                                                 && (utilizationDay.removed == false || utilizationDay.removed == null)
                                                 orderby utilizationDay.line_number descending
                                                 select utilizationDay)
                                                 .FirstOrDefault();


                    if (utilDays != null)
                    {
                        if (utilDays.util_decision_id != null)
                        {
                            intUtilDecisionToReturn = utilDays.util_decision_id.Value;
                        }
                    }

                }


                return intUtilDecisionToReturn;

            }
            catch(Exception ex)
            {
                return intUtilDecisionToReturn;
            }


        }

        public List<NotesViewModel> GetReferralUtilizationInpatientNotesForUtilizationItem(NotesViewModel notevmInpatient)
        {

            var notvmUmNotesToReturn = new List<NotesViewModel>();

            try
            {

                foreach (UtilizationInpatientDayViewModel utilinpat in notevmInpatient.InpatientUtilizations)
                {

                    string strReferralNumber = utilinpat.ReferralNumber;
                    string strUtilizationType = utilinpat.UtilizationType;
                    int intLineNumber = utilinpat.LineNumber;


                    if (!string.IsNullOrEmpty(strReferralNumber) && !string.IsNullOrEmpty(strUtilizationType) && intLineNumber.CompareTo(0) > 0)
                    {

                        using (var db = new ICMS2DbContext())
                        {

                            var individNotesList = new List<NotesViewModel>();


                            //Get each UM note's record_date
                            individNotesList = (from notes in db.DbmsUtilizationDayNotes
                                                where notes.referral_number == strReferralNumber
                                                && notes.referral_type == strUtilizationType
                                                && notes.line_number == intLineNumber
                                                select new NotesViewModel
                                                {
                                                    RecordDate = notes.record_date
                                                }).Distinct().ToList();



                            //Go through each note and retrieve the note's evaluation_text and record_seq_num
                            foreach (NotesViewModel getnotetext in individNotesList)
                            {


                                var individNoteTextList = new List<NotesViewModel>();
                                StringBuilder evaltext = new StringBuilder();


                                individNoteTextList = (from notes in db.DbmsUtilizationDayNotes
                                                       where notes.referral_number == strReferralNumber
                                                       && notes.referral_type == strUtilizationType
                                                       && notes.record_date == getnotetext.RecordDate
                                                       orderby notes.record_date descending, notes.record_seq_num
                                                       select new NotesViewModel
                                                       {
                                                           SequenceNumber = notes.record_seq_num,
                                                           NoteText = notes.evaluation_text
                                                       }).ToList();


                                //assign the note text to the string variable
                                foreach (NotesViewModel text in individNoteTextList)
                                {
                                    evaltext.Append(text.NoteText);
                                }


                                //This is the finished note to add to the return list
                                NotesViewModel addnote = new NotesViewModel();

                                addnote.BedType = utilinpat.BedType;
                                addnote.LineNumber = intLineNumber;
                                addnote.RecordDate = getnotetext.RecordDate;
                                addnote.NoteText = evaltext.ToString();

                                notvmUmNotesToReturn.Add(addnote);

                            }

                        }

                    }

                }




                if (notvmUmNotesToReturn != null)
                {

                    if (notvmUmNotesToReturn.Count.CompareTo(0) > 0)
                    {
                        return (notvmUmNotesToReturn.OrderByDescending(m => m.RecordDate).ToList());
                    }
                    else
                    {
                        return (notvmUmNotesToReturn);
                    }

                }
                else
                {
                    return (notvmUmNotesToReturn);
                }

            }
            catch(Exception ex)
            {
                return notvmUmNotesToReturn;
            }

        }

        public List<NotesViewModel> GetReferralUtilizationOutpatientNotesForUtilizationItem(NotesViewModel utiloutpatvmOutpatient)
        {

            var notvmUmNotesToReturn = new List<NotesViewModel>();

            try
            {

                foreach (UtilizationOutpatientDayViewModel utiloutpat in utiloutpatvmOutpatient.OutpatientUtilizations)
                {

                    string strReferralNumber = utiloutpat.ReferralNumber;
                    string strUtilizationType = utiloutpat.UtilizationType;
                    int intLineNumber = utiloutpat.LineNumber;


                    if (!string.IsNullOrEmpty(strReferralNumber) && !string.IsNullOrEmpty(strUtilizationType) && intLineNumber.CompareTo(0) > 0)
                    {

                        using (var db = new ICMS2DbContext())
                        {

                            var individNotesList = new List<NotesViewModel>();


                            //Get each UM note's record_date
                            individNotesList = (from notes in db.DbmsUtilizationDayNotes
                                                where notes.referral_number == strReferralNumber
                                                && notes.referral_type == strUtilizationType
                                                && notes.line_number == intLineNumber
                                                select new NotesViewModel
                                                {
                                                    RecordDate = notes.record_date
                                                }).Distinct().ToList();



                            //Go through each note and retrieve the note's evaluation_text and record_seq_num
                            foreach (NotesViewModel getnotetext in individNotesList)
                            {


                                var individNoteTextList = new List<NotesViewModel>();
                                StringBuilder evaltext = new StringBuilder();


                                individNoteTextList = (from notes in db.DbmsUtilizationDayNotes
                                                       where notes.referral_number == strReferralNumber
                                                       && notes.referral_type == strUtilizationType
                                                       && notes.record_date == getnotetext.RecordDate
                                                       orderby notes.record_date descending, notes.record_seq_num
                                                       select new NotesViewModel
                                                       {
                                                           SequenceNumber = notes.record_seq_num,
                                                           NoteText = notes.evaluation_text
                                                       }).ToList();


                                //assign the note text to the string variable
                                foreach (NotesViewModel text in individNoteTextList)
                                {
                                    evaltext.Append(text.NoteText);
                                }


                                //This is the finished note to add to the return list
                                NotesViewModel addnote = new NotesViewModel();

                                addnote.BedType = "Auth: " + utiloutpat.NumberPerPeriodAuthorized.ToString() + " " + utiloutpat.PeriodAuthorized;
                                addnote.LineNumber = intLineNumber;
                                addnote.RecordDate = getnotetext.RecordDate;
                                addnote.NoteText = evaltext.ToString();

                                notvmUmNotesToReturn.Add(addnote);

                            }

                        }

                    }

                }




                if (notvmUmNotesToReturn != null)
                {

                    if (notvmUmNotesToReturn.Count.CompareTo(0) > 0)
                    {
                        return (notvmUmNotesToReturn.OrderByDescending(m => m.RecordDate).ToList());
                    }
                    else
                    {
                        return (notvmUmNotesToReturn);
                    }

                }
                else
                {
                    return (notvmUmNotesToReturn);
                }

            }
            catch (Exception ex)
            {
                return notvmUmNotesToReturn;
            }

        }






        public List<ReferralSavingsViewModel> GetReferralUtilizationSavingsUsingReferralNumber(ReferralSavingsViewModel refsavvmReferralSavings)
        {

            var lstrefsavvmToReturn = new List<ReferralSavingsViewModel>();

            try
            {

                if (!string.IsNullOrEmpty(refsavvmReferralSavings.ReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        lstrefsavvmToReturn = (from saving in db.DbmsUtilizationSavings

                                               //left outer join
                                               join units in db.DbmsrSavingsUnits
                                               on saving.saving_units_id equals units.saving_units_id
                                               into unitsjoin
                                               from units in unitsjoin.DefaultIfEmpty()

                                               //left outer join
                                               join networks in db.DbmsNetworks
                                               on saving.network_id equals networks.network_id
                                               into networksjoin
                                               from networks in networksjoin.DefaultIfEmpty()

                                               where saving.referral_number == refsavvmReferralSavings.ReferralNumber
                                               orderby saving.line_number descending, saving.savings_line descending
                                               select new ReferralSavingsViewModel
                                               {
                                                   SavingsId = saving.utilization_savings_id,
                                                   LineNumber = saving.line_number,
                                                   SavingsLineNumber = saving.savings_line,
                                                   SavingsDescription = saving.item_description,
                                                   SavingsUnitId = saving.saving_units_id,
                                                   SavingsUnit = units.units_label,
                                                   SavingsQuantity = saving.quantity,
                                                   SavingsCost = saving.cost,
                                                   SavingsNegotiatedPerUnit = saving.negotiated,
                                                   SavingsPerUnit = saving.savings,
                                                   SavingsDollarOrPercent = saving.dollar_or_percent,
                                                   SavingsLineItem = saving.line_item,
                                                   SavingsCptCode = saving.cpt_code,
                                                   SavingsNetworkId = saving.network_id,
                                                   SavingsNetwork = networks.network_name,
                                                   SavingsNotes = saving.notes
                                               }).ToList();

                    }

                }


                return (lstrefsavvmToReturn);

            }
            catch(Exception ex)
            {
                return (lstrefsavvmToReturn);
            }

        }






        public List<ReferralLetterViewModel> GetReferralLettersUsingReferralNumber(string strReferralNumber)
        {

            var lettsToReturn = new List<ReferralLetterViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    lettsToReturn = (from refletts in db.DbmsMemberReferralLetters 
                                     where refletts.referral_number == strReferralNumber
                                     orderby refletts.letter_created descending
                                     select new ReferralLetterViewModel
                                        {
                                            MemberId = refletts.member_id.ToString(),
                                            ReferralNumber = refletts.referral_number,
                                            Id = refletts.id,
                                            FileName = refletts.file_identifier,
                                            LetterCreatedDate = refletts.letter_created
                                     })
                                     .ToList();
                }


                return (lettsToReturn);

            }
            catch (Exception ex)
            {
                return (lettsToReturn);
            }

        }

        public string GetReferralNumberUsingReferralLetterId(int intLetterId)
        {

            string strReferralNumberToReturn = "";

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    strReferralNumberToReturn = (from refletts in db.DbmsMemberReferralLetters
                                                 where refletts.id == intLetterId
                                                 select refletts.referral_number)
                                                 .SingleOrDefault();

                }

                return strReferralNumberToReturn;

            }
            catch(Exception ex)
            {
                return strReferralNumberToReturn;
            }

        }






        public void GetReferralReferredByItemsUsingReferralNumber(ref ReferralRefersViewModel vmRefers)
        {

            try
            {

                vmRefers.ReferredByFacilityId = 0;
                vmRefers.ReferredByFacilityName = "";
                vmRefers.ReferredByProviderPcpId = "";
                vmRefers.ReferredByProviderName = "";
                vmRefers.ReferredByPlaceOfServiceId = 0;
                vmRefers.ReferredByPlaceOfServiceName = "";
                vmRefers.ReferredByStdOfficeLocationName = "";


                if (!string.IsNullOrEmpty(vmRefers.ReferralNumber))
                {

                    string strReferralNumber = vmRefers.ReferralNumber;

                    using (var db = new ICMS2DbContext())
                    {
                        var refrefsvmReturnValues = (from refs in db.DbmsMemberReferrals

                                                     //left outer join
                                                     join depts in db.DbmsDepartments
                                                     on refs.referred_by_department_id equals depts.id
                                                     into deptsjoin
                                                     from depts in deptsjoin.DefaultIfEmpty()

                                                     //left outer join
                                                     join pcps in db.DbmsPcpProviders
                                                     on refs.referring_pcp_id equals pcps.pcp_id
                                                     into pcpjoin
                                                     from pcps in pcpjoin.DefaultIfEmpty()

                                                     //left outer join
                                                     join locs in db.DbmsLocationPos
                                                     on refs.referring_locationpos_id equals locs.id
                                                     into locsjoin
                                                     from locs in locsjoin.DefaultIfEmpty()

                                                     where refs.referral_number == strReferralNumber
                                                     select new ReferralRefersViewModel
                                                     {
                                                         ReferredByFacilityId = refs.referred_by_department_id,
                                                         ReferredByFacilityName = depts.label,

                                                         ReferredByProviderPcpId = refs.referring_pcp_id.ToString(),
                                                         ReferredByProviderName = pcps.provider_first_name + " " + pcps.provider_last_name,

                                                         ReferredByPlaceOfServiceId = refs.referring_locationpos_id,
                                                         ReferredByPlaceOfServiceName = locs.name,

                                                         ReferredByStdOfficeLocationName = refs.std_office_location
                                                     }).FirstOrDefault();


                        vmRefers.ReferredByFacilityId = refrefsvmReturnValues.ReferredByFacilityId;
                        vmRefers.ReferredByFacilityName = refrefsvmReturnValues.ReferredByFacilityName;
                        vmRefers.ReferredByProviderPcpId = refrefsvmReturnValues.ReferredByProviderPcpId;
                        vmRefers.ReferredByProviderName = refrefsvmReturnValues.ReferredByProviderName;
                        vmRefers.ReferredByPlaceOfServiceId = refrefsvmReturnValues.ReferredByPlaceOfServiceId;
                        vmRefers.ReferredByPlaceOfServiceName = refrefsvmReturnValues.ReferredByPlaceOfServiceName;
                        vmRefers.ReferredByStdOfficeLocationName = refrefsvmReturnValues.ReferredByStdOfficeLocationName;

                    }

                }

            }
            catch(Exception ex)
            {

            }

        }

        public void GetReferralReferredToItemsUsingReferralNumber(ref ReferralRefersViewModel vmRefers)
        {

            try
            {

                vmRefers.ReferredToFacilityId = 0;
                vmRefers.ReferredToFacilityName = "";
                vmRefers.ReferredToProviderPcpId = "";
                vmRefers.ReferredToProviderName = "";
                vmRefers.ReferredToPlaceOfServiceId = 0;
                vmRefers.ReferredToPlaceOfServiceName = "";


                if (!string.IsNullOrEmpty(vmRefers.ReferralNumber))
                {

                    string strReferralNumber = vmRefers.ReferralNumber;

                    using (var db = new ICMS2DbContext())
                    {
                        var refrefsvmReturnValues = (from refs in db.DbmsMemberReferrals

                                                         //left outer join
                                                     join depts in db.DbmsDepartments
                                                     on refs.referred_to_department_id equals depts.id
                                                     into deptsjoin
                                                     from depts in deptsjoin.DefaultIfEmpty()

                                                     //left outer join
                                                     join pcps in db.DbmsPcpProviders
                                                     on refs.referred_to_pcp_id equals pcps.pcp_id
                                                     into pcpjoin
                                                     from pcps in pcpjoin.DefaultIfEmpty()

                                                     //left out join
                                                     join vend in db.DbmsVendors
                                                     on refs.referred_to_vendor_id equals vend.id
                                                     into vendjoin
                                                     from vend in vendjoin.DefaultIfEmpty()

                                                     //left outer join
                                                     join locs in db.DbmsLocationPos
                                                     on refs.referred_to_locationpos_id equals locs.id
                                                     into locsjoin
                                                     from locs in locsjoin.DefaultIfEmpty()

                                                     where refs.referral_number == strReferralNumber
                                                     select new ReferralRefersViewModel
                                                     {
                                                         ReferredToFacilityId = refs.referred_to_department_id,
                                                         ReferredToFacilityName = depts.label,

                                                         ReferredToProviderPcpId = refs.referred_to_pcp_id.ToString(),
                                                         ReferredToProviderName = pcps.provider_first_name + " " + pcps.provider_last_name,

                                                         ReferredToVendorId = refs.referred_to_vendor_id,
                                                         ReferredToVendorName = vend.label,

                                                         ReferredToPlaceOfServiceId = refs.referred_to_locationpos_id,
                                                         ReferredToPlaceOfServiceName = locs.name
                                                     }).FirstOrDefault();


                        vmRefers.ReferredToFacilityId = refrefsvmReturnValues.ReferredToFacilityId;
                        vmRefers.ReferredToFacilityName = refrefsvmReturnValues.ReferredToFacilityName;
                        vmRefers.ReferredToProviderPcpId = refrefsvmReturnValues.ReferredToProviderPcpId;
                        vmRefers.ReferredToProviderName = refrefsvmReturnValues.ReferredToProviderName;
                        vmRefers.ReferredToVendorId = refrefsvmReturnValues.ReferredToVendorId;
                        vmRefers.ReferredToVendorName = refrefsvmReturnValues.ReferredToVendorName;
                        vmRefers.ReferredToPlaceOfServiceId = refrefsvmReturnValues.ReferredToPlaceOfServiceId;
                        vmRefers.ReferredToPlaceOfServiceName = refrefsvmReturnValues.ReferredToPlaceOfServiceName;

                    }

                }

            }
            catch (Exception ex)
            {

            }

        }

        public List<rLocationPos> GetPlaceOfServices()
        {

            var rlocposToReturn = new List<rLocationPos>();

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    rlocposToReturn = (from pos in db.DbmsLocationPos
                                       orderby pos.name
                                       select pos)
                                       .ToList();
                }


                return (rlocposToReturn);

            }
            catch (Exception ex)
            {
                return (rlocposToReturn);
            }

        }






        public List<SystemUserViewModel> GetReferralMdsForRequests()
        {

            var MdsToReturn = new List<SystemUserViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    MdsToReturn = (from users in db.DbmsSystemUsers
                                    where users.user_inactive_flag == false
                                    && users.review_md == 1
                                   select new SystemUserViewModel
                                    {
                                        SystemUserId = users.system_user_id.ToString(),
                                        SystemUserFullName = users.system_user_first_name + " " + users.system_user_last_name
                                    })
                                    .ToList();

                }


                return MdsToReturn;

            }
            catch(Exception ex)
            {
                return MdsToReturn;
            }

        }

        public int GetReferralTopLevelMdReviewRequestId(string strReferralNumber)
        {

            int intMdReviewRequestIdToReturn = 0;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    intMdReviewRequestIdToReturn = (from mdrequest in db.DbmsMdReviewRequest
                                                    where mdrequest.referral_number == strReferralNumber
                                                    orderby mdrequest.date_entered descending
                                                    select mdrequest.md_review_request_id).FirstOrDefault();
                }

                return intMdReviewRequestIdToReturn;

            }
            catch(Exception ex)
            {
                return intMdReviewRequestIdToReturn;
            }

        }

        public List<ReferralRequestViewModel> GetReferralReviewRequestsUsingReferralNumber(string strReferralNumber)
        {

            var vmRefRequest = new List<ReferralRequestViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    vmRefRequest = (from mdrequest in db.DbmsMdReviewRequest
                                    join sysuser in db.DbmsSystemUsers 
                                    on mdrequest.assigned_to_system_user_id equals sysuser.system_user_id
                                    where mdrequest.referral_number == strReferralNumber
                                    orderby mdrequest.date_entered
                                    select new ReferralRequestViewModel
                                    {
                                        MdReviewRequestId = mdrequest.md_review_request_id,
                                        MdReviewQuestionId = 0,
                                        RequestType = "Request",
                                        RequestText = mdrequest.md_review_appeal_note,
                                        DateEntered = mdrequest.date_entered,
                                        SystemUserFullName = sysuser.system_user_first_name + " " + sysuser.system_user_last_name
                                    }
                                    ).ToList();
                }


                return vmRefRequest;

            }
            catch (Exception ex)
            {
                return vmRefRequest;
            }

        }

        public List<ReferralRequestViewModel> GetReferralReviewQuestionsUsingReferralNumber(string strReferralNumber)
        {

            var vmRefRequest = new List<ReferralRequestViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    vmRefRequest = (from reviewquestion in db.DbmsMdReviewQuestion
                                    join sysuser in db.DbmsSystemUsers
                                    on reviewquestion.assigned_to_system_user_id equals sysuser.system_user_id

                                    where reviewquestion.referral_number == strReferralNumber
                                    orderby reviewquestion.date_entered
                                    select new ReferralRequestViewModel
                                    {
                                        MdReviewRequestId = 0,
                                        MdReviewQuestionId = reviewquestion.md_review_question_id,
                                        RequestType = "Question",
                                        RequestText = reviewquestion.md_question_note,
                                        AnswerText = reviewquestion.md_answer_note,
                                        DateEntered = reviewquestion.date_entered,
                                        SystemUserFullName = sysuser.system_user_first_name + " " + sysuser.system_user_last_name
                                    }
                                    ).ToList();
                }


                return vmRefRequest;

            }
            catch (Exception ex)
            {
                return vmRefRequest;
            }

        }






        public List<rSavingsUnits> GetSavingsUnits()
        {

            var rsavunitToReturn = new List<rSavingsUnits>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rsavunitToReturn = (from units in db.DbmsrSavingsUnits
                                        orderby units.units_label
                                        select units).ToList();

                }


                return rsavunitToReturn;

            }
            catch (Exception ex)
            {
                return rsavunitToReturn;
            }

        }

        public List<Networks> GetNetworks()
        {

            var netwrkToReturn = new List<Networks>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    netwrkToReturn = (from netwrk in db.DbmsNetworks
                                      orderby netwrk.network_name
                                      select netwrk).ToList();

                }


                return netwrkToReturn;

            }
            catch (Exception ex)
            {
                return netwrkToReturn;
            }

        }






        public List<MedicalCodeSearchViewModel> GetReferralDiagnosisCodesUsingReferralNumber(string strReferralNumber)
        {

            var diagsToReturn = new List<MedicalCodeSearchViewModel>();


            using (var db = new ICMS2DbContext())
            {
                diagsToReturn = (from refdiags in db.DbmsMemberReferralDiags
                                 join diag in db.DbmsDiagnoisiCodes10 on refdiags.diagnosis_or_procedure_code equals diag.diagnosis_code
                                 where refdiags.referral_number == strReferralNumber
                                 orderby refdiags.creation_date descending
                                 select new MedicalCodeSearchViewModel
                                 {
                                     SelectedSearchItemCodeId = refdiags.id,
                                     Code = refdiags.diagnosis_or_procedure_code,
                                     SearchReturnShortDescription = diag.short_description
                                 })
                                 .ToList();
            }


            return (diagsToReturn);

        }

        public List<MedicalCodeSearchViewModel> GetReferralCptCodesUsingReferralNumber(string strReferralNumber)
        {

            var cptToReturn = new List<MedicalCodeSearchViewModel>();


            using (var db = new ICMS2DbContext())
            {
                cptToReturn = (from refcpts in db.DbmsMemberReferralCpts
                               join cpt in db.DbmsCptCodes2015 on refcpts.cpt_code equals cpt.cpt_code
                               where refcpts.referral_number == strReferralNumber
                               orderby refcpts.creation_date descending
                               select new MedicalCodeSearchViewModel
                               {
                                   SelectedSearchItemCodeId = refcpts.id,
                                   Code = refcpts.cpt_code,
                                   SearchReturnShortDescription = cpt.cpt_descr
                               })
                                 .ToList();
            }


            return (cptToReturn);

        }

        public List<MedicalCodeSearchViewModel> GetReferralHcpcsCodesUsingReferralNumber(string strReferralNumber)
        {

            var hcpcsToReturn = new List<MedicalCodeSearchViewModel>();


            using (var db = new ICMS2DbContext())
            {
                hcpcsToReturn = (from refhcpcs in db.DbmsMemberReferralHcpcs
                                 join hcpcs in db.DbmsHcpcsCodes2015 on refhcpcs.hcpcs_code equals hcpcs.hcp_code
                                 where refhcpcs.referral_number == strReferralNumber
                                 orderby refhcpcs.creation_date descending
                                 select new MedicalCodeSearchViewModel
                                 {
                                     SelectedSearchItemCodeId = refhcpcs.id,
                                     Code = refhcpcs.hcpcs_code,
                                     SearchReturnShortDescription = hcpcs.hcpcs_short
                                 })
                                 .ToList();
            }


            return (hcpcsToReturn);

        }

        public List<MedicalCodeSearchViewModel> GetDiagnosisCodesUsingCodeLikeSearchText(string strSearchText, string strReferralNumber)
        {

            var vmCodesToReturn = new List<MedicalCodeSearchViewModel>();

            try
            {

                using (var dbcode = new ICMS2DbContext())
                {

                    vmCodesToReturn = (from diags in dbcode.DbmsDiagnoisiCodes10
                                       where diags.diagnosis_code.StartsWith(strSearchText)
                                       && diags.diagnosis_code != null
                                       orderby diags.diagnosis_code, diags.short_description, diags.long_description
                                       select new MedicalCodeSearchViewModel
                                       {
                                           ReferralNumber = strReferralNumber,
                                           DiagnosisCodeSearch = true,
                                           CptCodeSearch = false,
                                           HcpcsCodeSearch = false,
                                           SearchReturnCodeId = diags.diagnosis_codes_10_id,
                                           SearchReturnCode = diags.diagnosis_code,
                                           SearchReturnShortDescription = diags.short_description,
                                           SearchReturnLongDescription = diags.long_description
                                       }).ToList();

                }

                return (vmCodesToReturn);

            }
            catch(Exception ex)
            {
                return (vmCodesToReturn);
            }

        }

        public List<MedicalCodeSearchViewModel> GetDiagnosisCodesUsingDescriptionLikeSearchText(string strSearchText, string strReferralNumber)

        {

            var vmCodesToReturn = new List<MedicalCodeSearchViewModel>();

            try
            {

                using (var dbcode = new ICMS2DbContext())
                {

                    vmCodesToReturn = (from diags in dbcode.DbmsDiagnoisiCodes10
                                       where diags.short_description.Contains(strSearchText) ||
                                             diags.medium_description.Contains(strSearchText) ||
                                             diags.long_description.Contains(strSearchText)
                                             && diags.diagnosis_code != null
                                       orderby diags.diagnosis_code, diags.short_description, diags.long_description
                                       select new MedicalCodeSearchViewModel
                                       {
                                           ReferralNumber = strReferralNumber,
                                           DiagnosisCodeSearch = true,
                                           CptCodeSearch = false,
                                           HcpcsCodeSearch = false,
                                           SearchReturnCodeId = diags.diagnosis_codes_10_id,
                                           SearchReturnCode = diags.diagnosis_code,
                                           SearchReturnShortDescription = diags.short_description,
                                           SearchReturnLongDescription = diags.long_description
                                       }).ToList();

                }

                return (vmCodesToReturn);

            }
            catch (Exception ex)
            {
                return (vmCodesToReturn);
            }

        }

        public List<MedicalCodeSearchViewModel> GetCptCodesLikeSearchText(string strSearchText, string strReferralNumber)
        {

            var vmCodesToReturn = new List<MedicalCodeSearchViewModel>();

            try
            {

                using (var dbcode = new ICMS2DbContext())
                {

                    vmCodesToReturn = (from cpts in dbcode.DbmsCptCodes2015
                                       where cpts.cpt_code.StartsWith(strSearchText)
                                       && cpts.cpt_code != null
                                       orderby cpts.cpt_code, cpts.cpt_descr
                                       select new MedicalCodeSearchViewModel
                                       {
                                           ReferralNumber = strReferralNumber,
                                           DiagnosisCodeSearch = false,
                                           CptCodeSearch = true,
                                           HcpcsCodeSearch = false,
                                           SearchReturnCodeId = cpts.cpt_codes_2015_id,
                                           SearchReturnCode = cpts.cpt_code,
                                           SearchReturnShortDescription = "",
                                           SearchReturnLongDescription = cpts.cpt_descr
                                       }).ToList();

                }

                return (vmCodesToReturn);

            }
            catch (Exception ex)
            {
                return (vmCodesToReturn);
            }

        }

        public List<MedicalCodeSearchViewModel> GetCptCodesUsingDescriptionLikeSearchText(string strSearchText, string strReferralNumber)
        {

            var vmCodesToReturn = new List<MedicalCodeSearchViewModel>();

            try
            {

                using (var dbcode = new ICMS2DbContext())
                {

                    vmCodesToReturn = (from cpts in dbcode.DbmsCptCodes2015
                                       where cpts.cpt_descr.Contains(strSearchText)
                                       && cpts.cpt_code != null
                                       orderby cpts.cpt_code, cpts.cpt_descr
                                       select new MedicalCodeSearchViewModel
                                       {
                                           ReferralNumber = strReferralNumber,
                                           DiagnosisCodeSearch = false,
                                           CptCodeSearch = true,
                                           HcpcsCodeSearch = false,
                                           SearchReturnCodeId = cpts.cpt_codes_2015_id,
                                           SearchReturnCode = cpts.cpt_code,
                                           SearchReturnShortDescription = "",
                                           SearchReturnLongDescription = cpts.cpt_descr
                                       }).ToList();

                }

                return (vmCodesToReturn);

            }
            catch (Exception ex)
            {
                return (vmCodesToReturn);
            }

        }

        public List<MedicalCodeSearchViewModel> GetHcpcsCodesLikeSearchText(string strSearchText, string strReferralNumber)
        {

            var vmCodesToReturn = new List<MedicalCodeSearchViewModel>();

            try
            {

                using (var dbcode = new ICMS2DbContext())
                {

                    vmCodesToReturn = (from hcpcs in dbcode.DbmsHcpcsCodes2015 
                                       where hcpcs.hcp_code.StartsWith(strSearchText)
                                       && hcpcs.hcp_code != null
                                       orderby hcpcs.hcp_code, hcpcs.hcpcs_short, hcpcs.hcpcs_full
                                       select new MedicalCodeSearchViewModel
                                       {
                                           ReferralNumber = strReferralNumber,
                                           DiagnosisCodeSearch = false,
                                           CptCodeSearch = false,
                                           HcpcsCodeSearch = true,
                                           SearchReturnCodeId = hcpcs.hcpcs_codes_2015_id,
                                           SearchReturnCode = hcpcs.hcp_code,
                                           SearchReturnShortDescription = hcpcs.hcpcs_short,
                                           SearchReturnLongDescription = hcpcs.hcpcs_full
                                       }).ToList();

                }

                return (vmCodesToReturn);

            }
            catch (Exception ex)
            {
                return (vmCodesToReturn);
            }

        }

        public List<MedicalCodeSearchViewModel> GetHcpcsCodesUsingDescriptionLikeSearchText(string strSearchText, string strReferralNumber)
        {

            var vmCodesToReturn = new List<MedicalCodeSearchViewModel>();

            try
            {

                using (var dbcode = new ICMS2DbContext())
                {

                    vmCodesToReturn = (from hcpcs in dbcode.DbmsHcpcsCodes2015
                                       where hcpcs.hcpcs_short.Contains(strSearchText) ||
                                             hcpcs.hcpcs_full.Contains(strSearchText)
                                             && hcpcs.hcp_code != null
                                       orderby hcpcs.hcp_code, hcpcs.hcpcs_short, hcpcs.hcpcs_full
                                       select new MedicalCodeSearchViewModel
                                       {
                                           ReferralNumber = strReferralNumber,
                                           DiagnosisCodeSearch = false,
                                           CptCodeSearch = false,
                                           HcpcsCodeSearch = true,
                                           SearchReturnCodeId = hcpcs.hcpcs_codes_2015_id,
                                           SearchReturnCode = hcpcs.hcp_code,
                                           SearchReturnShortDescription = hcpcs.hcpcs_short,
                                           SearchReturnLongDescription = hcpcs.hcpcs_full
                                       }).ToList();

                }

                return (vmCodesToReturn);

            }
            catch (Exception ex)
            {
                return (vmCodesToReturn);
            }

        }

        public string GetMedicalCodeUsingCodeTypeAndCodeId(MedicalCodeSearchViewModel vmCodeToSearch)
        {

            string ReturnCode = "";

            try
            {

                if (vmCodeToSearch.DiagnosisCodeSearch)
                {
                    ReturnCode = DiagnosisCodeUsingCodeId(vmCodeToSearch);
                }
                else if (vmCodeToSearch.CptCodeSearch)
                {
                    ReturnCode = GetCptCodeUsingCodeId(vmCodeToSearch);
                }
                else if (vmCodeToSearch.HcpcsCodeSearch)
                {
                    ReturnCode = GetHcpcsCodeUsingCodeId(vmCodeToSearch);
                }

                return ReturnCode;

            }
            catch(Exception ex)
            {
                return ReturnCode;
            }

        }

        private string DiagnosisCodeUsingCodeId(MedicalCodeSearchViewModel vmCodeToSearch)
        {

            string DiagReturnCode = "";

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    DiagReturnCode = (from diags in db.DbmsDiagnoisiCodes10
                                      where diags.diagnosis_codes_10_id == vmCodeToSearch.SelectedSearchItemCodeId
                                      select diags.diagnosis_code)
                                      .SingleOrDefault();
                }


                return DiagReturnCode;

            }
            catch(Exception ex)
            {
                return DiagReturnCode;
            }

        }

        private string GetCptCodeUsingCodeId(MedicalCodeSearchViewModel vmCodeToSearch)
        {

            string CptReturnCode = "";

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    CptReturnCode = (from diags in db.DbmsCptCodes2015
                                     where diags.cpt_codes_2015_id == vmCodeToSearch.SelectedSearchItemCodeId
                                     select diags.cpt_code)
                                     .SingleOrDefault();
                }


                return CptReturnCode;

            }
            catch (Exception ex)
            {
                return CptReturnCode;
            }

        }

        private string GetHcpcsCodeUsingCodeId(MedicalCodeSearchViewModel vmCodeToSearch)
        {

            string HcpcsReturnCode = "";

            try
            {

                using (var db = new ICMS2DbContext())
                {
                    HcpcsReturnCode = (from hpcs in db.DbmsHcpcsCodes2015 
                                       where hpcs.hcpcs_codes_2015_id == vmCodeToSearch.SelectedSearchItemCodeId
                                       select hpcs.hcp_code)
                                       .SingleOrDefault();
                }


                return HcpcsReturnCode;

            }
            catch (Exception ex)
            {
                return HcpcsReturnCode;
            }

        }
        






        public List<rReferralType> GetAllReferralTypes()
        {

            var reftypes = new List<rReferralType>();


            using (var db = new ICMS2DbContext())
            {

                reftypes = (from authreftypes in db.DbmsReferralTypes
                            where (authreftypes.disabled == null || authreftypes.disabled == 0)
                            orderby authreftypes.label
                            select authreftypes)
                            .ToList();

            }
 

            return (reftypes);

        }

        public List<rReferralContext> GetAllContexts()
        {

            var refcontext = new List<rReferralContext>();


            using (var db = new ICMS2DbContext())
            {

                refcontext = (from refcont in db.DbmsReferralContext
                              orderby refcont.label
                              select refcont)
                              .ToList();

            }


            return (refcontext);

        }

        public List<rReferralPriority> GetAllPriorities()

        {

            var refpriorities = new List<rReferralPriority>();


            using (var db = new ICMS2DbContext())
            {

                refpriorities = (from refprior in db.DbmsReferralPriority
                                orderby refprior.label
                                select refprior)
                                .ToList();

            }


            return (refpriorities);

        }

        public List<rReferralCategory> GetAllCategories()

        {

            var refcategories = new List<rReferralCategory>();


            using (var db = new ICMS2DbContext())
            {

                refcategories = (from refcat in db.DbmsReferralCategory
                                 orderby refcat.label
                                 select refcat)
                                .ToList();

            }


            return (refcategories);

        }

        public List<rCurrentStatus> GetAllInitiateActions()
        {

            var initiateactions = new List<rCurrentStatus>();


            using (var db = new ICMS2DbContext())
            {

                initiateactions = (from initact in db.DbmsCurrentStatus
                                   orderby initact.label
                                   select initact)
                                   .ToList();

            }


            return (initiateactions);

        }

        public List<SystemUserViewModel> GetAllActionAssignToUsers()
        {

            var assigntouser = new List<SystemUserViewModel>();


            using (var db = new ICMS2DbContext())
            {

                assigntouser = (from users in db.DbmsSystemUsers
                                join userroles in db.DbmsSystemUserRoles
                                on users.system_user_id equals userroles.system_user_id
                                where users.user_inactive_flag == false
                                && userroles.system_role_id == new Guid("A3B1DAEF-E201-4B0A-B624-46A5E39212EF")
                                && users.discipline_id == 53
                                select new SystemUserViewModel {
                                    SystemUserId = users.system_user_id.ToString(),
                                    SystemUserFullName = users.system_user_first_name + " " + users.system_user_last_name
                                })
                                .ToList();

            }


            return (assigntouser);

        }

        public List<SystemUserViewModel> GetAllReviewRequestedByUsers()
        {

            var assigntouser = new List<SystemUserViewModel>();


            using (var db = new ICMS2DbContext())
            {

                assigntouser = (from users in db.DbmsSystemUsers
                                join userroles in db.DbmsSystemUserRoles
                                on users.system_user_id equals userroles.system_user_id
                                where users.review_md == 1
                                select new SystemUserViewModel
                                {
                                    SystemUserId = users.system_user_id.ToString(),
                                    SystemUserFullName = users.system_user_first_name + " " + users.system_user_last_name
                                })
                                .ToList();

            }


            return (assigntouser);

        }

        public List<rReferralPendReason> GetAllPendReasons()
        {

            var pendreason = new List<rReferralPendReason>();


            using (var db = new ICMS2DbContext())
            {

                pendreason = (from reasons in db.DbmsReferralPendReasons
                              orderby reasons.label
                              select reasons)
                              .ToList();

            }


            return (pendreason);

        }

        public List<rReferralPendReason> GetReasonForActionUsingCurrentStatusId(string strCurrentStatusId)
        {

            var pendreason = new List<rReferralPendReason>();


            if (!string.IsNullOrEmpty(strCurrentStatusId))
            {

                int CurrentStatusId = Convert.ToInt32(strCurrentStatusId);

                using (var db = new ICMS2DbContext())
                {

                    pendreason = (from reasons in db.DbmsReferralPendReasons
                                  where reasons.currentstatus_id == CurrentStatusId
                                  orderby reasons.label
                                  select reasons)
                                  .ToList();

                }

            }


            return (pendreason);

        }

        public List<rBedDayType> GetAllBedTypes()
        {

            var bedtypes = new List<rBedDayType>();

            try
            {              

                using (var db = new ICMS2DbContext())
                {

                    bedtypes = (from types in db.DbmsBedDayType
                                orderby types.label
                                select types)
                                .ToList();

                }


                return (bedtypes);

            }
            catch(Exception ex)
            {
                return (bedtypes);
            }

        }

        public List<ReviewTypeItems> GetAllReviewTypeItems()
        {

            var reviewtypeitems = new List<ReviewTypeItems>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    reviewtypeitems = (from types in db.DbmsReviewTypeItems
                                       orderby types.name
                                       select types)
                                       .ToList();

                }


                return (reviewtypeitems);

            }
            catch (Exception ex)
            {
                return (reviewtypeitems);
            }

        }

        public List<rUtilizationDaysDecision> GetAllUtilizationDaysDecisions()

        {

            var reviewtypeitems = new List<rUtilizationDaysDecision>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    reviewtypeitems = (from types in db.DbmsUtilizationDaysDecision
                                       orderby types.label
                                       select types)
                                       .ToList();

                }


                return (reviewtypeitems);

            }
            catch (Exception ex)
            {
                return (reviewtypeitems);
            }

        }

        public List<rDenialReason> GetAllDenialReasons()
        {

            var denialreasons = new List<rDenialReason>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    denialreasons = (from types in db.DbmsDenialReason
                                     orderby types.label
                                     select types)
                                     .ToList();

                }


                return (denialreasons);

            }
            catch (Exception ex)
            {
                return (denialreasons);
            }

        }

        public List<rUtilizationVisitPeriod> GetAllUtilizationsVisitPeriods()
        {

            var visitperiods = new List<rUtilizationVisitPeriod>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    visitperiods = (from periods in db.DbmsUtilizationVisitPeriod
                                    orderby periods.label
                                    select periods)
                                    .ToList();

                }


                return (visitperiods);

            }
            catch (Exception ex)
            {
                return (visitperiods);
            }

        }





        public ReferralViewModel InitializeReferralGeneral(string strReferralNumber)
        {

            ReferralViewModel vmForNavbar = new ReferralViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmForNavbar = (from refs in db.DbmsMemberReferrals
                                       where refs.referral_number == strReferralNumber
                                       select new ReferralViewModel
                                       {
                                           ReferralNumber = refs.referral_number,
                                           MemberId = refs.member_id.ToString(),
                                           AuthNumber = refs.auth_number,
                                           AuthStartDate = refs.auth_start_date,
                                           AuthEndDate = refs.auth_end_date,
                                           type_id = refs.type_id,
                                           context_id = refs.context_id,
                                           priority_id = refs.priority_id,
                                           referral_category = refs.referral_category
                                       }).SingleOrDefault();


                    }

                }


                return vmForNavbar;

            }
            catch(Exception ex)
            {
                return vmForNavbar;
            }

        }

        public void InitializeReferralGeneralControls(ref ReferralViewModel vmGeneralView)
        {

            try
            {

                //populate the Referral Type dropdown
                vmGeneralView.ReferralTypesInDbms = GetAllReferralTypes();
                //populate the Context dropdown
                vmGeneralView.ReferralContextsInDbms = GetAllContexts();
                //populate the Priority dropdown
                vmGeneralView.ReferralPrioritiesInDbms = GetAllPriorities();
                //populate the Categories dropdown
                vmGeneralView.ReferralCategoriesInDbms = GetAllCategories();

            }
            catch(Exception ex)
            {

            }

        }





        public ReferralViewModel InitializeReferralActions(string strReferralNumber)
        {

            ReferralViewModel vmForNavbar = new ReferralViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmForNavbar = (from refs in db.DbmsMemberReferrals
                                       where refs.referral_number == strReferralNumber
                                       select new ReferralViewModel
                                       {
                                           ReferralNumber = refs.referral_number,
                                           AuthNumber = refs.auth_number,
                                           AuthStartDate = refs.auth_start_date,
                                           AuthEndDate = refs.auth_end_date
                                       }).SingleOrDefault();


                    }

                }


                return vmForNavbar;

            }
            catch (Exception ex)
            {
                return vmForNavbar;
            }

        }

        public void InitializeReferralActionControls(ref ReferralViewModel vmActionsView)
        {

            try
            {

                //populate the Initiate Action dropdown
                vmActionsView.ReferralInitiateActionInDbms = GetAllInitiateActions();
                //populate the Assign Action To dropdown
                vmActionsView.ReferralActionAssignedToInDbms = GetAllActionAssignToUsers();
                //populate the Reason For Action dropdown
                vmActionsView.ReferralPendReasonInDbms = GetAllPendReasons();
                //populate the Review Requested By To dropdown
                vmActionsView.ReferralReviewRequestedByInDbms = GetAllReviewRequestedByUsers();

            }
            catch (Exception ex)
            {

            }

        }





        public ReferralViewModel InitializeReferralCodes(string strReferralNumber)
        {

            ReferralViewModel vmForNavbar = new ReferralViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmForNavbar = (from refs in db.DbmsMemberReferrals
                                       where refs.referral_number == strReferralNumber
                                       select new ReferralViewModel
                                       {
                                           ReferralNumber = refs.referral_number,
                                           AuthNumber = refs.auth_number,
                                           AuthStartDate = refs.auth_start_date,
                                           AuthEndDate = refs.auth_end_date
                                       }).SingleOrDefault();


                    }

                }


                return vmForNavbar;

            }
            catch (Exception ex)
            {
                return vmForNavbar;
            }

        }

        public void InitializeReferralCodesControls(ref ReferralViewModel vmCodesView)
        {

            try
            {

                vmCodesView.ReferralDiagnosisCodesInDbms = GetReferralDiagnosisCodesUsingReferralNumber(vmCodesView.ReferralNumber);
                vmCodesView.ReferralCptCodesInDbms = GetReferralCptCodesUsingReferralNumber(vmCodesView.ReferralNumber);
                vmCodesView.ReferralHcpcsCodesInDbms = GetReferralHcpcsCodesUsingReferralNumber(vmCodesView.ReferralNumber);


            }
            catch (Exception ex)
            {

            }

        }





        public UtilizationInpatientDayViewModel InitializeInpatientReferralUtilization(string strReferralNumber)

        {

            UtilizationInpatientDayViewModel vmForNavbar = new UtilizationInpatientDayViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmForNavbar = (from refs in db.DbmsMemberReferrals
                                       join reftype in db.DbmsReferralTypes 
                                       on refs.type_id equals reftype.id
                                       where refs.referral_number == strReferralNumber
                                       select new UtilizationInpatientDayViewModel
                                       {
                                           MemberId = refs.member_id.ToString(),
                                           ReferralNumber = refs.referral_number,
                                           AuthNumber = refs.auth_number,
                                           AuthStartDate = refs.auth_start_date,
                                           AuthEndDate = refs.auth_end_date,
                                           InpatientOutpatientType = reftype.inpatient_outpatient_type
                                       }).SingleOrDefault();


                    }

                }


                return vmForNavbar;

            }
            catch (Exception ex)
            {
                return vmForNavbar;
            }

        }

        public void InitializeInpatientReferralUtilizationControls(ref UtilizationInpatientDayViewModel vmUtilizationViewModel)
        {

            try
            {
                vmUtilizationViewModel.ReferralBedTypesInDbms = GetAllBedTypes();
                vmUtilizationViewModel.ReviewTypeItemsInDbms = GetAllReviewTypeItems();
                vmUtilizationViewModel.UtilizationDaysDecisionInDbms = GetAllUtilizationDaysDecisions();
                vmUtilizationViewModel.DenialReasonsInDbms = GetAllDenialReasons();

                vmUtilizationViewModel.InpatientUtilizationDaysInReferral = GetReferralInpatientUtilizationDaysUsingReferralNumber(vmUtilizationViewModel.ReferralNumber);

            }
            catch(Exception ex)
            {

            }

        }

        public UtilizationOutpatientDayViewModel InitializeOutpatientReferralUtilization(string strReferralNumber)

        {

            UtilizationOutpatientDayViewModel vmForNavbar = new UtilizationOutpatientDayViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmForNavbar = (from refs in db.DbmsMemberReferrals
                                       join reftype in db.DbmsReferralTypes
                                       on refs.type_id equals reftype.id
                                       where refs.referral_number == strReferralNumber
                                       select new UtilizationOutpatientDayViewModel
                                       {
                                           MemberId = refs.member_id.ToString(),
                                           ReferralNumber = refs.referral_number,
                                           AuthNumber = refs.auth_number,
                                           AuthStartDate = refs.auth_start_date,
                                           AuthEndDate = refs.auth_end_date,
                                           InpatientOutpatientType = reftype.inpatient_outpatient_type
                                       }).SingleOrDefault();


                    }

                }


                return vmForNavbar;

            }
            catch (Exception ex)
            {
                return vmForNavbar;
            }

        }

        public void InitializeOutpatientReferralUtilizationControls(ref UtilizationOutpatientDayViewModel vmUtilizationViewModel)
        {

            try
            {
                vmUtilizationViewModel.VisitPeriodsRequestedItemsInDbms = GetAllUtilizationsVisitPeriods();
                vmUtilizationViewModel.VisitPeriodsAuthorizedItemsInDbms = GetAllUtilizationsVisitPeriods();
                vmUtilizationViewModel.ReviewTypeItemsInDbms = GetAllReviewTypeItems();
                vmUtilizationViewModel.UtilizationDaysDecisionInDbms = GetAllUtilizationDaysDecisions();
                vmUtilizationViewModel.DenialReasonsInDbms = GetAllDenialReasons();

                vmUtilizationViewModel.OutpatientUtilizationDaysInReferral = GetReferralOutpatientUtilizationDaysUsingReferralNumber(vmUtilizationViewModel.ReferralNumber);

            }
            catch(Exception ex)
            {

            }

        }





        
        public ReferralLetterViewModel InitializeReferralLetter(string strReferralNumber)
        {

            ReferralLetterViewModel vmLetter = new ReferralLetterViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmLetter = (from refs in db.DbmsMemberReferrals
                                    where refs.referral_number == strReferralNumber
                                    select new ReferralLetterViewModel
                                    {
                                           ReferralNumber = refs.referral_number,
                                           MemberId = refs.member_id.ToString(),
                                           AuthNumber = refs.auth_number,
                                    }).SingleOrDefault();


                    }

                }


                return vmLetter;

            }
            catch (Exception ex)
            {
                return vmLetter;
            }

        }

        public void InitializeReferralLetterControls(ref ReferralLetterViewModel vmLetterViewModel)
        {

            try
            {
                vmLetterViewModel.LettersInReferral = GetReferralLettersUsingReferralNumber(vmLetterViewModel.ReferralNumber);
                vmLetterViewModel.ReferralDecision = GetReferralMostRecentDecisionUsingReferralNumber(vmLetterViewModel.ReferralNumber);
            }
            catch(Exception ex)
            {

            }

        }

        public ReferralLetterViewModel GenerateReferralApprovalLetter(string strMemberId,string strReferralNumber)
        {

            UmLetterRepository umltRepo = new UmLetterRepository();
            ReferralLetterViewModel vmGeneratedLetter = new ReferralLetterViewModel();

            try
            {

                vmGeneratedLetter =  umltRepo.GenerateUmApprovalLetter(strMemberId, strReferralNumber);

                return vmGeneratedLetter;

            }
            catch(Exception ex)
            {
                return vmGeneratedLetter;
            }

        }

        public byte[] GetUmLetterUsingId(int Id)
        {

            byte[] byteToReturn = null;


            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT file_blob FROM r_MEMBER_REFERRAL_LETTERS WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Connection = con;
                        con.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            byteToReturn = (byte[])sdr["file_blob"];
                        }

                        con.Close();

                    }

                }


                return byteToReturn;

            }
            catch(Exception ex)
            {
                return byteToReturn;
            }

        }







        public ReferralRefersViewModel InitializeReferralRefers(string strReferralNumber)
        {

            ReferralRefersViewModel refrefsvmToReturn = new ReferralRefersViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        refrefsvmToReturn = (from refs in db.DbmsMemberReferrals
                                             where refs.referral_number == strReferralNumber
                                             select new ReferralRefersViewModel
                                             {
                                                  ReferralNumber = refs.referral_number,
                                                  MemberId = refs.member_id.ToString(),
                                                  AuthNumber = refs.auth_number,
                                             }).SingleOrDefault();


                    }

                }


                return refrefsvmToReturn;

            }
            catch (Exception ex)
            {
                return refrefsvmToReturn;
            }

        }

        public void InitializeReferralRefersControls(ref ReferralRefersViewModel vmRefers)
        {

            try
            {

                GetReferralReferredByItemsUsingReferralNumber(ref vmRefers);
                GetReferralReferredToItemsUsingReferralNumber(ref vmRefers);

                StatesRepository statesinusa = new StatesRepository();
                vmRefers.StatesInUsa = statesinusa.GetAllStates();

                vmRefers.PlaceOfServices = GetPlaceOfServices();

            }
            catch(Exception ex)
            {

            }

        }

        public bool RemoveReferralReferItem(string RefNum, string RemoveType, string RemoveId)
        {

            bool Removed = false;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rMemberReferral referral = new rMemberReferral();

                    referral = (from refs in db.DbmsMemberReferrals
                                where refs.referral_number == RefNum
                                select refs).SingleOrDefault();

                    if (referral != null)
                    {

                        bool blnContinue = false;

                        switch (RemoveType)
                        {

                            case "ReferredByProvider":
                                referral.referring_pcp_id = null;
                                blnContinue = true;
                                break;

                            case "ReferredToProvider":
                                referral.referred_to_pcp_id = null;
                                blnContinue = true;
                                break;

                            case "ReferredByFacility":
                                referral.referred_by_department_id = null;
                                blnContinue = true;
                                break;

                            case "ReferredToFacility":
                                referral.referred_to_department_id = null;
                                blnContinue = true;
                                break;

                            case "ReferredToVendor":
                                referral.referred_to_vendor_id = null;
                                blnContinue = true;
                                break;

                            case "ReferredByPlaceOfService":
                                referral.referring_locationpos_id = null;
                                blnContinue = true;
                                break;

                            case "ReferredToPlaceOfService":
                                referral.referred_to_locationpos_id = null;
                                blnContinue = true;
                                break;

                            case "ReferredByStdOfficeLocation":
                                referral.std_office_location = null;
                                blnContinue = true;
                                break;

                        }

                        if (blnContinue)
                        {
                            //update the review question to the mdreviewquestion context
                            db.Entry(referral).State = EntityState.Modified;

                            //update the model (IcmsMember) in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {
                                Removed = true;
                            }

                        }

                    }

                }

                return Removed;

            }
            catch(Exception ex)
            {
                return Removed;
            }

        }

        public List<ProviderSearchViewModel> GetProviderUsingNameLikeSearchText(string FirstName, string LastName, 
                                                                                string City, string State)
        {

            var vmProviderToReturn = new List<ProviderSearchViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    if (!string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(State))
                    {

                        vmProviderToReturn = (from pcps in db.DbmsPcpProviders

                                              //left outer join
                                              join provadd in db.DbmsProviderAddress
                                              on pcps.pcp_id equals provadd.pcp_id
                                              into provaddjoin
                                              from provadd in provaddjoin.DefaultIfEmpty()

                                              where pcps.provider_first_name.StartsWith(FirstName)
                                              && pcps.provider_last_name.StartsWith(LastName)
                                              && provadd.city.StartsWith(City)
                                              && provadd.state_abbrev == State
                                              orderby pcps.provider_last_name, pcps.provider_first_name
                                              select new ProviderSearchViewModel
                                              {
                                                  PcpId = pcps.pcp_id.ToString(),
                                                  FirstName = pcps.provider_first_name,
                                                  LastName = pcps.provider_last_name,
                                                  Address1 = provadd.address_line1,
                                                  Address2 = provadd.address_line2,
                                                  City = provadd.city,
                                                  State = provadd.state_abbrev
                                              }).ToList();

                    }
                    else if (!string.IsNullOrEmpty(City))
                    {

                        vmProviderToReturn = (from pcps in db.DbmsPcpProviders

                                              //left outer join
                                              join provadd in db.DbmsProviderAddress
                                              on pcps.pcp_id equals provadd.pcp_id
                                              into provaddjoin
                                              from provadd in provaddjoin.DefaultIfEmpty()

                                              where pcps.provider_first_name.StartsWith(FirstName)
                                              && pcps.provider_last_name.StartsWith(LastName)
                                              && provadd.city.StartsWith(City)
                                              orderby pcps.provider_last_name, pcps.provider_first_name
                                              select new ProviderSearchViewModel
                                              {
                                                  PcpId = pcps.pcp_id.ToString(),
                                                  FirstName = pcps.provider_first_name,
                                                  LastName = pcps.provider_last_name,
                                                  Address1 = provadd.address_line1,
                                                  Address2 = provadd.address_line2,
                                                  City = provadd.city,
                                                  State = provadd.state_abbrev
                                              }).ToList();

                    }
                    else if (!string.IsNullOrEmpty(State))
                    {

                        vmProviderToReturn = (from pcps in db.DbmsPcpProviders

                                              //left outer join
                                              join provadd in db.DbmsProviderAddress
                                              on pcps.pcp_id equals provadd.pcp_id
                                              into provaddjoin
                                              from provadd in provaddjoin.DefaultIfEmpty()

                                              where pcps.provider_first_name.StartsWith(FirstName)
                                              && pcps.provider_last_name.StartsWith(LastName)
                                              && provadd.state_abbrev == State
                                              orderby pcps.provider_last_name, pcps.provider_first_name
                                              select new ProviderSearchViewModel
                                              {
                                                  PcpId = pcps.pcp_id.ToString(),
                                                  FirstName = pcps.provider_first_name,
                                                  LastName = pcps.provider_last_name,
                                                  Address1 = provadd.address_line1,
                                                  Address2 = provadd.address_line2,
                                                  City = provadd.city,
                                                  State = provadd.state_abbrev
                                              }).ToList();

                    }
                    else
                    {

                        vmProviderToReturn = (from pcps in db.DbmsPcpProviders

                                              //left outer join
                                              join provadd in db.DbmsProviderAddress
                                              on pcps.pcp_id equals provadd.pcp_id
                                              into provaddjoin
                                              from provadd in provaddjoin.DefaultIfEmpty()

                                              where pcps.provider_first_name.StartsWith(FirstName)
                                              && pcps.provider_last_name.StartsWith(LastName)
                                              orderby pcps.provider_last_name, pcps.provider_first_name
                                              select new ProviderSearchViewModel
                                              {
                                                  PcpId = pcps.pcp_id.ToString(),
                                                  FirstName = pcps.provider_first_name,
                                                  LastName = pcps.provider_last_name,
                                                  Address1 = provadd.address_line1,
                                                  Address2 = provadd.address_line2,
                                                  City = provadd.city,
                                                  State = provadd.state_abbrev
                                              }).ToList();

                    }

                }

                return (vmProviderToReturn);

            }
            catch (Exception ex)
            {
                return (vmProviderToReturn);
            }

        }

        public bool AddReferralReferProviderItem(ProviderSearchViewModel provsrchvmToAdd)
        {

            bool Added = false;

            try
            {

                if (!string.IsNullOrEmpty(provsrchvmToAdd.PcpId) && !string.IsNullOrEmpty(provsrchvmToAdd.ReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        rMemberReferral referral = new rMemberReferral();

                        referral = (from refs in db.DbmsMemberReferrals
                                    where refs.referral_number == provsrchvmToAdd.ReferralNumber
                                    select refs).SingleOrDefault();

                        if (referral != null)
                        {

                            switch (provsrchvmToAdd.AddType)
                            {

                                case "ReferredByProvider":
                                    referral.referring_pcp_id = new Guid(provsrchvmToAdd.PcpId);
                                    break;

                                case "ReferredToProvider":
                                    referral.referred_to_pcp_id = new Guid(provsrchvmToAdd.PcpId);
                                    break;

                            }


                            //update the review question to the mdreviewquestion context
                            db.Entry(referral).State = EntityState.Modified;

                            //update the model (IcmsMember) in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {
                                Added = true;
                            }

                        }

                    }

                }

                return Added;

            }
            catch(Exception ex)
            {
                return Added;
            }

        }

        public List<FacilitySearchViewModel> GetFacilityUsingNameLikeSearchText(string Name, string City, string State)
        {

            var vmFacilityToReturn = new List<FacilitySearchViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    if (!string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(State))
                    {

                        vmFacilityToReturn = (from facilities in db.DbmsDepartments

                                              //left outer join
                                              join facadd in db.DbmsFacilityAddress
                                              on facilities.id equals facadd.id
                                              into provaddjoin
                                              from facadd in provaddjoin.DefaultIfEmpty()

                                              where facilities.label.StartsWith(Name)                                              
                                              && facadd.city.StartsWith(City)
                                              && facadd.state_abbrev == State
                                              orderby facilities.label
                                              select new FacilitySearchViewModel
                                              {
                                                  FacilityId = facilities.id,
                                                  Name = facilities.label,
                                                  Address1 = facadd.address_line_one,
                                                  Address2 = facadd.address_line_two,
                                                  City = facadd.city,
                                                  State = facadd.state_abbrev
                                              }).ToList();

                    }
                    else if (!string.IsNullOrEmpty(City))
                    {

                        vmFacilityToReturn = (from facilities in db.DbmsDepartments

                                              //left outer join
                                              join facadd in db.DbmsFacilityAddress
                                              on facilities.id equals facadd.id
                                              into provaddjoin
                                              from facadd in provaddjoin.DefaultIfEmpty()

                                              where facilities.label.StartsWith(Name)                                              
                                              && facadd.city.StartsWith(City)
                                              orderby facilities.label
                                              select new FacilitySearchViewModel
                                              {
                                                  FacilityId = facilities.id,
                                                  Name = facilities.label,
                                                  Address1 = facadd.address_line_one,
                                                  Address2 = facadd.address_line_two,
                                                  City = facadd.city,
                                                  State = facadd.state_abbrev
                                              }).ToList();

                    }
                    else if (!string.IsNullOrEmpty(State))
                    {

                        vmFacilityToReturn = (from facilities in db.DbmsDepartments

                                              //left outer join
                                              join facadd in db.DbmsFacilityAddress
                                              on facilities.id equals facadd.id
                                              into provaddjoin
                                              from facadd in provaddjoin.DefaultIfEmpty()

                                              where facilities.label.StartsWith(Name)                                              
                                              && facadd.state_abbrev == State
                                              orderby facilities.label
                                              select new FacilitySearchViewModel
                                              {
                                                  FacilityId = facilities.id,
                                                  Name = facilities.label,
                                                  Address1 = facadd.address_line_one,
                                                  Address2 = facadd.address_line_two,
                                                  City = facadd.city,
                                                  State = facadd.state_abbrev
                                              }).ToList();

                    }
                    else
                    {

                        vmFacilityToReturn = (from facilities in db.DbmsDepartments

                                              //left outer join
                                              join facadd in db.DbmsFacilityAddress
                                              on facilities.id equals facadd.id
                                              into provaddjoin
                                              from facadd in provaddjoin.DefaultIfEmpty()

                                              where facilities.label.StartsWith(Name)                                              
                                              orderby facilities.label
                                              select new FacilitySearchViewModel
                                              {
                                                  FacilityId = facilities.id,
                                                  Name = facilities.label,
                                                  Address1 = facadd.address_line_one,
                                                  Address2 = facadd.address_line_two,
                                                  City = facadd.city,
                                                  State = facadd.state_abbrev
                                              }).ToList();

                    }

                }

                return (vmFacilityToReturn);

            }
            catch (Exception ex)
            {
                return (vmFacilityToReturn);
            }

        }

        public bool AddReferralReferFacilityItem(FacilitySearchViewModel facsrchvmToAdd)
        {

            bool Added = false;

            try
            {

                if (facsrchvmToAdd.FacilityId.CompareTo(0) > 0 && !string.IsNullOrEmpty(facsrchvmToAdd.ReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        rMemberReferral referral = new rMemberReferral();

                        referral = (from refs in db.DbmsMemberReferrals
                                    where refs.referral_number == facsrchvmToAdd.ReferralNumber
                                    select refs).SingleOrDefault();

                        if (referral != null)
                        {

                            switch (facsrchvmToAdd.AddType)
                            {

                                case "ReferredByFacility":
                                    referral.referred_by_department_id = facsrchvmToAdd.FacilityId;
                                    break;

                                case "ReferredToFacility":
                                    referral.referred_to_department_id = facsrchvmToAdd.FacilityId;
                                    break;

                            }


                            //update the review question to the mdreviewquestion context
                            db.Entry(referral).State = EntityState.Modified;

                            //update the model (IcmsMember) in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {
                                Added = true;
                            }

                        }

                    }

                }

                return Added;

            }
            catch (Exception ex)
            {
                return Added;
            }

        }

        public List<VendorSearchViewModel> GetVendorUsingNameLikeSearchText(string Name, string City, string State)
        {

            var vmVendorToReturn = new List<VendorSearchViewModel>();

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    if (!string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(State))
                    {

                        vmVendorToReturn = (from vendors in db.DbmsVendors

                                              //left outer join
                                              join vendadd in db.DbmsVendorAddress
                                              on vendors.id equals vendadd.id
                                              into vendaddjoin
                                              from vendadd in vendaddjoin.DefaultIfEmpty()

                                              where vendors.label.StartsWith(Name)
                                              && vendadd.city.StartsWith(City)
                                              && vendadd.state_abbrev == State
                                              orderby vendors.label
                                              select new VendorSearchViewModel
                                              {
                                                  VendorId = vendors.id,
                                                  Name = vendors.label,
                                                  Address1 = vendadd.address_line_one,
                                                  Address2 = vendadd.address_line_two,
                                                  City = vendadd.city,
                                                  State = vendadd.state_abbrev
                                              }).ToList();

                    }
                    else if (!string.IsNullOrEmpty(City))
                    {

                        vmVendorToReturn = (from vendors in db.DbmsVendors

                                              //left outer join
                                              join vendadd in db.DbmsVendorAddress
                                              on vendors.id equals vendadd.id
                                              into vendaddjoin
                                              from vendadd in vendaddjoin.DefaultIfEmpty()

                                              where vendors.label.StartsWith(Name)
                                              && vendadd.city.StartsWith(City)
                                              orderby vendors.label
                                              select new VendorSearchViewModel
                                              {
                                                  VendorId = vendors.id,
                                                  Name = vendors.label,
                                                  Address1 = vendadd.address_line_one,
                                                  Address2 = vendadd.address_line_two,
                                                  City = vendadd.city,
                                                  State = vendadd.state_abbrev
                                              }).ToList();

                    }
                    else if (!string.IsNullOrEmpty(State))
                    {

                        vmVendorToReturn = (from vendors in db.DbmsVendors

                                              //left outer join
                                              join vendadd in db.DbmsVendorAddress
                                              on vendors.id equals vendadd.id
                                              into vendaddjoin
                                              from vendadd in vendaddjoin.DefaultIfEmpty()

                                              where vendors.label.StartsWith(Name)
                                              && vendadd.state_abbrev == State
                                              orderby vendors.label
                                              select new VendorSearchViewModel
                                              {
                                                  VendorId = vendors.id,
                                                  Name = vendors.label,
                                                  Address1 = vendadd.address_line_one,
                                                  Address2 = vendadd.address_line_two,
                                                  City = vendadd.city,
                                                  State = vendadd.state_abbrev
                                              }).ToList();

                    }
                    else
                    {

                        vmVendorToReturn = (from vendors in db.DbmsVendors

                                              //left outer join
                                              join vendadd in db.DbmsVendorAddress
                                              on vendors.id equals vendadd.id
                                              into vendaddjoin
                                              from vendadd in vendaddjoin.DefaultIfEmpty()

                                              where vendors.label.StartsWith(Name)
                                              orderby vendors.label
                                              select new VendorSearchViewModel
                                              {
                                                  VendorId = vendors.id,
                                                  Name = vendors.label,
                                                  Address1 = vendadd.address_line_one,
                                                  Address2 = vendadd.address_line_two,
                                                  City = vendadd.city,
                                                  State = vendadd.state_abbrev
                                              }).ToList();

                    }

                }

                return (vmVendorToReturn);

            }
            catch (Exception ex)
            {
                return (vmVendorToReturn);
            }

        }

        public bool AddReferralReferVendorItem(VendorSearchViewModel vendsrchvmToAdd)
        {

            bool Added = false;

            try
            {

                if (vendsrchvmToAdd.VendorId.CompareTo(0) > 0 && !string.IsNullOrEmpty(vendsrchvmToAdd.ReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        rMemberReferral referral = new rMemberReferral();

                        referral = (from refs in db.DbmsMemberReferrals
                                    where refs.referral_number == vendsrchvmToAdd.ReferralNumber
                                    select refs).SingleOrDefault();

                        if (referral != null)
                        {

                            switch (vendsrchvmToAdd.AddType)
                            {

                                case "ReferredToVendor":
                                    referral.referred_to_vendor_id = vendsrchvmToAdd.VendorId;
                                    break;

                            }


                            //update the context
                            db.Entry(referral).State = EntityState.Modified;

                            //update the model in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {
                                Added = true;
                            }

                        }

                    }

                }

                return Added;

            }
            catch (Exception ex)
            {
                return Added;
            }

        }

        public bool AddReferralReferPlaceOfServiceItem(string RefNum, string AddType, string AddId)
        {

            bool Added = false;

            try
            {

                if (!string.IsNullOrEmpty(AddId) && !string.IsNullOrEmpty(RefNum))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        rMemberReferral referral = new rMemberReferral();

                        referral = (from refs in db.DbmsMemberReferrals
                                    where refs.referral_number == RefNum
                                    select refs).SingleOrDefault();

                        if (referral != null)
                        {

                            switch (AddType)
                            {

                                case "ReferredToPlaceOfService":
                                    referral.referred_to_locationpos_id = Convert.ToInt32(AddId);
                                    break;

                                case "ReferredByPlaceOfService":
                                    referral.referring_locationpos_id = Convert.ToInt32(AddId);
                                    break;

                            }


                            //update the context
                            db.Entry(referral).State = EntityState.Modified;

                            //update the model in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {
                                Added = true;
                            }

                        }

                    }

                }

                return Added;

            }
            catch (Exception ex)
            {
                return Added;
            }

        }

        public bool AddReferralReferStdOfficeLocationItem(string RefNum, string AddType, string AddId)
        {

            bool Added = false;

            try
            {

                if (!string.IsNullOrEmpty(AddId) && !string.IsNullOrEmpty(RefNum))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        rMemberReferral referral = new rMemberReferral();

                        referral = (from refs in db.DbmsMemberReferrals
                                    where refs.referral_number == RefNum
                                    select refs).SingleOrDefault();

                        if (referral != null)
                        {

                            switch (AddType)
                            {

                                case "ReferredByStdOfficeLocation":
                                    referral.std_office_location = AddId;
                                    break;

                            }


                            //update the context
                            db.Entry(referral).State = EntityState.Modified;

                            //update the model in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {
                                Added = true;
                            }

                        }

                    }

                }

                return Added;

            }
            catch (Exception ex)
            {
                return Added;
            }

        }






        public ReferralRequestViewModel InitializeReferralRequest(string strReferralNumber)

        {

            ReferralRequestViewModel vmRequest = new ReferralRequestViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmRequest = (from refs in db.DbmsMemberReferrals
                                    where refs.referral_number == strReferralNumber
                                    select new ReferralRequestViewModel
                                    {
                                        ReferralNumber = refs.referral_number,
                                        MemberId = refs.member_id.ToString(),
                                        AuthNumber = refs.auth_number,
                                    }).SingleOrDefault();


                    }

                }


                return vmRequest;

            }
            catch (Exception ex)
            {
                return vmRequest;
            }

        }

        public void InitializeReferralRequestControls(ref ReferralRequestViewModel refvmRequest)

        {

            try
            {
                refvmRequest.TopLevelMdReviewRequestId = GetReferralTopLevelMdReviewRequestId(refvmRequest.ReferralNumber);
                refvmRequest.ReferralMdRequestsFor = GetReferralMdsForRequests();
                refvmRequest.requests = GetReferralReviewRequestsUsingReferralNumber(refvmRequest.ReferralNumber);
                refvmRequest.questions = GetReferralReviewQuestionsUsingReferralNumber(refvmRequest.ReferralNumber);
            }
            catch (Exception ex)
            {

            }

        }

        public bool AddReferralMdReview(string strReferralNumber, string strMemberId, string strAssignToSystemUserId, 
                                        string strRequestText, string strCreationSystemUserId)
        {

            bool Added = false;

            try
            {

                MdReviewRequest mdrvreqToAdd = new MdReviewRequest();

                using (var db = new ICMS2DbContext())
                {

                    DateTime dteNow = DateTime.Now;

                    // from table ICMS_TASK where code = 'MDREVREQ'
                    mdrvreqToAdd.task_id = 401;
                    mdrvreqToAdd.assigned_to_system_user_id = new Guid(strAssignToSystemUserId);
                    mdrvreqToAdd.start_action_date = dteNow;
                    mdrvreqToAdd.end_action_date = dteNow.AddDays(2);
                    mdrvreqToAdd.completed = false;
                    mdrvreqToAdd.entered_by_system_user_id = new Guid(strCreationSystemUserId);
                    mdrvreqToAdd.date_entered = dteNow;
                    mdrvreqToAdd.task_note = "An MD Review Request for referral " + strReferralNumber + " was entered on " + dteNow.ToShortDateString();
                    mdrvreqToAdd.member_id = new Guid(strMemberId);
                    mdrvreqToAdd.referral_number = strReferralNumber;
                    mdrvreqToAdd.md_review_appeal_note = strRequestText;
                    mdrvreqToAdd.creation_date = dteNow;

                    //add the md review request to the md review request context
                    db.DbmsMdReviewRequest.Add(mdrvreqToAdd);
                    
                    int updatesreturned = db.SaveChanges();

                    if (updatesreturned.CompareTo(0) > 0)
                    {
                        Added = true;
                    }

                }

                return Added;

            }
            catch(Exception ex)
            {
                return Added;
            }

        }

        public bool UpdateReferralReviewAnswerForReferralReviewQuestion(string strReferralNumber, int intQuestionId, string strAnswer)
        {

            bool Updated = false;

            try
            {

                MdReviewQuestion mdrvqusToUpdate = new MdReviewQuestion();

                using (var db = new ICMS2DbContext())
                {

                    mdrvqusToUpdate = (from reviewquestion in db.DbmsMdReviewQuestion
                                       where reviewquestion.md_review_question_id == intQuestionId
                                       select reviewquestion
                                      ).SingleOrDefault();

                
                    if (mdrvqusToUpdate != null)
                    {

                        mdrvqusToUpdate.md_answer_note = strAnswer;

                        //update the review question to the mdreviewquestion context
                        db.Entry(mdrvqusToUpdate).State = EntityState.Modified;

                        //update the model (IcmsMember) in the database
                        int updatesreturned = db.SaveChanges();


                        if (updatesreturned.CompareTo(0) > 0)
                        {
                            Updated = true;
                        }

                    }
                }


                return Updated;

            }
            catch(Exception ex)
            {
                return Updated;
            }

        }

        public void SendReferralReviewEmail(string strReferralNumber, int intQuestionId, string strUserId)
        {

            try
            {

                MdReviewQuestion mdrvqusReviewForEmail = new MdReviewQuestion();

                using (var db = new ICMS2DbContext())
                {

                    mdrvqusReviewForEmail = (from reviewquestion in db.DbmsMdReviewQuestion
                                       where reviewquestion.md_review_question_id == intQuestionId
                                       select reviewquestion
                                      ).SingleOrDefault();


                    if (mdrvqusReviewForEmail != null)
                    {

                        if (!string.IsNullOrEmpty(mdrvqusReviewForEmail.entered_by_system_user_id.ToString()))
                        {

                            SystemUser suUserEmail = new SystemUser();

                            suUserEmail = (from sysUsers in db.DbmsSystemUsers
                                           where sysUsers.system_user_id == mdrvqusReviewForEmail.entered_by_system_user_id
                                           select sysUsers
                                           ).SingleOrDefault();

                            if (suUserEmail != null)
                            {

                                if (!string.IsNullOrEmpty(suUserEmail.email_address))
                                {

                                    EmailsOutbound emoutToMd = new EmailsOutbound();

                                    emoutToMd.user_id = new Guid(strUserId);
                                    emoutToMd.creation_date = DateTime.Now;
                                    emoutToMd.email_to = suUserEmail.email_address;
                                    emoutToMd.email_subject = "MD Answer Submitted On " + DateTime.Now.ToShortDateString();
                                    emoutToMd.email_message = "MD Answer Request has been entered.  " +
                                                              "Please visit http://www.dbmshealth.com/ and click on the MD Review link.";
                                    emoutToMd.email_sent = false;

                                    db.DbmsEmailsOutbound.Add(emoutToMd);

                                    db.SaveChanges();

                                }
                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {

            }

        }








        public NotesViewModel InitializeReferralNotes(string strReferralNumber)
        {

            NotesViewModel vmRequest = new NotesViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmRequest = (from refs in db.DbmsMemberReferrals
                                     where refs.referral_number == strReferralNumber
                                     select new NotesViewModel
                                     {
                                         ReferralNumber = refs.referral_number,
                                         MemberId = refs.member_id.ToString(),
                                         AuthNumber = refs.auth_number,
                                     }).SingleOrDefault();


                    }

                }


                return vmRequest;

            }
            catch (Exception ex)
            {
                return vmRequest;
            }

        }

        public void InitializeReferralNotesControls(ref NotesViewModel notvmReferralNotes)
        {


            notvmReferralNotes.UtilizationType = GetReferralUtilizationTypeUsingReferralNumber(notvmReferralNotes.ReferralNumber);


            if (string.IsNullOrEmpty(notvmReferralNotes.UtilizationType))
            {
                notvmReferralNotes.UtilizationType = GetReferralUtilizationTypeFromReferralTypeTable(notvmReferralNotes.ReferralNumber);
            }


            if (notvmReferralNotes.UtilizationType.Equals("I"))
            {

                notvmReferralNotes.InpatientUtilizations = GetReferralInpatientUtilizationDaysUsingReferralNumber(notvmReferralNotes.ReferralNumber);

                if (notvmReferralNotes.InpatientUtilizations != null)
                {
                    notvmReferralNotes.UmNotes = GetReferralUtilizationInpatientNotesForUtilizationItem(notvmReferralNotes);                   
                }

            }
            else
            {

                notvmReferralNotes.OutpatientUtilizations = GetReferralOutpatientUtilizationDaysUsingReferralNumber(notvmReferralNotes.ReferralNumber);

                if (notvmReferralNotes.OutpatientUtilizations != null)
                {
                    notvmReferralNotes.UmNotes = GetReferralUtilizationOutpatientNotesForUtilizationItem(notvmReferralNotes);
                }

            }

        }







        public ReferralSavingsViewModel InitializeReferralSavings(string strReferralNumber)
        {

            ReferralSavingsViewModel vmRequest = new ReferralSavingsViewModel();

            try
            {

                if (!string.IsNullOrEmpty(strReferralNumber))
                {

                    using (var db = new ICMS2DbContext())
                    {

                        vmRequest = (from refs in db.DbmsMemberReferrals
                                     where refs.referral_number == strReferralNumber
                                     select new ReferralSavingsViewModel
                                     {
                                         ReferralNumber = refs.referral_number,
                                         MemberId = refs.member_id.ToString(),
                                         AuthNumber = refs.auth_number,
                                     }).SingleOrDefault();


                    }

                }


                return vmRequest;

            }
            catch (Exception ex)
            {
                return vmRequest;
            }

        }

        public void InitializeReferralSavingsControls(ref ReferralSavingsViewModel refsavvmReferralSavings)
        {

            try
            {

                refsavvmReferralSavings.UtilizationType = GetReferralUtilizationTypeUsingReferralNumber(refsavvmReferralSavings.ReferralNumber);


                if (string.IsNullOrEmpty(refsavvmReferralSavings.UtilizationType))
                {
                    refsavvmReferralSavings.UtilizationType = GetReferralUtilizationTypeFromReferralTypeTable(refsavvmReferralSavings.ReferralNumber);
                }


                if (refsavvmReferralSavings.UtilizationType.Equals("I"))
                {
                    refsavvmReferralSavings.InpatientUtilizations = GetReferralInpatientUtilizationDaysUsingReferralNumber(refsavvmReferralSavings.ReferralNumber);
                }
                else
                {
                    refsavvmReferralSavings.OutpatientUtilizations = GetReferralOutpatientUtilizationDaysUsingReferralNumber(refsavvmReferralSavings.ReferralNumber);
                }


                if (refsavvmReferralSavings.InpatientUtilizations != null || refsavvmReferralSavings.OutpatientUtilizations != null)
                {
                    refsavvmReferralSavings.ReferralSavings = GetReferralUtilizationSavingsUsingReferralNumber(refsavvmReferralSavings);
                }


                refsavvmReferralSavings.Units = GetSavingsUnits();
                refsavvmReferralSavings.Networks = GetNetworks();

            }
            catch(Exception ex)
            {

            }

        }

        public bool AddReferralSavings(ReferralSavingsViewModel refsavvmToAdd)
        {

            bool Added = false;

            try
            {               

                using (var db = new ICMS2DbContext())
                {

                    rUtilizationSavings rutilsavToAdd = new rUtilizationSavings();

                    DateTime dteNow = DateTime.Now;


                    rutilsavToAdd.referral_number = refsavvmToAdd.ReferralNumber;
                    rutilsavToAdd.member_id = new Guid(refsavvmToAdd.MemberId);
                    rutilsavToAdd.referral_type = refsavvmToAdd.UtilizationType;
                    rutilsavToAdd.line_number = refsavvmToAdd.LineNumber;
                    rutilsavToAdd.item_description = refsavvmToAdd.SavingsDescription;
                    rutilsavToAdd.saving_units_id = refsavvmToAdd.SavingsUnitId;
                    rutilsavToAdd.quantity = refsavvmToAdd.SavingsQuantity;
                    rutilsavToAdd.cost = refsavvmToAdd.SavingsCost;
                    rutilsavToAdd.negotiated = refsavvmToAdd.SavingsNegotiatedPerUnit;
                    rutilsavToAdd.savings = refsavvmToAdd.SavingsPerUnit;
                    rutilsavToAdd.dollar_or_percent = refsavvmToAdd.SavingsDollarOrPercent;
                    rutilsavToAdd.line_item = refsavvmToAdd.SavingsLineItem;
                    rutilsavToAdd.cpt_code = refsavvmToAdd.SavingsCptCode;
                    rutilsavToAdd.network_id = refsavvmToAdd.SavingsNetworkId;
                    rutilsavToAdd.system_user_id = refsavvmToAdd.UserId;
                    rutilsavToAdd.date_updated = dteNow;


                    //add the savings item to the utiliztion savings context
                    db.DbmsUtilizationSavings.Add(rutilsavToAdd);

                    int updatesreturned = db.SaveChanges();

                    if (updatesreturned.CompareTo(0) > 0)
                    {
                        Added = true;
                    }

                }


                return Added;

            }
            catch(Exception ex)
            {
                return Added;
            }

        }








        public bool AddReferralMedicalCode(MedicalCodeSearchViewModel vmCodeToAdd)
        {

            bool Added = false;

            try
            {

                if (vmCodeToAdd.DiagnosisCodeSearch)
                {
                    Added = AddReferralDiagnosisCode(vmCodeToAdd);
                }
                else if (vmCodeToAdd.CptCodeSearch)
                {
                    Added = AddReferralCptCode(vmCodeToAdd);
                }
                else if (vmCodeToAdd.HcpcsCodeSearch)
                {
                    Added = AddReferralHcpcsCode(vmCodeToAdd);
                }

                return Added;

            }
            catch(Exception ex)
            {
                return Added;
            }


        }

        private bool AddReferralDiagnosisCode(MedicalCodeSearchViewModel vmCodeToAdd)
        {

            bool DiagAdded = false;

            try
            {

                rMemberReferralDiags memRefDiag = new rMemberReferralDiags();

                memRefDiag.diagnosis_or_procedure_code = vmCodeToAdd.Code;
                memRefDiag.referral_number = vmCodeToAdd.ReferralNumber;
                memRefDiag.member_id = new Guid(vmCodeToAdd.MemberId);
                memRefDiag.creation_date = DateTime.Now;
                memRefDiag.creation_user_id = new Guid(vmCodeToAdd.UserId);
                memRefDiag.is_icd_10 = 1;
                memRefDiag.entered_via_web = 1;

                using (var db = new ICMS2DbContext())
                {

                    //add the diag to the referral diagnosis context
                    db.DbmsMemberReferralDiags.Add(memRefDiag);

                    int updatesreturned = db.SaveChanges();

                    if (updatesreturned.CompareTo(0) > 0)
                    {
                        DiagAdded = true;
                    }

                }

                return DiagAdded;

            }
            catch(Exception ex)
            {
                return DiagAdded;
            }

        }

        private bool AddReferralCptCode(MedicalCodeSearchViewModel vmCodeToAdd)
        {

            bool CptAdded = false;

            try
            {
                
                rMemberReferralCpts memRefCpts = new rMemberReferralCpts();

                memRefCpts.cpt_code = vmCodeToAdd.Code;
                memRefCpts.referral_number = vmCodeToAdd.ReferralNumber;
                memRefCpts.member_id = new Guid(vmCodeToAdd.MemberId);
                memRefCpts.creation_date = DateTime.Now;
                memRefCpts.creation_user_id = new Guid(vmCodeToAdd.UserId);
                memRefCpts.is_cpt_15 = 1;
                memRefCpts.entered_via_web = 1;

                using (var db = new ICMS2DbContext())
                {

                    //add the cpt to the referral cpt context
                    db.DbmsMemberReferralCpts.Add(memRefCpts);

                    int updatesreturned = db.SaveChanges();

                    if (updatesreturned.CompareTo(0) > 0)
                    {
                        CptAdded = true;
                    }

                }

                return CptAdded;

            }
            catch (Exception ex)
            {
                return CptAdded;
            }

        }

        private bool AddReferralHcpcsCode(MedicalCodeSearchViewModel vmCodeToAdd)
        {

            bool HcpcsAdded = false;

            try
            {
                
                rMemberReferralHcpcs memRefHcpcs = new rMemberReferralHcpcs();

                memRefHcpcs.hcpcs_code = vmCodeToAdd.Code;
                memRefHcpcs.referral_number = vmCodeToAdd.ReferralNumber;
                memRefHcpcs.member_id = new Guid(vmCodeToAdd.MemberId);
                memRefHcpcs.creation_date = DateTime.Now;
                memRefHcpcs.creation_user_id = new Guid(vmCodeToAdd.UserId);
                memRefHcpcs.is_hcpcs_15 = 1;
                memRefHcpcs.entered_via_web = 1;

                using (var db = new ICMS2DbContext())
                {

                    //add the hcpcs to the referral hcpcs context
                    db.DbmsMemberReferralHcpcs.Add(memRefHcpcs);

                    int updatesreturned = db.SaveChanges();

                    if (updatesreturned.CompareTo(0) > 0)
                    {
                        HcpcsAdded = true;
                    }

                }

                return HcpcsAdded;

            }
            catch (Exception ex)
            {
                return HcpcsAdded;
            }

        }


        public bool RemoveReferralMedicalCode(MedicalCodeSearchViewModel vmCodeToRemove)
        {

            bool Removed = false;

            try
            {

                if (vmCodeToRemove.DiagnosisCodeSearch)
                {
                    Removed = RemoveReferralDiagnosisCode(vmCodeToRemove);
                }
                else if (vmCodeToRemove.CptCodeSearch)
                {
                    Removed = RemoveReferralCptCode(vmCodeToRemove);
                }
                else if (vmCodeToRemove.HcpcsCodeSearch)
                {
                    Removed = RemoveReferralHcpcsCode(vmCodeToRemove);
                }

                return Removed;

            }
            catch (Exception ex)
            {
                return Removed;
            }


        }

        private bool RemoveReferralDiagnosisCode(MedicalCodeSearchViewModel vmCodeToRemove)
        {

            bool DiagRemoved = false;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rMemberReferralDiags memRefDiag = db.DbmsMemberReferralDiags.Find(vmCodeToRemove.SelectedSearchItemCodeId);

                    if (memRefDiag != null)
                    {

                        //remove the diag from the referral diagnosis context
                        db.DbmsMemberReferralDiags.Remove(memRefDiag);

                        int updatesreturned = db.SaveChanges();

                        if (updatesreturned.CompareTo(0) > 0)
                        {
                            DiagRemoved = true;
                        }

                    }

                }

                return DiagRemoved;

            }
            catch (Exception ex)
            {
                return DiagRemoved;
            }

        }

        private bool RemoveReferralCptCode(MedicalCodeSearchViewModel vmCodeToRemove)
        {

            bool CptRemoved = false;

            try
            {
                
                using (var db = new ICMS2DbContext())
                {

                    rMemberReferralCpts memRefCpt = db.DbmsMemberReferralCpts.Find(vmCodeToRemove.SelectedSearchItemCodeId);

                    if (memRefCpt != null)
                    {

                        //remove the cpt from the referral cpt context
                        db.DbmsMemberReferralCpts.Remove(memRefCpt);

                        int updatesreturned = db.SaveChanges();

                        if (updatesreturned.CompareTo(0) > 0)
                        {
                            CptRemoved = true;
                        }

                    }

                }

                return CptRemoved;

            }
            catch (Exception ex)
            {
                return CptRemoved;
            }

        }

        private bool RemoveReferralHcpcsCode(MedicalCodeSearchViewModel vmCodeToRemove)
        {

            bool HcpcsRemoved = false;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rMemberReferralHcpcs memRefHcpcs = db.DbmsMemberReferralHcpcs.Find(vmCodeToRemove.SelectedSearchItemCodeId);

                    if (memRefHcpcs != null)
                    {
                        //remove the diag from the referral diagnosis context
                        db.DbmsMemberReferralHcpcs.Remove(memRefHcpcs);

                        int updatesreturned = db.SaveChanges();

                        if (updatesreturned.CompareTo(0) > 0)
                        {
                            HcpcsRemoved = true;
                        }

                    }

                }

                return HcpcsRemoved;

            }
            catch (Exception ex)
            {
                return HcpcsRemoved;
            }

        }






        public List<ReferralViewModel> GenerateNewAuthNumber(string RefNum)
        {

            var refsToReturn = new List<ReferralViewModel>();

            try
            {

                if (!string.IsNullOrEmpty(RefNum))
                {

                    ReferralViewModel vmAuthNum = new ReferralViewModel();

                    vmAuthNum.AuthNumber = CreateNewAuthNumber();

                    if (!string.IsNullOrEmpty(vmAuthNum.AuthNumber))
                    {

                        if (UpdateReferralWithNewAuthNumber(RefNum, vmAuthNum.AuthNumber))
                        {
                            refsToReturn.Add(vmAuthNum);
                        }

                    }

                }
                

                return (refsToReturn);

            }
            catch(Exception ex)
            {
                return (refsToReturn);
            }

        }

        private string CreateNewAuthNumber()
        {

            string strAuthNumber = "TEST1234";

            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);


                SqlCommand sqlcmd = new SqlCommand("GenAuthNum", conn);


                sqlcmd.CommandText = "GenAuthNum";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Connection = conn;

                Guid guid = new Guid("8C4AA16B-75FE-11D3-A7EE-00500499C350");
                sqlcmd.Parameters.Add("@callerid", SqlDbType.UniqueIdentifier).Value = guid;


                conn.Open();

                strAuthNumber = Convert.ToString(sqlcmd.ExecuteScalar());

                sqlcmd.Connection.Close();


                return strAuthNumber;


            }
            catch(Exception ex)
            {
                return strAuthNumber;
            }

        }

        private bool UpdateReferralWithNewAuthNumber(string RefNum, string AuthNum)
        {

            bool Updated = false;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rMemberReferral refToUpdate = (from memref in db.DbmsMemberReferrals
                                                   where memref.referral_number == RefNum
                                                   select memref)
                                                   .SingleOrDefault();

                    if (refToUpdate != null)
                    {

                        refToUpdate.auth_number = AuthNum;


                        db.Entry(refToUpdate).State = EntityState.Modified;

                        //update the model (IcmsMember) in the database
                        int updatesreturned = db.SaveChanges();


                        if (updatesreturned.CompareTo(0) > 0)
                        {
                            Updated = true;
                        }

                    }

                }

                return Updated;

            }
            catch(Exception ex)
            {
                return Updated;
            }

        }






        public List<UtilizationInpatientDayViewModel> SaveInpatientReferralAuthDates(UtilizationInpatientDayViewModel vmFromUtilization)
        {

            var utilsToReturn = new List<UtilizationInpatientDayViewModel>();

            try
            {
                

                if (!string.IsNullOrEmpty(vmFromUtilization.ReferralNumber))
                {

                    if (!string.IsNullOrEmpty(vmFromUtilization.AuthStartDate.ToString()) || !string.IsNullOrEmpty(vmFromUtilization.AuthEndDate.ToString()))
                    {


                        using (var db = new ICMS2DbContext())
                        {

                            rMemberReferral refToUpdate = (from memref in db.DbmsMemberReferrals
                                                           where memref.referral_number == vmFromUtilization.ReferralNumber
                                                           select memref)
                                                           .SingleOrDefault();


                            refToUpdate.auth_end_date = vmFromUtilization.AuthEndDate;
                            refToUpdate.auth_start_date = vmFromUtilization.AuthStartDate;

                            db.Entry(refToUpdate).State = EntityState.Modified;

                            //update the model (IcmsMember) in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {

                                UtilizationInpatientDayViewModel vmToReturn = new UtilizationInpatientDayViewModel();

                                vmToReturn.ReferralNumber = refToUpdate.referral_number;
                                vmToReturn.AuthStartDate = refToUpdate.auth_start_date;
                                vmToReturn.AuthEndDate = refToUpdate.auth_end_date;

                                utilsToReturn.Add(vmToReturn);

                            }

                        }

                    }

                }


                return (utilsToReturn);

            }
            catch (Exception ex)
            {
                return (utilsToReturn);
            }

        }

        public List<UtilizationOutpatientDayViewModel> SaveOutpatientReferralAuthDates(UtilizationOutpatientDayViewModel vmFromUtilization)
        {

            var utilsToReturn = new List<UtilizationOutpatientDayViewModel>();

            try
            {


                if (!string.IsNullOrEmpty(vmFromUtilization.ReferralNumber))
                {

                    if (!string.IsNullOrEmpty(vmFromUtilization.AuthStartDate.ToString()) || !string.IsNullOrEmpty(vmFromUtilization.AuthEndDate.ToString()))
                    {


                        using (var db = new ICMS2DbContext())
                        {

                            rMemberReferral refToUpdate = (from memref in db.DbmsMemberReferrals
                                                           where memref.referral_number == vmFromUtilization.ReferralNumber
                                                           select memref)
                                                           .SingleOrDefault();


                            refToUpdate.auth_end_date = vmFromUtilization.AuthEndDate;
                            refToUpdate.auth_start_date = vmFromUtilization.AuthStartDate;

                            db.Entry(refToUpdate).State = EntityState.Modified;

                            //update the model (IcmsMember) in the database
                            int updatesreturned = db.SaveChanges();


                            if (updatesreturned.CompareTo(0) > 0)
                            {

                                UtilizationOutpatientDayViewModel vmToReturn = new UtilizationOutpatientDayViewModel();

                                vmToReturn.ReferralNumber = refToUpdate.referral_number;
                                vmToReturn.AuthStartDate = refToUpdate.auth_start_date;
                                vmToReturn.AuthEndDate = refToUpdate.auth_end_date;

                                utilsToReturn.Add(vmToReturn);

                            }

                        }

                    }

                }


                return (utilsToReturn);

            }
            catch (Exception ex)
            {
                return (utilsToReturn);
            }

        }

        public List<UtilizationInpatientDayViewModel> AddReferralInpatientUtilization(UtilizationInpatientDayViewModel vmFromUtilization)
        {

            var utilsToReturn = new List<UtilizationInpatientDayViewModel>();

            try
            {


                if (!string.IsNullOrEmpty(vmFromUtilization.ReferralNumber))
                {


                    int intLineNumber = 1;

                    intLineNumber = GetInpatientReferralUtilizationNextLineNumber(vmFromUtilization);


                    int intNumDays = 0;
                    double dblNumDays = 0;

                    if (vmFromUtilization.next_review_date != null && vmFromUtilization.start_date != null)
                    {
                        dblNumDays = (Convert.ToDateTime(vmFromUtilization.next_review_date) - Convert.ToDateTime(vmFromUtilization.start_date)).TotalDays;
                        intNumDays = Convert.ToInt32(dblNumDays);
                    }



                    rUtilizationDays refUtil = new rUtilizationDays();

                    refUtil.member_id = new Guid(vmFromUtilization.MemberId);
                    refUtil.referral_number  = vmFromUtilization.ReferralNumber;
                    refUtil.line_number = intLineNumber;
                    refUtil.referral_type = vmFromUtilization.InpatientOutpatientType;
                    refUtil.type_id = vmFromUtilization.bed_type_id;
                    refUtil.surgery_flag = vmFromUtilization.surgery_flag;
                    refUtil.surgery_on_first_day_flag = vmFromUtilization.surgery_on_first_day_flag;
                    refUtil.start_date = vmFromUtilization.start_date;
                    refUtil.next_review_date = vmFromUtilization.next_review_date;
                    refUtil.number_of_days = intNumDays;
                    refUtil.util_decision_id = vmFromUtilization.util_decision_id;
                    refUtil.denial_reason_id = vmFromUtilization.denial_reason_id;
                    refUtil.Date_Created = DateTime.Now;


                    using (var db = new ICMS2DbContext())
                    {

                        //add the utilization to the utilization days context
                        db.DbmsUtilizationDays.Add(refUtil);

                        int updatesreturned = db.SaveChanges();

                        if (updatesreturned.CompareTo(0) > 0)
                        {


                            //add utilization review
                            if (vmFromUtilization.review_type_items_id.Value.CompareTo(0) > 0)
                            {

                                vmFromUtilization.line_number = refUtil.line_number;

                                AddInpatientReferralUtilizationReview(vmFromUtilization);

                            }


                            utilsToReturn.Add(vmFromUtilization);

                        }

                    }

                }


                return (utilsToReturn);

            }
            catch (Exception ex)
            {
                return (utilsToReturn);
            }

        }

        public List<UtilizationOutpatientDayViewModel> AddReferralOutpatientUtilization(UtilizationOutpatientDayViewModel vmFromUtilization)
        {

            var utilsToReturn = new List<UtilizationOutpatientDayViewModel>();

            try
            {


                if (!string.IsNullOrEmpty(vmFromUtilization.ReferralNumber))
                {


                    int intLineNumber = 1;

                    intLineNumber = GetOutpatientReferralUtilizationNextLineNumber(vmFromUtilization);


                    rUtilizationDays refUtil = new rUtilizationDays();

                    refUtil.member_id = new Guid(vmFromUtilization.MemberId);
                    refUtil.referral_number = vmFromUtilization.ReferralNumber;
                    refUtil.line_number = intLineNumber;
                    refUtil.referral_type = vmFromUtilization.InpatientOutpatientType;
                    refUtil.visits_authorized_end_date = vmFromUtilization.visits_authorized_end_date;
                    refUtil.visits_authorized_start_date = vmFromUtilization.visits_authorized_start_date;
                    refUtil.visits_num_periods_authorized = vmFromUtilization.visits_num_periods_authorized;
                    refUtil.visits_num_periods_requested = vmFromUtilization.visits_num_periods_requested;
                    refUtil.visits_num_per_period_authorized = vmFromUtilization.visits_num_per_period_authorized;
                    refUtil.visits_num_per_period_requested = vmFromUtilization.visits_num_per_period_requested;
                    refUtil.visits_period_authorized = vmFromUtilization.visits_period_authorized;
                    refUtil.visits_period_requested = vmFromUtilization.visits_period_requested;
                    refUtil.visits_recurring_flag = vmFromUtilization.visits_recurring_flag;
                    refUtil.util_decision_id = vmFromUtilization.util_decision_id;
                    refUtil.denial_reason_id = vmFromUtilization.denial_reason_id;
                    refUtil.Date_Created = DateTime.Now;


                    using (var db = new ICMS2DbContext())
                    {

                        //add the utilization to the utilization days context
                        db.DbmsUtilizationDays.Add(refUtil);

                        int updatesreturned = db.SaveChanges();

                        if (updatesreturned.CompareTo(0) > 0)
                        {

                            //add utilization review
                            if (vmFromUtilization.review_type_items_id.Value.CompareTo(0) > 0)
                            {

                                vmFromUtilization.line_number = refUtil.line_number;

                                AddOutpatientReferralUtilizationReview(vmFromUtilization);

                            }


                            utilsToReturn.Add(vmFromUtilization);

                        }

                    }

                }


                return (utilsToReturn);

            }
            catch (Exception ex)
            {
                return (utilsToReturn);
            }

        }

        private void AddInpatientReferralUtilizationReview(UtilizationInpatientDayViewModel vmFromUtilization)
        {

            try
            {


                rUtilizationReviews refrev = new rUtilizationReviews();

                refrev.member_id = new Guid(vmFromUtilization.MemberId);
                refrev.referral_number = vmFromUtilization.ReferralNumber;
                refrev.line_number = vmFromUtilization.line_number;
                refrev.review_type_items_id = vmFromUtilization.review_type_items_id;
                refrev.denial_reason_id = vmFromUtilization.denial_reason_id;
                refrev.util_decision_id = vmFromUtilization.util_decision_id;                
                refrev.creation_date = DateTime.Now;
                refrev.created_user_id = new Guid(vmFromUtilization.SystemUserId);


                using (var db = new ICMS2DbContext())
                {

                    //add the review to the utilization reviews context
                    db.DbmsUtilizationReviews.Add(refrev);

                    int updatesreturned = db.SaveChanges();

                }


            }
            catch(Exception ex)
            {

            }

        }

        private void AddOutpatientReferralUtilizationReview(UtilizationOutpatientDayViewModel vmFromUtilization)
        {
            
            try
            {


                rUtilizationReviews refrev = new rUtilizationReviews();

                refrev.member_id = new Guid(vmFromUtilization.MemberId);
                refrev.referral_number = vmFromUtilization.ReferralNumber;
                refrev.line_number = vmFromUtilization.line_number;
                refrev.review_type_items_id = vmFromUtilization.review_type_items_id;
                refrev.denial_reason_id = vmFromUtilization.denial_reason_id;
                refrev.util_decision_id = vmFromUtilization.util_decision_id;
                refrev.creation_date = DateTime.Now;
                refrev.created_user_id = new Guid(vmFromUtilization.SystemUserId);


                using (var db = new ICMS2DbContext())
                {

                    //add the review to the utilization reviews context
                    db.DbmsUtilizationReviews.Add(refrev);

                    int updatesreturned = db.SaveChanges();

                }


            }
            catch (Exception ex)
            {

            }

        }


        public bool RemoveInpatientUtilizationFromReferral(UtilizationInpatientDayViewModel vmUtilizationToRemove)
        {
            bool InpatUtilRemoved = false;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rUtilizationDays utilday = (from rutils in db.DbmsUtilizationDays
                                                where rutils.referral_number == vmUtilizationToRemove.ReferralNumber
                                                && rutils.referral_type == vmUtilizationToRemove.InpatientOutpatientType
                                                && rutils.line_number == vmUtilizationToRemove.LineNumber
                                                select rutils)
                                                .SingleOrDefault();


                    if (utilday != null)
                    {

                        utilday.removed = true;
                        utilday.removed_date = DateTime.Now;
                        utilday.removed_user_id = new Guid(vmUtilizationToRemove.SystemUserId);


                        db.Entry(utilday).State = EntityState.Modified;

                        //update the model (rUtilizationDays) in the database
                        int updatesreturned = db.SaveChanges();


                        if (updatesreturned.CompareTo(0) > 0)
                        {
                            InpatUtilRemoved = true;
                        }

                    }

                }


                return InpatUtilRemoved;

            }
            catch(Exception ex)
            {
                return InpatUtilRemoved;
            }

        }

        public bool RemoveOutpatientUtilizationFromReferral(UtilizationOutpatientDayViewModel vmUtilizationToRemove)
        {
            bool OutpatUtilRemoved = false;

            try
            {

                using (var db = new ICMS2DbContext())
                {

                    rUtilizationDays utilday = (from rutils in db.DbmsUtilizationDays
                                                where rutils.referral_number == vmUtilizationToRemove.ReferralNumber
                                                && rutils.referral_type == vmUtilizationToRemove.InpatientOutpatientType
                                                && rutils.line_number == vmUtilizationToRemove.LineNumber
                                                select rutils)
                                                .SingleOrDefault();


                    if (utilday != null)
                    {

                        utilday.removed = true;
                        utilday.removed_date = DateTime.Now;
                        utilday.removed_user_id = new Guid(vmUtilizationToRemove.SystemUserId);


                        db.Entry(utilday).State = EntityState.Modified;

                        //update the model (rUtilizationDays) in the database
                        int updatesreturned = db.SaveChanges();


                        if (updatesreturned.CompareTo(0) > 0)
                        {
                            OutpatUtilRemoved = true;
                        }

                    }

                }


                return OutpatUtilRemoved;

            }
            catch (Exception ex)
            {
                return OutpatUtilRemoved;
            }

        }

    }
}