using Sales.MVCClient.Models;
using Sales.MVCClient.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.MVCClient.Models.CreateEdit;
using Sales.BL.Interfaces;
using Sales.MVCClient.Helper;
using Sales.BL.Infrastructure;

namespace Sales.MVCClient.Controllers
{
    [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesUser)]
    public class OperationController : Controller
    {
        Sales.BL.Handler handler;
        IOperationCRUD operationCRUD;
        MVCMapper mapper;
        const int pageSize = 3;

        public OperationController(IOperationCRUD opCRUD)
        {
            handler = new BL.Handler();
            handler.Connect(Sales.MVCClient.Helper.MagicString.PathSalesDataBase);
            operationCRUD = opCRUD;
            mapper = new MVCMapper();
        }
        // GET: Operations
        public ActionResult Index(int? client, int? manager, int? product, int pageNumber = 1)
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
                    TotalItems = operationCRUD.Operations.Count()
                };
                IndexViewModelPagination ivmp = new IndexViewModelPagination
                {
                    PageInfo = pageInfo,
                    OperationsPerPages = operationCRUD.GetOperationPerPage(pageSize, pageNumber, client, manager, product).Select(x => mapper.Mapping(x)),
                    ItemsList = GetItemsList()
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
                    ViewBag.ErrorMessage = e.Message;
                return View("Error");
            }
        }

        // GET: Operations/Details/5
        public ActionResult Details(int id)
        {
            var operation = operationCRUD.Operations.FirstOrDefault(x => x.ID == id);
            if (operation != null)
                return View(mapper.Mapping(operation));
            else
                return View("Error");
        }

        // GET: Operations/Create
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
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
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create(Operation operation)
        {
            if (ModelState.IsValid == true)
                try
                {
                    operationCRUD.AddOperation(mapper.Mapping(operation));
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                    return View("Error");
                }
            else
            {
                OperationCreateEdit op = new OperationCreateEdit() { ItemsList = GetItemsList() };
                return View(op);
            }
        }

        // GET: Operations/Edit/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id)
        {
            var operation = operationCRUD.Operations.FirstOrDefault(x => x.ID == id);
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
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id, Operation operation)
        {
            if (ModelState.IsValid == true)
                try
                {
                    operationCRUD.EditOperation(mapper.Mapping(operation));
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                    return View("Error");
                }
            else
            {
                OperationCreateEdit op = new OperationCreateEdit() { ItemsList = GetItemsList() };
                return View(op);
            }
        }

        // GET: Operations/Delete/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id)
        {
            var operation = operationCRUD.Operations.FirstOrDefault(x => x.ID == id);
            if (operation != null)
                return View(mapper.Mapping(operation));
            else
                return View("Error");
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                operationCRUD.DeleteOperation(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                return View("Error");
            }
        }

        private ItemsList GetItemsList()
        {
            return new ItemsList()
            {
                Clients = new SelectList(handler.Clients.Select(x => mapper.Mapping(x)), "ID", "Name"),
                Managers = new SelectList(handler.Managers.Select(x => mapper.Mapping(x)), "ID", "Name"),
                Products = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name"),
                PriceHistories = new SelectList(handler.PriceHistories.Select(x => mapper.Mapping(x)), "ID", "Price")
            };
        }
    }
}
