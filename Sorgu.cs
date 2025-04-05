using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace KAYIT_ARSIV
{
    public class Sorgu
    {
        private readonly SQLiteConnection baglanti = new(SQLiteHelper.GetConnectionString());

        public void KisiyeGoreSorgu(ComboBox KisiSorgu, ComboBox BelgeSorgu, TextBox YilSorgu, TextBox AySorgu, DataGridView SorguDataGrid)
        {
            if (KisiSorgu.SelectedItem == null || KisiSorgu.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir kişi seçin.");
                return;
            }

            int kisiID = Convert.ToInt32(KisiSorgu.SelectedValue);
            string? belgeTuru = BelgeSorgu.SelectedItem?.ToString();
            string? yil = YilSorgu.Text.Trim();
            string? ay = AySorgu.Text.Trim();

            string sorgu = @"
                SELECT 
                    b.BelgeID, 
                    b.BelgeTipi, 
                    b.BelgeAdi, 
                    b.DosyaTipi, 
                    b.YuklemeTarihi, 
                    b.DosyaAciklamasi,
                    k.Ad || ' ' || k.Soyad AS AdSoyad
                FROM 
                    Belgeler b
                INNER JOIN 
                    KisiBelge kb ON b.BelgeID = kb.BelgeID
                INNER JOIN 
                    Kisiler k ON kb.KisiID = k.KisiID
                WHERE 
                    kb.KisiID = @KisiID";

            // Dinamik filtre eklemeleri
            if (!string.IsNullOrEmpty(belgeTuru))
            {
                sorgu += " AND b.BelgeTipi = @BelgeTipi";
            }

            if (!string.IsNullOrEmpty(yil))
            {
                sorgu += " AND strftime('%Y', b.YuklemeTarihi) = @Yil";
            }

            if (!string.IsNullOrEmpty(ay))
            {
                sorgu += " AND strftime('%m', b.YuklemeTarihi) = @Ay";
            }

            try
            {
                baglanti.Open();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sorgu, baglanti);
                adapter.SelectCommand.Parameters.AddWithValue("@KisiID", kisiID);

                if (!string.IsNullOrEmpty(belgeTuru))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@BelgeTipi", belgeTuru);
                }

                if (!string.IsNullOrEmpty(yil))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Yil", yil);
                }

                if (!string.IsNullOrEmpty(ay) && int.TryParse(ay, out int ayInt))
                {
                    // SQLite'ta ay 2 basamaklı olmalı: 01, 02, ..., 12
                    adapter.SelectCommand.Parameters.AddWithValue("@Ay", ayInt.ToString("D2"));
                }

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                SorguDataGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorgu sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
