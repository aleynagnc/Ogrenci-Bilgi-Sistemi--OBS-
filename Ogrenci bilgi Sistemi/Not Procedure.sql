Create Procedure tbNotlar
AS
select NotID,Vize,final,ortalama,harfnotu,OgrtID from Not_
inner join Ders
on Not_.DersKodu=Ders.DersKodu
inner join Ogrenci
on Not_.OgrNo=Ogrenci.OgrNo