using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OnlineShoppingStore.WebUI.Models;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Concrete;
using System.Web.Security;

namespace OnlineShoppingStore.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IAuthentication authentication;
        public AccountController(IAuthentication authen)
        {
            authentication = authen;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authentication.Authenticate(model.UserName, model.Password))
                {

                    
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                    
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }
    }
}