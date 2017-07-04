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
    public class ProductController : Controller
    {
        Sales.BL.Handler handler;
        IProductCRUD productCRUD;
        MVCMapper mapper;
        const int pageSize = 3;

        public ProductController(IProductCRUD handlerCRUD)
        {
            handler = new BL.Handler();
            handler.Connect(Sales.MVCClient.Helper.MagicString.PathSalesDataBase);
            productCRUD = handlerCRUD;
            mapper = new MVCMapper();
        }

        // GET: Products
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
                    TotalItems = productCRUD.Products.Count()
                };
                IndexViewModelPagination ivmp = new IndexViewModelPagination
                {
                    PageInfo = pageInfo,
                    ProductsPerPages = productCRUD.GetProductPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x))
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

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = productCRUD.Products.FirstOrDefault(x => x.ID == id);
            if (product != null)
                return View(mapper.Mapping(product));
            else
                return View("Error");
        }

        // GET: Products/Create
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    productCRUD.AddProduct(mapper.Mapping(product));
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                    return View("Error");
                }
            }
            else
                return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id)
        {
            var product = productCRUD.Products.FirstOrDefault(x => x.ID == id);
            if (product != null)
                return View(mapper.Mapping(product));
            else
                return View("Error");
        }

        // POST: Products/Edit/5
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid == true)
                try
                {
                    productCRUD.EditProduct(mapper.Mapping(product));
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = new ErrorMessage().Get(e);
                    return View("Error");
                }
            else
                return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id)
        {
            var product = productCRUD.Products.FirstOrDefault(x => x.ID == id);
            if (product != null)
                return View(mapper.Mapping(product));
            else
                return View("Error");
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                productCRUD.DeleteProduct(id);
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
