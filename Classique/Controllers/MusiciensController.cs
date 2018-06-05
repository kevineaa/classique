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

    // Controller Class
    public class MusiciensController : Controller
    {
        private Classique_Web_2017Entities db = new Classique_Web_2017Entities();

        // GET: Musiciens
        public ActionResult Index(string searchString, string currentFilter, string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.BirthDateSortParm = sortOrder == "Date" ? "année_naissance_desc" : "Date";
            ViewBag.DeathDateSortParm = sortOrder == "Date" ? "année_mort_desc" : "Date";

            var compositeurs = db.Musicien.Include(c => c.Composer);

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
                compositeurs = db.Musicien.Include(c => c.Composer).Where(c => c.Nom_Musicien.StartsWith(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    compositeurs = compositeurs.OrderByDescending(s => s.Nom_Musicien);
                    break;
                case "firstname_desc":
                    compositeurs = compositeurs.OrderByDescending(s => s.Prenom_Musicien);
                    break;
                case "annee_naissance_desc":
                    compositeurs = compositeurs.OrderByDescending(s => s.Annee_Naissance);
                    break;
                case "annee_mort_desc":
                    compositeurs = compositeurs.OrderByDescending(s => s.Annee_Mort);
                    break;
                default:
                    compositeurs = compositeurs.OrderBy(s => s.Nom_Musicien);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(compositeurs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Musiciens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicien musicien = db.Musicien.Find(id);
            if (musicien == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Albums = getAlbums(musicien);
            }
            return View(musicien);
        }

        public List<Album> getAlbums(Musicien musicien)
        {   

            var albums = (from a in db.Album
                          join d in db.Disque on a.Code_Album equals d.Code_Album
                          join c in db.Composition_Disque on d.Code_Disque equals c.Code_Disque
                          join e in db.Enregistrement on c.Code_Morceau equals e.Code_Morceau
                          join m in db.Composition on e.Code_Composition equals m.Code_Composition
                          join co in db.Composition_Oeuvre on m.Code_Composition equals co.Code_Composition
                          join o in db.Oeuvre on co.Code_Oeuvre equals o.Code_Oeuvre
                          join comp in db.Composer on o.Code_Oeuvre equals comp.Code_Oeuvre
                          join mu in db.Musicien on comp.Code_Musicien equals mu.Code_Musicien
                          where mu.Code_Musicien == musicien.Code_Musicien
                          select a).Distinct();
            return albums.ToList();
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
