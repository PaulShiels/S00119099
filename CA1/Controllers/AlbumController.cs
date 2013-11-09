using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA1.Controllers
{
    public class AlbumController : Controller
    {
        //
        MusicDBDataContext db = new MusicDBDataContext();
        // GET: /Album/

        [AllowAnonymous]
        public ActionResult Index(int id=0)
        {
            var q = from a in db.Albums
                    select a;
            return View(q);
        }
        public ActionResult Albums(int id=0)
        {
            return View(db.Albums);

        }

        [AllowAnonymous]
        public ActionResult Album(int id, string btnBack)
        {
            if (btnBack == "Back")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (id == 0)
                {
                    return View((db.Albums).OrderBy(a => a.ArtistId));
                }
                else
                {
                    var q = from a in db.Albums
                            join o in db.OrderDetails on a.AlbumId equals o.AlbumId
                            where o.OrderId == id
                            select a;
                    return View(q);
                }
                                
            }

            
        }

        //
        // GET: /Album/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Album/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Album/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
