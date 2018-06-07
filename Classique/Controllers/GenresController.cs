using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Classique.Models;

namespace Classique.Controllers
{
    public class GenresController : Controller
    {
        private Classique_Web_2017Entities db = new Classique_Web_2017Entities();

        // GET: Genres
        public ActionResult Index()
        {
            return View(db.Genre.ToList());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Albums = getAlbums(genre);
            }

            return View(genre);
        }

        public List<Album> getAlbums(Genre genre)
        {

            var albums = (from a in db.Album
                          where a.Code_Genre == genre.Code_Genre
                          select a);
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
