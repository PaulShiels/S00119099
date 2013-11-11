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
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View("UnderDev");
            }
        }

        //
        // GET: /Album/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View("UnderDev");
            }
        }

        //
        // POST: /Album/Create
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View("UnderDev");
            }
        }

        //
        // GET: /Album/Edit/5
        [AllowAnonymous]
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View("UnderDev");
            }
        }

        //
        // POST: /Album/Edit/5
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View("UnderDev");
            }
        }

        //
        // GET: /Album/Delete/5
        [AllowAnonymous]
        public ActionResult Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View("UnderDev");
            }
        }

        //
        // POST: /Album/Delete/5
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View("UnderDev");
            }
        }
    }
}
