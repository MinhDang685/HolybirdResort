﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ManageHotel.Entity
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class ManageHotelEntities : DbContext
{
    public ManageHotelEntities()
        : base("name=ManageHotelEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<ChiTietGiaoDich> ChiTietGiaoDiches { get; set; }

    public virtual DbSet<DichVuPhong> DichVuPhongs { get; set; }

    public virtual DbSet<GiaoDich> GiaoDiches { get; set; }

    public virtual DbSet<Hang> Hangs { get; set; }

    public virtual DbSet<HeThong> HeThongs { get; set; }

    public virtual DbSet<HinhThuc> HinhThucs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiHeThong> LoaiHeThongs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<TinhTrangGiaoDich> TinhTrangGiaoDiches { get; set; }

    public virtual DbSet<TrangThaiPhong> TrangThaiPhongs { get; set; }


    public virtual ObjectResult<sp_LayDanhSachDoan_Result> sp_LayDanhSachDoan(Nullable<int> idDoan)
    {

        var idDoanParameter = idDoan.HasValue ?
            new ObjectParameter("idDoan", idDoan) :
            new ObjectParameter("idDoan", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LayDanhSachDoan_Result>("sp_LayDanhSachDoan", idDoanParameter);
    }


    public virtual int sp_CapNhatChiTietGiaoDich(Nullable<int> id, Nullable<int> idGiaoDich, Nullable<int> idPhong, Nullable<int> idKhach, Nullable<System.DateTime> ngayBatDau, Nullable<System.DateTime> ngayKetThuc)
    {

        var idParameter = id.HasValue ?
            new ObjectParameter("id", id) :
            new ObjectParameter("id", typeof(int));


        var idGiaoDichParameter = idGiaoDich.HasValue ?
            new ObjectParameter("idGiaoDich", idGiaoDich) :
            new ObjectParameter("idGiaoDich", typeof(int));


        var idPhongParameter = idPhong.HasValue ?
            new ObjectParameter("idPhong", idPhong) :
            new ObjectParameter("idPhong", typeof(int));


        var idKhachParameter = idKhach.HasValue ?
            new ObjectParameter("idKhach", idKhach) :
            new ObjectParameter("idKhach", typeof(int));


        var ngayBatDauParameter = ngayBatDau.HasValue ?
            new ObjectParameter("ngayBatDau", ngayBatDau) :
            new ObjectParameter("ngayBatDau", typeof(System.DateTime));


        var ngayKetThucParameter = ngayKetThuc.HasValue ?
            new ObjectParameter("ngayKetThuc", ngayKetThuc) :
            new ObjectParameter("ngayKetThuc", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CapNhatChiTietGiaoDich", idParameter, idGiaoDichParameter, idPhongParameter, idKhachParameter, ngayBatDauParameter, ngayKetThucParameter);
    }


    public virtual ObjectResult<sp_LayChiTietGiaoDichTheoDoan_Result> sp_LayChiTietGiaoDichTheoDoan(Nullable<int> idDoan)
    {

        var idDoanParameter = idDoan.HasValue ?
            new ObjectParameter("idDoan", idDoan) :
            new ObjectParameter("idDoan", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LayChiTietGiaoDichTheoDoan_Result>("sp_LayChiTietGiaoDichTheoDoan", idDoanParameter);
    }


    public virtual int sp_ThemChiTietGiaoDich(Nullable<int> idGiaoDich, Nullable<int> idPhong, Nullable<int> idKhach, Nullable<System.DateTime> ngayBatDau, Nullable<System.DateTime> ngayKetThuc)
    {

        var idGiaoDichParameter = idGiaoDich.HasValue ?
            new ObjectParameter("idGiaoDich", idGiaoDich) :
            new ObjectParameter("idGiaoDich", typeof(int));


        var idPhongParameter = idPhong.HasValue ?
            new ObjectParameter("idPhong", idPhong) :
            new ObjectParameter("idPhong", typeof(int));


        var idKhachParameter = idKhach.HasValue ?
            new ObjectParameter("idKhach", idKhach) :
            new ObjectParameter("idKhach", typeof(int));


        var ngayBatDauParameter = ngayBatDau.HasValue ?
            new ObjectParameter("ngayBatDau", ngayBatDau) :
            new ObjectParameter("ngayBatDau", typeof(System.DateTime));


        var ngayKetThucParameter = ngayKetThuc.HasValue ?
            new ObjectParameter("ngayKetThuc", ngayKetThuc) :
            new ObjectParameter("ngayKetThuc", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemChiTietGiaoDich", idGiaoDichParameter, idPhongParameter, idKhachParameter, ngayBatDauParameter, ngayKetThucParameter);
    }


    public virtual int sp_XoaChiTietGiaoDich(Nullable<int> id)
    {

        var idParameter = id.HasValue ?
            new ObjectParameter("id", id) :
            new ObjectParameter("id", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaChiTietGiaoDich", idParameter);
    }


    public virtual int sp_XoaChiTietGiaoDichTheoDoan(Nullable<int> id)
    {

        var idParameter = id.HasValue ?
            new ObjectParameter("id", id) :
            new ObjectParameter("id", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaChiTietGiaoDichTheoDoan", idParameter);
    }


    public virtual ObjectResult<sp_LayThongTinDoan_Result> sp_LayThongTinDoan(Nullable<int> id)
    {

        var idParameter = id.HasValue ?
            new ObjectParameter("id", id) :
            new ObjectParameter("id", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LayThongTinDoan_Result>("sp_LayThongTinDoan", idParameter);
    }


    public virtual ObjectResult<sp_SearchAvailableRoom_Result> sp_SearchAvailableRoom(Nullable<int> floor, Nullable<int> state, Nullable<int> level, Nullable<int> numberslot, string datestart, string dateend)
    {

        var floorParameter = floor.HasValue ?
            new ObjectParameter("floor", floor) :
            new ObjectParameter("floor", typeof(int));


        var stateParameter = state.HasValue ?
            new ObjectParameter("state", state) :
            new ObjectParameter("state", typeof(int));


        var levelParameter = level.HasValue ?
            new ObjectParameter("level", level) :
            new ObjectParameter("level", typeof(int));


        var numberslotParameter = numberslot.HasValue ?
            new ObjectParameter("numberslot", numberslot) :
            new ObjectParameter("numberslot", typeof(int));


        var datestartParameter = datestart != null ?
            new ObjectParameter("datestart", datestart) :
            new ObjectParameter("datestart", typeof(string));


        var dateendParameter = dateend != null ?
            new ObjectParameter("dateend", dateend) :
            new ObjectParameter("dateend", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchAvailableRoom_Result>("sp_SearchAvailableRoom", floorParameter, stateParameter, levelParameter, numberslotParameter, datestartParameter, dateendParameter);
    }


    public virtual int sp_CapNhatTinhTrangGiaoDich(Nullable<int> idDoan, Nullable<int> idTinhTrang)
    {

        var idDoanParameter = idDoan.HasValue ?
            new ObjectParameter("idDoan", idDoan) :
            new ObjectParameter("idDoan", typeof(int));


        var idTinhTrangParameter = idTinhTrang.HasValue ?
            new ObjectParameter("idTinhTrang", idTinhTrang) :
            new ObjectParameter("idTinhTrang", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CapNhatTinhTrangGiaoDich", idDoanParameter, idTinhTrangParameter);
    }

}

}
