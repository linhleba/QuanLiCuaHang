using QuanLiCuaHang.Areas.Manager.Data;
using QuanLiCuaHang.Areas.Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Areas.Manager.Repository
{
    public class ThamSoRepository
    {
        private QUANLYCUAHANGEntity objQUANLYCUAHANGEntity;

        public ThamSoRepository()
        {
            objQUANLYCUAHANGEntity = new QUANLYCUAHANGEntity();
        }

        public bool AddThamSo(ThamSoViewModel thamsoViewModel)
        {
            THAMSO thamso = new THAMSO();
            thamso.PhanTramTraTruoc = thamsoViewModel.PhanTramTraTruoc;
            var db = objQUANLYCUAHANGEntity.THAMSOes.Single(c => c.Ma == 1);
            //objQUANLYCUAHANGEntity.THAMSOes.Add(thamso);
            db.PhanTramTraTruoc = thamsoViewModel.PhanTramTraTruoc;
            //objQUANLYCUAHANGEntity.THAMSOes.Add(db);
            objQUANLYCUAHANGEntity.SaveChanges();
            return true;

        }
    }
}