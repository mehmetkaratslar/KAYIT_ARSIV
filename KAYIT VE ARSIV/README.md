
---

## 📁 Kayıt ve Arşiv Yönetim Sistemi (C# WinForms Projesi)

Bu proje, kullanıcıların kişisel bilgilerini ve onlara ait belgeleri sistematik bir şekilde saklamalarına ve yönetmelerine olanak sağlayan bir **Kayıt ve Arşiv Uygulamasıdır**. Uygulama, C# ve Windows Forms (WinForms) ile geliştirilmiştir.

---

### 🎯 Projenin Amacı

Kullanıcıların:
- Kişi bilgilerini sisteme eklemesi,
- Belge ve dosya eklemesi,
- Kayıtlı veriler üzerinde sorgulama yapması,
- Dosyaları güncellemesi veya silmesi

işlemlerini kolay ve kullanıcı dostu bir arayüzle gerçekleştirmesini sağlar.

---

### 🔍 Uygulama Panelleri ve Özellikleri

#### 📌 1. **Kişi Ekle Paneli**

Kullanıcı bu bölümden sisteme yeni bir kişi ekleyebilir, mevcut kişileri güncelleyebilir veya silebilir.

**Alanlar:**
- Adı
- Soyadı
- Doğum Tarihi
- Cinsiyet
- ID (Güncelleme ve silme işlemleri için)

**Butonlar:**
- ✅ Yeni Kişi Ekle
- ❌ Kişi Sil
- 🛠️ Kişi Güncelle
- 📋 Kişileri Getir

> 💡 Alt bölümde kayıtlı kişileri tablo şeklinde görüntüleyebilir, çift tıklayarak bilgilerini forma aktarabilirsiniz.

---

#### 📌 2. **Dosya Ekle Paneli**
Bu panel, kişilere ait belge veya dosyaların eklenmesini ve yönetilmesini sağlar.

**Alanlar:**
- Kişi Seç (Dropdown)
- Belge Tipi (İş, Sağlık, Resmi, Okul vb.)
- Dosya Tipi (PDF, JPG, DOCX vb.)
- Belge Adı
- Dosya Açıklaması
- ID (Silme işlemi için)

**Butonlar:**
- 📎 Dosya Ekle
- 💾 Dosyaları Kaydet
- 🗑️ Dosyayı Sil

> 📝 Dosyalar liste halinde altta gösterilir.

Görselde yer alan **Yedekleme Paneli** için README dosyasına ekleyebileceğin açıklayıcı bir bölüm aşağıda hazır:

---

### 💾 4. **Yedekleme Paneli**

Bu panel, sistemde kayıtlı kişi ve belgelerin yedeğini almak için kullanılır. Kullanıcı dilerse tek bir kişiyi, dilerse tüm kişileri seçerek yedekleme işlemini başlatabilir.

#### 🔹 Özellikler:
- **KİŞİ SEÇİNİZ:** Açılır listeden (ComboBox) yedeği alınacak kişi seçilir.
- **TÜM KİŞİLERİ YEDEKLE:** Bu kutu işaretlenirse, sistemdeki tüm kişilerin bilgileri ve belgeleri yedeklenir.
- **YEDEKLEMEYE BAŞLA:** Seçime göre yedekleme işlemini başlatır.

> ☑️ Yedeklemeler genellikle dışa aktarma (export) veya ayrı bir klasöre kopyalama şeklinde gerçekleşir.

#### 📁 Yedekleme İçeriği:
- Kişi bilgileri (Ad, Soyad, Doğum Tarihi, Cinsiyet vb.)
- Kişiye ait yüklenmiş tüm belgeler
- Dosya açıklamaları ve tür bilgileri

#### 🎯 Amaç:
Veri kaybına karşı önlem almak ve kayıtlı verileri başka bir ortamda saklayabilmeyi sağlamak.

---

Eğer istersen bu işlemlerin SQL yedeği mi yoksa dosya kopyalama mı olduğunu da açıklayabiliriz. Hangi tür yedekleme yapılıyor projenizde? `.bak`, `.zip`, `.csv`, `.json` ya da sadece klasör kopyalama? Ona göre teknik detay ekleyelim mi?
---

#### 📌 3. **Sorgu Paneli**
Bu panel, sisteme yüklenen dosyalar ve belgeler üzerinde filtreli sorgular yapılmasını sağlar.

**Filtreleme Alanları:**
- Yıl
- Ay
- Kişi
- Belge Türü

**Buton:**
- 🔍 Sorguyu Başlat

---

### 🛠️ Kullanılan Teknolojiler

- **Dil:** C#  
- **Arayüz:** Windows Forms (WinForms)  
- **Veritabanı:** (İsteğe bağlı: SQL Server, SQLite veya Access)  
- **Dosya Sistemi:** Belgeler klasörüne veya veritabanına dosya yolu ile kaydetme

---

### 📸 Ekran Görüntüleri

| Kişi Ekle Paneli | Dosya Ekle Paneli | Sorgu Paneli |
|------------------|-------------------|--------------|
| ![Kişi Ekle](./screenshots/kisi_ekle.png) | ![Dosya Ekle](./screenshots/dosya_ekle.png) | ![Sorgu Paneli](./screenshots/sorgu_paneli.png) |

> `screenshots` klasörü oluşturarak ekran görüntülerini oraya koyabilirsin.

---

### 📦 Kurulum

1. Visual Studio ile projeyi açın.
2. Gerekirse `veritabani.mdf` bağlantısını ayarlayın.
3. Uygulamayı başlatın ve test edin.

---

### 🧠 Geliştirici Notları

- Kodlar katmanlı mimariye göre sadeleştirilebilir (Entity, DAL, BLL gibi).
- Dosyalar fiziksel olarak da kaydedilebilir (örneğin `AppData` içine).
- Giriş ekranı ve kullanıcı yetkilendirmesi eklenebilir.

---

### 📬 İletişim

Projeyle ilgili herhangi bir öneri ya da katkı için benimle iletişime geçmekten çekinmeyin.

---

İstersen bu README’yi `.md` uzantılı bir dosya olarak da hazırlayabilirim veya senin yerine görselleri `screenshots/` klasörüne uygun adlarla kaydetmen için yönlendirme verebilirim.

Devam etmek ister misin?