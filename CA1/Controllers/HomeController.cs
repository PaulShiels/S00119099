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

        public ActionResult Index(string searchTerm, string sortBy)
        {
            //ViewBag.Title = "List of Orders";
            //var q = from o in db.Orders
            //        select o;
            //return View(q);

            if (sortBy == "size")
            {
                var size = from o in db.Orders
                           join od in db.OrderDetails on o.OrderId equals od.OrderId
                           select o;
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

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

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
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
