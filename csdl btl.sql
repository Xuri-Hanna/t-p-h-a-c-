create database quanlibanhang
use quanlibanhang
go
create table dodung (
madodung nvarchar(50) primary key,
dodung nvarchar(50)
)
create table khach(
makhach nvarchar(10) primary key,
tenkhach nvarchar(50),
diachi nvarchar(50),
dienthoai nvarchar(50),

)
create table hang(
mahang nvarchar(50) primary key,
tenhang nvarchar(50),
madodung nvarchar(50),
soluong int,
dongianhap int,
dongiaban int,
anh nvarchar(200),
ghichu nvarchar(200),
foreign key (madodung) references dodung(madodung)
)
create table nhanvien(
manhanvien nvarchar(50) primary key,
tennhanvien nvarchar(50),
gioitinh nvarchar(50),
diachi nvarchar(50),
dienthoai int ,
ngaysinh datetime
)
create table hdban(
mahdban nvarchar(50) primary key,
manhanvien nvarchar(50),
ngayban datetime,
makhach nvarchar(10),
tongtien int,
foreign key (manhanvien) references nhanvien(manhanvien),
foreign key (makhach) references khach(makhach),
)
create table chitiethdban(
mahdban nvarchar(30) ,
mahang nvarchar(50),
soluong int,
dongia int,
giamgia int,
thanhtien int,
primary key clustered ([mahdban] ASC,[mahang] ASC)

)
alter table hang
drop column ghichu