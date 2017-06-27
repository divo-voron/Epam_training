using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.MVCClient.Models;
using Sales.MVCClient.Models.Pagination;

namespace Sales.MVCClient.Controllers
{
    [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesUser)]
    public class ManagerController : Controller
    {
        BL.Handler handler;
        MVCMapper mapper;
        const int pageSize = 3;

        public ManagerController()
        {
            handler = new BL.Handler(Sales.MVCClient.Helper.MagicString.PathSalesDataBase);
            mapper = new MVCMapper();
        }

        // GET: Managers
        public ActionResult Index(int pageNumber = 1)
        {
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = handler.Managers.Count()
            };
            IndexViewModelPagination ivmp = new IndexViewModelPagination
            {
                PageInfo = pageInfo,
                ManagersPerPages = handler.GetManagerPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x))
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
                return View("Error");
        }

        // GET: Managers/Create
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create(Manager manager)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    handler.AddManager(mapper.Mapping(manager));
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            }
            else
                return View();
        }

        // GET: Managers/Edit/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id)
        {
            var manager = handler.Managers.FirstOrDefault(x => x.ID == id);
            if (manager != null)
                return View(mapper.Mapping(manager));
            else
                return View("Error");
        }

        // POST: Managers/Edit/5
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id, Manager manager)
        {
            if (ModelState.IsValid == true)
                try
                {
                    handler.EditManager(mapper.Mapping(manager));
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            else
                return View(manager);
        }

        // GET: Managers/Delete/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
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
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id, Manager manager)
        {
            try
            {
                handler.DeleteManager(mapper.Mapping(manager));
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
