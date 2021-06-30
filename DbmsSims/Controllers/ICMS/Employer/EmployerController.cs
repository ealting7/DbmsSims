using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbmsSims.Models.ICMS2;

namespace DbmsSims.Controllers.ICMS
{
    public class EmployerController : Controller
    {


        private ICMS2DbContext IcmsDb = new ICMS2DbContext();



        // GET: Employer
        public ActionResult Index()
        {
            return View();
        }




    }
}