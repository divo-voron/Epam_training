using Sales.MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.MVCClient.Controllers
{
    public class ManagersController : Controller
    {
        BL.Handler handler;
        MVCMapper mapper;
        const int pageSize = 3; // количество объектов на страницу

        public ManagersController()
        {
            handler = new BL.Handler();
            mapper = new MVCMapper();
        }

        // GET: Managers
        public ActionResult Index(int pageNumber = 1)
        {
            IEnumerable<Manager> managersPerPages = handler.GetManagerPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x));
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = handler.Managers.Count()
            };
            IndexViewModelPagination ivmp = new IndexViewModelPagination
            {
                PageInfo = pageInfo,
                ManagersPerPages = managersPerPages
            };
            return View(ivmp);
        }

        // GET: Managers/Details/5
        public ActionResult Details(int id)
        {
            var manager = handler.Managers.FirstOrDefault(x => x.ID == id);
            if (manager != null)
                return View(mapper.Mapping(manager));
            else
                return View();
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
        [HttpPost]
        public ActionResult Create(Manager manager)
        {
            try
            {
                handler.AddManager(mapper.Mapping(manager));
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
            var manager = handler.Managers.FirstOrDefault(x => x.ID == id);
            if (manager != null)
                return View(mapper.Mapping(manager));
            else
                return View();
        }

        // POST: Managers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Manager manager)
        {
            try
            {
                handler.EditManager(mapper.Mapping(manager));
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
            var manager = handler.Managers.FirstOrDefault(x => x.ID == id);
            if (manager != null)
                return View(mapper.Mapping(manager));
            else
                return View();
        }

        // POST: Managers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Manager manager)
        {
            try
            {
                handler.DeleteManager(mapper.Mapping(manager));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
