use HOLYBIRDRESORT
go

CREATE PROCEDURE sp_CapNhatDichVuPhong @idGiaoDich int, @idKhach int, @idPhong int, @noiDung nvarchar(100),@tien int
AS
BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	declare @idCTGD int = (select ID from ChiTietGiaoDich 
	where ID_GiaoDich = @idGiaoDich and ID_KhachHang = @idKhach and ID_MaPhong = @idPhong)
	IF (@idCTGD IS NULL)
	BEGIN
		RAISERROR (N'Giao dich, khach hang va phong khong khop voi nhau',16,1)
		ROLLBACK
	END
	ELSE
	BEGIN TRY
		declare @tienPhongHienTai int = (select ThanhTien from ChiTietGiaoDich where ID = @idCTGD)
		declare @tienPhongMoi int = @tienPhongHienTai + @tien
		INSERT INTO DichVuPhong (ID_ChiTietGiaoDich, GhiChu, ThanhTien) values(@idCTGD, @noiDung, @tien)
		UPDATE ChiTietGiaoDich
		SET ThanhTien = @tienPhongMoi
		WHERE ID = @idCTGD
	END TRY
	BEGIN CATCH
		RAISERROR (N'LỖI HỆ THỐNG',16,1)
		ROLLBACK TRAN
		RETURN
	END CATCH
COMMIT TRANSACTION
GO

CREATE PROCEDURE sp_TinhThanhTienPhong @idGiaoDich int, @idPhong int
AS
BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	declare @idCTGD int = (select ID from ChiTietGiaoDich 
	where ID_GiaoDich = @idGiaoDich and ID_MaPhong = @idPhong)
	IF (@idCTGD IS NULL)
	BEGIN
		RAISERROR (N'Giao dich va phong khong khop voi nhau',16,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		SELECT SUM(ct.ThanhTien)
		FROM ChiTietGiaoDich ct
		WHERE ct.ID_MaPhong = @idPhong
	END
COMMIT TRANSACTION
GO


--Lỗi UNREPEATABLE READ
--Khách hàng đăng nhập
CREATE PROCEDURE sp_DangNhap
(@tendangnhap NVARCHAR(100), @matkhau NVARCHAR(100))
AS
BEGIN TRAN
	BEGIN TRY
		IF(NOT EXISTS (SELECT * FROM GiaoDich WHERE TenDangNhap = @tendangnhap))
		BEGIN
			PRINT @tendangnhap + N' KHÔNG TỒN TẠI'
			ROLLBACK TRAN
			RETURN
		END
		IF(NOT EXISTS(SELECT * FROM GiaoDich WHERE TenDangNhap = @tendangnhap AND MatKhau = @matkhau))
		BEGIN
			PRINT N'SAI MẬT KHẨU'
			ROLLBACK TRAN
			RETURN
		END
		IF(NOT EXISTS(SELECT * FROM GiaoDich WHERE TenDangNhap = @tendangnhap AND MatKhau = @matkhau AND TinhTrang <> 4 AND TinhTrang <> 5))
		BEGIN
			PRINT N'TÀI KHOẢN TRONG GIAO DỊCH NÀY ĐÃ BỊ XÓA'
			ROLLBACK TRAN
			RETURN
		END
		WAITFOR DELAY '0:0:05'
		SELECT * FROM GiaoDich WHERE TenDangNhap = @tendangnhap AND MatKhau = @matkhau AND TinhTrang <> 4 AND TinhTrang <> 5
		PRINT N'ĐĂNG NHẬP THÀNH CÔNG'
	END TRY
	BEGIN CATCH
		RAISERROR (N'LỖI HỆ THỐNG',16,1)
		ROLLBACK TRAN
		RETURN
	END CATCH
COMMIT TRAN
GO

--Hủy giao dich(khóa tài khoản)
CREATE PROCEDURE sp_CapNhatTinhTrangGiaoDich
(@id INT, @tinhtrang INT)
AS
BEGIN TRAN
	BEGIN TRY
		UPDATE GiaoDich
		SET TinhTrang = @tinhtrang
		WHERE ID = @id
	END TRY
	BEGIN CATCH
		RAISERROR (N'LỖI HỆ THỐNG',16,1)
		ROLLBACK TRAN
		RETURN
	END CATCH	
COMMIT TRAN
go
--Lỗi DIRTY READ
--Tạo mới giao dịch
CREATE PROCEDURE sp_TaoMoiGiaoDich
(@madoan VARCHAR(50), @tendangnhap NVARCHAR(100), @matkhau NVARCHAR(100), @songuoi INT, @sophong INT
, @ngaybatdau DATETIME, @ngayketthuc DATETIME, @tinhtrang INT, @tongtien INT)
AS
BEGIN TRAN

	INSERT INTO GiaoDich (MaDoan, TenDangNhap, MatKhau, SoNguoi, SoPhong, NgayBatDau, NgayKetThuc, TinhTrang, TongTien)
	VALUES (@madoan, @tendangnhap, @matkhau, @songuoi, @sophong, @ngaybatdau, @ngayketthuc, @tinhtrang, @tongtien)
	waitfor delay '0:0:10'

	IF @ngaybatdau <= @ngayketthuc
		COMMIT TRAN
	ELSE
		ROLLBACK TRAN

GO
--Lấy tất cả giao dịch
CREATE PROCEDURE sp_LayTatCaGiaoDich
AS
BEGIN TRAN
	SET TRAN ISOLATION LEVEL READ UNCOMMITTED
	BEGIN TRY
		SELECT * 
		FROM GiaoDich
	END TRY
	BEGIN CATCH
		DECLARE @ERRORMSG NVARCHAR(1000)
		SET @ERRORMSG = N'LỖI : ' + ERROR_MESSAGE()
		RAISERROR (@ERRORMSG, 16,1)
		ROLLBACK TRAN
		RETURN
	END CATCH
COMMIT TRAN
go
-----------------------

create procedure sp_SearchAvailableRoom(
		@floor int
	  , @state int
	  , @level int
	  , @numberslot int
	  , @datestart varchar(20)
	  , @dateend varchar(20))
AS
BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	declare @start int = DATEDIFF(dd, '12/30/1899', @datestart)
	declare @end int = DATEDIFF(dd, '12/30/1899', @dateend)
	IF (@end < @start) 
	BEGIN
		RAISERROR (N'Ngày bắt đầu lớn hơn ngày kết thúc',16,1)
		ROLLBACK
	END
	ELSE IF NOT EXISTS (select p.*, ht.ThongTin, h.ThongTin AS roomlevel, @datestart AS ngayBatDau, @dateend AS ngayKetThuc
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
						AND p.Hang = h.ID)
	BEGIN
		RAISERROR (N'Không có phòng thỏa yêu cầu đã chọn',16,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		select p.*, ht.ThongTin, h.ThongTin AS roomlevel, @datestart AS ngayBatDau, @dateend AS ngayKetThuc
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
COMMIT TRANSACTION
go

create procedure sp_ThemChiTietGiaoDich @idGiaoDich int, @idPhong int, @idKhach int, 
										@ngayBatDau Datetime, @ngayKetThuc Datetime
as
begin transaction
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	declare @thanhTien int
	declare @start int = DATEDIFF(dd, '12/30/1899', @ngayBatDau)
	declare @end int = DATEDIFF(dd, '12/30/1899', @ngayKetThuc)
	IF (@end < @start) 
	BEGIN
		RAISERROR (N'Ngày bắt đầu lớn hơn ngày kết thúc',16,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		set @thanhTien = dbo.fGetRoomPrice(@idPhong) * abs(@end - @start + 1)
		insert into ChiTietGiaoDich (ID_GiaoDich, ID_MaPhong, ID_KhachHang, NgayBatDau, NgayKetThuc, ThanhTien)
				values (@idGiaoDich, @idPhong, @idKhach, @ngayBatDau, @ngayKetThuc, @thanhTien)
	END
commit transaction
go

create procedure sp_XoaChiTietGiaoDich @id int
as
begin transaction
	if not exists (select * from ChiTietGiaoDich where ID = @id)
	begin
		RAISERROR (N'Chi tiet giao dich khong ton tai',16,1)
		ROLLBACK
	end
	else 
	begin
		delete from ChiTietGiaoDich
		where ID = @id
	end
commit transaction
go








