using Sales.BL.Interfaces;
using Sales.MVCClient.Helper;
using Sales.MVCClient.Models;
using Sales.MVCClient.Models.CreateEdit;
using Sales.MVCClient.Models.Pagination;
using Sales.MVCClient.Models.Visualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.MVCClient.Controllers
{
    [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesUser)]
    public class PriceHistoryController : Controller
    {
        Sales.BL.Handler handler;
        IPriceHistoryCRUD priceHistoryCRUD;
        MVCMapper mapper;
        const int pageSize = 3;

        public PriceHistoryController(IPriceHistoryCRUD phCRUD)
        {
            handler = new BL.Handler();
            handler.Connect(Sales.MVCClient.Helper.MagicString.PathSalesDataBase);
            priceHistoryCRUD = phCRUD;
            mapper = new MVCMapper();
        }

        // GET: PriceHistory
        public ActionResult Index(int pageNumber = 1)
        {
            if (User.IsInRole(Sales.MVCClient.Helper.MagicString.RolesAdmin))
                ViewBag.IsAdmin = true;
            else
                ViewBag.IsAdmin = false; 
            try
            {
                PageInfo pageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems = priceHistoryCRUD.PriceHistories.Count()
                };
                IndexViewModelPagination ivmp = new IndexViewModelPagination
                {
                    PageInfo = pageInfo,
                    PriceHistoriesPerPages = priceHistoryCRUD.GetPriceHistoryPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x))
                };
                return View(ivmp);
            }
            catch (Exception e)
            {
                if (User.IsInRole(Sales.MVCClient.Helper.MagicString.RolesAdmin))
                    ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                return View("Error");
            }
        }

        // GET: PriceHistory/Details/5
        public ActionResult Details(int id)
        {
            var priceHistory = priceHistoryCRUD.PriceHistories.FirstOrDefault(x => x.ID == id);
            if (priceHistory != null)
                return View(mapper.Mapping(priceHistory));
            else
                return View("Error");
        }

        // GET: PriceHistory/Edit/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id)
        {
            var priceHistory = priceHistoryCRUD.PriceHistories.FirstOrDefault(x => x.ID == id);
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
                    priceHistoryCRUD.EditPriceHistory(mapper.Mapping(priceHistory));
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
            var priceHistory = priceHistoryCRUD.PriceHistories.FirstOrDefault(x => x.ID == id);
            if (priceHistory != null)
                return View(mapper.Mapping(priceHistory));
            else
                return View("Error");
        }

        // POST: PriceHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                priceHistoryCRUD.DeletePriceHistory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Chart()
        {
            ViewBag.ProductsList = new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
            return View(new Product());
        }

        private SelectList GetProductsSelectList()
        {
            return new SelectList(handler.Products.Select(x => mapper.Mapping(x)), "ID", "Name");
        }

        public JsonResult GetChartData(object id)
        {
            int productId;
            //if (Int32.TryParse(id.ToString(), out productId))
            {
                var result = priceHistoryCRUD.PriceHistories
                    .Where(x => x.Product_ID == 2)
                    .Select(x => new PriceHistoryChartItem() { Date = x.Date.ToShortDateString(), Price = x.Price });

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            //else
              //  return null;
        }
    }
}
