using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webdemo.Areas.CusUser.Controllers
{
    public class HomeCusUserController : Controller
    {
        // GET: CusUser/HomeCusUser
        public ActionResult Index()
        {
            return View();
        }
    }
}