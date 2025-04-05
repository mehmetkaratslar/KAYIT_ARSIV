using KAYIT_ARSIV;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace KAYIT_VE_ARŞİV
{
    public partial class Anasayfa : Form
    {
        private readonly SQLiteConnection baglanti = new(SQLiteHelper.GetConnectionString());
        private readonly Yedeklem yedek = new();
        private readonly DosyaAlani dosya = new();

        public Anasayfa()
        {
            InitializeComponent(); // Sadece bir kez çağrılmalı
            this.Load += Anasayfa_Load; // Form yüklenince çalışacak
           

        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            DatabaseInitializer.InitializeDatabase(); // Veritabanını oluştur


            KisileriYukle();                          // ComboBox'lara kişileri yükle
            BelgeTurleriniYukle();                    // ComboBox'a belge türlerini yükle
            yedek.TarihleriYukle(YedekTarih);         // Yedek tarihlerini yükle
           

        }

        #region BELGE TÜRLERİNİ YÜKLEME

        private void BelgeTurleriniYukle()
        {
            try
            {
                baglanti.Open();
                string sorgu = "SELECT DISTINCT BelgeTipi FROM Belgeler";
                using SQLiteCommand komut = new(sorgu, baglanti);
                using SQLiteDataReader reader = komut.ExecuteReader();
                BelgeSorgu.Items.Clear();

                while (reader.Read())
                {
                    string belgeTipi = reader["BelgeTipi"]?.ToString();
                    if (!string.IsNullOrEmpty(belgeTipi))
                        BelgeSorgu.Items.Add(belgeTipi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Belge türleri yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region KİŞİLERİ YÜKLEME

        void KisileriYukle()
        {
            DataTable dt = new();
            SQLiteDataAdapter adapter = new("SELECT KisiID, Ad || ' ' || Soyad AS AdSoyad FROM Kisiler", baglanti);
            adapter.Fill(dt);

            KisiSec.DataSource = dt;
            KisiSec.DisplayMember = "AdSoyad";
            KisiSec.ValueMember = "KisiID";

            KisiSorgu.DataSource = dt.Copy();
            KisiSorgu.DisplayMember = "AdSoyad";
            KisiSorgu.ValueMember = "KisiID";

            YedekKisiSec.DataSource = dt.Copy();
            YedekKisiSec.DisplayMember = "AdSoyad";
            YedekKisiSec.ValueMember = "KisiID";
        }

        #endregion

        #region KİŞİ LİSTELEME

        void Listele()
        {
            DataTable dt = new();
            SQLiteDataAdapter adapter = new("SELECT * FROM Kisiler", baglanti);
            adapter.Fill(dt);
            KisiGoster.DataSource = dt;
        }

        #endregion

        #region TEMİZLEME

        void Temizle()
        {
            AdiEkle.Clear();
            SoyadiEkle.Clear();
            DogumTarihi.Clear();
            Cinsiyet.Clear();
            Id.Clear();
            DosyaTipi.Clear();
            DosyaAciklamasi.Clear();
            Sil_ID.Clear();
            BelgeTipi.Clear();
            BelgeAdi.Clear();
        }

        #endregion

        #region SORGULAMA

        private void SorguYap_Click(object sender, EventArgs e)
        {
            new Sorgu().KisiyeGoreSorgu(KisiSorgu, BelgeSorgu, YilSorgu, AySorgu, SorguDataGrid);
        }

        #endregion

        #region YENİ KAYIT EKLEME

        private void YeniKayit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AdiEkle.Text) || string.IsNullOrWhiteSpace(SoyadiEkle.Text) || string.IsNullOrWhiteSpace(DogumTarihi.Text) || string.IsNullOrWhiteSpace(Cinsiyet.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            if (!DateTime.TryParse(DogumTarihi.Text, out DateTime dogumTarihi))
            {
                MessageBox.Show("Doğum tarihi geçersiz. Örnek: 1991-01-30");
                return;
            }

            try
            {
                baglanti.Open();
                SQLiteCommand komut = new("INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet) VALUES (@Ad, @Soyad, @DogumTarihi, @Cinsiyet)", baglanti);
                komut.Parameters.AddWithValue("@Ad", AdiEkle.Text);
                komut.Parameters.AddWithValue("@Soyad", SoyadiEkle.Text);
                komut.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                komut.Parameters.AddWithValue("@Cinsiyet", Cinsiyet.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kişi eklendi.");
                Listele();
                Temizle();
                KisileriYukle();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Id.Text))
            {
                MessageBox.Show("Lütfen bir kişi seçiniz.");
                return;
            }

            if (!DateTime.TryParse(DogumTarihi.Text, out DateTime dogumTarihi))
            {
                MessageBox.Show("Geçersiz tarih formatı.");
                return;
            }

            try
            {
                baglanti.Open();
                SQLiteCommand komut = new("UPDATE Kisiler SET Ad = @Ad, Soyad = @Soyad, DogumTarihi = @DogumTarihi, Cinsiyet = @Cinsiyet WHERE KisiID = @KisiID", baglanti);
                komut.Parameters.AddWithValue("@KisiID", Id.Text);
                komut.Parameters.AddWithValue("@Ad", AdiEkle.Text);
                komut.Parameters.AddWithValue("@Soyad", SoyadiEkle.Text);
                komut.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                komut.Parameters.AddWithValue("@Cinsiyet", Cinsiyet.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kişi güncellendi.");
                Listele();
                Temizle();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region KİŞİ GETİRME

        private void KisiGetir_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void KisiGoster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = KisiGoster.Rows[e.RowIndex];

                Id.Text = row.Cells["KisiID"].Value?.ToString();
                AdiEkle.Text = row.Cells["Ad"].Value?.ToString();
                SoyadiEkle.Text = row.Cells["Soyad"].Value?.ToString();

                var dogumTarihiDegeri = row.Cells["DogumTarihi"].Value;
                if (dogumTarihiDegeri != null && DateTime.TryParse(dogumTarihiDegeri.ToString(), out DateTime dogumTarihi))
                {
                    DogumTarihi.Text = dogumTarihi.ToString("yyyy-MM-dd");
                }
                else
                {
                    DogumTarihi.Text = string.Empty;
                }

                Cinsiyet.Text = row.Cells["Cinsiyet"].Value?.ToString();
            }
        }


        #endregion

        #region DOSYA İŞLEMLERİ

        private void D_ekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Resim, PDF ve Word Dosyaları|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx"
            };

            if (dosya.ShowDialog() != DialogResult.OK)
                return;

            foreach (string dosyaYolu in dosya.FileNames)
            {
                string dosyaAdi = Path.GetFileName(dosyaYolu);
                LinkLabel link = new LinkLabel
                {
                    Text = dosyaAdi,
                    Tag = dosyaYolu,
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                link.Click += (s, ev) =>
                {
                    try { Process.Start(new ProcessStartInfo(dosyaYolu) { UseShellExecute = true }); }
                    catch (Exception ex) { MessageBox.Show("Dosya açılamadı: " + ex.Message); }
                };

                flowLayoutPanel1.Controls.Add(link);
            }
        }

        private void D_Kaydet_Click(object sender, EventArgs e)
        {
            dosya.DosyaEkle(KisiSec, BelgeTipi, DosyaAciklamasi, flowLayoutPanel1);
            Temizle();
            dosya.DosyaListele(SonDosya);
        }

        private void DosyaSil_Click(object sender, EventArgs e)
        {
            dosya.DosyaSil(Sil_ID, SonDosya);
            Temizle();
        }

        private void DosyaGuncelle_Click(object sender, EventArgs e)
        {
            dosya.DosyaGuncelle(Sil_ID, BelgeTipi, BelgeAdi, DosyaTipi, DosyaAciklamasi, SonDosya);
            Temizle();
        }

        private void DosyaAc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Sil_ID.Text))
                dosya.DosyaAc(Convert.ToInt32(Sil_ID.Text));
        }

        private void SonDosyaGetir_Click(object sender, EventArgs e)
        {
            dosya.DosyaListele(SonDosya);
        }

        private void SonDosya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = SonDosya.Rows[e.RowIndex];
                Sil_ID.Text = row.Cells["BelgeID"].Value.ToString();
                BelgeTipi.Text = row.Cells["BelgeTipi"].Value.ToString();
                BelgeAdi.Text = row.Cells["BelgeAdi"].Value.ToString();
                DosyaTipi.Text = row.Cells["DosyaTipi"].Value.ToString();
                DosyaAciklamasi.Text = row.Cells["DosyaAciklamasi"].Value.ToString();
            }
        }

        #endregion

        #region YEDEKLEME

        private void YedekBasla_Click(object sender, EventArgs e)
        {
            yedek.KisiVeyaTumunuYedekle(KisiSorgu, YedekTarih, TumKisi, YedekData);
        }

        #endregion

        private void Sil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Id.Text))
            {
                MessageBox.Show("Lütfen silinecek kişiyi seçiniz.");
                return;
            }

            DialogResult sonuc = MessageBox.Show("Bu kişiyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                baglanti.Open();
                SQLiteCommand komut = new("DELETE FROM Kisiler WHERE KisiID = @KisiID", baglanti);
                komut.Parameters.AddWithValue("@KisiID", Id.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kişi silindi.");
                KisileriYukle();
                Listele();
                Temizle();
            }
        }


        private void SorguDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = SorguDataGrid.Rows[e.RowIndex];

                if (row.Cells["BelgeID"]?.Value != null)
                {
                    int belgeID = Convert.ToInt32(row.Cells["BelgeID"].Value);
                    dosya.DosyaAc(belgeID); // DosyaAlani sınıfından çağırıyoruz
                }
                else
                {
                    MessageBox.Show("BelgeID bulunamadı.");
                }
            }
        }

    }
}
