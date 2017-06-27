using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.MVCClient.Models;
using Sales.MVCClient.Models.CreateEdit;
using Sales.MVCClient.Models.Pagination;

namespace Sales.MVCClient.Controllers
{
    [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesUser)]
    public class PriceHistoryController : Controller
    {
        BL.Handler handler;
        MVCMapper mapper;
        const int pageSize = 3;

        public PriceHistoryController()
        {
            handler = new BL.Handler(Sales.MVCClient.Helper.MagicString.PathSalesDataBase);
            mapper = new MVCMapper();
        }

        // GET: PriceHistory
        public ActionResult Index(int pageNumber = 1)
        {
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = handler.PriceHistories.Count()
            };
            IndexViewModelPagination ivmp = new IndexViewModelPagination
            {
                PageInfo = pageInfo,
                PriceHistoriesPerPages = handler.GetPriceHistoryPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x))
            };
            return View(ivmp);
        }

        // GET: PriceHistory/Details/5
        public ActionResult Details(int id)
        {
            var priceHistory = handler.PriceHistories.FirstOrDefault(x => x.ID == id);
            if (priceHistory != null)
                return View(mapper.Mapping(priceHistory));
            else
                return View("Error");
        }

        // GET: PriceHistory/Create
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create()
        {
            PriceHistoryCreateEdit price = new PriceHistoryCreateEdit()
            {
                Products = GetProductsSelectList()
            };
            return View(price);
        }

        // POST: PriceHistory/Create
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create(PriceHistory priceHistory)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    handler.AddPriceHistory(mapper.Mapping(priceHistory));
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            }
            else
                return View(priceHistory);
        }

        // GET: PriceHistory/Edit/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id)
        {
            var priceHistory = handler.PriceHistories.FirstOrDefault(x => x.ID == id);
            if (priceHistory != null)
            {
                PriceHistoryCreateEdit price = new PriceHistoryCreateEdit()
                {
                    PriceHistory = mapper.Mapping(priceHistory),
                    Products = GetProductsSelectList()
                };
                return View(price);
            }
            else
                return View("Error");
        }

        // POST: PriceHistory/Edit/5
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id, PriceHistory priceHistory)
        {
            if (ModelState.IsValid == true)
                try
                {
                    handler.EditPriceHistory(mapper.Mapping(priceHistory));
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            else
                return View(priceHistory);
        }

        // GET: PriceHistory/Delete/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id)
        {
            var priceHistory = handler.PriceHistories.FirstOrDefault(x => x.ID == id);
            if (priceHistory != null)
                return View(mapper.Mapping(priceHistory));
            else
                return View("Error");
        }

        // POST: PriceHistory/Delete/5
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id, PriceHistory priceHistory)
        {
            try
            {
                handler.DeletePriceHistory(mapper.Mapping(priceHistory));
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        private SelectList GetProductsSelectList()
        {
            return new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
        }
    }
}
