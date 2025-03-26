using KAYIT_ARSIV;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;


namespace KAYIT_VE_ARŞİV
{
    public partial class Anasayfa : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=;Initial Catalog=KayitVeArsiv;Integrated Security=True;Trust Server Certificate=True");

        Yedeklem yedek = new Yedeklem();
        public Anasayfa()
        {
            InitializeComponent();
            KisileriYukle(); // ComboBox'lara kişileri yükle
            BelgeTurleriniYukle(); // ComboBox'a belge türlerini yükle
            yedek.TarihleriYukle(YedekTarih);

        }


        #region BELGE TÜRLERİNİ YÜKLEME COMOBOXSA


        private void BelgeTurleriniYukle()
        {
            try
            {
                baglanti.Open();

                // Belgeler tablosundaki benzersiz BelgeTipi değerlerini çek
                string sorgu = "SELECT DISTINCT BelgeTipi FROM Belgeler";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataReader reader = komut.ExecuteReader();

                // ComboBox'ı temizle
                BelgeSorgu.Items.Clear();

                // ComboBox'a belge türlerini ekle
                // ComboBox'a belge türlerini ekle
                while (reader.Read())
                {
                    var belgeTipi = reader["BelgeTipi"]?.ToString();
                    if (!string.IsNullOrEmpty(belgeTipi))
                    {
                        BelgeSorgu.Items.Add(belgeTipi);
                    }
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



        #region KİŞİLERİN LİSTESİNİ GÖSTERME

        void KisileriYukle()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT KisiID, Ad + ' ' + Soyad AS AdSoyad FROM Kisiler", baglanti);
            adapter.Fill(dt);

            // KisiSec ComboBox'ına kişileri yükle
            KisiSec.DataSource = dt;
            KisiSec.DisplayMember = "AdSoyad";
            KisiSec.ValueMember = "KisiID";

            // KisiSorgu ComboBox'ına kişileri yükle
            KisiSorgu.DataSource = dt.Copy(); // DataTable'ın bir kopyasını kullan
            KisiSorgu.DisplayMember = "AdSoyad";
            KisiSorgu.ValueMember = "KisiID";

            YedekKisiSec.DataSource = dt.Copy(); // DataTable'ın bir kopyasını kullan
            YedekKisiSec.DisplayMember = "AdSoyad";
            YedekKisiSec.ValueMember = "KisiID";

        }

        #endregion



        #region KİŞİ LİSTELEM İŞİ
        void Listele()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Kisiler", baglanti);

            adapter.Fill(dt);
            KisiGoster.DataSource = dt;
            SorguDataGrid.DataSource = dt;

        }
        #endregion


        #region TEMİZLEME İŞİ

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


        #region SORGULAMA İŞLEMİ

        private void SorguYap_Click(object sender, EventArgs e)
        {

            Sorgu sorgu = new Sorgu();
            sorgu.KisiyeGoreSorgu(KisiSorgu, BelgeSorgu, YilSorgu, AySorgu, SorguDataGrid);

        }


        #endregion


        #region YENİ KİŞİ KAYIT ALANI


        private void YeniKayit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AdiEkle.Text) || string.IsNullOrWhiteSpace(SoyadiEkle.Text) || string.IsNullOrWhiteSpace(DogumTarihi.Text) || string.IsNullOrWhiteSpace(Cinsiyet.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            try
            {
                DateTime dogumTarihi;
                if (!DateTime.TryParse(DogumTarihi.Text, out dogumTarihi))
                {
                    MessageBox.Show("Lütfen Doğum tarihi doğru formatta giriniz. Örnek:1991-01-30 bu şekilinde olmalı");
                    return;
                }
                else if (AdiEkle.Text.Length < 2 || SoyadiEkle.Text.Length < 2 || Cinsiyet.Text.Length < 2)
                {
                    MessageBox.Show("Ad, soyad ve cinsiyet alanları düzgün giriniz");
                    return;
                }

                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Kisiler (Ad, Soyad, DogumTarihi, Cinsiyet) VALUES (@Ad, @Soyad, @DogumTarihi, @Cinsiyet)", baglanti);
                komut.Parameters.AddWithValue("@Ad", AdiEkle.Text);
                komut.Parameters.AddWithValue("@Soyad", SoyadiEkle.Text);
                komut.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                komut.Parameters.AddWithValue("@Cinsiyet", Cinsiyet.Text);

                komut.ExecuteNonQuery();

                MessageBox.Show("Kişi başarıyla eklendi.");
                Listele();

                // TextBox'ları temizle
                Temizle();

            }
            catch (SqlException ex)
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

            if (string.IsNullOrWhiteSpace(labelID.Text) || string.IsNullOrWhiteSpace(AdiEkle.Text) || string.IsNullOrWhiteSpace(SoyadiEkle.Text) || string.IsNullOrWhiteSpace(DogumTarihi.Text) || string.IsNullOrWhiteSpace(Cinsiyet.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            try
            {
                DateTime dogumTarihi;
                if (!DateTime.TryParse(DogumTarihi.Text, out dogumTarihi))
                {
                    MessageBox.Show("Lütfen Doğum tarihi doğru formatta giriniz. Örnek:1991-01-30 bu şekilinde olmalı");
                    return;
                }
                else if (AdiEkle.Text.Length < 2 || SoyadiEkle.Text.Length < 2 || Cinsiyet.Text.Length < 2)
                {
                    MessageBox.Show("Ad, soyad ve cinsiyet alanları düzgün giriniz");
                    return;
                }

                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE Kisiler SET Ad = @Ad, Soyad = @Soyad, DogumTarihi = @DogumTarihi, Cinsiyet = @Cinsiyet WHERE KisiID = @KisiID", baglanti);
                komut.Parameters.AddWithValue("@KisiID", Id.Text);
                komut.Parameters.AddWithValue("@Ad", AdiEkle.Text);
                komut.Parameters.AddWithValue("@Soyad", SoyadiEkle.Text);
                komut.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                komut.Parameters.AddWithValue("@Cinsiyet", Cinsiyet.Text);

                komut.ExecuteNonQuery();

                MessageBox.Show("Kişi başarıyla güncellendi.");
                Listele();

                // TextBox'ları temizle
                Temizle();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion


        #region  KİŞİ VERİSİ GETİRME ALANI

        private void KisiGetir_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            Listele();
            baglanti.Close();


        }

        private void KisiGoster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = KisiGoster.Rows[e.RowIndex];

                Id.Text = row.Cells["KisiID"].Value.ToString();
                AdiEkle.Text = row.Cells["Ad"].Value.ToString();
                SoyadiEkle.Text = row.Cells["Soyad"].Value.ToString();
                DogumTarihi.Text = Convert.ToDateTime(row.Cells["DogumTarihi"].Value).ToString("yyyy-MM-dd");
                Cinsiyet.Text = row.Cells["Cinsiyet"].Value.ToString();
            }
        }

        #endregion


        #region DOSYALAMA İŞLEMİ


        void DosyalariListele()
        {
            DataTable veri = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter(" SELECT b.BelgeID,b.BelgeTipi,b.BelgeAdi,b.DosyaTipi,b.YuklemeTarihi,b.DosyaAciklamasi," +
                "k.Ad + ' ' + k.Soyad AS AdSoyad FROM Belgeler b INNER JOIN KisiBelge kb ON b.BelgeID = kb.BelgeID INNER JOIN " +
                "Kisiler k ON kb.KisiID = k.KisiID ORDER BY  b.YuklemeTarihi DESC", baglanti);
            adptr.Fill(veri);
            SonDosya.DataSource = veri;
            Temizle();
        }
        private void D_ekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Multiselect = true;
            // Desteklenen dosya türleri: resim, PDF, Word
            dosya.Filter = "Resim, PDF ve Word Dosyaları|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx";

            if (dosya.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (string dosyaYolu in dosya.FileNames)
            {
                // Dosya adını alıyoruz
                string dosyaAdi = Path.GetFileName(dosyaYolu);


                // Dinamik olarak bir LinkLabel oluşturuyoruz
                LinkLabel link = new LinkLabel();
                link.Text = dosyaAdi;
                // Dosya yolunu Tag özelliğinde saklıyoruz
                link.Tag = dosyaYolu;
                link.AutoSize = true;
                link.Margin = new Padding(5);

                // LinkLabel'e tıklandığında dosyayı açacak olay ekliyoruz
                link.Click += (s, ev) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(dosyaYolu) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya açılamadı: " + ex.Message);
                    }
                };

                // LinkLabel'i FlowLayoutPanel (veya başka bir container) içine ekliyoruz
                flowLayoutPanel1.Controls.Add(link);

            }

        }
        private void SonDosya_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = SonDosya.Rows[e.RowIndex];

                Sil_ID.Text = row.Cells["BelgeID"].Value.ToString();
                BelgeTipi.Text = row.Cells["BelgeTipi"].Value.ToString();
                BelgeAdi.Text = row.Cells["BelgeAdi"].Value.ToString();
                DosyaTipi.Text = row.Cells["DosyaTipi"].Value.ToString();
                DosyaAciklamasi.Text = row.Cells["DosyaAciklamasi"].Value.ToString();
            }
        }

        private void SonDosyaGetir_Click(object sender, EventArgs e)
        {
            dosya.DosyaListele(SonDosya);
        }
        DosyaAlani dosya = new DosyaAlani();

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

        private void SonDosya_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                Sil_ID.Text = SonDosya.Rows[e.RowIndex].Cells["BelgeID"].Value.ToString();
        }

        private void SonDosya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = SonDosya.Rows[e.RowIndex];
                Sil_ID.Text = row.Cells["BelgeID"].Value.ToString();
                BelgeTipi.Text = row.Cells["BelgeTipi"].Value.ToString();
                BelgeAdi.Text = row.Cells["BelgeAdi"].Value.ToString();
                DosyaTipi.Text = row.Cells["DosyaTipi"].Value.ToString();
                DosyaAciklamasi.Text = row.Cells["DosyaAciklamasi"].Value.ToString();
            }
        }

        private void DosyaAc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Sil_ID.Text))
                dosya.DosyaAc(Convert.ToInt32(Sil_ID.Text));
        }

        private void DosyaGuncelle_Click(object sender, EventArgs e)
        {
            dosya.DosyaGuncelle(Sil_ID, BelgeTipi, BelgeAdi, DosyaTipi, DosyaAciklamasi, SonDosya);
            Temizle();
        }

        #endregion


        #region YEDEKLEME ALANI


        private void YedekBasla_Click(object sender, EventArgs e)
        {

            Yedeklem yedeklem = new Yedeklem();
            yedeklem.KisiVeyaTumunuYedekle(KisiSorgu, YedekTarih, TumKisi, YedekData);


        }
        #endregion



    }
}
