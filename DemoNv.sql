create table nhanvien(
	manv nvarchar(20),
	hoten nvarchar(50),
	ngaysinh date,
	gioitinh nvarchar(10),
	quequan nvarchar(20),
	sodt varchar(10),
	luong float,
	chucvu nvarchar(10),
	primary key (manv)
);
insert into NHANVIEN values (N'NV.LT1',N'văn công hào', '2002-12-20', N'nam',N'Bình Định', '0397841046', 2000000, N'Lễ tân');
insert into NHANVIEN values (N'NV.LT2',N'nguyễn thị hồng nhung', '2003-04-18', N'nữ',N'Bình Định', '0397841046', 2000000, N'Lễ tân');
insert into NHANVIEN values (N'NV.TN1',N'nguyễn cao nam', '2000-08-12', N'nam',N'Hà Nội', '0397841046', 2000000, N'Thu ngân');
go
select * from nhanvien;