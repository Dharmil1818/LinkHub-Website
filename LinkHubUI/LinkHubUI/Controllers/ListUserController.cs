using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Controllers
{
        [Authorize(Roles ="A")]
    public class ListUserController : BaseAdminController
    {

        // GET: ListUser
     
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var users = objBs.userBs.GetALL();

            switch (SortBy)
            {
                case "UserEmail":
                    switch (SortOrder)
                    {
                        case "ASC":
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "DESC":
                            users = users.OrderByDescending(x => x.UserEmail).ToList();
                            break;
                        default:
                            break;
                                                }
                    break;

                case "Role":
                    switch (SortOrder)
                    {
                        case "ASC":
                    users = users.OrderBy(x => x.Role).ToList();
                            break;

                        case "DESC":
                            users = users.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    users = users.OrderBy(x => x.UserEmail).ToList();
                    break;
            }
            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            users = users.Skip((page - 1) * 10).Take(10).ToList();
            return View(users);
        }
    }
}