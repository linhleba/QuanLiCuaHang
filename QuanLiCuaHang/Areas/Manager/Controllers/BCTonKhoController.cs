using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using QuanLiCuaHang.Areas.Manager.Data;
using QuanLiCuaHang.Areas.Manager.ViewModel;
using System.Data.Entity.Core.Objects;
using System.IO;
using ClosedXML.Excel;

namespace QuanLiCuaHang.Areas.Manager.Controllers
{
   
    public class BCTonKhoController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        [HttpPost]
        public FileResult Export()
        {
            QUANLYCUAHANGEntity entities = new QUANLYCUAHANGEntity();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("TenSP"),
                                            new DataColumn("Tondau"),
                                            new DataColumn("TonCuoi"),
                                            new DataColumn("SLMuaVao"),
                                             new DataColumn("SLBanRa"),
                                            });

            var bctonkhos = from bctonkho in entities.BCTONKHOes.ToList()
                            select bctonkho;

            foreach (var bctonkho in bctonkhos)
            {
                dt.Rows.Add(bctonkho.SANPHAM.TenSanPham, bctonkho.Tondau, bctonkho.TonCuoi, bctonkho.SLMuaVao, bctonkho.SLBanRa);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
        // GET: Manager/BCTonKho
        public ActionResult Index(int? Thang, int? Nam)
        {
            //var thang = Convert.ToInt32(Thang);
            var bCTONKHOes = db.BCTONKHOes.Include(b => b.SANPHAM);

            var result = (bCTONKHOes.Where(x => x.Thang == Thang && x.Nam == Nam ).ToList());
            if (result.Count == 0)
            {
                TempData["testmsg"] = "<script> alert('Báo cáo tháng này chưa được tạo');</script>";
            }                
            return View(result);
            //return View(bCTONKHOes.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Thang,Nam,MaSP,Tondau,TonCuoi,SLMuaVao,SLBanRa")] BCTONKHO bCTONKHO)
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
                    TempData["testmsg"] = "<script> alert('Tạo thành cônng');</script>";
                    db.TAO_BCTONKHO(bCTONKHO.Thang, bCTONKHO.Nam, 0, 0, 0, 0, 0);
               
                    db.SaveChanges();
                }

            }
            else
            {
                TempData["testmsg"] = "<script> alert('Khong the tao');</script>";
            }
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", bCTONKHO.MaSP);
            //return RedirectToAction("Index", "BCTonKho", bCTONKHO.Thang);
            return View();

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
          
            var bCTONKHOes = db.BCTONKHOes.Include(b => b.SANPHAM);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP");

            return RedirectToAction("Index", "BCTonKho", new { Thang = 1, Nam = 2020 });
            //return View();
        
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BCTONKHO bCTONKHO)
        {
            if (ModelState.IsValid)
            {
                if (db.BCTONKHOes.Any(x => x.Thang == bCTONKHO.Thang && x.Nam == bCTONKHO.Nam))
                {        
                        TempData["testmsg"] = "<script> alert('Báo cáo đã tạo, vui lòng nhấn tra cứu để xem thông tin');</script>";

                }


               else
                {
                    db.TAO_BCTONKHO(bCTONKHO.Thang, bCTONKHO.Nam, 0, 0, 0, 0, 0);
                    db.SaveChanges();
                }
            }
            else
            {
                TempData["testmsg"] = "<script> alert('Khong the tao');</script>";
            }
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", bCTONKHO.MaSP);

            ViewBag.Thang = bCTONKHO.Thang;

            ViewBag.Nam = bCTONKHO.Nam;
            return RedirectToAction("Index", "BCTonKho", new { ViewBag.Thang, ViewBag.Nam });
            //return View("Index");

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
