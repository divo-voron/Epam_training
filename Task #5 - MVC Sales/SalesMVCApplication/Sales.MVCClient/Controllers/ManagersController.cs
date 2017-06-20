using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.MVCClient.Controllers
{
    public class ManagersController : Controller
    {
        BL.Handler h = new BL.Handler();
        // GET: Managers
        public ActionResult Index()
        {
            return View(h.Method());
        
            //return View();
        }

        // GET: Managers/Details/5
        public ActionResult Details(int id)
        {
            var item = h.Method().FirstOrDefault(x => x.ID == id);
            return PartialView(item);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
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

        // GET: Managers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Managers/Edit/5
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

        // GET: Managers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Managers/Delete/5
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
