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
    public class ClientController : Controller
    {
        BL.Handler handler;
        MVCMapper mapper;
        const int pageSize = 3;

        public ClientController()
        {
            handler = new BL.Handler(Sales.MVCClient.Helper.MagicString.PathSalesDataBase);
            mapper = new MVCMapper();
        }

        // GET: Clients
        public ActionResult Index(int pageNumber = 1)
        {
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = handler.Clients.Count()
            };
            IndexViewModelPagination ivmp = new IndexViewModelPagination
            {
                PageInfo = pageInfo,
                ClientsPerPages = handler.GetClientPerPage(pageSize, pageNumber).Select(x => mapper.Mapping(x))
            };
            return View(ivmp);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            var client = handler.Clients.FirstOrDefault(x => x.ID == id);
            if (client != null)
                return View(mapper.Mapping(client));
            else
                return View("Error");
        }

        // GET: Clients/Create
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    handler.AddClient(mapper.Mapping(client));
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            }
            else
                return View(client);
        }

        // GET: Clients/Edit/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id)
        {
            var client = handler.Clients.FirstOrDefault(x => x.ID == id);
            if (client != null)
                return View(mapper.Mapping(client));
            else
                return View("Error");
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Edit(int id, Client client)
        {
            if (ModelState.IsValid == true)
                try
                {
                    handler.EditClient(mapper.Mapping(client));
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            else
                return View(client);
        }

        // GET: Clients/Delete/5
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id)
        {
            var client = handler.Clients.FirstOrDefault(x => x.ID == id);
            if (client != null)
                return View(mapper.Mapping(client));
            else
                return View("Error");
        }

        // POST: Clients/Delete/5
        [HttpPost]
        [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
        public ActionResult Delete(int id, Client client)
        {
            try
            {
                handler.DeleteClient(mapper.Mapping(client));
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
