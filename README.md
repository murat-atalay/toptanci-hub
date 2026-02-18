# 🛒 Toptancı Hub

**B2B Sosyal E-Ticaret Platformu**

Toptancı Hub, toptancılar ve satıcılar arasında köprü kuran, modern ve kullanıcı dostu bir B2B e-ticaret platformudur. Platformumuz, kampanya yönetimi, ürün katalogları, fiyat teklifleri ve kademeli fiyatlandırma gibi güçlü özellikler sunar.

## ✨ Özellikler

### 🎯 Kampanya Yönetimi
- Toptancılar özel kampanyalar oluşturabilir
- Kampanyalara özel görsel ve açıklama eklenebilir
- Başlangıç ve bitiş tarihleri ile zamanlı kampanyalar
- Görüntülenme ve beğeni sayılarını takip

### 📦 Ürün Katalogları
- Her kampanya için ürün listeleme
- Detaylı ürün açıklamaları ve görseller
- Kategori bazlı ürün organizasyonu
- Stok takibi ve birim yönetimi

### 💰 Fiyat Teklifi Sistemi
- Satıcılar ürünler için fiyat teklifi verebilir
- Teklifler bekliyor, onaylandı, reddedildi durumlarını takip
- Toptancılar tekliflere not ekleyebilir
- Otomatik toplam tutar hesaplama

### 📊 Kademeli Fiyatlandırma
- Miktar bazlı indirim yüzdeleri
- Minimum ve maksimum miktar aralıkları
- Sabit fiyat seçenekleri
- Otomatik fiyat hesaplama

### 👥 Kullanıcı Yönetimi
- İki rol: Satıcı ve Toptancı
- Profil yönetimi
- Güvenli kimlik doğrulama
- Hesap aktivasyon sistemi

## 🚀 Teknolojiler

### Platform
- **.NET 8**: En son .NET teknolojisi
- **.NET MAUI**: Cross-platform uygulama geliştirme
- **C#**: Modern programlama dili

### Kütüphaneler
- **CommunityToolkit.Mvvm (8.2.2)**: MVVM pattern implementasyonu
- **CommunityToolkit.Maui (7.0.1)**: MAUI için yardımcı araçlar
- **sqlite-net-pcl (1.9.172)**: Yerel veritabanı
- **SQLitePCLRaw.bundle_green (2.1.8)**: SQLite çalışma zamanı

### Mimari
- **MVVM Pattern**: Model-View-ViewModel mimarisi
- **Dependency Injection**: IoC container kullanımı
- **Repository Pattern**: Veri erişim katmanı soyutlaması

## 📱 Desteklenen Platformlar

- ✅ **Android** (API 21+)
- ✅ **iOS** (11.0+)
- ✅ **Windows** (10.0.17763.0+)
- ✅ **macOS** (Catalyst 13.1+)

## 🛠️ Kurulum

### Gereksinimler

1. **.NET 8 SDK veya üstü**
   ```bash
   dotnet --version
   ```

2. **Visual Studio 2022** (v17.8 veya üstü) veya **Visual Studio Code**
   - .NET MAUI workload yüklü olmalı

3. **Android SDK** (Android geliştirme için)
4. **Xcode** (iOS/macOS geliştirme için - sadece macOS)

### MAUI Workload Kurulumu

```bash
dotnet workload install maui
```

### Projeyi Klonlama

```bash
git clone https://github.com/murat-atalay/toptanci-hub.git
cd toptanci-hub
```

### NuGet Paketlerini Geri Yükleme

```bash
cd src/ToptanciHub
dotnet restore
```

### Derleme

```bash
dotnet build
```

### Çalıştırma

#### Android
```bash
dotnet build -t:Run -f net8.0-android
```

#### iOS (sadece macOS)
```bash
dotnet build -t:Run -f net8.0-ios
```

#### Windows
```bash
dotnet build -t:Run -f net8.0-windows10.0.19041.0
```

#### macOS
```bash
dotnet build -t:Run -f net8.0-maccatalyst
```

## 📁 Proje Yapısı

```
src/ToptanciHub/
├── Models/                 # Veri modelleri
│   ├── User.cs
│   ├── Campaign.cs
│   ├── Product.cs
│   ├── PriceOffer.cs
│   └── PriceTier.cs
├── ViewModels/             # View model sınıfları
│   ├── BaseViewModel.cs
│   └── MainViewModel.cs
├── Views/                  # XAML sayfaları
│   ├── MainPage.xaml
│   └── MainPage.xaml.cs
├── Services/               # Business logic ve veri servisleri
│   ├── DatabaseService.cs
│   └── AuthService.cs
├── Converters/             # Value converters
│   └── StringNotEmptyConverter.cs
├── Helpers/                # Yardımcı sınıflar
│   └── Constants.cs
├── Resources/              # Uygulama kaynakları
│   ├── Strings/           # Lokalizasyon dosyaları
│   ├── Styles/            # XAML stiller
│   ├── Images/            # Görseller
│   └── Fonts/             # Fontlar
├── Platforms/              # Platform-specific kod
│   └── Android/
│       └── AndroidManifest.xml
├── App.xaml               # Uygulama tanımı
├── AppShell.xaml          # Navigation yapısı
└── MauiProgram.cs         # Uygulama başlangıcı
```

## 🗄️ Veritabanı

Uygulama, SQLite yerel veritabanı kullanır. Veritabanı, uygulama ilk çalıştırıldığında otomatik olarak oluşturulur.

### Tablolar
- **Users**: Kullanıcı bilgileri
- **Campaigns**: Kampanya bilgileri
- **Products**: Ürün bilgileri
- **PriceOffers**: Fiyat teklifleri
- **PriceTiers**: Kademeli fiyatlandırma kuralları

Detaylı veritabanı şeması için: [DATABASE_SCHEMA.md](docs/DATABASE_SCHEMA.md)

## 🏗️ Mimari

Proje, MVVM (Model-View-ViewModel) mimarisi kullanır:
- **Models**: Veri yapıları ve business entities
- **Views**: XAML ile tanımlı kullanıcı arayüzü
- **ViewModels**: View ve Model arasındaki iletişim katmanı

Detaylı mimari açıklaması için: [ARCHITECTURE.md](docs/ARCHITECTURE.md)

## 🗺️ Roadmap

Proje 9 adımda geliştirilecektir:

1. ✅ **ADIM 1**: Temel .NET MAUI Proje Altyapısı (Mevcut)
2. ⏳ **ADIM 2**: Kimlik Doğrulama ve Kullanıcı Yönetimi
3. ⏳ **ADIM 3**: Kampanya Yönetimi Modülü
4. ⏳ **ADIM 4**: Ürün Katalog Sistemi
5. ⏳ **ADIM 5**: Fiyat Teklifi Sistemi
6. ⏳ **ADIM 6**: Kademeli Fiyatlandırma Modülü
7. ⏳ **ADIM 7**: Sosyal Etkileşim Özellikleri
8. ⏳ **ADIM 8**: Bildirim ve Mesajlaşma Sistemi
9. ⏳ **ADIM 9**: Raporlama ve Analytics

Detaylı roadmap için: [ROADMAP.md](docs/ROADMAP.md)

## 🎨 Tasarım

Uygulama Material Design prensiplerine uygun olarak tasarlanmıştır:
- **Primary Color**: Mavi (#1976D2)
- **Secondary Color**: Gri (#424242)
- **Accent Color**: Kırmızı (#FF5252)

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen şu adımları takip edin:

1. Projeyi fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'feat: Add amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request açın

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 👨‍💻 Geliştirici

**Murat Atalay**

## 📞 İletişim

Sorularınız için issue açabilirsiniz.

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!
