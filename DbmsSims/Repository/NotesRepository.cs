using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbmsSims.Models.ICMS2;
using DbmsSims.Models.ICMS2.ViewModels;
using System.Text;

namespace DbmsSims.Repository
{
    public class NotesRepository
    {


        public List<NotesViewModel> GetAllMemberNotesByNoteTypeAndMemberId(string type, string id)
        {

            var notes = new List<NotesViewModel>();


            switch(type)
            {

                case "Member":
                    notes = GetAllMemberNotesByMemberId(id);
                    break;

                case "UM":
                    notes = GetAllUmNotesByMemberId(id);
                    break;

                case "DM":
                    notes = GetAllDmNotesByMemberId(id);
                    break;

                case "STD":
                    notes = GetAllStdNotesByMemberId(id);
                    break;

                case "Client":
                    notes = GetAllClientNotesByMemberId(id);
                    break; 

                case "Wellness":
                    notes = GetAllWellnessNotesByMemberId(id);
                    break;

                case "Patient":
                    notes = GetAllPatientNotesByMemberId(id);
                    break;

                case "Radiology":
                    notes = GetAllRadiologyNotesByMemberId(id);
                    break;

                case "Labs":
                    notes = GetAllLabsNotesByMemberId(id);
                    break;

                case "Care":
                    notes = GetAllCareNotesByMemberId(id);
                    break;

            }


            return (notes);

        }



        public List<NotesViewModel> GetAllMemberNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();
           

            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }              

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllUmNotesByMemberId(string id)

        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsUtilizationDayNotes
                                    where notes.member_id == new Guid(id)
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsUtilizationDayNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }


            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllDmNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    && notes.lcn == true
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllStdNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    && notes.std_note == true
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllClientNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    && notes.web_client_note == true
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllWellnessNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    && notes.telephone == true
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllPatientNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    && notes.internal_patient == true
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllRadiologyNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    && notes.radiology == true
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllLabsNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    && notes.lab == true
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }


        public List<NotesViewModel> GetAllCareNotesByMemberId(string id)
        {

            var notesToReturn = new List<NotesViewModel>();


            using (var db = new ICMS2DbContext())
            {

                var individNotesList = new List<NotesViewModel>();


                //Get each note's record_date, billing_id, and rn_notes
                individNotesList = (from notes in db.DbmsMemberNotes
                                    where notes.member_id == new Guid(id)
                                    && notes.care_plan_note == true
                                    select new NotesViewModel
                                    {
                                        RecordDate = notes.record_date,
                                        BillingId = notes.billing_id,
                                        BillingMinutes = notes.RN_notes
                                    }
                                    ).Distinct().ToList();


                //Go through each note and retrieve the note's evaluation_text and record_seq_num
                foreach (NotesViewModel getnotetext in individNotesList)
                {


                    var individNoteTextList = new List<NotesViewModel>();
                    StringBuilder evaltext = new StringBuilder();


                    individNoteTextList = (from notes in db.DbmsMemberNotes
                                           where notes.member_id == new Guid(id)
                                           && notes.record_date == getnotetext.RecordDate
                                           orderby notes.record_seq_num
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

                    addnote.RecordDate = getnotetext.RecordDate;
                    addnote.BillingId = getnotetext.BillingId;
                    addnote.BillingMinutes = getnotetext.BillingMinutes;
                    addnote.NoteText = evaltext.ToString();

                    notesToReturn.Add(addnote);

                }

            }



            return (notesToReturn.OrderByDescending(m => m.RecordDate).ToList());

        }






        public List<BillingCodes> GetLcmBillingCodes()
        {

            var codes = new List<BillingCodes>();

            using (var db = new ICMS2DbContext())
            {

                codes = (from billcodes in db.DbmsLcmBillingCodes
                         orderby billcodes.billing_description
                         select billcodes).ToList();

            }

            return (codes);

        }


        public List<Minutes> GetBillingMinutes()
        {

            var minutes = new List<Minutes>();


            for(int i = 0; i <= 180; i++)
            {

                var addminute = new Minutes();


                if (i == 60)
                {
                    addminute.MinuteDisplay = "1 hr";
                }
                else if (i == 120)
                {
                    addminute.MinuteDisplay = "2 hrs";
                }
                else if (i == 180)
                {
                    addminute.MinuteDisplay = "3 hrs";
                }
                else
                {                    
                    addminute.MinuteDisplay = i.ToString() + " mins";
                }


                addminute.BillMinutes = i;

                minutes.Add(addminute);

            }


            return minutes;

        }





        public bool InsertUmNote(NotesViewModel noteToInsert)
        {

            bool Inserted = false;

            try
            {

                double dblFullNoteLength = 512.0;

                Guid guidMemberId = new Guid(noteToInsert.MemberId);
                DateTime dteNow = DateTime.Now;
                string strNote = noteToInsert.NoteText;
                int? intBillingId = noteToInsert.BillingId;
                int? intBillingMinutes = noteToInsert.BillingMinutes;
                bool blnOnLetter = noteToInsert.OnLetter;
                string strReferralNumber = noteToInsert.ReferralNumber;
                string strUtilizationType = noteToInsert.UtilizationType;
                int intUtilizationLineNumber = noteToInsert.LineNumber;
                Guid guidEnteredById = noteToInsert.UserId;


                double dblLengthOfNote = strNote.Length;


                if (dblLengthOfNote <= dblFullNoteLength)
                {
                    Inserted = ProcessInsertNote("UM", 1, guidMemberId, dteNow, strNote, guidEnteredById, intBillingId, intBillingMinutes, blnOnLetter,
                                                 strReferralNumber, strUtilizationType, intUtilizationLineNumber);
                }
                else
                {

                    double dblLineNumbers = dblLengthOfNote / dblFullNoteLength;

                    int intLineNumbers = Convert.ToInt32(dblLineNumbers);


                    for (int i = 0; i < intLineNumbers; i++)
                    {

                        int intStart = Convert.ToInt32(i * dblFullNoteLength + 1);


                        if (intStart > dblFullNoteLength)
                        {

                            double dblRemainingLength = dblLengthOfNote - intStart;

                            strNote = strNote.Substring(intStart, Convert.ToInt32(dblRemainingLength));

                        }
                        else
                        {
                            strNote = strNote.Substring(intStart, Convert.ToInt32(dblFullNoteLength));
                        }


                        Inserted = ProcessInsertNote("UM", i + 1, guidMemberId, dteNow, strNote, guidEnteredById, intBillingId, intBillingMinutes,
                                                     blnOnLetter, strReferralNumber, strUtilizationType, intUtilizationLineNumber);

                    }

                }


                return Inserted;

            }
            catch(Exception ex)
            {
                return Inserted;
            }

        }




        private bool ProcessInsertNote(string NoteType, int SequenceNumber, Guid MemberId, DateTime DateEntered, string NoteText, Guid EnteredById, 
                                       int? BillingId, int? BillingMinutes, bool OnLetter, string ReferralNumber, string UtilizationType, 
                                       int UtilizationLineNumber)
        {
            bool Inserted = false;

            try
            {

                switch (NoteType)
                {

                    case "UM":

                        rUtilizationDayNotes rudnoteNoteToAdd = new rUtilizationDayNotes();
                        
                        rudnoteNoteToAdd.record_seq_num = SequenceNumber;
                        rudnoteNoteToAdd.member_id = MemberId;
                        rudnoteNoteToAdd.record_date = DateEntered;
                        rudnoteNoteToAdd.evaluation_text = NoteText;
                        rudnoteNoteToAdd.system_user_id = EnteredById;
                        rudnoteNoteToAdd.billing_id = BillingId;
                        rudnoteNoteToAdd.RN_notes = BillingMinutes;
                        rudnoteNoteToAdd.onletter = OnLetter;
                        rudnoteNoteToAdd.referral_number = ReferralNumber;
                        rudnoteNoteToAdd.referral_type = UtilizationType;
                        rudnoteNoteToAdd.line_number = UtilizationLineNumber;


                        using (var db = new ICMS2DbContext())
                        {
                            //add the um note to the um note context
                            db.DbmsUtilizationDayNotes.Add(rudnoteNoteToAdd);

                            int updatesreturned = db.SaveChanges();

                            if (updatesreturned.CompareTo(0) > 0)
                            {
                                Inserted = true;
                            }

                        }

                        break;

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