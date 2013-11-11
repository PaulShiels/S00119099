using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CA1.Controllers
{
    public class HomeController : Controller
    {
        MusicDBDataContext db = new MusicDBDataContext();
        //
        // GET: /Home/
        [AllowAnonymous]
        public ActionResult Index(string searchTerm, string sortBy)
        {
            //ViewBag.Title = "List of Orders";
            //var q = from o in db.Orders
            //        select o;
            //new
            //return View(q);
           
            if (sortBy == "size")
            {
                var size = db.Orders
                    .OrderByDescending(o => o.Total);
                           //join od in db.OrderDetails on o.OrderId equals od.OrderId
                           //select o;
                return View(size);
            }
             else if(sortBy == "date")
            {
                var sortbydate = db.Orders
                    .OrderBy(o => o.OrderDate);
                return View(sortbydate);
            }
            else
            {
                var allOrders = db.Orders
                    .Where(ord => searchTerm == null || ord.FirstName.Contains(searchTerm))
                    .OrderBy(a => a.FirstName);
                return View(allOrders);
            }

        }


        //
        // GET: /Home/Details/5
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
        // GET: /Home/Edit/5
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
        // POST: /Home/Edit/5
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
        // GET: /Home/Delete/5
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
        // POST: /Home/Delete/5
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
