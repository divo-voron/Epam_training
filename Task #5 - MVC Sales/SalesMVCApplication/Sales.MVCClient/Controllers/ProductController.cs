﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.MVCClient.Models;
using Sales.MVCClient.Models.Pagination;

namespace Sales.MVCClient.Controllers
{
    [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesUser)]
    public class ProductController : Controller
    {
        BL.Handler handler;
        MVCMapper mapper;
        const int pageSize = 3;

        public ProductController()
        {
            handler = new BL.Handler(Sales.MVCClient.Helper.MagicString.PathSalesDataBase);
            mapper = new MVCMapper();
        }

        // GET: Products
        public ActionResult Index(int pageNumber = 1)
        {
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = handler.Products.Count()
            };
            IndexViewModelPagination ivmp = new IndexViewModelPagination
            {
                PageInfo = pageInfo,
                ProductsPerPages = handler.GetProductPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x))
            };
            return View(ivmp);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = handler.Products.FirstOrDefault(x => x.ID == id);
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
                    handler.AddProduct(mapper.Mapping(product));
                    return RedirectToAction("Index");
                }
                catch
                {
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
            var product = handler.Products.FirstOrDefault(x => x.ID == id);
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
                    handler.EditProduct(mapper.Mapping(product));
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            else
                return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id)
        {
            var product = handler.Products.FirstOrDefault(x => x.ID == id);
            if (product != null)
                return View(mapper.Mapping(product));
            else
                return View("Error");
        }

        // POST: Products/Delete/5
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                handler.DeleteProduct(mapper.Mapping(product));
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
