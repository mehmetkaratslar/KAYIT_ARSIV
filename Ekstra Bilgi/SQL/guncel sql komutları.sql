-- Veritaban� olu�turma
CREATE DATABASE KayitVeArsiv
COLLATE Turkish_CI_AS; -- T�rk�e karakter deste�i i�in collation ayar�

USE KayitVeArsiv;

CREATE TABLE Kisiler (
    KisiID INT IDENTITY(1,1) PRIMARY KEY, -- Otomatik artan birincil anahtar
    Ad NVARCHAR(50) NOT NULL, -- T�rk�e karakter deste�i i�in NVARCHAR
    Soyad NVARCHAR(50) NOT NULL,
    DogumTarihi DATE,
    Cinsiyet NVARCHAR(10) -- �rne�in, "Erkek", "Kad�n"
);

CREATE TABLE Belgeler (
    BelgeID INT IDENTITY(1,1) PRIMARY KEY, -- Otomatik artan birincil anahtar
    BelgeTipi NVARCHAR(50) NOT NULL, -- �rne�in, "��", "Resmi", "Okul", "Sa�l�k"
    BelgeAdi NVARCHAR(100) NOT NULL,
    Dosya VARBINARY(MAX) NOT NULL, -- Fiziksel dosyan�n binary olarak saklanaca�� alan
    DosyaTipi NVARCHAR(20) NOT NULL, -- �rne�in, "PDF", "Resim", "Excel"
    YuklemeTarihi DATETIME DEFAULT GETDATE(), -- Y�kleme tarihi otomatik olarak eklenir
    DosyaAciklamasi NVARCHAR(255) -- Belgeyle ilgili a��klama
);

CREATE TABLE KisiBelge (
    BelgeID INT NOT NULL,
    KisiID INT NOT NULL,
    PRIMARY KEY (BelgeID, KisiID), -- Birle�ik birincil anahtar
    FOREIGN KEY (BelgeID) REFERENCES Belgeler(BelgeID) ON DELETE CASCADE,
    FOREIGN KEY (KisiID) REFERENCES Kisiler(KisiID) ON DELETE CASCADE
);

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('NES�H', 'KARATA�', '1991-01-30', 'Erkek');

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('VES�LA', 'KARATA�', '1997-05-15', 'Kad�n');

--INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet)
--VALUES ('H�VDA', 'KARATA�', '2023-05-15', 'Kad�n');

--INSERT INTO Belgeler (BelgeTipi, BelgeAdi, Dosya, DosyaTipi, DosyaAciklamasi)
--VALUES ('��', '�� S�zle�mesi', 0x255044462D312E, 'PDF', 'NES�H Y�lmaz i� s�zle�mesi');

--INSERT INTO KisiBelge (BelgeID, KisiID)
--VALUES (1, 1); -- BelgeID 1, KisiID 1 ile ili�kilendirildi

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
--WHERE BelgeID = 1; -- �rnek olarak BelgeID = 1