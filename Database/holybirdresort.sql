create database HOLYBIRDRESORT;
go
use HOLYBIRDRESORT;
go

create table Hang(
/*Thường, trung bình, sang, rất sang, VIP*/
	ID int IDENTITY(1,1),
	ThongTin nvarchar(100),
	PRIMARY KEY (ID)
);
insert into Hang (ThongTin) values (N'Thường');
insert into Hang (ThongTin) values (N'Trung bình');
insert into Hang (ThongTin) values (N'Sang');
insert into Hang (ThongTin) values (N'Rất sang');
insert into Hang (ThongTin) values (N'VIP');
go

create table HinhThuc(
	ID int IDENTITY(1,1),
	ThongTin nvarchar(100), /*1 giường đôi, 1 giường đơn, 2 giường đôi, 2 giường đơn*/
	SoLuongCho int,
	PRIMARY KEY (ID)
);
insert into HinhThuc (ThongTin, SoLuongCho) values (N'1 giường đôi', 2);
insert into HinhThuc (ThongTin, SoLuongCho) values (N'1 giường đơn', 1);
insert into HinhThuc (ThongTin, SoLuongCho) values (N'2 giường đôi', 2);
insert into HinhThuc (ThongTin, SoLuongCho) values (N'2 giường đơn', 1);
go

create table TrangThaiPhong(
	ID int IDENTITY(1,1),
	TrangThai nvarchar(50), /*rảnh, không rảnh*/	
	PRIMARY KEY (ID)
);
insert into TrangThaiPhong (TrangThai) values (N'Rảnh');
insert into TrangThaiPhong (TrangThai) values (N'Không rảnh');
go

create table Phong (
	ID int IDENTITY(1,1),
	MaPhong varchar(10),
	ViTriTang varchar(10),
	Hang int foreign key references Hang(ID),
	HinhThuc int foreign key references HinhThuc(ID),
	DonGia int, 
	TrangThai int foreign key references TrangThaiPhong(ID),
	PRIMARY KEY (ID)
);
 
create table TinhTrangGiaoDich(
	ID int IDENTITY(1,1),
	TinhTrang nvarchar(50), -- đã đăng ký, đã mướn phòng, đã nhận phòng, đã trả phòng, đã bị hủy
	PRIMARY KEY (ID)
);
insert into TinhTrangGiaoDich (TinhTrang) values (N'Đã đăng ký'); -- khi đã nhập thông tin đoàn đầy đủ
insert into TinhTrangGiaoDich (TinhTrang) values (N'Đã mướn phòng'); -- khi đã nhập đủ thông tin mướn phòng (ai sẽ ở phòng nào) 
insert into TinhTrangGiaoDich (TinhTrang) values (N'Đã nhận phòng'); -- đã đến nhận phòng
insert into TinhTrangGiaoDich (TinhTrang) values (N'Đã trả phòng'); -- giao dịch hoàn tất
insert into TinhTrangGiaoDich (TinhTrang) values (N'Đã bị hủy'); 
/* đã bị hủy: k đủ phòng, k nhập đủ thông tin mướn phòng hoặc mướn phòng xong k nhận*/

create table GiaoDich(
	ID int IDENTITY(1,1),
	MaDoan varchar(50),
	TenDangNhap nvarchar(100),
	MatKhau nvarchar(100),
	ID_NguoiDaiDien int,
	SoNguoi int,
	SoPhong int,
	NgayBatDau Datetime,
	NgayKetThuc Datetime,
	TinhTrang int,
	TongTien int,
	PRIMARY KEY (ID)
);

create table KhachHang (
	ID int IDENTITY(1,1),
	ID_GiaoDich int foreign key references GiaoDich(ID),
	HoTen nvarchar(100),
	CMND varchar(50),
	MatKhau nvarchar(100),
	PRIMARY KEY (ID)
);

create table ChiTietGiaoDich(
	ID int IDENTITY(1,1),
	ID_GiaoDich int foreign key references GiaoDich(ID),
	ID_MaPhong int foreign key references Phong(ID),
	ID_KhachHang int foreign key references KhachHang(ID),
	NgayBatDau Datetime,
	NgayKetThuc Datetime,
	ThanhTien int, /*đơn giá phòng + tất cả dịch vụ phòng khách đã sử dụng*/
	PRIMARY KEY (ID)
);

create table DichVuPhong (
	ID int IDENTITY(1,1),
	ID_ChiTietGiaoDich int foreign key references ChiTietGiaoDich(ID),
	GhiChu nvarchar(100), /*vd: hư quạt 50k*/
	ThanhTien int,
	PRIMARY KEY (ID)
);

create table LoaiHeThong (
	ID int IDENTITY(1,1),
	LoaiHeThong nvarchar(100), /*hiện tại có 2 loại là hệ thống tại resort và hệ thống online*/
	PRIMARY KEY (ID)
);
insert into LoaiHeThong (LoaiHeThong) values ('resort');
insert into LoaiHeThong (LoaiHeThong) values ('online');

create table HeThong (
	ID int IDENTITY(1,1),
	DiaChi nvarchar(100),
	ID_LoaiHeThong int foreign key references LoaiHeThong(ID),
	PRIMARY KEY (ID)
);
insert into HeThong (DiaChi, ID_LoaiHeThong) values (N'Nha Trang',1);
insert into HeThong (DiaChi, ID_LoaiHeThong) values (N'Da Nang',2);
insert into HeThong (DiaChi, ID_LoaiHeThong) values (N'New York',2);
insert into HeThong (DiaChi, ID_LoaiHeThong) values (N'Sydney',2);

create table NhanVien (
	ID int IDENTITY(1,1),
	TenDangNhap nvarchar(100),
	MatKhau nvarchar(100),
	ID_HeThong int,
	constraint FK_NV_HT foreign key (ID_HeThong) references HeThong(ID),
	PRIMARY KEY (ID)
);
insert into NhanVien (TenDangNhap, MatKhau, ID_HeThong) values (N'nv001','123', 1);
insert into NhanVien (TenDangNhap, MatKhau, ID_HeThong) values (N'nv002','123', 1);
insert into NhanVien (TenDangNhap, MatKhau, ID_HeThong) values (N'nv003','123', 2);
insert into NhanVien (TenDangNhap, MatKhau, ID_HeThong) values (N'nv004','123', 2);
insert into NhanVien (TenDangNhap, MatKhau, ID_HeThong) values (N'nv005','123', 3);
insert into NhanVien (TenDangNhap, MatKhau, ID_HeThong) values (N'nv006','123', 4);
go

create function fRandomInteger (@seed uniqueidentifier, @from int, @to int)
returns int
as 
begin
	return ABS(Checksum(@seed) % (@to - @from + 1)) + @from
end
go

create procedure sp_KhoiTaoDanhSachPhong @roomInAFloor int, @totalFloor int
as 
begin
	declare @i int
	declare @j int
	set @i = 1
	set @j = 1
	while(@i <= @totalFloor)
	begin
		while(@j <= @roomInAFloor)
		begin
			declare @hang int
			declare @hinhThuc int
			declare @maPhong nvarchar(10)
			declare @donGia int
			set @maPhong = 'R' + CAST(@j as varchar) + 'F' + CAST(@i as varchar)
			set @hang = dbo.fRandomInteger(NewID(),1,5)
			set @hinhThuc = dbo.fRandomInteger(NewID(),1,4)
			set @donGia = @hang * 100000 + @hinhThuc * 50000
			insert into Phong (MaPhong, ViTriTang, Hang, HinhThuc, DonGia, TrangThai) 
			values (@maPhong, @i, @hang, @hinhThuc, @donGia, 1)
			set @j = @j + 1
		end
		set @j = 1
		set @i = @i + 1
	end
end
go

EXEC sp_KhoiTaoDanhSachPhong 10, 10
go


/*Store Search Phong available*/
create procedure sp_SearchAvailableRoom(
		@floor int
	  , @state int
	  , @level int
	  , @numberslot int
	  , @datestart varchar(20)
	  , @dateend varchar(20))
AS
BEGIN
	select p.*, ht.ThongTin, h.ThongTin AS roomlevel
	from Phong p, HinhThuc ht, Hang h
	where	p.ViTriTang = @floor
		AND p.TrangThai = @state
		AND p.Hang = @level
		AND p.HinhThuc = ht.ID
		AND ht.ID = @numberslot
		AND p.ID NOT IN(
			select ct.ID_MaPhong
			from ChiTietGiaoDich ct
			where  CONVERT(varchar, ct.NgayBatDau, 111) between  @datestart AND @dateend
				OR CONVERT(varchar, ct.NgayKetThuc, 111) between @datestart AND @dateend
		)
		AND p.Hang = h.ID
END

EXEC sp_SearchAvailableRoom 1, 1,5, 1, '2018/01/01', '2018/06/16'
go


create function fGetRoomPrice(@roomId int)
returns int
as
begin 
	declare @price int
	select @price = DonGia
	from Phong
	where ID = @roomId
	return @price
end
go

create procedure sp_ThemChiTietGiaoDich @idGiaoDich int, @idPhong int, @idKhach int, 
										@ngayBatDau Datetime, @ngayKetThuc Datetime
as
begin
	declare @thanhTien int
	set @thanhTien = dbo.fGetRoomPrice(@idPhong)
	insert into ChiTietGiaoDich 
				(ID_GiaoDich, ID_MaPhong, ID_KhachHang, NgayBatDau, NgayKetThuc, ThanhTien)
		values (@idGiaoDich, @idPhong, @idKhach, @ngayBatDau, @ngayKetThuc, @thanhTien)
end








