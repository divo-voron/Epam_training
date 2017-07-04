using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.MVCClient.Models;
using Sales.MVCClient.Models.Pagination;
using Sales.BL.Interfaces;
using Sales.MVCClient.Helper;
using Sales.BL.Infrastructure;

namespace Sales.MVCClient.Controllers
{
    [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesUser)]
    public class ManagerController : Controller
    {
        Sales.BL.Handler handler;
        IManagerCRUD managerCRUD;
        MVCMapper mapper;
        const int pageSize = 3;

        public ManagerController(IManagerCRUD handlerCRUD)
        {
            handler = new BL.Handler();
            handler.Connect(Sales.MVCClient.Helper.MagicString.PathSalesDataBase);
            managerCRUD = handlerCRUD;
            mapper = new MVCMapper();
        }

        // GET: Managers
        public ActionResult Index(int pageNumber = 1)
        {
            try
            {
                if (User.IsInRole(Sales.MVCClient.Helper.MagicString.RolesAdmin))
                    ViewBag.IsAdmin = true;
                else
                    ViewBag.IsAdmin = false; 

                PageInfo pageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems = managerCRUD.Managers.Count()
                };
                IndexViewModelPagination ivmp = new IndexViewModelPagination
                {
                    PageInfo = pageInfo,
                    ManagersPerPages = managerCRUD.GetManagerPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x))
                };
                return View(ivmp);
            }
            catch (MyInvalidOperationException e)
            {
                ViewBag.Title = "Invalid Operation";
                ViewBag.ErrorMessage = e.ErrorMessage;
                return View("Error");
            }
            catch (Exception e)
            {
                if (User.IsInRole(Sales.MVCClient.Helper.MagicString.RolesAdmin))
                    ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                return View("Error");
            }
        }

        // GET: Managers/Details/5
        public ActionResult Details(int id)
        {
            var manager = managerCRUD.Managers.FirstOrDefault(x => x.ID == id);
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
                    managerCRUD.AddManager(mapper.Mapping(manager));
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = new ErrorMessage().Get(e);
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
            var manager = managerCRUD.Managers.FirstOrDefault(x => x.ID == id);
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
                    managerCRUD.EditManager(mapper.Mapping(manager));
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                    return View("Error");
                }
            else
                return View(manager);
        }

        // GET: Managers/Delete/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id)
        {
            var manager = managerCRUD.Managers.FirstOrDefault(x => x.ID == id);
            if (manager != null)
                return View(mapper.Mapping(manager));
            else
                return View();
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                managerCRUD.DeleteManager(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                return View("Error");
            }
        }
    }
}
