using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Classique.Models;

namespace Classique.Controllers
{
    public class PanierController : Controller
    {
        private Classique_WebEntities1 db = new Classique_WebEntities1();
        List<Item> panier;

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Addtopanier(int id, string url)
        {
            if (url != null)
            {
                Session["url"] = url;
            }
            
            if (Session["panier"] == null)
            {
                panier = new List<Item>();
            }
            else
            {
                panier = (List<Item>)Session["panier"];    
            }
            panier.Add(new Item(db.Enregistrement.Find(id), 1));
            Session["panier"] = panier;
            return View("Index");
        }
    }
}