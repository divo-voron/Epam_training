using Microsoft.AspNet.Identity.Owin;
using Sales.BLIdentity.DTO;
using Sales.BLIdentity.Infrastructure;
using Sales.BLIdentity.Interfaces;
using Sales.MVCClient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.MVCClient.Controllers
{
    [Authorize(Roles = Sales.MVCClient.Helper.MagicString.RolesAdmin)]
    public class AccountManagerController : Controller
    {
        MVCMapper mapper;
        public AccountManagerController()
        {
            mapper = new MVCMapper();
        }
        private IUserService UserService
        {
            get { return HttpContext.GetOwinContext().GetUserManager<IUserService>(); }
        }
        // GET: AccountManager
        public ActionResult Index()
        {
            IEnumerable<User> users = UserService.GetUsers().Select(x => mapper.Mapping(x));
            return View(users);
        }
        
        // GET: AccountManager/Create
        public ActionResult Create()
        {
            UserCreate user = new UserCreate();
            ViewBag.Roles = UserService.GetRoles();
            return View(user);
        }

        // POST: AccountManager/Create
        [HttpPost]
        public ActionResult Create(UserCreate user)
        {
            //SetInitialDataAsync();
            if (ModelState.IsValid == true)
                try
                {
                    OperationDetails operationDetails = UserService.Create(mapper.Mapping(user));
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            else
            {
                ViewBag.Roles = UserService.GetRoles();
                return View(user);
            }
        }

        // GET: AccountManager/Edit/5
        public ActionResult Edit(string id)
        {
            UserDTO userDTO = UserService.GetUsers().FirstOrDefault(x => x.Id == id);

            if (userDTO != null)
            {
                ViewBag.Roles = UserService.GetRoles();

                User user = mapper.Mapping(userDTO);
                return View(user);
            }
            else
                return View("Error");
        }

        // POST: AccountManager/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, User user)
        {
            //SetInitialDataAsync();
            if (ModelState.IsValid == true)
                try
                {
                    UserDTO userDTO = mapper.Mapping(user);
                    OperationDetails operationDetails = UserService.Update(userDTO);
                    if (operationDetails.Succedeed)
                        return RedirectToAction("Index");
                    else
                        return RedirectToAction("Error");
                }
                catch
                {
                    return View("Error");
                }
            else
            {
                UserDTO userDTO = UserService.GetUsers().FirstOrDefault(x => x.Id == id);
                if (userDTO != null)
                {
                    ViewBag.RolesDTO = UserService.GetRoles();
                    return View(mapper.Mapping(userDTO));
                }
                else
                    return View("Error");
            }
        }

        // GET: AccountManager/Delete/5
        public ActionResult Delete(string id)
        {
            var user = UserService.GetUsers().FirstOrDefault(x => x.Id == id);
            if (user != null)
                return View(mapper.Mapping(user));
            else
                return View("Error");
        }

        // POST: AccountManager/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, User user)
        {
            try
            {
                UserService.Delete(mapper.Mapping(user));
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
