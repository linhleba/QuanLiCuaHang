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
    public class DVTController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // GET: Manager/DVT
        public ActionResult DanhSach()
        {
            return View(db.DONVITINHs.ToList());
        }



        //CheckTenLoaiSP
        public JsonResult IsTenDVTavailable(string TenDVT)
        {
            return Json(!db.DONVITINHs.Any(x => x.TenDVT == TenDVT), JsonRequestBehavior.AllowGet);
        }






        // GET: Manager/DVT/ChiTiet/5
        public ActionResult ChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONVITINH dONVITINH = db.DONVITINHs.Find(id);
            if (dONVITINH == null)
            {
                return HttpNotFound();
            }
            return View(dONVITINH);
        }

        // GET: Manager/DVT/Tao
        public ActionResult Tao()
        {
            return View();
        }

        // POST: Manager/DVT/Tao
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DanhSach([Bind(Include = "MaDVT,TenDVT")] DONVITINH dONVITINH)
        {

            if (ModelState.IsValid)
            {
                db.DONVITINHs.Add(dONVITINH);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }

            return View(dONVITINH);
        }

        // GET: Manager/DVT/Sua/5
        public ActionResult Sua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONVITINH dONVITINH = db.DONVITINHs.Find(id);
            if (dONVITINH == null)
            {
                return HttpNotFound();
            }
            return View(dONVITINH);
        }

        // POST: Manager/DVT/Sua/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua([Bind(Include = "MaDVT,TenDVT")] DONVITINH dONVITINH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONVITINH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(dONVITINH);
        }

        // GET: Manager/DVT/Xoa/5
        public ActionResult Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONVITINH dONVITINH = db.DONVITINHs.Find(id);
            if (dONVITINH == null)
            {
                return HttpNotFound();
            }
            return View(dONVITINH);
        }

        // POST: Manager/DVT/Xoa/5
        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONVITINH dONVITINH = db.DONVITINHs.Find(id);
            db.DONVITINHs.Remove(dONVITINH);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

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
