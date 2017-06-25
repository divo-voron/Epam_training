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

        public ActionResult Index(int pageNumber = 1)
        {
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = handler.Operations.Count()
            };
            IndexViewModelPagination ivmp = new IndexViewModelPagination
            {
                PageInfo = pageInfo,
                OperationsPerPages = handler.GetOperationPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x)),
                ItemsList = GetItemsList()
            };
            return View(ivmp);
        }

        [HttpPost]
        public ActionResult Filter(IndexViewModelPagination model)
        {
            //PageInfo pageInfo = new PageInfo
            //{
            //    PageNumber = pageNumber,
            //    PageSize = pageSize,
            //    TotalItems = handler.Operations.Count()
            //};
            //IndexViewModelPagination ivmp = new IndexViewModelPagination
            //{
            //    PageInfo = pageInfo,
            //    OperationsPerPages = handler.GetOperationPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x)),
            //    ItemsList = GetItemsList()
            //};

            return View("Index", model);
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
            OperationCreateEdit op = new OperationCreateEdit()
            {
                ItemsList = GetItemsList()
            };

            return View(op);
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
                    OperationCreateEdit op = new OperationCreateEdit() { ItemsList = GetItemsList() };
                    return View(op);
                }
            else
            {
                OperationCreateEdit op = new OperationCreateEdit() { ItemsList = GetItemsList() };
                return View(op);
            }
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int id)
        {
            var operation = handler.Operations.FirstOrDefault(x => x.ID == id);
            if (operation != null)
            {
                OperationCreateEdit op = new OperationCreateEdit()
                {
                    Operation = mapper.Mapping(operation),
                    ItemsList = GetItemsList()
                };
                return View(op);
            }
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
                    return View("Error");
                }
            else
            {
                OperationCreateEdit op = new OperationCreateEdit() { ItemsList = GetItemsList() };
                return View(op);
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

        private ItemsList GetItemsList()
        {
            return new ItemsList()
            {
                Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name"),
                Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name"),
                Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name"),
                PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price"),
                Sessions = new SelectList(handler.Sessions.Select(x => mapper.Mapping(x)), "ID", "Name")
            };
        }
    }
}
