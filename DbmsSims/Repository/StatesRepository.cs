using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbmsSims.Models.ICMS2;

namespace DbmsSims.Repository
{
    public class StatesRepository
    {

        private ICMS2DbContext _IcmsDb = new ICMS2DbContext();



        public List<States> GetAllStates()
        {

            var states = new List<States>();


            states = (from statesinusa in _IcmsDb.DbmsStates
                      orderby statesinusa.state_name
                      select statesinusa).ToList();
                                
            return (states);

        }


    }
}