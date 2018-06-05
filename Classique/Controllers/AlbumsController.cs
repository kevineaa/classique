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
    public class AlbumsController : Controller
    {
        private Classique_Web_2017Entities db = new Classique_Web_2017Entities();

        // GET: Albums
        public ActionResult Index(string searchString, string currentFilter, string sortOrder, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var albums = db.Album.Include(a => a.Editeur).Include(a => a.Genre);

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
                albums = db.Album.Include(a => a.Editeur).Include(a => a.Genre).Where(c => c.Titre_Album.StartsWith(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    albums = albums.OrderByDescending(s => s.Titre_Album);
                    break;
                case "date_desc":
                    albums = albums.OrderByDescending(s => s.Annee_Album);
                    break;
                default:
                    albums = albums.OrderBy(s => s.Titre_Album);
                    break;
            }

           

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(albums.ToPagedList(pageNumber, pageSize));
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Enregistrements = getEnregistrements(album);
            }
            return View(album);
        }

        public List<Enregistrement> getEnregistrements(Album album)
        {
            var enregistrements = (from e in db.Enregistrement
                          join c in db.Composition_Disque on e.Code_Morceau equals c.Code_Morceau
                          join d in db.Disque on c.Code_Disque equals d.Code_Disque
                          join a in db.Album on d.Code_Album equals a.Code_Album
                          where a.Code_Album == album.Code_Album
                          select e).Distinct();
            return enregistrements.ToList();
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
