using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace KAYIT_ARSIV
{
    public class DosyaAlani
    {
        private readonly SQLiteConnection baglanti = new(SQLiteHelper.GetConnectionString());

        public void DosyaEkle(ComboBox kisiSec, TextBox belgeTipi, TextBox dosyaAciklama, FlowLayoutPanel panel)
        {
            if (string.IsNullOrEmpty(kisiSec.SelectedValue?.ToString()))
            {
                MessageBox.Show("Lütfen bir kişi seçin.");
                return;
            }

            int kisiID = Convert.ToInt32(kisiSec.SelectedValue);

            try
            {
                baglanti.Open();

                foreach (Control control in panel.Controls)
                {
                    if (control is LinkLabel link && link.Tag != null)
                    {
                        string dosyaYolu = link.Tag.ToString();
                        if (!File.Exists(dosyaYolu))
                        {
                            MessageBox.Show("Dosya bulunamadı: " + dosyaYolu);
                            continue;
                        }

                        byte[] dosyaBytes = File.ReadAllBytes(dosyaYolu);
                        string dosyaAdi = Path.GetFileNameWithoutExtension(dosyaYolu);
                        string uzanti = Path.GetExtension(dosyaYolu).ToLower();

                        // Belge ekle
                        SQLiteCommand belgeKomut = new SQLiteCommand(@"
                            INSERT INTO Belgeler (BelgeTipi, BelgeAdi, Dosya, DosyaTipi, YuklemeTarihi, DosyaAciklamasi)
                            VALUES (@BelgeTipi, @BelgeAdi, @Dosya, @DosyaTipi, CURRENT_TIMESTAMP, @DosyaAciklamasi);
                            SELECT last_insert_rowid();", baglanti);

                        belgeKomut.Parameters.AddWithValue("@BelgeTipi", belgeTipi.Text);
                        belgeKomut.Parameters.AddWithValue("@BelgeAdi", dosyaAdi);
                        belgeKomut.Parameters.AddWithValue("@Dosya", dosyaBytes);
                        belgeKomut.Parameters.AddWithValue("@DosyaTipi", uzanti);
                        belgeKomut.Parameters.AddWithValue("@DosyaAciklamasi", dosyaAciklama.Text);

                        long belgeID = (long)belgeKomut.ExecuteScalar();

                        // Kisi-Belge eşle
                        SQLiteCommand kisiBelgeKomut = new SQLiteCommand("INSERT INTO KisiBelge (BelgeID, KisiID) VALUES (@BelgeID, @KisiID)", baglanti);
                        kisiBelgeKomut.Parameters.AddWithValue("@BelgeID", belgeID);
                        kisiBelgeKomut.Parameters.AddWithValue("@KisiID", kisiID);
                        kisiBelgeKomut.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Dosyalar başarıyla kaydedildi.");
                panel.Controls.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        public void DosyaListele(DataGridView grid)
        {
            DataTable veri = new DataTable();

            string sql = @"
                SELECT b.BelgeID, b.BelgeTipi, b.BelgeAdi, b.DosyaTipi, b.YuklemeTarihi, b.DosyaAciklamasi,
                       k.Ad || ' ' || k.Soyad AS AdSoyad
                FROM Belgeler b
                INNER JOIN KisiBelge kb ON b.BelgeID = kb.BelgeID
                INNER JOIN Kisiler k ON kb.KisiID = k.KisiID
                ORDER BY b.YuklemeTarihi DESC";

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, baglanti);
            adapter.Fill(veri);
            grid.DataSource = veri;
        }

        public void DosyaSil(TextBox silID, DataGridView grid)
        {
            if (string.IsNullOrWhiteSpace(silID.Text))
            {
                MessageBox.Show("Lütfen bir Dosya BelgeID seçin.");
                return;
            }

            try
            {
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand("DELETE FROM Belgeler WHERE BelgeID = @BelgeID", baglanti);
                komut.Parameters.AddWithValue("@BelgeID", silID.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Dosya başarıyla silindi.");
                DosyaListele(grid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        public void DosyaAc(int belgeID)
        {
            try
            {
                baglanti.Open();

                SQLiteCommand komut = new SQLiteCommand("SELECT Dosya, DosyaTipi, BelgeAdi FROM Belgeler WHERE BelgeID = @BelgeID", baglanti);
                komut.Parameters.AddWithValue("@BelgeID", belgeID);

                using (SQLiteDataReader reader = komut.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] dosyaBytes = (byte[])reader["Dosya"];
                        string tip = reader["DosyaTipi"].ToString();
                        string ad = reader["BelgeAdi"].ToString();

                        string yol = Path.Combine(Path.GetTempPath(), ad + tip);
                        File.WriteAllBytes(yol, dosyaBytes);
                        Process.Start(new ProcessStartInfo(yol) { UseShellExecute = true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya açma hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        public void DosyaGuncelle(TextBox belgeID, TextBox belgeTipi, TextBox belgeAdi, TextBox dosyaTipi, TextBox dosyaAciklama, DataGridView grid)
        {
            try
            {
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand(@"
                    UPDATE Belgeler
                    SET BelgeTipi = @BelgeTipi,
                        BelgeAdi = @BelgeAdi,
                        DosyaTipi = @DosyaTipi,
                        DosyaAciklamasi = @DosyaAciklamasi
                    WHERE BelgeID = @BelgeID", baglanti);

                komut.Parameters.AddWithValue("@BelgeTipi", belgeTipi.Text);
                komut.Parameters.AddWithValue("@BelgeAdi", belgeAdi.Text);
                komut.Parameters.AddWithValue("@DosyaTipi", dosyaTipi.Text);
                komut.Parameters.AddWithValue("@DosyaAciklamasi", dosyaAciklama.Text);
                komut.Parameters.AddWithValue("@BelgeID", belgeID.Text);

                komut.ExecuteNonQuery();

                MessageBox.Show("Dosya bilgileri güncellendi.");
                DosyaListele(grid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
