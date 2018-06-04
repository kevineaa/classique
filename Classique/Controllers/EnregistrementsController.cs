using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Classique.Models;
using PagedList;

namespace Classique.Controllers
{
    public class EnregistrementsController : Controller
    {
        private Classique_WebEntities1 db = new Classique_WebEntities1();

        // GET: Enregistrements
        public ActionResult Index(string searchString, string currentFilter, string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DurationSortParm = String.IsNullOrEmpty(sortOrder) ? "duration_desc" : "";

            var enregistrement = db.Enregistrement.Include(e => e.Composition);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            if (!String.IsNullOrEmpty(searchString))
            {
                enregistrement = db.Enregistrement.Include(e => e.Composition).Where(c => c.Titre.StartsWith(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    enregistrement = enregistrement.OrderByDescending(s => s.Nom_de_Fichier);
                    break;
                case "duration_desc":
                    enregistrement = enregistrement.OrderByDescending(s => s.Durée_Seconde);
                    break;
                default:
                    enregistrement = enregistrement.OrderBy(s => s.Nom_de_Fichier);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(enregistrement.ToPagedList(pageNumber, pageSize));
        }

        // GET: Enregistrements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enregistrement enregistrement = db.Enregistrement.Find(id);
            if (enregistrement == null)
            {
                return HttpNotFound();
            }
            return View(enregistrement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
