using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbmsSims.Models.ICMS2;

namespace DbmsSims.Repository 
{

   
    public class EmployerRepository
    {


        private ICMS2DbContext _IcmsDb = new ICMS2DbContext();


        public List<Employer> GetAllEmployersThatAreActive()
        {

            var employers = new List<Employer>();


            using (var db = new ICMS2DbContext())
            {

                employers = (from emply in db.DbmsEmployers
                             join tpaemply in db.DbmsTpaEmployer on emply.employer_id equals tpaemply.employer_id
                             where tpaemply.termination_date == null &&
                             (emply.employer_name != null && emply.employer_name != "")
                             orderby emply.employer_name
                             select emply)
                         .ToList();

            }
 

            return (employers);

        }

        public ClientBuEmployer GetEmployerClient(int employerid)
        {

            ClientBuEmployer clntbuemply = new ClientBuEmployer();


            using (var db = new ICMS2DbContext())
            {
                clntbuemply = (from clientbuemploy in db.DbmsClientBuEmployer
                               where clientbuemploy.employer_id == employerid
                               select clientbuemploy)
                               .SingleOrDefault();

            }


            return clntbuemply;

        }

        public ClientBu GetClientBuClaimSystemId(int clientbuid)
        {

            ClientBu clntbu = new ClientBu();


            using (var db = new ICMS2DbContext())
            {

                clntbu = (from clientbu in db.DbmsClientBu
                          where clientbu.client_bu_id == clientbuid
                          select clientbu)
                          .SingleOrDefault();

            }


            return clntbu;

        }

        public string GetTpaNameUsingTpaId(int TpaId)
        {

            string TpaName = "";

            try
            {

                if (TpaId.CompareTo(0) > 0)
                {

                    using (var db = new ICMS2DbContext())
                    {
                        TpaName = (from tpas in db.DbmsTpas
                                   where tpas.tpa_id == TpaId
                                   select tpas.tpa_name).SingleOrDefault();
                    }

                }

                return TpaName;
            }
            catch(Exception ex)
            {
                return TpaName;
            }

        }


    }






}