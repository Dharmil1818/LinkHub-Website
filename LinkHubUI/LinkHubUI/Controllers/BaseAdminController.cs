using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Controllers
{
    public class BaseAdminController : Controller
    {
        // GET: BaseAdmin
      // baseadmin controller
        protected AdminBs objBs;
        public BaseAdminController()
        {
            objBs = new AdminBs();
        }
    }
}