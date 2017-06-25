using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sales.BLIdentity.DTO;
using Sales.BLIdentity.Infrastructure;
using Sales.BLIdentity.Interfaces;
using Sales.MVCClient.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace Sales.MVCClient.Controllers
{
    public class AccountController : Controller
    {
        MVCMapper mapper;
        public AccountController()
        {
            mapper = new MVCMapper();
        }
        private IUserService UserService
        {
            get { return HttpContext.GetOwinContext().GetUserManager<IUserService>(); }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            SetInitialDataAsync();
            if (ModelState.IsValid == true)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            SetInitialDataAsync();
            if (ModelState.IsValid == true)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Roles = new List<string>() { "user" }
                };
                OperationDetails operationDetails = UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
        private void SetInitialDataAsync()
        {
            UserService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                Address = "ул. Спортивная, д.30, кв.75",
                Roles = new List<string> { "user", "admin" }
            }, new List<string> { "user", "admin" });
        }

        public ActionResult Users()
        {
            IEnumerable<User> users = UserService.GetUsers().Select(x => mapper.Mapping(x));
            return View(users);
        }

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
        [HttpPost]
        public ActionResult Edit(string id, User user)
        {
            SetInitialDataAsync();
            if (ModelState.IsValid == true)
                try
                {
                    UserDTO userDTO = mapper.Mapping(user);
                    OperationDetails operationDetails = UserService.Update(userDTO);
                    if (operationDetails.Succedeed)
                        return RedirectToAction("Users");
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

        // GET: Operations/Create
        public ActionResult Create()
        {
            UserCreate user = new UserCreate();
            ViewBag.Roles = UserService.GetRoles();
            return View(user);
        }
        // POST: Operations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate user)
        {
            SetInitialDataAsync();
            if (ModelState.IsValid == true)
                try
                {
                    OperationDetails operationDetails = UserService.Create(mapper.Mapping(user));
                    return RedirectToAction("Users");
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

        // GET: Operations/Delete/5
        public ActionResult Delete(string id)
        {
            var user = UserService.GetUsers().FirstOrDefault(x => x.Id == id);
            if (user != null)
                return View(mapper.Mapping(user));
            else
                return View("Error");
        }

        // POST: Operations/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, User user)
        {
            try
            {
                UserService.Delete(mapper.Mapping(user));
                return RedirectToAction("Users");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}