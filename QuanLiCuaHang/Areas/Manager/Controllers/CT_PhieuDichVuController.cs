using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiCuaHang.Areas.Manager.Data;
using QuanLiCuaHang.Areas.Manager.Repository;
using QuanLiCuaHang.Areas.Manager.ViewModel;

namespace QuanLiCuaHang.Areas.Manager.Controllers
{
    public class CT_PhieuDichVuController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // Ham lay ra don gia DV
        public JsonResult GetDonGiaDV(int MaLoaiDV)
        {
            decimal dongiaDV = db.LOAIDVs.Single(d => d.MaLoaiDV == MaLoaiDV).DonGiaDV;

            return Json(dongiaDV, JsonRequestBehavior.AllowGet);
        }

        // Hàm lấy ra phần trăm trả trước
        public JsonResult GetPhanTramTraTruoc()
        {
            decimal phanTramTraTruoc = db.THAMSOes.FirstOrDefault().PhanTramTraTruoc;

            return Json(phanTramTraTruoc, JsonRequestBehavior.AllowGet);
        }


        // GET: Manager/CT_PhieuDichVu
        public ActionResult Index()
        {
            var cHITIET_PHIEUDV = db.CHITIET_PHIEUDV.Include(c => c.LOAIDV).Include(c => c.PHIEUDV).Include(c => c.TINHTRANGDV);
            return View(cHITIET_PHIEUDV.ToList());
        }

        // GET: Manager/CT_PhieuDichVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_PHIEUDV cHITIET_PHIEUDV = db.CHITIET_PHIEUDV.Find(id);
            if (cHITIET_PHIEUDV == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_PHIEUDV);
        }

        // GET: Manager/CT_PhieuDichVu/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDV = new SelectList(db.LOAIDVs, "MaLoaiDV", "TenLoaiDV");
            ViewBag.MaPDV = new SelectList(db.PHIEUDVs, "MaPDV", "TenKH", "MaTinhTrangPDV");
            ViewBag.MaTinhTrangDV = new SelectList(db.TINHTRANGDVs, "MaTinhTrangDV", "TenTinhTrang");
            ViewBag.MaTinhTrangPDV = new SelectList(db.TINHTRANGPDVs, "MaTinhTrangPDV", "TenTinhTrang");
            return View();
        }

        // POST: Manager/CT_PhieuDichVu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public JsonResult Create([System.Web.Http.FromBody] PhieuDichVuViewModel phieuDichVu)
        {
            CT_PhieuDichVuRepository cT_PhieuDichVuRepository = new CT_PhieuDichVuRepository();
            cT_PhieuDichVuRepository.AddCT_PhieuDichVu(phieuDichVu);

            return Json(data: "Tạo phiếu bán hàng thành công", JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaPDV,MaLoaiDV,DonGiaDuocTinh,SoLuong,ThanhTien,ThanhToanTraTruoc,ThanhToanConLai,NgayGiao,MaTinhTrangDV")] CHITIET_PHIEUDV cHITIET_PHIEUDV)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CHITIET_PHIEUDV.Add(cHITIET_PHIEUDV);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaLoaiDV = new SelectList(db.LOAIDVs, "MaLoaiDV", "TenLoaiDV", cHITIET_PHIEUDV.MaLoaiDV);
        //    ViewBag.MaPDV = new SelectList(db.PHIEUDVs, "MaPDV", "TenKH", cHITIET_PHIEUDV.MaPDV);
        //    ViewBag.MaTinhTrangDV = new SelectList(db.TINHTRANGDVs, "MaTinhTrangDV", "TenTinhTrang", cHITIET_PHIEUDV.MaTinhTrangDV);
        //    return View(cHITIET_PHIEUDV);
        //}

        // GET: Manager/CT_PhieuDichVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_PHIEUDV cHITIET_PHIEUDV = db.CHITIET_PHIEUDV.Find(id);
            if (cHITIET_PHIEUDV == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDV = new SelectList(db.LOAIDVs, "MaLoaiDV", "TenLoaiDV", cHITIET_PHIEUDV.MaLoaiDV);
            ViewBag.MaPDV = new SelectList(db.PHIEUDVs, "MaPDV", "TenKH", cHITIET_PHIEUDV.MaPDV);
            ViewBag.MaTinhTrangDV = new SelectList(db.TINHTRANGDVs, "MaTinhTrangDV", "TenTinhTrang", cHITIET_PHIEUDV.MaTinhTrangDV);
            return View(cHITIET_PHIEUDV);
        }

        // POST: Manager/CT_PhieuDichVu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPDV,MaLoaiDV,DonGiaDuocTinh,SoLuong,ThanhTien,ThanhToanTraTruoc,ThanhToanConLai,NgayGiao,MaTinhTrangDV")] CHITIET_PHIEUDV cHITIET_PHIEUDV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIET_PHIEUDV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDV = new SelectList(db.LOAIDVs, "MaLoaiDV", "TenLoaiDV", cHITIET_PHIEUDV.MaLoaiDV);
            ViewBag.MaPDV = new SelectList(db.PHIEUDVs, "MaPDV", "TenKH", cHITIET_PHIEUDV.MaPDV);
            ViewBag.MaTinhTrangDV = new SelectList(db.TINHTRANGDVs, "MaTinhTrangDV", "TenTinhTrang", cHITIET_PHIEUDV.MaTinhTrangDV);
            return View(cHITIET_PHIEUDV);
        }

        // GET: Manager/CT_PhieuDichVu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_PHIEUDV cHITIET_PHIEUDV = db.CHITIET_PHIEUDV.Find(id);
            if (cHITIET_PHIEUDV == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_PHIEUDV);
        }

        // POST: Manager/CT_PhieuDichVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIET_PHIEUDV cHITIET_PHIEUDV = db.CHITIET_PHIEUDV.Find(id);
            db.CHITIET_PHIEUDV.Remove(cHITIET_PHIEUDV);
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
