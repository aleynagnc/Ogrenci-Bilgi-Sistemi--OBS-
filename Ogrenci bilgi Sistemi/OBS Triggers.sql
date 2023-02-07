create trigger ogrsil
on Ogrenci
after delete
as
insert into dbo.SilinenOgrKayit(OgrNo, OgrAd, OgrSoyad, Cinsiyet, DogumTar, OgrTelNo, Sinif,
OgrResim, OgrMail, OgrSifre, DanismanID,BolumID,PersonelID)
select d.OgrNo,d.OgrAd,d.OgrSoyad,d.Cinsiyet,d.DogumTar, d.OgrTelNo, d.Sinif, 
d.OgrResim,d.OgrMail,d.OgrSifre, d.DanismanID, d.BolumID,d.PersonelID
from deleted d


create trigger ogrtsil
on OgretimElemani
after delete 
as
insert into dbo.SilinenOgrtKayit(OgrtID, OgrtAd, OgrtSoyad, Unvan, OgrtMail, OgrtSifre)
select d.OgrtID, d.OgrtAd, d.OgrtSoyad, d.Unvan,d.OgrtMail, d.OgrtSifre
from deleted d


create trigger derssil
on Ders
after delete 
as
insert into dbo.SilinenDersKayit(DersKodu, Yariyil, DersAdi, Dil, Kredi, Akts, BolumID)
select d.DersKodu, d.Yariyil, d.DersAdi, d.Dil,d.Kredi, d.Akts,d.BolumID
from deleted d


create trigger bolumsil
on Bolum
after delete 
as
insert into dbo.SilinenBolumKayit(BolumID,BolumAd,PersonelID,FakulteID)
select d.BolumID, d.BolumAd, d.PersonelID, d.FakulteID
from deleted d


create trigger persil
on OgrenciIsleri
after delete 
as
insert into dbo.SilinenPerKayit(PersonelID,PersonelAd,PersonelSoyad,PersonelTel,PersonelMail,PersonelSifre)
select d.PersonelID,d.PersonelAd,d.PersonelSoyad,d.PersonelTel,d.PersonelMail,d.PersonelSifre
from deleted d

create trigger fakultesil
on Fakulte
after delete
as
insert into dbo.SilinenFakulteKayit(FakulteID,FakulteAd)
select d.FakulteID,d.FakulteAd
from deleted d

create trigger YetkiKoru
on Yetki
instead of delete 
as
begin
print('Yetki Silinemez')
rollback
end


create trigger ogrEklendi
on Ogrenci
for insert
as
declare @OgrAd varchar(30)
declare @OgrSoyad varchar(50)
begin
select @OgrAd=(select OgrAd from inserted)
select @OgrSoyad=(select OgrSoyad from inserted)
print(@OgrAd +' '+@OgrSoyad+' isimli öðrenci sisteme kaydedildi')
end 


create trigger OgrSay
on Ogrenci
for insert
as
declare @say varchar
begin
select @say= count(*) from Ogrenci
print('Sistemde '+@say+' Öðrenci kaydý var')
end


insert into Ogrenci values('191001071','Aliye','Karasu','k','2000-08-08','5453679797','3','C:\Users\LENOVA\Desktop\dosyalarým\wp img\IMG-20170618-WA0032.jpg','aliyekarasu@ogr.duzce.edu.tr','1234','1234563252',2,4,'4')
insert into Ogrenci values('191001072','Ayþe','Fýrýncý','k','2000-06-25','5453645625','3','C:\Users\LENOVA\Desktop\dosyalarým\wp img\IMG-20170618-WA0032.jpg','aysefirinci@ogr.duzce.edu.tr','1234','1234563252',2,4,'4')
insert into Ogrenci values('191001073','Hilal','Saat','k','2000-06-25','5453645485','3','hilalsaat@ogr.duzce.edu.tr','1234','1234563252',2,4,'4')


create trigger ogrtEklendi
on OgretimElemani
for insert
as
declare @OgrtAd varchar(30),@OgrtSoyad varchar(50)
begin
select @OgrtAd=(select OgrtAd from inserted)
select @OgrtSoyad=(select OgrtSoyad from inserted)
print(@OgrtAd + ' '+@OgrtSoyad+' isimli Ogretim Elemaný sisteme kaydedildi')
end 


create trigger OgrtSay
on OgretimElemani
for insert
as
declare @sayoe varchar
begin
select @sayoe= count(*) from OgretimElemani
print('Sistemde '+@sayoe+' Öðretim Elemaný kaydý var')
end

insert into OgretimElemani values('1234566595','Nihat','Sezgin','doktor','nihatsezgin@duzce.edu.tr','1234','2')

create trigger personelEklendi
on OgrenciIsleri
for insert
as
declare @PersonelAd varchar(30), @PersonelSoyad varchar(50)
begin
select @PersonelAd=(select PersonelAd from inserted)
select @PersonelSoyad=(select PersonelSoyad from inserted)
print(@PersonelAd + ' '+@PersonelSoyad+' isimli Personel sisteme kaydedildi')
end 

create trigger personelSay
on OgrenciIsleri
for insert
as
declare @sayp varchar
begin
select @sayp= count(*) from OgrenciIsleri
print('Sistemde '+@sayp+' Personel kaydý var')
end

insert into OgrenciIsleri values('Kemal','Kýrgýz','5698585645','kkirgiz@duzce.edu.tr','1234','3')

create trigger personelguncelle
on dbo.Bolum
for update
as
begin
if update (PersonelID)
update dbo.Ogrenci
set PersonelID=inserted.PersonelID
from inserted
inner join dbo.Ogrenci on inserted.BolumID=Ogrenci.BolumID
where inserted.PersonelID <> Ogrenci.PersonelID
end
