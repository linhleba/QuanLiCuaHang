using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiCuaHang.Areas.Manager.Data;
using QuanLiCuaHang.Areas.Manager.ViewModel;

namespace QuanLiCuaHang.Areas.Manager.Controllers
{
    public class BCTonKhoController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // GET: Manager/BCTonKho
        public ActionResult Index(int Thang)
        {
            var bCTONKHOes = db.BCTONKHOes.Include(b => b.SANPHAM);
            return View(bCTONKHOes.Where(x => x.Thang.Equals(Thang)).ToList());
        }

        // GET: Manager/BCTonKho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCTONKHO bCTONKHO = db.BCTONKHOes.Find(id);
            if (bCTONKHO == null)
            {
                return HttpNotFound();
            }
            return View(bCTONKHO);
        }

        // GET: Manager/BCTonKho/Create
        public ActionResult Create()
        {
            //BCTonKhoViewModel viewModelList = new BCTonKhoViewModel();
            //ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham");
            //var bCTONKHOes = db.BCTONKHOes.Include(b => b.SANPHAM);
            //viewModelList.LBCTONKHO = (from bctonkho in db.BCTONKHOes where  bctonkho.Thang == "6" select bctonkho).ToList();
            //var bCTONKHOes = db.BCTONKHOes.Include(b => b.SANPHAM);
            //viewModelList.LBCTONKHO = bCTONKHOes.ToList();

            var bCTONKHOes = db.BCTONKHOes.Include(b => b.SANPHAM);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP");

            return View();
        }

        // POST: Manager/BCTonKho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //public ActionResult Create([Bind(Include = "Thang,Nam,MaSP,Tondau,TonCuoi,SLMuaVao,SLBanRa")] BCTONKHO bCTONKHO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.BCTONKHOes.Add(bCTONKHO);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", bCTONKHO.MaSP);
        //    return View(bCTONKHO);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Thang,Nam,MaSP,Tondau,TonCuoi,SLMuaVao,SLBanRa")] BCTONKHO bCTONKHO)
        {
            if (ModelState.IsValid)
            {
                if (db.BCTONKHOes.Any(x => x.Thang == bCTONKHO.Thang))
                {
                    if (db.BCTONKHOes.Any(x => x.Nam == bCTONKHO.Nam))
                    {
                        //Index(bCTONKHO.Thang);
                        
                        TempData["testmsg"] = "<script> alert('Tạo không thành cônng');</script>";
                    }
                }
                else
                {
                    db.CREATE_BCTONKHO(bCTONKHO.Thang, bCTONKHO.Nam, 0, 0, 0, 0, 0);
                    db.SaveChanges();
                }

            }
            else
            {
                TempData["testmsg"] = "<script> alert('Khong the tao');</script>";
            }
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", bCTONKHO.MaSP);

            return View();

        } 
        // GET: Manager/BCTonKho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCTONKHO bCTONKHO = db.BCTONKHOes.Find(id);
            if (bCTONKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", bCTONKHO.MaSP);
            return View(bCTONKHO);
        }

        // POST: Manager/BCTonKho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Thang,Nam,MaSP,Tondau,TonCuoi,SLMuaVao,SLBanRa")] BCTONKHO bCTONKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bCTONKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSanPham", bCTONKHO.MaSP);
            return View(bCTONKHO);
        }

        // GET: Manager/BCTonKho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCTONKHO bCTONKHO = db.BCTONKHOes.Find(id);
            if (bCTONKHO == null)
            {
                return HttpNotFound();
            }
            return View(bCTONKHO);
        }

        // POST: Manager/BCTonKho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BCTONKHO bCTONKHO = db.BCTONKHOes.Find(id);
            db.BCTONKHOes.Remove(bCTONKHO);
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
