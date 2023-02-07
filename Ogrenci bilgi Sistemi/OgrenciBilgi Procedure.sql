Create procedure Ogrencibil
AS
Select OgrNO,OgrAd,OgrSoyad, Cinsiyet,DogumTar,OgrTelNo,Sinif,OgrResim,
OgrMail,OgrSifre,DanismanID from Ogrenci
inner join Bolum
on Bolum.BolumID=Ogrenci.BolumID
inner join OgrenciIsleri
on OgrenciIsleri.PersonelID=Ogrenci.PersonelID
inner join OgretimElemani
on OgretimElemani.OgrtID=Ogrenci.DanismanID