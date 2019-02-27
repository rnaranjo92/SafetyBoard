using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafetyBoard.Controllers
{
    public class InspectionsController : Controller
    {
        // GET: Inspections
        public ActionResult Index()
        {
            return View();
        }
    }
}