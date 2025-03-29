-- Veritabanı oluşturma
CREATE DATABASE KayitVeArsiv
COLLATE Turkish_CI_AS; -- Türkçe karakter desteği için collation ayarı

USE KayitVeArsiv;

CREATE TABLE Kisiler (
    KisiID INT IDENTITY(1,1) PRIMARY KEY, -- Otomatik artan birincil anahtar
    Ad NVARCHAR(50) NOT NULL, -- Türkçe karakter desteği için NVARCHAR
    Soyad NVARCHAR(50) NOT NULL,
    DogumTarihi DATE,
    Cinsiyet NVARCHAR(10) -- Örneğin, "Erkek", "Kadın"
);

CREATE TABLE Belgeler (
    BelgeID INT IDENTITY(1,1) PRIMARY KEY, -- Otomatik artan birincil anahtar
    BelgeTipi NVARCHAR(50) NOT NULL, -- Örneğin, "İş", "Resmi", "Okul", "Sağlık"
    BelgeAdi NVARCHAR(100) NOT NULL,
    Dosya VARBINARY(MAX) NOT NULL, -- Fiziksel dosyanın binary olarak saklanacağı alan
    DosyaTipi NVARCHAR(20) NOT NULL, -- Örneğin, "PDF", "Resim", "Excel"
    YuklemeTarihi DATETIME DEFAULT GETDATE(), -- Yükleme tarihi otomatik olarak eklenir
    DosyaAciklamasi NVARCHAR(255) -- Belgeyle ilgili açıklama
);

CREATE TABLE KisiBelge (
    BelgeID INT NOT NULL,
    KisiID INT NOT NULL,
    PRIMARY KEY (BelgeID, KisiID), -- Birleşik birincil anahtar
    FOREIGN KEY (BelgeID) REFERENCES Belgeler(BelgeID) ON DELETE CASCADE,
    FOREIGN KEY (KisiID) REFERENCES Kisiler(KisiID) ON DELETE CASCADE
);

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('MERT', 'KARA', '1991-01-30', 'Erkek');

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('MELİKE ', 'KAR', '1997-05-15', 'Kadın');

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('SEMRA', 'KARTAL', '2023-05-15', 'Kadın');

--INSERT INTO Belgeler (BelgeTipi, BelgeAdi, Dosya, DosyaTipi, DosyaAciklamasi)
--VALUES ('İş', 'İş Sözleşmesi', 0x255044462D312E, 'PDF', 'NESİH Yılmaz iş sözleşmesi');

--INSERT INTO KisiBelge (BelgeID, KisiID)
--VALUES (1, 1); -- BelgeID 1, KisiID 1 ile ilişkilendirildi

--SELECT k.Ad, k.Soyad, b.BelgeAdi, b.BelgeTipi, b.YuklemeTarihi
--FROM Kisiler k
--INNER JOIN KisiBelge kb ON k.KisiID = kb.KisiID
--INNER JOIN Belgeler b ON kb.BelgeID = b.BelgeID
--WHERE k.KisiID = 1;

--SELECT b.BelgeAdi, b.BelgeTipi, b.YuklemeTarihi, b.DosyaAciklamasi
--FROM Belgeler b
--WHERE b.YuklemeTarihi BETWEEN '2023-01-01' AND '2023-12-31';

--SELECT * FROM INFORMATION_SCHEMA.TABLES;

--SELECT Dosya, DosyaTipi, BelgeAdi
--FROM Belgeler
--WHERE BelgeID = 1; -- Örnek olarak BelgeID = 1