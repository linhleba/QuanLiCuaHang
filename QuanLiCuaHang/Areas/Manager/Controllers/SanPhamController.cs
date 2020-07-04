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
    public class SanPhamController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // GET: Manager/SanPham
        public ActionResult Index()
        {

            ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP");
            return View();
        }
        public ActionResult Details()
        {

            ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP");
            return View(db.SANPHAMs.ToList());
        }



        //Check ten san pham
        public JsonResult IsTenSPAvailable(string TenSanPham)
        {
            return Json(!db.SANPHAMs.Any(x => x.TenSanPham == TenSanPham), JsonRequestBehavior.AllowGet);

        }

        //Get phan tram loi nhuan

        public JsonResult GetPhanTramLoiNhuan(int MaLoaiSP)
        {
            decimal phantramloinhuan = (decimal)db.LOAISANPHAMs.Single(x => x.MaLoaiSP == MaLoaiSP).PhanTramLoiNhuan;
            return Json(phantramloinhuan, JsonRequestBehavior.AllowGet);

        }





        // GET: Manager/SanPham/ChiTiet/5
        public ActionResult ChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }


        public ActionResult Tao()
        {
            return View();
        }

        // POST: Manager/SanPham/Tao
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "MaSP,TenSanPham,GiaMuaVao,GiaBanRa,SoLuongTon,MaLoaiSP")] SANPHAM sANPHAM)
        {

            if (ModelState.IsValid)
            {

                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP", sANPHAM.MaLoaiSP);
            return View(sANPHAM);
        }

        // GET: Manager/SanPham/Sua/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP", sANPHAM.MaLoaiSP);
            return View(sANPHAM);
        }

        // POST: Manager/SanPham/Sua/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSanPham,GiaMuaVao,GiaBanRa,SoLuongTon,MaLoaiSP")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP", sANPHAM.MaLoaiSP);
            return View(sANPHAM);
        }

        // GET: Manager/SanPham/Xoa/5
        public ActionResult Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: Manager/SanPham/Xoa/5
        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
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
