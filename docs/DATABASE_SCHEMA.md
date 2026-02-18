# 🗄️ Veritabanı Şeması

## Genel Bakış

Toptancı Hub, SQLite yerel veritabanı kullanır. Tüm veriler cihazda saklanır ve backend sunucuya ihtiyaç yoktur.

## 📊 Tablolar

### 1. Users (Kullanıcılar)

Sistemdeki tüm kullanıcı bilgilerini saklar.

| Kolon | Tip | Açıklama | Özellikler |
|-------|-----|----------|-----------|
| Id | INTEGER | Benzersiz kullanıcı kimliği | PRIMARY KEY, AUTOINCREMENT |
| Ad | TEXT | Kullanıcının adı | NOT NULL |
| Soyad | TEXT | Kullanıcının soyadı | NOT NULL |
| Email | TEXT | E-posta adresi | NOT NULL, UNIQUE |
| Sifre | TEXT | Şifre (hash'lenmiş olmalı) | NOT NULL |
| Rol | INTEGER | Kullanıcı rolü (1=Satıcı, 2=Toptancı) | NOT NULL |
| Telefon | TEXT | Telefon numarası | NOT NULL |
| Adres | TEXT | Adres bilgisi | NULL |
| ProfilFotoUrl | TEXT | Profil fotoğrafı URL'i | NULL |
| KayitTarihi | DATETIME | Kayıt tarihi | NOT NULL |
| AktifMi | BOOLEAN | Hesap aktif mi? | NOT NULL, DEFAULT TRUE |

**İndeksler:**
- `idx_users_email` on Email
- `idx_users_rol` on Rol

### 2. Campaigns (Kampanyalar)

Toptancılar tarafından oluşturulan kampanya bilgilerini saklar.

| Kolon | Tip | Açıklama | Özellikler |
|-------|-----|----------|-----------|
| Id | INTEGER | Benzersiz kampanya kimliği | PRIMARY KEY, AUTOINCREMENT |
| ToptanciId | INTEGER | Kampanya sahibi toptancı ID | NOT NULL, FOREIGN KEY |
| Baslik | TEXT | Kampanya başlığı | NOT NULL |
| Aciklama | TEXT | Kampanya açıklaması | NULL |
| GorselUrl | TEXT | Kampanya görseli URL'i | NULL |
| BaslangicTarihi | DATETIME | Kampanya başlangıç tarihi | NOT NULL |
| BitisTarihi | DATETIME | Kampanya bitiş tarihi | NOT NULL |
| AktifMi | BOOLEAN | Kampanya aktif mi? | NOT NULL, DEFAULT TRUE |
| GoruntulenmeSayisi | INTEGER | Kaç kez görüntülendi | DEFAULT 0 |
| BegeniSayisi | INTEGER | Beğeni sayısı | DEFAULT 0 |
| OlusturmaTarihi | DATETIME | Oluşturulma tarihi | NOT NULL |

**İlişkiler:**
- `ToptanciId` → `Users(Id)` where Rol = Toptanci

**İndeksler:**
- `idx_campaigns_toptanci` on ToptanciId
- `idx_campaigns_aktif` on AktifMi
- `idx_campaigns_tarih` on BaslangicTarihi, BitisTarihi

### 3. Products (Ürünler)

Kampanyalardaki ürün bilgilerini saklar.

| Kolon | Tip | Açıklama | Özellikler |
|-------|-----|----------|-----------|
| Id | INTEGER | Benzersiz ürün kimliği | PRIMARY KEY, AUTOINCREMENT |
| KampanyaId | INTEGER | Bağlı olduğu kampanya ID | NOT NULL, FOREIGN KEY |
| UrunAdi | TEXT | Ürün adı | NOT NULL |
| Aciklama | TEXT | Ürün açıklaması | NULL |
| TemelFiyat | DECIMAL | Temel fiyat | NOT NULL |
| Birim | TEXT | Birim (kg, adet, vb.) | NOT NULL |
| StokMiktari | INTEGER | Stok miktarı | NOT NULL, DEFAULT 0 |
| Kategori | TEXT | Ürün kategorisi | NULL |
| GorselUrl | TEXT | Ürün görseli URL'i | NULL |

**İlişkiler:**
- `KampanyaId` → `Campaigns(Id)`

**İndeksler:**
- `idx_products_kampanya` on KampanyaId
- `idx_products_kategori` on Kategori

### 4. PriceOffers (Fiyat Teklifleri)

Satıcıların ürünler için verdiği fiyat tekliflerini saklar.

| Kolon | Tip | Açıklama | Özellikler |
|-------|-----|----------|-----------|
| Id | INTEGER | Benzersiz teklif kimliği | PRIMARY KEY, AUTOINCREMENT |
| UrunId | INTEGER | Teklif edilen ürün ID | NOT NULL, FOREIGN KEY |
| SaticiId | INTEGER | Teklifi veren satıcı ID | NOT NULL, FOREIGN KEY |
| Miktar | INTEGER | Teklif edilen miktar | NOT NULL |
| TeklifEdilenFiyat | DECIMAL | Birim başına teklif fiyat | NOT NULL |
| ToplamTutar | DECIMAL | Toplam tutar (Miktar × Fiyat) | NOT NULL |
| Durum | INTEGER | Teklif durumu (1=Bekliyor, 2=Onaylandı, 3=Reddedildi, 4=SiparisVerildi) | NOT NULL, DEFAULT 1 |
| TeklifTarihi | DATETIME | Teklifin verildiği tarih | NOT NULL |
| CevapTarihi | DATETIME | Teklifin cevaplanma tarihi | NULL |
| ToptanciNotu | TEXT | Toptancının notu | NULL |

**İlişkiler:**
- `UrunId` → `Products(Id)`
- `SaticiId` → `Users(Id)` where Rol = Satici

**İndeksler:**
- `idx_priceoffers_urun` on UrunId
- `idx_priceoffers_satici` on SaticiId
- `idx_priceoffers_durum` on Durum

### 5. PriceTiers (Kademeli Fiyatlandırma)

Ürünler için miktar bazlı fiyatlandırma kurallarını saklar.

| Kolon | Tip | Açıklama | Özellikler |
|-------|-----|----------|-----------|
| Id | INTEGER | Benzersiz kural kimliği | PRIMARY KEY, AUTOINCREMENT |
| UrunId | INTEGER | Bağlı olduğu ürün ID | NOT NULL, FOREIGN KEY |
| MinMiktar | INTEGER | Minimum miktar | NOT NULL |
| MaxMiktar | INTEGER | Maksimum miktar | NOT NULL |
| IndirimYuzdesi | DECIMAL | İndirim yüzdesi | NOT NULL, DEFAULT 0 |
| SabitFiyat | DECIMAL | Sabit fiyat (varsa) | NULL |

**İlişkiler:**
- `UrunId` → `Products(Id)`

**İndeksler:**
- `idx_pricetiers_urun` on UrunId

## 🔗 İlişki Diyagramı

```
Users (Toptancı)
    |
    | 1:N
    |
Campaigns
    |
    | 1:N
    |
Products ──────┐
    |          |
    | 1:N      | 1:N
    |          |
PriceOffers  PriceTiers
    |
    | N:1
    |
Users (Satıcı)
```

## 💡 Önemli Notlar

### Veri Bütünlüğü
- Tüm foreign key ilişkileri uygulama seviyesinde kontrol edilir
- SQLite'ın foreign key constraints özelliği aktif değilse manuel kontrol gerekir

### Performans Optimizasyonu
- Sık kullanılan sorgular için indeksler tanımlanmıştır
- Büyük veri setleri için pagination kullanılmalıdır

### Veri Silme Stratejisi
- **Cascade Delete**: Kampanya silindiğinde, ona bağlı ürünler de silinir
- **Soft Delete**: Kullanıcılar ve kampanyalar `AktifMi` alanı ile soft delete yapılabilir

### Güvenlik
- Şifreler kesinlikle düz metin olarak saklanmamalı (hash + salt kullan)
- Hassas veriler için encryption düşünülmelidir

## 📝 Örnek Sorgular

### Aktif Kampanyaları Getir
```sql
SELECT * FROM Campaigns 
WHERE AktifMi = 1 
  AND BaslangicTarihi <= datetime('now') 
  AND BitisTarihi >= datetime('now')
ORDER BY OlusturmaTarihi DESC;
```

### Bir Ürün İçin Tüm Fiyat Kademelerini Getir
```sql
SELECT * FROM PriceTiers 
WHERE UrunId = ? 
ORDER BY MinMiktar ASC;
```

### Bekleyen Teklifleri Getir
```sql
SELECT po.*, p.UrunAdi, u.Ad, u.Soyad
FROM PriceOffers po
INNER JOIN Products p ON po.UrunId = p.Id
INNER JOIN Users u ON po.SaticiId = u.Id
WHERE po.Durum = 1
ORDER BY po.TeklifTarihi DESC;
```

### Bir Toptancının Kampanyalarını ve Ürün Sayılarını Getir
```sql
SELECT c.*, COUNT(p.Id) as UrunSayisi
FROM Campaigns c
LEFT JOIN Products p ON c.Id = p.KampanyaId
WHERE c.ToptanciId = ?
GROUP BY c.Id
ORDER BY c.OlusturmaTarihi DESC;
```

## 🔄 Migration Stratejisi

Veritabanı şeması değişiklikleri için:
1. Versiyon kontrolü kullan (örn: `DatabaseVersion` tablosu)
2. Migration scriptleri oluştur
3. Eski verileri koru
4. Geriye dönük uyumluluğu test et
