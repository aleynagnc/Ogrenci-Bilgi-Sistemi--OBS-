create procedure secilmisdersler 
as
select DersSecID, OgrAd, OgrSoyad, Yariyil, DersAdi, Akts, Kredi, BolumAd from DersSecme
inner join Ogrenci
on Ogrenci.OgrNo = DersSecme.OgrNo
inner join Ders
on DersSecme.DersKodu=Ders.DersKodu
inner join Bolum
on Bolum.BolumID=DersSecme.BolumID