using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KAYIT_ARSIV
{
    public class Sorgu
    {
       private SqlConnection baglanti = new SqlConnection("Data Source=MEHMET;Initial Catalog=KayitVeArsiv;Integrated Security=True;TrustServerCertificate=True");

        public void KisiyeGoreSorgu(ComboBox KisiSorgu, ComboBox BelgeSorgu, TextBox YilSorgu, TextBox AySorgu, DataGridView SorguDataGrid)
        {
            if (KisiSorgu.SelectedItem == null || KisiSorgu.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir kişi seçin.");
                return;
            }

            int kisiID = (int)KisiSorgu.SelectedValue;
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
            k.Ad + ' ' + k.Soyad AS AdSoyad
        FROM 
            Belgeler b
        INNER JOIN 
            KisiBelge kb ON b.BelgeID = kb.BelgeID
        INNER JOIN 
            Kisiler k ON kb.KisiID = k.KisiID
        WHERE 
            kb.KisiID = @KisiID";

            // Dinamik sorguya yıl ve ayı ekle
            if (!string.IsNullOrEmpty(belgeTuru))
            {
                sorgu += " AND b.BelgeTipi = @BelgeTipi";
            }

            if (!string.IsNullOrEmpty(yil))
            {
                sorgu += " AND YEAR(b.YuklemeTarihi) = @Yil";
            }

            if (!string.IsNullOrEmpty(ay))
            {
                sorgu += " AND MONTH(b.YuklemeTarihi) = @Ay";
            }

            try
            {
                baglanti.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
                adapter.SelectCommand.Parameters.AddWithValue("@KisiID", kisiID);

                if (!string.IsNullOrEmpty(belgeTuru))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@BelgeTipi", belgeTuru);
                }

                if (!string.IsNullOrEmpty(yil) && int.TryParse(yil, out int yilInt))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Yil", yilInt);
                }

                if (!string.IsNullOrEmpty(ay) && int.TryParse(ay, out int ayInt))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Ay", ayInt);
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
