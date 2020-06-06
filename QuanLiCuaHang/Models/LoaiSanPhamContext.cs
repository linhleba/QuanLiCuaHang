using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Models
{
    public class LoaiSanPhamContext : DbContext
    {
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }

        public void AddLoaiSanPham(LoaiSanPham loaisanpham)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LoaiSanPhamContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddLoaiSanPham", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paraTen = new SqlParameter();
                paraTen.ParameterName = "@TenLoaiSP";
                paraTen.Value = loaisanpham.TenLoaiSP;
                cmd.Parameters.Add(paraTen);

                SqlParameter paraLoiNhuan = new SqlParameter();
                paraLoiNhuan.ParameterName = "@PhanTramLoiNhuan";
                paraLoiNhuan.Value = loaisanpham.PhanTramLoiNhuan;
                cmd.Parameters.Add(paraLoiNhuan);

                SqlParameter paraDVT = new SqlParameter();
                paraDVT.ParameterName = "@MaDVT";
                paraDVT.Value = loaisanpham.MaDVT;
                cmd.Parameters.Add(paraDVT);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveLoaiSanPham(LoaiSanPham loaisanpham)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LoaiSanPhamContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SAVELOAISANPHAM", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // ID bi hidden 
                SqlParameter paraID = new SqlParameter();
                paraID.ParameterName = "@MaLoaiSP";
                paraID.Value = loaisanpham.MaLoaiSP;
                cmd.Parameters.Add(paraID);

                SqlParameter paraTen = new SqlParameter();
                paraTen.ParameterName = "@TenLoaiSP";
                paraTen.Value = loaisanpham.TenLoaiSP;
                cmd.Parameters.Add(paraTen);

                SqlParameter paraLoiNhuan = new SqlParameter();
                paraLoiNhuan.ParameterName = "@PhanTramLoiNhuan";
                paraLoiNhuan.Value = loaisanpham.PhanTramLoiNhuan;
                cmd.Parameters.Add(paraLoiNhuan);

                SqlParameter paraDVT = new SqlParameter();
                paraDVT.ParameterName = "@MaDVT";
                paraDVT.Value = loaisanpham.MaDVT;
                cmd.Parameters.Add(paraDVT);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete 
        public void DeleteLoaiSanPham(int MaLoaiSP)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LoaiSanPhamContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETELOAISANPHAM", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paraID = new SqlParameter();
                paraID.ParameterName = "@MaLoaiSP";
                paraID.Value = MaLoaiSP;
                cmd.Parameters.Add(paraID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}


    