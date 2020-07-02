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
    public class LoaiSPController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // GET: Manager/LOAISP
        public ActionResult DanhSach()
        {
            var lOAISANPHAMs = db.LOAISANPHAMs.Include(l => l.DONVITINH);
            return View(lOAISANPHAMs.ToList());
        }

        // GET: Manager/LOAISP/ChiTiet/5
        public ActionResult ChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAISANPHAM);
        }

        // GET: Manager/LOAISP/Tao
        public ActionResult Tao()
        {
            ViewBag.MaDVT = new SelectList(db.DONVITINHs, "MaDVT", "TenDVT");
            return View();
        }

        // POST: Manager/LOAISP/Tao
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tao([Bind(Include = "MaLoaiSP,TenLoaiSP,PhanTramLoiNhuan,MaDVT")] LOAISANPHAM lOAISANPHAM)
        {
            if (string.IsNullOrEmpty(lOAISANPHAM.TenLoaiSP))
            {
                ModelState.AddModelError("TenLoaiSP", "Tên loại sản phẩm không được phép rỗng");
            }

            if (double.IsNaN(lOAISANPHAM.PhanTramLoiNhuan))
            {
                ModelState.AddModelError("PhanTramLoiNhuan", "Phần trăm lợi nhuận không được phép rỗng");
            }

            if (ModelState.IsValid)
            {
                db.LOAISANPHAMs.Add(lOAISANPHAM);
                db.SaveChanges();
                return RedirectToAction("Danhsach");
            }

            ViewBag.MaDVT = new SelectList(db.DONVITINHs, "MaDVT", "TenDVT", lOAISANPHAM.MaDVT);
            return View(lOAISANPHAM);
        }

        // GET: Manager/LOAISP/Sua/5
        public ActionResult Sua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDVT = new SelectList(db.DONVITINHs, "MaDVT", "TenDVT", lOAISANPHAM.MaDVT);
            return View(lOAISANPHAM);
        }

        // POST: Manager/LOAISP/Sua/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua([Bind(Include = "MaLoaiSP,TenLoaiSP,PhanTramLoiNhuan,MaDVT")] LOAISANPHAM lOAISANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAISANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            ViewBag.MaDVT = new SelectList(db.DONVITINHs, "MaDVT", "TenDVT", lOAISANPHAM.MaDVT);
            return View(lOAISANPHAM);
        }

        // GET: Manager/LOAISP/Xoa/5
        public ActionResult Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAISANPHAM);
        }

        // POST: Manager/LOAISP/Xoa/5
        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            db.LOAISANPHAMs.Remove(lOAISANPHAM);
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
