using CVGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Curriculum.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {

        private CurriculumEntities db = new CurriculumEntities();

        // GET: Reports
        public ActionResult Index()
        {
            ViewBag.Datos = "Datos para el reporte";
            ViewBag.count = db.Curricula.Count();
            return View();
        }

    }
}