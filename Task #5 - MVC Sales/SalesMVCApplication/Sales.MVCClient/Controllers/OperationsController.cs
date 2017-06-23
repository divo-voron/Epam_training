using Sales.MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.MVCClient.Controllers
{
    public class OperationsController : Controller
    {
        BL.Handler handler;
        MVCMapper mapper;
        const int pageSize = 5;

        public OperationsController()
        {
            handler = new BL.Handler();
            mapper = new MVCMapper();
        }

        // GET: Operations
        public ActionResult Index(int pageNumber = 1)
        {
            IEnumerable<Operation> operationsPerPages = handler.GetOperationPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x));
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = handler.Operations.Count()
            };
            IndexViewModelPagination ivmp = new IndexViewModelPagination
            {
                PageInfo = pageInfo,
                Operations = operationsPerPages
            };

            ViewBag.Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price");
            ViewBag.Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name");

            return View(ivmp);
        }

        [HttpGet]
        public ActionResult Filter(int? pageNumber, Manager manager, Client client, Product product, PriceHistory price, Session session)
        {
            if (pageNumber != null)
            {
                IEnumerable<Operation> operationsPerPages = handler.GetOperationPerPage(pageSize, pageNumber.Value).Select(x => mapper.Mapping(x));
                PageInfo pageInfo = new PageInfo
                {
                    PageNumber = pageNumber.Value,
                    PageSize = pageSize,
                    TotalItems = handler.Operations.Count()
                };
                IndexViewModelPagination ivmp = new IndexViewModelPagination
                {
                    PageInfo = pageInfo,
                    Operations = operationsPerPages
                };

                ViewBag.Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price");
                ViewBag.Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name");

                return View("Index", ivmp);
            }
            else return View("Index");
        }

        // GET: Operations/Details/5
        public ActionResult Details(int id)
        {
            var operation = handler.Operations.FirstOrDefault(x => x.ID == id);
            if (operation != null)
                return View(mapper.Mapping(operation));
            else
                return View();
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            ViewBag.Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price");
            ViewBag.Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name");
            return View();
        }

        // POST: Operations/Create
        [HttpPost]
        public ActionResult Create(Operation operation)
        {
            if (ModelState.IsValid == true)
                try
                {
                    handler.AddOperation(mapper.Mapping(operation));
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name");
                    ViewBag.Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name");
                    ViewBag.Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
                    ViewBag.PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price");
                    ViewBag.Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name");
                    return View(operation);
                }
            else
            {
                ViewBag.Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price");
                ViewBag.Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name");
                return View(operation);
            }
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
            ViewBag.PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price");
            ViewBag.Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name");

            var operation = handler.Operations.FirstOrDefault(x => x.ID == id);
            if (operation != null)
                return View(mapper.Mapping(operation));
            else
                return View();
        }

        // POST: Operations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Operation operation)
        {
            if (ModelState.IsValid == true)
                try
                {
                    handler.EditOperation(mapper.Mapping(operation));
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name");
                    ViewBag.Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name");
                    ViewBag.Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
                    ViewBag.PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price");
                    ViewBag.Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name");
                    return View(operation);
                }
            else
            {
                ViewBag.Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
                ViewBag.PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price");
                ViewBag.Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name");
                return View(operation);
            }
        }

        // GET: Operations/Delete/5
        public ActionResult Delete(int id)
        {
            var operation = handler.Operations.FirstOrDefault(x => x.ID == id);
            if (operation != null)
                return View(mapper.Mapping(operation));
            else
                return View();
        }

        // POST: Operations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Operation operation)
        {
            try
            {
                handler.DeleteOperation(mapper.Mapping(operation));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
