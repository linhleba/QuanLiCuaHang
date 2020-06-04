using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiCuaHang.Areas.Manager.Controllers
{
    public class HomeController : Controller
    {
        // GET: Manager/Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Layout()
        {
            return View();
        }
    }
}