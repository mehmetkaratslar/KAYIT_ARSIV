-- Veritabaný oluþturma
CREATE DATABASE KayitVeArsiv
COLLATE Turkish_CI_AS; -- Türkçe karakter desteði için collation ayarý

USE KayitVeArsiv;

CREATE TABLE Kisiler (
    KisiID INT IDENTITY(1,1) PRIMARY KEY, -- Otomatik artan birincil anahtar
    Ad NVARCHAR(50) NOT NULL, -- Türkçe karakter desteði için NVARCHAR
    Soyad NVARCHAR(50) NOT NULL,
    DogumTarihi DATE,
    Cinsiyet NVARCHAR(10) -- Örneðin, "Erkek", "Kadýn"
);

CREATE TABLE Belgeler (
    BelgeID INT IDENTITY(1,1) PRIMARY KEY, -- Otomatik artan birincil anahtar
    BelgeTipi NVARCHAR(50) NOT NULL, -- Örneðin, "Ýþ", "Resmi", "Okul", "Saðlýk"
    BelgeAdi NVARCHAR(100) NOT NULL,
    Dosya VARBINARY(MAX) NOT NULL, -- Fiziksel dosyanýn binary olarak saklanacaðý alan
    DosyaTipi NVARCHAR(20) NOT NULL, -- Örneðin, "PDF", "Resim", "Excel"
    YuklemeTarihi DATETIME DEFAULT GETDATE(), -- Yükleme tarihi otomatik olarak eklenir
    DosyaAciklamasi NVARCHAR(255) -- Belgeyle ilgili açýklama
);

CREATE TABLE KisiBelge (
    BelgeID INT NOT NULL,
    KisiID INT NOT NULL,
    PRIMARY KEY (BelgeID, KisiID), -- Birleþik birincil anahtar
    FOREIGN KEY (BelgeID) REFERENCES Belgeler(BelgeID) ON DELETE CASCADE,
    FOREIGN KEY (KisiID) REFERENCES Kisiler(KisiID) ON DELETE CASCADE
);

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('NESÝH', 'KARATAÞ', '1991-01-30', 'Erkek');

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('VESÝLA', 'KARATAÞ', '1997-05-15', 'Kadýn');

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('HÝVDA', 'KARATAÞ', '2023-05-15', 'Kadýn');

--INSERT INTO Belgeler (BelgeTipi, BelgeAdi, Dosya, DosyaTipi, DosyaAciklamasi)
--VALUES ('Ýþ', 'Ýþ Sözleþmesi', 0x255044462D312E, 'PDF', 'NESÝH Yýlmaz iþ sözleþmesi');

--INSERT INTO KisiBelge (BelgeID, KisiID)
--VALUES (1, 1); -- BelgeID 1, KisiID 1 ile iliþkilendirildi

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