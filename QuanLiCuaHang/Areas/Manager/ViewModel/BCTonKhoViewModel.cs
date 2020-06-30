using QuanLiCuaHang.Areas.Manager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Areas.Manager.ViewModel
{
    public class BCTonKhoViewModel
    {
        public BCTONKHO BCTONKHO { get; set; }
        public IEnumerable<BCTONKHO> LBCTONKHO { get; set; }


    }
}