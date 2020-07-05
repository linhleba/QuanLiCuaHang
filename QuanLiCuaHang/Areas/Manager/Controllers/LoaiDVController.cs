using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiCuaHang.Areas.Manager.Data;

namespace QuanLiCuaHang.Areas.Manager.Controllers
{
    public class LoaiDVController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // GET: Manager/LoaiDV
        public ActionResult Index()
        {
            var lOAIDICHVU = new LOAIDV();
            return View(lOAIDICHVU);
        }


        [HttpPost]
        public ActionResult Index([Bind(Include = "MaLoaiDV,TenLoaiDV,DonGiaDV")] LOAIDV lOAIDV)
        {
            if (ModelState.IsValid)
            {
                db.LOAIDVs.Add(lOAIDV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIDV);
        }



        // GET: Manager/LoaiDV/Details/5
        public ActionResult Details()
        {
            return View(db.LOAIDVs.ToList());
        }

        public JsonResult IsTenDVAvailable(string TenLoaiDV)
        {
            return Json(!db.LOAIDVs.Any(x => x.TenLoaiDV == TenLoaiDV), JsonRequestBehavior.AllowGet);

        }

        // GET: Manager/LoaiDV/Create


        // GET: Manager/LoaiDV/Edit/5

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
