using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Controllers
{
        [AllowAnonymous]
    public class QuickSubmitURLController : BaseAdminController
    {
        // GET: QuickSubmitURL
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetALL().ToList(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuickSubmitURLModel MyQuckURL)
        {
            try 
            {
                //MyQuckURL.MyUser.ConfirmPassword//

                tbl_User U = MyQuckURL.MyUser;
                ModelState.Remove("MyUser.Password");
                ModelState.Remove("MyUser.ConfirmPassword");
                ModelState.Remove("MyUrl.UrlDesc");

                if(ModelState.IsValid)
                    {
                    objBs.InsertQuickURL(MyQuckURL);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetALL().ToList(),"CategoryId","CategoryName");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed :" + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}