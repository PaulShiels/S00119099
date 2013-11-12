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
            if (sortBy == "size")
            {
                searchTerm = Request.QueryString["searchTerm"];
                var size = new SearchParamSet();
                size.query = db.Orders
                    .Where(ord => searchTerm == null || ord.FirstName.Contains(searchTerm))
                    .OrderByDescending(o => o.Total);
                size.searchTerm = searchTerm;
                size.sortBy = sortBy;
                return View(size.query);


            }
             else if(sortBy == "date")
            {
                searchTerm = Request.QueryString["searchTerm"];
                var sortbydate = new SearchParamSet();
                sortbydate.query = db.Orders
                    .Where(ord => searchTerm == null || ord.FirstName.Contains(searchTerm))
                    .OrderBy(o => o.OrderDate);
                sortbydate.searchTerm = searchTerm;
                sortbydate.sortBy = sortBy;
                return View(sortbydate.query);
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
