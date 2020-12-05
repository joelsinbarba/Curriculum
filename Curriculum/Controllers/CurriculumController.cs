using CVGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVGenerator.Controllers
{
    public class CurriculumController : Controller
    {
        private CurriculumEntities db = new CurriculumEntities();

        public IEnumerable<SelectListItem> Paises { get; set; }

        // GET: Curriculum
        public ActionResult Index()
        {
            var listaCurriculum = db.Curricula.ToList();
            return View(listaCurriculum);
        }

        [Authorize]
        public ActionResult Crear()
        {
            var paises = db.Pais.ToList();
            Paises = GetAllPaises();
            ViewBag.paises = GetAllPaises();
            ViewData["Nacionalidad"] = new SelectList(paises.Select(i => new Pais(i.id, i.descripcion)));
            
            return View(); 
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Curriculum curriculum)
        {
            var paises = db.Pais.ToList();
            Paises = GetAllPaises();
            ViewBag.paises = new SelectList(paises.Select(i => i));
            ViewData["Nacionalidad"] = new SelectList(paises.Select(i => new Pais(i.id,i.descripcion)));
            if (ModelState.IsValid)
            {
                db.Curricula.Add(curriculum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curriculum);
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
         
            Curriculum curriculum = db.Curricula.Find(id);
            if(curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        [Authorize]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curricula.Find(id);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
           
            var paises = db.Pais.ToList();
            Paises = GetAllPaises();
            ViewBag.paises = GetAllPaises();
            ViewData["Nacionalidad"] = new SelectList(paises.Select(i => new Pais(i.id, i.descripcion)));

            curriculum.Paises = new SelectList(paises, "id", "descripcion", curriculum.Pais);

            return View(curriculum);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Curriculum curriculum)
        {
         
            if (ModelState.IsValid)
            {
                curriculum.Pais = db.Pais.First(i => i.id == curriculum.Pais.id);
                curriculum.nacionalidad = curriculum.Pais.id;
                db.Entry(curriculum).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curriculum);
        }

        [Authorize]
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Curriculum curriculum = db.Curricula.Find(id);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            Curriculum curriculum = db.Curricula.Find(id);
            db.Curricula.Remove(curriculum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private IEnumerable<SelectListItem> GetAllPaises()
        {
            IEnumerable<SelectListItem> list = db.Pais.Select(s => new SelectListItem
            {
                Selected = false,
                Text = s.descripcion,
                Value = s.id.ToString()
            });

            return list;
        }
    }
}