using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sales.BLIdentity.DTO;
using Sales.BLIdentity.Infrastructure;
using Sales.BLIdentity.Interfaces;
using Sales.MVCClient.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Sales.MVCClient.Models.Account;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid == true)
            {
                UserDto userDto = new UserDto { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", Sales.MVCClient.Helper.MagicString.ErrorWrongLoginOrPassword);
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
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid == true)
            {
                UserDto userDto = new UserDto
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Roles = new List<string>() { Sales.MVCClient.Helper.MagicString.RolesUser }
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDto
            {
                Email = "admin@mail.ru",
                UserName = "admin@mail.ru",
                Password = "Qwe123!",
                Name = "adminName",
                Address = "adminHome",
                Roles = new List<string> 
                { 
                    Sales.MVCClient.Helper.MagicString.RolesUser,
                    Sales.MVCClient.Helper.MagicString.RolesAdmin 
                }
            },
            new List<string> 
            {
                Sales.MVCClient.Helper.MagicString.RolesUser, 
                Sales.MVCClient.Helper.MagicString.RolesAdmin 
            });
        }
    }
}