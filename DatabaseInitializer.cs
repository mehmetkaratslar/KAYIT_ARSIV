using System;
using System.Data.SQLite;
using System.IO;

namespace KAYIT_ARSIV
{
    public class DatabaseInitializer
    {
        // Veritabanı klasörü: Çalışma klasörü içindeki "Veriler"
        private static readonly string FolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Veriler");

        // Veritabanı dosyasının tam yolu
        private static readonly string DatabaseFilePath = Path.Combine(FolderPath, "arsiv.db");

        // Uygulama ilk çalıştığında çağrılır
        public static void InitializeDatabase()
        {
            // 1. Klasör yoksa oluştur
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            // 2. Veritabanı yoksa oluştur ve tabloları kur
            if (!File.Exists(DatabaseFilePath))
            {
                SQLiteConnection.CreateFile(DatabaseFilePath);

                using var connection = new SQLiteConnection($"Data Source={DatabaseFilePath};Version=3;");
                connection.Open();

                string createKisiler = @"
                    CREATE TABLE IF NOT EXISTS Kisiler (
                        KisiID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Ad TEXT NOT NULL,
                        Soyad TEXT NOT NULL,
                        DogumTarihi DATE,
                        Cinsiyet TEXT
                    );";

                string createBelgeler = @"
                    CREATE TABLE IF NOT EXISTS Belgeler (
                        BelgeID INTEGER PRIMARY KEY AUTOINCREMENT,
                        BelgeTipi TEXT NOT NULL,
                        BelgeAdi TEXT NOT NULL,
                        Dosya BLOB NOT NULL,
                        DosyaTipi TEXT NOT NULL,
                        YuklemeTarihi DATETIME DEFAULT CURRENT_TIMESTAMP,
                        DosyaAciklamasi TEXT
                    );";

                string createKisiBelge = @"
                    CREATE TABLE IF NOT EXISTS KisiBelge (
                        BelgeID INTEGER NOT NULL,
                        KisiID INTEGER NOT NULL,
                        PRIMARY KEY (BelgeID, KisiID),
                        FOREIGN KEY (BelgeID) REFERENCES Belgeler(BelgeID) ON DELETE CASCADE,
                        FOREIGN KEY (KisiID) REFERENCES Kisiler(KisiID) ON DELETE CASCADE
                    );";

                new SQLiteCommand(createKisiler, connection).ExecuteNonQuery();
                new SQLiteCommand(createBelgeler, connection).ExecuteNonQuery();
                new SQLiteCommand(createKisiBelge, connection).ExecuteNonQuery();

                connection.Close();
                Console.WriteLine("✅ Veritabanı ve tablolar başarıyla oluşturuldu.");
            }
        }

        // Diğer sınıflar tarafından kullanılacak bağlantı dizesi
        public static string GetConnectionString()
        {
            return $"Data Source={DatabaseFilePath};Version=3;";
        }
    }
}
