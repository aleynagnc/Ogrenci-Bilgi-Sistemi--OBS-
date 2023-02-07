create database ObsDb
use ObsDb
create table Yonetici(
YoneticiID char(5),
YoneticiSifre varchar(15)
)
alter table Yonetici add YoneticiYetkiID char(1) constraint ck_yyetki check(YoneticiYetkiID in ('1')) 
constraint df_yoneticiyetki default('1')

CREATE TABLE Fakulte(
FakulteID int PRIMARY KEY IDENTITY,
FakulteAd varchar(150) not null,
)


create table Yetki(
Yetkiid char(1),
Yetkili varchar(15)
)

CREATE TABLE OgrenciIsleri(
PersonelID int identity(1,1) Primary Key,
PersonelAd varchar (30) not null,
PersonelSoyad varchar (50) not null,
PersonelTel char(10)
	Constraint ck_personeltel
	check(PersonelTel like '[5][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
PersonelMail varchar(60) 
	Constraint ck_permail
	Check (PersonelMail like '_%@duzce.edu.tr'),
PersonelSifre varchar(15),
)
alter table OgrenciIsleri add PersonelYetkiID char(1) constraint ck_pyetki check(PersonelYetkiID in ('3')) 
constraint df_personelyetki default('3')

CREATE TABLE Bolum(
BolumID int identity PRIMARY KEY,
BolumAd varchar(150) not null,
PersonelID int 
	constraint fk_personel
	foreign key references OgrenciIsleri(PersonelID) on delete set Null,
FakulteID int 
	constraint fk_fakulte
	foreign key references Fakulte(FakulteID) on delete cascade,
)

create table Ders(
DersKodu char(5) primary key
 constraint ck_derskodu
 check(derskodu like '[A-Z][A-Z][0-9][0-9][0-9]'),
Yariyil char(1)
 constraint ck_dersyariyil
 check(yariyil like '[0-9]'),
DersAdi varchar(100),
Dil varchar(15)
 constraint ck_dersdil
 check(dil in ('Türkçe','Ýngilizce')),
Kredi float,
Akts float,
BolumID int
	constraint fk_bolum
	foreign key references Bolum(BolumID) on delete cascade
)


CREATE TABLE OgretimElemani(
OgrtID char(10) PRIMARY KEY,
 constraint ck_OgrtID
 check(OgrtID like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
OgrtAd varchar(50) not null,
OgrtSoyad varchar(50) not null,
Unvan varchar(50),
OgrtMail varchar(60)
	constraint ck_OgrtMail
	check(OgrtMail like '_%@duzce.edu.tr'),
OgrtSifre varchar(15)
)
alter table OgretimElemani add OgrtYetkiID char(1) constraint ck_oeyetki check(OgrtYetkiID in ('2')) 
constraint df_ogrteyetki default('2')

create table calisir(
OgrtID char(10)
	constraint fk_ogrt
	foreign key references OgretimElemani(OgrtID) on delete set null,
BolumID int
	constraint fk_bolumm
	foreign key references Bolum(BolumID) on delete set null
)


create table KayitOnaylar(
OgrtID char(10)
	constraint fk_ogrtID
	foreign key references OgretimElemani(OgrtID)on delete set null,
DersKodu char(5)
	constraint fk_derskodu
	foreign key references Ders(DersKodu)on delete set null,
OnayTarihi date
)

create table Ogrenci(
OgrNo char(9) primary key 
 constraint ck_ogrno
 check(ogrno like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
OgrAd varchar(30) not null,
OgrSoyad varchar(50) not null,
Cinsiyet char(1)
	constraint ck_cinsiyet
	check(cinsiyet in('E','K')),
DogumTar date,
OgrTelNo char(10)
 constraint ck_OgrTelNo
 check(OgrTelNo like '[5][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
Sinif varchar(8)
	constraint ck_sinif
	check(Sinif in('Hazýrlýk','1','2','3','4')),
OgrResim varchar(250),
OgrMail varchar(60)
	constraint ck_ogrmail
	check(OgrMail like '_%@ogr.duzce.edu.tr'),
OgrSifre varchar(15),
DanismanID char(10)
	constraint fk_ogrtIDD
	foreign key references OgretimElemani(OgrtID) on delete set null,
BolumID int
	constraint fk_bolummm
	foreign key references Bolum(BolumID) on delete set null,
PersonelID int 
	constraint fk_personell
	foreign key references OgrenciIsleri(PersonelID)on delete set null
)
alter table Ogrenci add OgrYetkiID char(1) constraint ck_oyetki check(OgrYetkiID in ('4')) 
constraint df_ogryetki default('4')


create table Not_(
NotID int primary key identity, 
vize int,
final int,
ortalama float,
harfnotu char(2)
	constraint ck_harfnotu
	check(harfnotu like '[A-F][A-F]'),
OgrtID char(10)
	constraint fk_ogrtI
	foreign key references OgretimElemani(OgrtID) on delete set null,
DersKodu char(5)
	constraint fk_derskoduu
	foreign key references Ders(DersKodu) on delete cascade,
OgrNo char(9)
	constraint fk_ogrno
	foreign key references Ogrenci(OgrNo) on delete cascade
)

create table DersSecme(
DersSecID int primary key,
OgrNo char(9)
	constraint fk_ogrrno
	foreign key references Ogrenci(OgrNo),
BolumID int
	constraint fk_boluumm
	foreign key references Bolum(BolumID) on delete set null,
DersKodu char(5)
	constraint fk_dersskoduu
	foreign key references Ders(DersKodu)
)

create table SilinenOgrtKayit(
OgrtID char(10),
OgrtAd varchar(50),
OgrtSoyad varchar(50),
Unvan varchar(50),
OgrtMail varchar(60),
OgrtSifre varchar(15)
)

create table SilinenDersKayit(
DersKodu char(5),
Yariyil char(1),
DersAdi varchar(100),
Dil varchar(15),
Kredi float,
Akts float,
BolumID int,
)


create table SilinenBolumKayit(
BolumID int,
BolumAd varchar(150),
PersonelID int ,
FakulteID int 
)


create table SilinenFakulteKayit(
FakulteID int, 
FakulteAd varchar(150)
)


create table SilinenPerKayit(
PersonelID int ,
PersonelAd varchar (30),
PersonelSoyad varchar (50),
PersonelTel char(10),
PersonelMail varchar(60),
PersonelSifre varchar(15)
)

create table SilinenOgrKayit(
OgrNo char(9),
OgrAd varchar(30),
OgrSoyad varchar(50),
Cinsiyet char(1),
DogumTar date,
OgrTelNo char(10),
Sinif varchar(8),
OgrResim varchar(250),
OgrMail varchar(60),
OgrSifre varchar(15),
DanismanID char(10),
BolumID int,
PersonelID int ,
)


