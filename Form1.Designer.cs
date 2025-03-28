namespace KAYIT_VE_ARŞİV
{
    partial class Anasayfa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabControl tabControl1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            SorguPanel = new TabPage();
            BelgeSorgu = new ComboBox();
            label8 = new Label();
            SorguYap = new Button();
            SorguDataGrid = new DataGridView();
            KisiSorgu = new ComboBox();
            label2 = new Label();
            AySorgu = new TextBox();
            YilSorgu = new TextBox();
            ay = new Label();
            yil = new Label();
            DosyaEkle = new TabPage();
            DosyaSil = new Button();
            label10 = new Label();
            Sil_ID = new TextBox();
            label11 = new Label();
            BelgeAdi = new TextBox();
            B_Adi = new Label();
            label6 = new Label();
            DosyaTipi = new TextBox();
            SonDosyaGetir = new Button();
            KisiSec = new ComboBox();
            label9 = new Label();
            label7 = new Label();
            SonDosya = new DataGridView();
            DosyaAciklamasi = new TextBox();
            DosyaKonusu = new Label();
            BelgeTipi = new TextBox();
            D_Kaydet = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            D_ekle = new Button();
            D_tipi = new Label();
            Y_sec = new Label();
            YedeklemePanel = new TabPage();
            YedekBasla = new Button();
            label4 = new Label();
            YedekData = new DataGridView();
            YedekTarih = new ComboBox();
            label3 = new Label();
            YedekKisiSec = new ComboBox();
            TumKisi = new CheckBox();
            label1 = new Label();
            YeniKisiEkle = new TabPage();
            label5 = new Label();
            KisiGetir = new Button();
            Id = new TextBox();
            labelID = new Label();
            KisiGoster = new DataGridView();
            Guncelle = new Button();
            Sil = new Button();
            Cinsiyet = new TextBox();
            DogumTarihi = new TextBox();
            SoyadiEkle = new TextBox();
            AdiEkle = new TextBox();
            KisiEkleOkul = new Label();
            KisiEkleIs = new Label();
            KisiEkleSoyadi = new Label();
            KisiEkleAdi = new Label();
            YeniKayit = new Button();
            tabControl1 = new TabControl();
            tabControl1.SuspendLayout();
            SorguPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SorguDataGrid).BeginInit();
            DosyaEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SonDosya).BeginInit();
            YedeklemePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)YedekData).BeginInit();
            YeniKisiEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)KisiGoster).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.AllowDrop = true;
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(SorguPanel);
            tabControl1.Controls.Add(DosyaEkle);
            tabControl1.Controls.Add(YedeklemePanel);
            tabControl1.Controls.Add(YeniKisiEkle);
            tabControl1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabControl1.ImeMode = ImeMode.On;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(30, 9);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1842, 1177);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 0;
            // 
            // SorguPanel
            // 
            SorguPanel.AllowDrop = true;
            SorguPanel.AutoScroll = true;
            SorguPanel.AutoScrollMargin = new Size(25, 15);
            SorguPanel.BackColor = Color.White;
            SorguPanel.BackgroundImage = (Image)resources.GetObject("SorguPanel.BackgroundImage");
            SorguPanel.Controls.Add(BelgeSorgu);
            SorguPanel.Controls.Add(label8);
            SorguPanel.Controls.Add(SorguYap);
            SorguPanel.Controls.Add(SorguDataGrid);
            SorguPanel.Controls.Add(KisiSorgu);
            SorguPanel.Controls.Add(label2);
            SorguPanel.Controls.Add(AySorgu);
            SorguPanel.Controls.Add(YilSorgu);
            SorguPanel.Controls.Add(ay);
            SorguPanel.Controls.Add(yil);
            SorguPanel.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            SorguPanel.ForeColor = SystemColors.ControlText;
            SorguPanel.Location = new Point(4, 56);
            SorguPanel.Name = "SorguPanel";
            SorguPanel.Padding = new Padding(3);
            SorguPanel.RightToLeft = RightToLeft.No;
            SorguPanel.Size = new Size(1834, 1117);
            SorguPanel.TabIndex = 0;
            SorguPanel.Text = "SORGU PANELİ";
            // 
            // BelgeSorgu
            // 
            BelgeSorgu.AllowDrop = true;
            BelgeSorgu.FormattingEnabled = true;
            BelgeSorgu.Location = new Point(259, 185);
            BelgeSorgu.Name = "BelgeSorgu";
            BelgeSorgu.Size = new Size(267, 40);
            BelgeSorgu.TabIndex = 9;
            // 
            // label8
            // 
            label8.AllowDrop = true;
            label8.AutoSize = true;
            label8.BackColor = Color.Azure;
            label8.ForeColor = Color.DarkBlue;
            label8.Location = new Point(21, 193);
            label8.MinimumSize = new Size(0, 20);
            label8.Name = "label8";
            label8.Size = new Size(210, 32);
            label8.TabIndex = 8;
            label8.Text = "BELGE TÜRÜ SEÇ";
            // 
            // SorguYap
            // 
            SorguYap.AllowDrop = true;
            SorguYap.BackColor = Color.BlanchedAlmond;
            SorguYap.ForeColor = Color.DarkOrange;
            SorguYap.Location = new Point(674, 170);
            SorguYap.Name = "SorguYap";
            SorguYap.Size = new Size(269, 68);
            SorguYap.TabIndex = 7;
            SorguYap.Text = "SORGUYU BAŞLAT";
            SorguYap.UseVisualStyleBackColor = false;
            SorguYap.Click += SorguYap_Click;
            // 
            // SorguDataGrid
            // 
            SorguDataGrid.AllowDrop = true;
            SorguDataGrid.AllowUserToOrderColumns = true;
            SorguDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SorguDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SorguDataGrid.BackgroundColor = Color.DarkCyan;
            SorguDataGrid.ColumnHeadersHeight = 34;
            SorguDataGrid.Location = new Point(8, 253);
            SorguDataGrid.Name = "SorguDataGrid";
            SorguDataGrid.RowHeadersWidth = 62;
            SorguDataGrid.Size = new Size(1820, 856);
            SorguDataGrid.TabIndex = 6;
            // 
            // KisiSorgu
            // 
            KisiSorgu.AllowDrop = true;
            KisiSorgu.FormattingEnabled = true;
            KisiSorgu.Location = new Point(259, 105);
            KisiSorgu.Name = "KisiSorgu";
            KisiSorgu.Size = new Size(267, 40);
            KisiSorgu.TabIndex = 5;
            // 
            // label2
            // 
            label2.AllowDrop = true;
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.ForeColor = Color.DarkBlue;
            label2.Location = new Point(21, 113);
            label2.Name = "label2";
            label2.Size = new Size(184, 32);
            label2.TabIndex = 4;
            label2.Text = "KİŞİYİ SEÇİNİZ";
            // 
            // AySorgu
            // 
            AySorgu.AllowDrop = true;
            AySorgu.Location = new Point(846, 39);
            AySorgu.Name = "AySorgu";
            AySorgu.Size = new Size(267, 40);
            AySorgu.TabIndex = 3;
            // 
            // YilSorgu
            // 
            YilSorgu.AllowDrop = true;
            YilSorgu.Location = new Point(259, 42);
            YilSorgu.Name = "YilSorgu";
            YilSorgu.Size = new Size(267, 40);
            YilSorgu.TabIndex = 1;
            // 
            // ay
            // 
            ay.AllowDrop = true;
            ay.AutoSize = true;
            ay.BackColor = Color.Azure;
            ay.ForeColor = Color.DarkBlue;
            ay.Location = new Point(674, 42);
            ay.Name = "ay";
            ay.Size = new Size(154, 32);
            ay.TabIndex = 2;
            ay.Text = "AYI GİRİNİZ";
            // 
            // yil
            // 
            yil.AllowDrop = true;
            yil.AutoSize = true;
            yil.BackColor = Color.Azure;
            yil.ForeColor = Color.DarkBlue;
            yil.Location = new Point(21, 42);
            yil.MinimumSize = new Size(0, 20);
            yil.Name = "yil";
            yil.Size = new Size(149, 32);
            yil.TabIndex = 0;
            yil.Text = "YIL GİRİNİZ";
            // 
            // DosyaEkle
            // 
            DosyaEkle.AllowDrop = true;
            DosyaEkle.BackColor = SystemColors.ControlLight;
            DosyaEkle.BackgroundImage = (Image)resources.GetObject("DosyaEkle.BackgroundImage");
            DosyaEkle.Controls.Add(DosyaSil);
            DosyaEkle.Controls.Add(label10);
            DosyaEkle.Controls.Add(Sil_ID);
            DosyaEkle.Controls.Add(label11);
            DosyaEkle.Controls.Add(BelgeAdi);
            DosyaEkle.Controls.Add(B_Adi);
            DosyaEkle.Controls.Add(label6);
            DosyaEkle.Controls.Add(DosyaTipi);
            DosyaEkle.Controls.Add(SonDosyaGetir);
            DosyaEkle.Controls.Add(KisiSec);
            DosyaEkle.Controls.Add(label9);
            DosyaEkle.Controls.Add(label7);
            DosyaEkle.Controls.Add(SonDosya);
            DosyaEkle.Controls.Add(DosyaAciklamasi);
            DosyaEkle.Controls.Add(DosyaKonusu);
            DosyaEkle.Controls.Add(BelgeTipi);
            DosyaEkle.Controls.Add(D_Kaydet);
            DosyaEkle.Controls.Add(flowLayoutPanel1);
            DosyaEkle.Controls.Add(D_ekle);
            DosyaEkle.Controls.Add(D_tipi);
            DosyaEkle.Controls.Add(Y_sec);
            DosyaEkle.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            DosyaEkle.Location = new Point(4, 56);
            DosyaEkle.Name = "DosyaEkle";
            DosyaEkle.Padding = new Padding(3);
            DosyaEkle.Size = new Size(1834, 1117);
            DosyaEkle.TabIndex = 1;
            DosyaEkle.Text = "DOSYA EKLE";
            // 
            // DosyaSil
            // 
            DosyaSil.BackColor = Color.Crimson;
            DosyaSil.Location = new Point(320, 400);
            DosyaSil.Name = "DosyaSil";
            DosyaSil.Size = new Size(278, 50);
            DosyaSil.TabIndex = 27;
            DosyaSil.Text = "DOSYAYI SİL";
            DosyaSil.UseVisualStyleBackColor = false;
            DosyaSil.Click += DosyaSil_Click;
            // 
            // label10
            // 
            label10.AllowDrop = true;
            label10.AutoSize = true;
            label10.ForeColor = Color.DarkViolet;
            label10.Location = new Point(901, 409);
            label10.Name = "label10";
            label10.Size = new Size(425, 32);
            label10.TabIndex = 26;
            label10.Text = "KİŞİYE  TIKLAYARAK SEÇEBİLİRSİN";
            // 
            // Sil_ID
            // 
            Sil_ID.AllowDrop = true;
            Sil_ID.Location = new Point(757, 406);
            Sil_ID.Name = "Sil_ID";
            Sil_ID.Size = new Size(138, 40);
            Sil_ID.TabIndex = 25;
            // 
            // label11
            // 
            label11.AllowDrop = true;
            label11.AutoSize = true;
            label11.Location = new Point(613, 409);
            label11.Name = "label11";
            label11.Size = new Size(138, 32);
            label11.TabIndex = 24;
            label11.Text = "ID GİRİNİZ";
            // 
            // BelgeAdi
            // 
            BelgeAdi.AllowDrop = true;
            BelgeAdi.BackColor = SystemColors.ActiveCaption;
            BelgeAdi.Location = new Point(232, 170);
            BelgeAdi.Name = "BelgeAdi";
            BelgeAdi.Size = new Size(283, 40);
            BelgeAdi.TabIndex = 22;
            // 
            // B_Adi
            // 
            B_Adi.AllowDrop = true;
            B_Adi.AutoSize = true;
            B_Adi.Location = new Point(28, 170);
            B_Adi.Name = "B_Adi";
            B_Adi.Size = new Size(138, 32);
            B_Adi.TabIndex = 21;
            B_Adi.Text = "BELGE ADİ";
            // 
            // label6
            // 
            label6.AllowDrop = true;
            label6.AutoSize = true;
            label6.BackColor = Color.Coral;
            label6.Location = new Point(521, 72);
            label6.Name = "label6";
            label6.Size = new Size(451, 32);
            label6.TabIndex = 20;
            label6.Text = "Belge adi (iş, Resmi, Sağlık, Okul vb.)";
            // 
            // DosyaTipi
            // 
            DosyaTipi.AllowDrop = true;
            DosyaTipi.BackColor = SystemColors.ActiveCaption;
            DosyaTipi.Location = new Point(232, 122);
            DosyaTipi.Name = "DosyaTipi";
            DosyaTipi.Size = new Size(283, 40);
            DosyaTipi.TabIndex = 19;
            // 
            // SonDosyaGetir
            // 
            SonDosyaGetir.Location = new Point(8, 400);
            SonDosyaGetir.Name = "SonDosyaGetir";
            SonDosyaGetir.Size = new Size(278, 50);
            SonDosyaGetir.TabIndex = 18;
            SonDosyaGetir.Text = "EKLENEN DOSYLAR GETİR";
            SonDosyaGetir.UseVisualStyleBackColor = true;
            SonDosyaGetir.Click += SonDosyaGetir_Click;
            // 
            // KisiSec
            // 
            KisiSec.AllowDrop = true;
            KisiSec.BackColor = SystemColors.ActiveCaption;
            KisiSec.FormattingEnabled = true;
            KisiSec.Location = new Point(232, 20);
            KisiSec.Name = "KisiSec";
            KisiSec.Size = new Size(283, 40);
            KisiSec.TabIndex = 17;
            // 
            // label9
            // 
            label9.AllowDrop = true;
            label9.AutoSize = true;
            label9.BackColor = SystemColors.Control;
            label9.Location = new Point(28, 23);
            label9.Name = "label9";
            label9.Size = new Size(110, 32);
            label9.TabIndex = 16;
            label9.Text = "KİŞİ SEÇ";
            // 
            // label7
            // 
            label7.AllowDrop = true;
            label7.AutoSize = true;
            label7.ForeColor = Color.SandyBrown;
            label7.Location = new Point(8, 341);
            label7.Name = "label7";
            label7.Size = new Size(0, 32);
            label7.TabIndex = 15;
            // 
            // SonDosya
            // 
            SonDosya.AllowDrop = true;
            SonDosya.AllowUserToAddRows = false;
            SonDosya.AllowUserToDeleteRows = false;
            SonDosya.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SonDosya.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SonDosya.BackgroundColor = Color.Cyan;
            SonDosya.BorderStyle = BorderStyle.Fixed3D;
            SonDosya.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            SonDosya.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SonDosya.EditMode = DataGridViewEditMode.EditOnF2;
            SonDosya.ImeMode = ImeMode.On;
            SonDosya.Location = new Point(8, 456);
            SonDosya.Name = "SonDosya";
            SonDosya.ReadOnly = true;
            SonDosya.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            SonDosya.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            SonDosya.Size = new Size(1818, 653);
            SonDosya.TabIndex = 14;
            SonDosya.VirtualMode = true;
            SonDosya.CellContentClick += SonDosya_CellClick;
            SonDosya.CellDoubleClick += SonDosya_CellClick;
            // 
            // DosyaAciklamasi
            // 
            DosyaAciklamasi.AllowDrop = true;
            DosyaAciklamasi.Location = new Point(292, 230);
            DosyaAciklamasi.Name = "DosyaAciklamasi";
            DosyaAciklamasi.Size = new Size(815, 40);
            DosyaAciklamasi.TabIndex = 13;
            // 
            // DosyaKonusu
            // 
            DosyaKonusu.AllowDrop = true;
            DosyaKonusu.AutoSize = true;
            DosyaKonusu.Location = new Point(28, 233);
            DosyaKonusu.Name = "DosyaKonusu";
            DosyaKonusu.Size = new Size(258, 32);
            DosyaKonusu.TabIndex = 12;
            DosyaKonusu.Text = "DOSYA ACIKLAMASI";
            // 
            // BelgeTipi
            // 
            BelgeTipi.AllowDrop = true;
            BelgeTipi.BackColor = SystemColors.ActiveCaption;
            BelgeTipi.Location = new Point(232, 69);
            BelgeTipi.Name = "BelgeTipi";
            BelgeTipi.Size = new Size(283, 40);
            BelgeTipi.TabIndex = 11;
            // 
            // D_Kaydet
            // 
            D_Kaydet.AllowDrop = true;
            D_Kaydet.ForeColor = Color.DodgerBlue;
            D_Kaydet.Location = new Point(751, 276);
            D_Kaydet.Name = "D_Kaydet";
            D_Kaydet.Size = new Size(356, 56);
            D_Kaydet.TabIndex = 10;
            D_Kaydet.Text = "DOSYALARI KAYDET";
            D_Kaydet.UseVisualStyleBackColor = true;
            D_Kaydet.Click += D_Kaydet_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = Color.Wheat;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(1119, 82);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(707, 291);
            flowLayoutPanel1.TabIndex = 9;
            // 
            // D_ekle
            // 
            D_ekle.AllowDrop = true;
            D_ekle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            D_ekle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            D_ekle.Location = new Point(1119, 34);
            D_ekle.Name = "D_ekle";
            D_ekle.Size = new Size(707, 42);
            D_ekle.TabIndex = 8;
            D_ekle.Text = "DOSYA EKLE";
            D_ekle.UseVisualStyleBackColor = true;
            D_ekle.Click += D_ekle_Click;
            // 
            // D_tipi
            // 
            D_tipi.AllowDrop = true;
            D_tipi.AutoSize = true;
            D_tipi.Location = new Point(28, 122);
            D_tipi.Name = "D_tipi";
            D_tipi.Size = new Size(170, 32);
            D_tipi.TabIndex = 4;
            D_tipi.Text = "DOSAYA TİPİ";
            // 
            // Y_sec
            // 
            Y_sec.AllowDrop = true;
            Y_sec.AutoSize = true;
            Y_sec.Location = new Point(28, 72);
            Y_sec.Name = "Y_sec";
            Y_sec.Size = new Size(141, 32);
            Y_sec.TabIndex = 0;
            Y_sec.Text = "BELGE TİPİ";
            // 
            // YedeklemePanel
            // 
            YedeklemePanel.AllowDrop = true;
            YedeklemePanel.BackColor = Color.Teal;
            YedeklemePanel.BackgroundImage = (Image)resources.GetObject("YedeklemePanel.BackgroundImage");
            YedeklemePanel.Controls.Add(YedekBasla);
            YedeklemePanel.Controls.Add(label4);
            YedeklemePanel.Controls.Add(YedekData);
            YedeklemePanel.Controls.Add(YedekTarih);
            YedeklemePanel.Controls.Add(label3);
            YedeklemePanel.Controls.Add(YedekKisiSec);
            YedeklemePanel.Controls.Add(TumKisi);
            YedeklemePanel.Controls.Add(label1);
            YedeklemePanel.Location = new Point(4, 56);
            YedeklemePanel.Name = "YedeklemePanel";
            YedeklemePanel.Padding = new Padding(3);
            YedeklemePanel.Size = new Size(1834, 1117);
            YedeklemePanel.TabIndex = 2;
            YedeklemePanel.Text = "YEDEKLEME PANELİ";
            // 
            // YedekBasla
            // 
            YedekBasla.AllowDrop = true;
            YedekBasla.BackColor = Color.BlanchedAlmond;
            YedekBasla.ForeColor = SystemColors.Desktop;
            YedekBasla.Location = new Point(645, 108);
            YedekBasla.Name = "YedekBasla";
            YedekBasla.Size = new Size(300, 68);
            YedekBasla.TabIndex = 32;
            YedekBasla.Text = "YEDEKLEMEYE BAŞLA";
            YedekBasla.UseVisualStyleBackColor = false;
            YedekBasla.Click += YedekBasla_Click;
            // 
            // label4
            // 
            label4.AllowDrop = true;
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.ForeColor = Color.DarkBlue;
            label4.Location = new Point(12, 342);
            label4.Name = "label4";
            label4.Size = new Size(306, 32);
            label4.TabIndex = 31;
            label4.Text = "YEDEKLENEN DOSYALAR";
            // 
            // YedekData
            // 
            YedekData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            YedekData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            YedekData.BackgroundColor = Color.Coral;
            YedekData.BorderStyle = BorderStyle.Fixed3D;
            YedekData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            YedekData.Location = new Point(3, 377);
            YedekData.Name = "YedekData";
            YedekData.RowHeadersWidth = 62;
            YedekData.Size = new Size(1828, 732);
            YedekData.TabIndex = 30;
            // 
            // YedekTarih
            // 
            YedekTarih.AllowDrop = true;
            YedekTarih.BackColor = SystemColors.Window;
            YedekTarih.FormattingEnabled = true;
            YedekTarih.Location = new Point(203, 118);
            YedekTarih.Name = "YedekTarih";
            YedekTarih.Size = new Size(360, 40);
            YedekTarih.TabIndex = 29;
            // 
            // label3
            // 
            label3.AllowDrop = true;
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.ForeColor = Color.DarkBlue;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(139, 32);
            label3.TabIndex = 28;
            label3.Text = "TARİH SEÇ";
            // 
            // YedekKisiSec
            // 
            YedekKisiSec.AllowDrop = true;
            YedekKisiSec.BackColor = SystemColors.Window;
            YedekKisiSec.FormattingEnabled = true;
            YedekKisiSec.Location = new Point(203, 25);
            YedekKisiSec.Name = "YedekKisiSec";
            YedekKisiSec.Size = new Size(360, 40);
            YedekKisiSec.TabIndex = 23;
            // 
            // TumKisi
            // 
            TumKisi.AutoSize = true;
            TumKisi.BackColor = SystemColors.ControlLight;
            TumKisi.ForeColor = Color.Crimson;
            TumKisi.Location = new Point(645, 29);
            TumKisi.Name = "TumKisi";
            TumKisi.Size = new Size(311, 36);
            TumKisi.TabIndex = 20;
            TumKisi.Text = "TÜM KİŞİLERİ YEDEKLE";
            TumKisi.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(160, 32);
            label1.TabIndex = 15;
            label1.Text = "KİŞİ SEÇİNİZ";
            // 
            // YeniKisiEkle
            // 
            YeniKisiEkle.AllowDrop = true;
            YeniKisiEkle.BackColor = Color.Wheat;
            YeniKisiEkle.Controls.Add(label5);
            YeniKisiEkle.Controls.Add(KisiGetir);
            YeniKisiEkle.Controls.Add(Id);
            YeniKisiEkle.Controls.Add(labelID);
            YeniKisiEkle.Controls.Add(KisiGoster);
            YeniKisiEkle.Controls.Add(Guncelle);
            YeniKisiEkle.Controls.Add(Sil);
            YeniKisiEkle.Controls.Add(Cinsiyet);
            YeniKisiEkle.Controls.Add(DogumTarihi);
            YeniKisiEkle.Controls.Add(SoyadiEkle);
            YeniKisiEkle.Controls.Add(AdiEkle);
            YeniKisiEkle.Controls.Add(KisiEkleOkul);
            YeniKisiEkle.Controls.Add(KisiEkleIs);
            YeniKisiEkle.Controls.Add(KisiEkleSoyadi);
            YeniKisiEkle.Controls.Add(KisiEkleAdi);
            YeniKisiEkle.Controls.Add(YeniKayit);
            YeniKisiEkle.Location = new Point(4, 56);
            YeniKisiEkle.Name = "YeniKisiEkle";
            YeniKisiEkle.Padding = new Padding(3);
            YeniKisiEkle.Size = new Size(1834, 1117);
            YeniKisiEkle.TabIndex = 3;
            YeniKisiEkle.Text = "KİŞİ EKLE";
            // 
            // label5
            // 
            label5.AllowDrop = true;
            label5.AutoSize = true;
            label5.ForeColor = Color.DarkBlue;
            label5.Location = new Point(753, 52);
            label5.Name = "label5";
            label5.Size = new Size(492, 32);
            label5.TabIndex = 18;
            label5.Text = "Kişi seçerken  tıklamınız yeterli olacaktır.";
            // 
            // KisiGetir
            // 
            KisiGetir.AllowDrop = true;
            KisiGetir.BackColor = Color.Turquoise;
            KisiGetir.Location = new Point(936, 309);
            KisiGetir.Name = "KisiGetir";
            KisiGetir.Size = new Size(265, 75);
            KisiGetir.TabIndex = 17;
            KisiGetir.Text = "KİŞİLERİ GETİR";
            KisiGetir.UseVisualStyleBackColor = false;
            KisiGetir.Click += KisiGetir_Click;
            // 
            // Id
            // 
            Id.AllowDrop = true;
            Id.Location = new Point(554, 85);
            Id.Name = "Id";
            Id.Size = new Size(138, 40);
            Id.TabIndex = 16;
            // 
            // labelID
            // 
            labelID.AllowDrop = true;
            labelID.AutoSize = true;
            labelID.Location = new Point(554, 50);
            labelID.Name = "labelID";
            labelID.Size = new Size(138, 32);
            labelID.TabIndex = 15;
            labelID.Text = "ID GİRİNİZ";
            // 
            // KisiGoster
            // 
            KisiGoster.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            KisiGoster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            KisiGoster.BackgroundColor = Color.Coral;
            KisiGoster.BorderStyle = BorderStyle.Fixed3D;
            KisiGoster.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            KisiGoster.Location = new Point(21, 420);
            KisiGoster.Name = "KisiGoster";
            KisiGoster.RowHeadersWidth = 62;
            KisiGoster.Size = new Size(1807, 689);
            KisiGoster.TabIndex = 14;
            KisiGoster.CellClick += KisiGoster_CellClick;
            KisiGoster.CellDoubleClick += KisiGoster_CellClick;
            // 
            // Guncelle
            // 
            Guncelle.AllowDrop = true;
            Guncelle.BackColor = Color.Yellow;
            Guncelle.Location = new Point(630, 309);
            Guncelle.Name = "Guncelle";
            Guncelle.Size = new Size(265, 75);
            Guncelle.TabIndex = 13;
            Guncelle.Text = "KİŞİ GÜNCELLE";
            Guncelle.UseVisualStyleBackColor = false;
            Guncelle.Click += Guncelle_Click;
            // 
            // Sil
            // 
            Sil.AllowDrop = true;
            Sil.BackColor = Color.Crimson;
            Sil.Location = new Point(319, 309);
            Sil.Name = "Sil";
            Sil.Size = new Size(265, 75);
            Sil.TabIndex = 12;
            Sil.Text = "KİŞİ SİL";
            Sil.UseVisualStyleBackColor = false;
            Sil.Click += Sil_Click;
            // 
            // Cinsiyet
            // 
            Cinsiyet.AllowDrop = true;
            Cinsiyet.Location = new Point(239, 250);
            Cinsiyet.Name = "Cinsiyet";
            Cinsiyet.Size = new Size(236, 40);
            Cinsiyet.TabIndex = 11;
            // 
            // DogumTarihi
            // 
            DogumTarihi.AllowDrop = true;
            DogumTarihi.Location = new Point(239, 184);
            DogumTarihi.Name = "DogumTarihi";
            DogumTarihi.Size = new Size(236, 40);
            DogumTarihi.TabIndex = 9;
            // 
            // SoyadiEkle
            // 
            SoyadiEkle.AllowDrop = true;
            SoyadiEkle.Location = new Point(239, 118);
            SoyadiEkle.Name = "SoyadiEkle";
            SoyadiEkle.Size = new Size(236, 40);
            SoyadiEkle.TabIndex = 8;
            // 
            // AdiEkle
            // 
            AdiEkle.AllowDrop = true;
            AdiEkle.Location = new Point(239, 52);
            AdiEkle.Name = "AdiEkle";
            AdiEkle.Size = new Size(236, 40);
            AdiEkle.TabIndex = 7;
            // 
            // KisiEkleOkul
            // 
            KisiEkleOkul.AllowDrop = true;
            KisiEkleOkul.AutoSize = true;
            KisiEkleOkul.Location = new Point(21, 254);
            KisiEkleOkul.Name = "KisiEkleOkul";
            KisiEkleOkul.Size = new Size(122, 32);
            KisiEkleOkul.TabIndex = 6;
            KisiEkleOkul.Text = "CİNSİYET";
            // 
            // KisiEkleIs
            // 
            KisiEkleIs.AllowDrop = true;
            KisiEkleIs.AutoSize = true;
            KisiEkleIs.Location = new Point(21, 186);
            KisiEkleIs.Name = "KisiEkleIs";
            KisiEkleIs.Size = new Size(200, 32);
            KisiEkleIs.TabIndex = 3;
            KisiEkleIs.Text = "DOĞUM TARİHİ";
            // 
            // KisiEkleSoyadi
            // 
            KisiEkleSoyadi.AllowDrop = true;
            KisiEkleSoyadi.AutoSize = true;
            KisiEkleSoyadi.Location = new Point(21, 118);
            KisiEkleSoyadi.Name = "KisiEkleSoyadi";
            KisiEkleSoyadi.Size = new Size(106, 32);
            KisiEkleSoyadi.TabIndex = 2;
            KisiEkleSoyadi.Text = "SOYADI";
            // 
            // KisiEkleAdi
            // 
            KisiEkleAdi.AllowDrop = true;
            KisiEkleAdi.AutoSize = true;
            KisiEkleAdi.Location = new Point(21, 50);
            KisiEkleAdi.Name = "KisiEkleAdi";
            KisiEkleAdi.Size = new Size(58, 32);
            KisiEkleAdi.TabIndex = 1;
            KisiEkleAdi.Text = "ADI";
            // 
            // YeniKayit
            // 
            YeniKayit.AllowDrop = true;
            YeniKayit.BackColor = Color.Lime;
            YeniKayit.Location = new Point(21, 309);
            YeniKayit.Name = "YeniKayit";
            YeniKayit.Size = new Size(265, 75);
            YeniKayit.TabIndex = 0;
            YeniKayit.Text = "YENİ KİŞİ EKLE";
            YeniKayit.UseVisualStyleBackColor = false;
            YeniKayit.Click += YeniKayit_Click;
            // 
            // Anasayfa
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1869, 1177);
            Controls.Add(tabControl1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Anasayfa";
            Text = "KAYIT VE ARŞİV";
            tabControl1.ResumeLayout(false);
            SorguPanel.ResumeLayout(false);
            SorguPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SorguDataGrid).EndInit();
            DosyaEkle.ResumeLayout(false);
            DosyaEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SonDosya).EndInit();
            YedeklemePanel.ResumeLayout(false);
            YedeklemePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)YedekData).EndInit();
            YeniKisiEkle.ResumeLayout(false);
            YeniKisiEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)KisiGoster).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabPage YeniKisiEkle;
        private TextBox Cinsiyet;
        private TextBox DogumTarihi;
        private TextBox SoyadiEkle;
        private TextBox AdiEkle;
        private Label KisiEkleOkul;
        private Label KisiEkleIs;
        private Label KisiEkleSoyadi;
        private Label KisiEkleAdi;
        private Button YeniKayit;
        private TabPage YedeklemePanel;
     
       
        private Label label1;
      
      
        public TabPage SorguPanel;
        private Button SorguYap;
        private DataGridView SorguDataGrid;
        private ComboBox KisiSorgu;
        private Label label2;
        private TextBox AySorgu;
        private TextBox YilSorgu;
        private Label ay;
        private Label yil;
        private TabPage DosyaEkle;
        private TextBox DosyaAciklamasi;
        private Label DosyaKonusu;
        private TextBox BelgeTipi;
        private Button D_Kaydet;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button D_ekle;
        private Label D_tipi;
        private Label Y_sec;
        private ComboBox BelgeSorgu;
        private Label label8;
        private Label label9;
        private DataGridView KisiGoster;
        private Button Guncelle;
        private Button Sil;
        private TextBox Id;
        private Label labelID;
        private Button KisiGetir;
        private Label label5;
        private Button SonDosyaGetir;
        private Label label7;
        private TextBox DosyaTipi;
        private Label label6;
        private TextBox BelgeAdi;
        private Label B_Adi;
        public DataGridView SonDosya;
        private Label label10;
        private TextBox Sil_ID;
        private Label label11;
        private Button DosyaSil;
        private CheckBox TumKisi;
        private ComboBox KisiSec;
        private ComboBox YedekKisiSec;
        private ComboBox YedekTarih;
        private Label label3;
        private Label label4;
        private DataGridView YedekData;
        private Button YedekBasla;
    }
}
