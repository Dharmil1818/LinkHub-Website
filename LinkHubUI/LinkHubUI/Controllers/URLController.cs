﻿using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Controllers
{
        [Authorize(Roles ="A,U")]
    public class URLController : BaseAdminController
    {

        // GET: URL
      
        public ActionResult Index()
        {
        ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetALL().ToList(), "CategoryId", "CategoryName");
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Url myUrl)
        {
            try
            {
                myUrl.IsApproved = "P";
                myUrl.UrlId = objBs.userBs.GetALL().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;

                if (ModelState.IsValid)
                {
                    objBs.urlBs.Insert(myUrl);
                    TempData["Msg"] = "Created Sucessfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetALL().ToList(), "CategoryId", "CategoryName");
                    //ViewBag.UserId = new SelectList(objBs.userBs.GetALL().ToList(), "UserId", "UserEmail");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }

        }
        
    }
}