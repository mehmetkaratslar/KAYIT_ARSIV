using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KAYIT_ARSIV
{
    public class Yedeklem
    {
        private SqlConnection baglanti = new SqlConnection("Data Source=MEHMET;Initial Catalog=KayitVeArsiv;Integrated Security=True;TrustServerCertificate=True");

        public void TarihleriYukle(ComboBox tarihComboBox)
        {
            try
            {
                baglanti.Open();
                string sorgu = "SELECT DISTINCT CAST(YuklemeTarihi AS DATE) AS Tarih FROM Belgeler ORDER BY Tarih DESC";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    DateTime tarih = reader.GetDateTime(0);
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
                    SqlCommand cmd = new SqlCommand("SELECT KisiID, Ad + ' ' + Soyad AS AdSoyad FROM Kisiler", baglanti);
                    SqlDataReader dr = cmd.ExecuteReader();

                    var kisiListesi = new List<(int KisiID, string AdSoyad)>();
                    while (dr.Read())
                    {
                        int kisiID = (int)dr["KisiID"];
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

                    int kisiID = (int)KisiComboBox.SelectedValue;
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
                       k.Ad + ' ' + k.Soyad AS KisiAdi
                FROM Belgeler b
                INNER JOIN KisiBelge kb ON b.BelgeID = kb.BelgeID
                INNER JOIN Kisiler k ON kb.KisiID = k.KisiID
                WHERE kb.KisiID = @KisiID";

            SqlCommand komut = new SqlCommand();

            if (!string.IsNullOrEmpty(tarihFiltre))
            {
                sorgu += " AND CAST(b.YuklemeTarihi AS DATE) = @Tarih";
                komut.Parameters.AddWithValue("@Tarih", tarihFiltre);
            }

            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.Parameters.AddWithValue("@KisiID", kisiID);

            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                string belgeAdi = reader["BelgeAdi"].ToString();
                string dosyaTipi = reader["DosyaTipi"].ToString();
                string belgeTuru = reader["BelgeTipi"].ToString();
                string kisiAdi = reader["KisiAdi"].ToString();
                DateTime yuklemeTarihi = Convert.ToDateTime(reader["YuklemeTarihi"]);
                byte[] dosya = (byte[])reader["Dosya"];

                // Her belge için tarih klasörü oluşturuluyor (eğer tarih filtrelenmemişse)
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
