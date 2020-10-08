using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Controllers
{
    [AllowAnonymous]
    public class BrowseURLController : BaseAdminController
    {


        // GET: BrowseURL
       
        public ActionResult Index(string SortOrder,string SortBy,string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var urls = objBs.urlBs.GetALL().Where(x=>x.IsApproved=="A");

            switch(SortBy)
            {
                case "Title":
            switch (SortOrder)
            {
                case "ASC":
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;

                case "DESC":
                    urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                    break;
                default:
                    break;
            }
                    break;

                case "Category":
                    switch (SortOrder)
                    {
                        case "ASC":
                            urls = urls.OrderBy(x => x.tbl_Category.CategoryName).ToList();
                            break;

                        case "DESC":
                            urls = urls.OrderByDescending(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Url":
                    switch (SortOrder)
                    {
                        case "ASC":
                            urls = urls.OrderBy(x => x.Url).ToList();
                            break;

                        case "DESC":
                            urls = urls.OrderByDescending(x => x.Url).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "UrlDesc":
                    switch (SortOrder)
                    {
                        case "ASC":
                            urls = urls.OrderBy(x => x.UrlDesc).ToList();
                            break;

                        case "DESC":
                            urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.urlBs.GetALL().Where(x => x.IsApproved == "A").Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            urls = urls.Skip((page - 1) * 10).Take(10);

            return View(urls);
        }
    }
}