use Project_BanHang
go

/*=============DANH MUC THIẾT BỊ=============*/

Create table ThietBi
( 
	MATB nvarchar(15) primary key,
	TENTB nvarchar(30)not null,
	LOAI nvarchar(30)not null,
	SOLUONG int not null,
	DONGIA float not null,
)

/*==============DANH MUC Khách Hàng============*/

Create table KhachHang
(
	MAKH nvarchar(15) not null primary key,
	TENKH nvarchar(30) not null,
	DIACHI nvarchar(50) not null,
	SDT int,	
)


/*==================Hoa Don========================*/

create table HoaDon
(
	 MAHD nvarchar (15)not null primary key,
	 MAKH nvarchar(15) not null,
	 DIACHIGIAO nvarchar(50) not null,
	 GIAOHANG int not null,
	 THANHTIEN float not null,
	 NGAYHD DATETIME not null,
)

/*=====================CTHD===================*/

Create table CTHD
(
	MAHD nvarchar(15) not null,
	MATB nvarchar(15) not null ,
	SOLUONG INT not null,
)

alter table CTHD
alter column MATB nvarchar(15)
go
/*==========================TAO KHOA NGOAI==============================*/
Alter table CTHD
add Constraint MAHD_MATB_pk primary key (MAHD,MATB)
Alter table CTHD
	add	constraint MAHD_fk foreign key (MAHD) references HoaDon(MAHD)
Alter table CTHD
	add	constraint MATB_fk foreign key (MATB) references ThietBi(MATB)
	Alter table HoaDon
	add	constraint MAKH_fk foreign key (MAKH) references KhachHang(MAKH)


/*==================NHAP DU LIEU====================*/


----Hien thi thiet bi theo loai-----
CREATE PROC USP_LoadTB
AS
BEGIN
	SELECT TB.MATB AS [Mã Thiết bị], TB.TENTB AS [Tên thiết bị],TB.LOAI AS [Danh mục],TB.SOLUONG AS [Số lượng],TB.DONGIA AS [Đơn giá] FROM ThietBi TB
END
GO
----show số lượng thiết bị sau khi trừ----
CREATE PROC USP_ShowQuantityofTB
@matb nvarchar(20)
AS
BEGIN
	SELECT SOLUONG FROM dbo.ThietBi WHERE MATB = @matb
END
GO
----Xóa thiết bị theo mã-----
CREATE PROC USP_DelThietBi 
@matb NVARCHAR(50) 
AS
BEGIN
	DELETE dbo.ThietBi WHERE MATB = @matb  
END
GO
----Load danh sách khách hàng----
CREATE PROC USP_LoadListMember
AS
BEGIN
	SELECT MAKH AS [Mã Khách Hàng], TENKH AS [Họ tên Khách hàng], GIOITINH AS [Giới tính], DIACHI AS [Địa chỉ], NGAYSINH AS [Ngày sinh], SDT AS [Điện thoại] FROM dbo.KhachHang
END
GO
----Tìm khách hàng theo mã----
CREATE PROC USP_FindMember 
@makh NVARCHAR(100)
AS
BEGIN
	SELECT MAKH AS [Mã Khách Hàng], TENKH AS [Họ tên Khách hàng], GIOITINH AS [Giới tính], DIACHI AS [Địa chỉ], NGAYSINH AS [Ngày sinh], SDT AS [Điện thoại] FROM dbo.KhachHang WHERE MAKH = @makh
END
GO
----MÃ THIẾT BỊ AUTO----
CREATE FUNCTION [dbo].[AUTO_IDTB]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)
	IF (SELECT COUNT(MATB) FROM ThietBi) = 0
		SET @ID = '00000001'
	ELSE
		SELECT @ID = MAX(RIGHT(MATB, 7)) FROM ThietBi
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'TB0000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'TB000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEn @ID <100 AND @ID >9 THEN 'TB00000'+ CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
-----------------makh auto------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDKH]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)
	IF (SELECT COUNT(MAKH) FROM KhachHang) = 0
		SET @ID = '00000001'
	ELSE
		SELECT @ID = MAX(RIGHT(MAKH, 7)) FROM KhachHang
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'KH0000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'KH000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEn @ID <100 AND @ID >9 THEN 'KH00000'+ CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO