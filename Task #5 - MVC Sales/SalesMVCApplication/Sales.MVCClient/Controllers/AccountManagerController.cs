using Microsoft.AspNet.Identity.Owin;
using Sales.BLIdentity.DTO;
using Sales.BLIdentity.Infrastructure;
using Sales.BLIdentity.Interfaces;
using Sales.MVCClient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.MVCClient.Models.CreateEdit;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Create(UserCreate user)
        {
            if (ModelState.IsValid == true)
                try
                {
                    OperationDetails operationDetails = await UserService.Create(mapper.Mapping(user));
                    if (operationDetails.Succedeed)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", operationDetails.Message);
                        ViewBag.Roles = UserService.GetRoles();
                        return View(user);
                    }
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
            UserDto userDTO = UserService.GetUsers().FirstOrDefault(x => x.Id == id);

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
        public async Task<ActionResult> Edit(string id, User user)
        {
            if (ModelState.IsValid == true)
                try
                {
                    UserDto userDTO = mapper.Mapping(user);
                    OperationDetails operationDetails = await UserService.Update(userDTO);
                    if (operationDetails.Succedeed)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", operationDetails.Message);
                        ViewBag.Roles = UserService.GetRoles();
                        return View(user);
                    }
                }
                catch
                {
                    return View("Error");
                }
            else
            {
                UserDto userDTO = UserService.GetUsers().FirstOrDefault(x => x.Id == id);
                if (userDTO != null)
                {
                    ViewBag.Roles = UserService.GetRoles();
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
                UserService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
