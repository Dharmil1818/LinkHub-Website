using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHubUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseAdminController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            try
            {

            if (Membership.ValidateUser(user.UserEmail, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Msg"] = "Login Failed";
                return RedirectToAction("Index");
            }
            }
            catch(Exception e1)
            {
                TempData["Msg"] = "Login Failed" + e1.Message;
                return RedirectToAction("Index");
             }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
            
    }
}