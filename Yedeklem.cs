using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace KAYIT_ARSIV
{
    public class Yedeklem
    {
        private readonly SQLiteConnection baglanti = new(SQLiteHelper.GetConnectionString());

        public void TarihleriYukle(ComboBox tarihComboBox)
        {
            try
            {
                baglanti.Open();
                string sorgu = "SELECT DISTINCT date(YuklemeTarihi) AS Tarih FROM Belgeler ORDER BY Tarih DESC";

                SQLiteCommand komut = new(sorgu, baglanti);
                SQLiteDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    DateTime tarih = Convert.ToDateTime(reader["Tarih"]);
                    tarihComboBox.Items.Add(tarih);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarihleri yüklerken hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        public void KisiVeyaTumunuYedekle(ComboBox KisiComboBox, ComboBox YedekTarih, CheckBox TumKisilerCheckBox, DataGridView YedekData)
        {
            string? secilenTarihStr = null;

            if (YedekTarih.SelectedItem != null)
            {
                DateTime secilenTarih = Convert.ToDateTime(YedekTarih.SelectedItem);
                secilenTarihStr = secilenTarih.ToString("yyyy-MM-dd");
            }

            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() != DialogResult.OK)
                return;

            string yedeklemeAnaYolu = Path.Combine(folderBrowser.SelectedPath, "Yedekler");
            Directory.CreateDirectory(yedeklemeAnaYolu);

            DataTable toplamTablo = new DataTable();

            try
            {
                baglanti.Open();

                if (TumKisilerCheckBox.Checked)
                {
                    string kisiSorgu = "SELECT KisiID, Ad || ' ' || Soyad AS AdSoyad FROM Kisiler";
                    SQLiteCommand cmd = new(kisiSorgu, baglanti);
                    SQLiteDataReader dr = cmd.ExecuteReader();

                    var kisiListesi = new List<(int KisiID, string AdSoyad)>();
                    while (dr.Read())
                    {
                        int kisiID = Convert.ToInt32(dr["KisiID"]);
                        string adSoyad = dr["AdSoyad"].ToString();
                        kisiListesi.Add((kisiID, adSoyad));
                    }
                    dr.Close();

                    foreach (var kisi in kisiListesi)
                    {
                        string kisiKlasoru = Path.Combine(yedeklemeAnaYolu, kisi.AdSoyad);
                        Directory.CreateDirectory(kisiKlasoru);
                        DataTable dt = YedekKisiBelgeleri(kisi.KisiID, kisiKlasoru, secilenTarihStr);
                        toplamTablo.Merge(dt);
                    }
                }
                else
                {
                    if (KisiComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Lütfen bir kişi seçin.");
                        return;
                    }

                    int kisiID = Convert.ToInt32(KisiComboBox.SelectedValue);
                    string kisiAdi = KisiComboBox.Text;
                    string kisiKlasoru = Path.Combine(yedeklemeAnaYolu, kisiAdi);
                    Directory.CreateDirectory(kisiKlasoru);
                    toplamTablo = YedekKisiBelgeleri(kisiID, kisiKlasoru, secilenTarihStr);
                }

                YedekData.DataSource = toplamTablo;
                MessageBox.Show("Yedekleme tamamlandı.");
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

        private DataTable YedekKisiBelgeleri(int kisiID, string kisiKlasoru, string? tarihFiltre)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Kişi Adı");
            dt.Columns.Add("Belge Adı");
            dt.Columns.Add("Belge Türü");
            dt.Columns.Add("Dosya Tipi");
            dt.Columns.Add("Yükleme Tarihi");

            string sorgu = @"
                SELECT b.BelgeAdi, b.Dosya, b.DosyaTipi, b.BelgeTipi, b.YuklemeTarihi,
                       k.Ad || ' ' || k.Soyad AS KisiAdi
                FROM Belgeler b
                INNER JOIN KisiBelge kb ON b.BelgeID = kb.BelgeID
                INNER JOIN Kisiler k ON kb.KisiID = k.KisiID
                WHERE kb.KisiID = @KisiID";

            if (!string.IsNullOrEmpty(tarihFiltre))
            {
                sorgu += " AND date(b.YuklemeTarihi) = @Tarih";
            }

            SQLiteCommand komut = new(sorgu, baglanti);
            komut.Parameters.AddWithValue("@KisiID", kisiID);

            if (!string.IsNullOrEmpty(tarihFiltre))
            {
                komut.Parameters.AddWithValue("@Tarih", tarihFiltre);
            }

            SQLiteDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                string belgeAdi = reader["BelgeAdi"].ToString();
                string dosyaTipi = reader["DosyaTipi"].ToString();
                string belgeTuru = reader["BelgeTipi"].ToString();
                string kisiAdi = reader["KisiAdi"].ToString();
                DateTime yuklemeTarihi = Convert.ToDateTime(reader["YuklemeTarihi"]);
                byte[] dosya = (byte[])reader["Dosya"];

                string tarihKlasoru = yuklemeTarihi.ToString("dd.MM.yyyy");
                string tamKlasorYolu = Path.Combine(kisiKlasoru, tarihKlasoru, belgeTuru);
                Directory.CreateDirectory(tamKlasorYolu);

                string tamYol = Path.Combine(tamKlasorYolu, $"{belgeAdi}{dosyaTipi}");
                File.WriteAllBytes(tamYol, dosya);

                dt.Rows.Add(kisiAdi, belgeAdi, belgeTuru, dosyaTipi, yuklemeTarihi.ToShortDateString());
            }

            reader.Close();
            return dt;
        }
    }
}
