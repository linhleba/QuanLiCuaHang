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

    public class CT_PhieuBanHangController : Controller

    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // Viet them ham ma san pham vo day

        [HttpGet]

        // Ham lay ra don gia
        public JsonResult GetDonGia(int MaSP)
        {
            decimal UnitPrice = db.SANPHAMs.Single(d => d.MaSP == MaSP).GiaBanRa;
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



        public JsonResult GetItem(int itemID)
        {
            decimal UnitPrice = db.SANPHAMs.Single(d => d.MaSP == itemID).GiaBanRa;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Create([System.Web.Http.FromBody] PhieuBanHangViewModel phieuBanHang)
        {
            CT_PhieuBanHangRepository cT_PhieuBanHangRepository = new CT_PhieuBanHangRepository();
            cT_PhieuBanHangRepository.AddCT_PhieuBanHang(phieuBanHang);

            return Json(data: "Tạo phiếu bán hàng thành công", JsonRequestBehavior.AllowGet);
        }


        //GET: Manager/CT_PhieuBanHang
        public ActionResult Index()
        {
            var cT_PHIEUBANHANG = db.CT_PHIEUBANHANG.Include(c => c.PHIEUBANHANG).Include(c => c.SANPHAM);
            return View(cT_PHIEUBANHANG.ToList());
        }

        // GET: Manager/CT_PhieuBanHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CT_PHIEUBANHANG cT_PHIEUBANHANG = db.CT_PHIEUBANHANG.Find(id);
            var CT_PhieuBanHang = db.CT_PHIEUBANHANG.Include(b => b.PHIEUBANHANG).Include(c => c.SANPHAM);
            var result = (CT_PhieuBanHang.Where(x => x.MaPBH == id)).ToList();
            return View(result);

        }

    
    // GET: Manager/CT_PhieuBanHang/Create
    public ActionResult Create()
        {
            ViewBag.MaPBH = new SelectList(db.PHIEUBANHANGs, "MaPBH", "TenKH");
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham");


            //BanHangContext banHangContext = new BanHangContext();


            //var objectMutipleModel = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(ViewBag.MaPBH, ViewBag.MaSP);
            return View();
        }



        // POST: Manager/CT_PhieuBanHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaPBH,MaSP,SoLuong,DonGia,ThanhTien")] CT_PHIEUBANHANG cT_PHIEUBANHANG)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CT_PHIEUBANHANG.Add(cT_PHIEUBANHANG);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaPBH = new SelectList(db.PHIEUBANHANGs, "MaPBH", "TenKH", cT_PHIEUBANHANG.MaPBH);
        //    ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", cT_PHIEUBANHANG.MaSP);
        //    return View(cT_PHIEUBANHANG);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaPBH,TenKH,NgayLap,TongTien")] PHIEUBANHANG pHIEUBANHANG)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PHIEUBANHANGs.Add(pHIEUBANHANG);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(pHIEUBANHANG);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaPBH,TenKH,NgayLap,TongTien")] PHIEUBANHANG bANHANG)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PHIEUBANHANGs.Add(bANHANG);
        //        //db.CT_PHIEUBANHANG.Add(bANHANG.CT_PHIEUBANGHANG);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(bANHANG);
        //}


        // GET: Manager/CT_PhieuBanHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUBANHANG cT_PHIEUBANHANG = db.CT_PHIEUBANHANG.Find(id);
            if (cT_PHIEUBANHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPBH = new SelectList(db.PHIEUBANHANGs, "MaPBH", "TenKH", cT_PHIEUBANHANG.MaPBH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", cT_PHIEUBANHANG.MaSP);
            return View(cT_PHIEUBANHANG);
        }

        // POST: Manager/CT_PhieuBanHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPBH,MaSP,SoLuong,DonGia,ThanhTien")] CT_PHIEUBANHANG cT_PHIEUBANHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_PHIEUBANHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPBH = new SelectList(db.PHIEUBANHANGs, "MaPBH", "TenKH", cT_PHIEUBANHANG.MaPBH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", cT_PHIEUBANHANG.MaSP);
            return View(cT_PHIEUBANHANG);
        }

        // GET: Manager/CT_PhieuBanHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUBANHANG cT_PHIEUBANHANG = db.CT_PHIEUBANHANG.Find(id);
            if (cT_PHIEUBANHANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEUBANHANG);
        }

        // POST: Manager/CT_PhieuBanHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_PHIEUBANHANG cT_PHIEUBANHANG = db.CT_PHIEUBANHANG.Find(id);
            db.CT_PHIEUBANHANG.Remove(cT_PHIEUBANHANG);
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