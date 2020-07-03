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
    public class CT_PhieuMuaHangController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // GET: Manager/CT_PhieuMuaHang

        // Ham lay ra don gia
        public JsonResult GetDonGia(int MaSP)
        {
            decimal UnitPrice = db.SANPHAMs.Single(d => d.MaSP == MaSP).GiaMuaVao;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]

        //// Ham lay ra loai san pham
        public JsonResult GetLoaiSanPham(int MaSP)
        {
            int MaLoaiSanPham = db.SANPHAMs.Single(d => d.MaSP == MaSP).MaLoaiSP;
            string LoaiSanPham = db.LOAISANPHAMs.Single(m => m.MaLoaiSP == MaLoaiSanPham).TenLoaiSP;
            return Json(LoaiSanPham, JsonRequestBehavior.AllowGet);
        }

        // Ham lay ra don vi tinh
        public JsonResult GetDonViTinh(int MaSP)
        {
            int MaLoaiSanPham = db.SANPHAMs.Single(d => d.MaSP == MaSP).MaLoaiSP;
            int LoaiSanPham = db.LOAISANPHAMs.Single(m => m.MaLoaiSP == MaLoaiSanPham).MaDVT;
            string DonViTinh = db.DONVITINHs.Single(m => m.MaDVT == LoaiSanPham).TenDVT;

            return Json(DonViTinh, JsonRequestBehavior.AllowGet);
        }

        // Ham lay ra số lượng tồn
        public JsonResult GetSoLuongTon(int MaSP)
        {
            int SoLuongTon = db.SANPHAMs.Single(d => d.MaSP == MaSP).SoLuongTon;
            return Json(SoLuongTon, JsonRequestBehavior.AllowGet);
        }

        // Hàm lấy ra số điện thoại
        public JsonResult GetSDT(int MaNCC)
        {
            var SDT = db.NHACUNGCAPs.Single(d => d.MaNCC == MaNCC).SDT;
            return Json(SDT, JsonRequestBehavior.AllowGet);
        }

        // Hàm lấy ra địa chỉ
        public JsonResult GetDiaChi(int MaNCC)
        {
            var DiaChi = db.NHACUNGCAPs.Single(d => d.MaNCC == MaNCC).DiaChi;
            return Json(DiaChi, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetItem(int itemID)
        {
            decimal UnitPrice = db.SANPHAMs.Single(d => d.MaSP == itemID).GiaBanRa;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Create([System.Web.Http.FromBody] PhieuMuaHangViewModel phieuMuaHang)
        {
            CT_PhieuMuaHangRepository cT_PhieuMuaHangRepository = new CT_PhieuMuaHangRepository();
            cT_PhieuMuaHangRepository.AddCT_PhieuMuaHang(phieuMuaHang);

            return Json(data: "Tạo phiếu bán hàng thành công", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var cHITIET_PMH = db.CHITIET_PMH.Include(c => c.PHIEUMUAHANG).Include(c => c.SANPHAM);
            return View(cHITIET_PMH.ToList());
        }

        // GET: Manager/CT_PhieuMuaHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var CT_PhieuMuaHang = db.CHITIET_PMH.Include(b => b.PHIEUMUAHANG).Include(c => c.SANPHAM);
            var result = (CT_PhieuMuaHang.Where(x => x.MaPMH == id)).ToList();
            return View(result);

        }

        // GET: Manager/CT_PhieuMuaHang/Create
        public ActionResult Create()
        {
            ViewBag.MaPMH = new SelectList(db.PHIEUMUAHANGs, "MaPMH", "MaPMH");
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham");
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Manager/CT_PhieuMuaHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaPMH,MaSP,SoLuong,DonGia,ThanhTien")] CHITIET_PMH cHITIET_PMH)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CHITIET_PMH.Add(cHITIET_PMH);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaPMH = new SelectList(db.PHIEUMUAHANGs, "MaPMH", "MaPMH", cHITIET_PMH.MaPMH);
        //    ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", cHITIET_PMH.MaSP);
        //    return View(cHITIET_PMH);
        //}

        // GET: Manager/CT_PhieuMuaHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_PMH cHITIET_PMH = db.CHITIET_PMH.Find(id);
            if (cHITIET_PMH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPMH = new SelectList(db.PHIEUMUAHANGs, "MaPMH", "MaPMH", cHITIET_PMH.MaPMH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", cHITIET_PMH.MaSP);
            return View(cHITIET_PMH);
        }

        // POST: Manager/CT_PhieuMuaHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPMH,MaSP,SoLuong,DonGia,ThanhTien")] CHITIET_PMH cHITIET_PMH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIET_PMH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPMH = new SelectList(db.PHIEUMUAHANGs, "MaPMH", "MaPMH", cHITIET_PMH.MaPMH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", cHITIET_PMH.MaSP);
            return View(cHITIET_PMH);
        }

        // GET: Manager/CT_PhieuMuaHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_PMH cHITIET_PMH = db.CHITIET_PMH.Find(id);
            if (cHITIET_PMH == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_PMH);
        }

        // POST: Manager/CT_PhieuMuaHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIET_PMH cHITIET_PMH = db.CHITIET_PMH.Find(id);
            db.CHITIET_PMH.Remove(cHITIET_PMH);
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
