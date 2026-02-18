# 🚀 Kurulum ve Derleme Kılavuzu

## Gerekli Araçlar

### 1. .NET SDK 8.0 veya üzeri
```bash
# Kurulu versiyonu kontrol edin
dotnet --version
```

İndirmek için: https://dotnet.microsoft.com/download

### 2. .NET MAUI Workload

MAUI workload'ı yükleyin:
```bash
dotnet workload install maui
```

Android geliştirme için:
```bash
dotnet workload install android
```

iOS geliştirme için (sadece macOS):
```bash
dotnet workload install ios
```

### 3. Visual Studio 2022 veya Visual Studio Code

#### Visual Studio 2022 (Önerilen)
- Minimum versiyon: 17.8 veya üzeri
- Workload: ".NET Multi-platform App UI development"

#### Visual Studio Code
- C# extension
- .NET MAUI extension

### 4. Platform-Specific Gereksinimler

#### Android
- Android SDK (API Level 21+)
- Android Emulator veya fiziksel cihaz

#### iOS (sadece macOS)
- Xcode 14+
- iOS Simulator veya fiziksel cihaz
- Apple Developer hesabı (gerçek cihazda test için)

#### Windows
- Windows 10 SDK (10.0.17763.0+)
- Windows 11 (önerilen)

## 📋 Kurulum Adımları

### Adım 1: Repository'yi Klonlayın
```bash
git clone https://github.com/murat-atalay/toptanci-hub.git
cd toptanci-hub
```

### Adım 2: Proje Dizinine Gidin
```bash
cd src/ToptanciHub
```

### Adım 3: Fontları Ekleyin (Opsiyonel)
Open Sans fontlarını indirin ve `Resources/Fonts/` dizinine yerleştirin:
- OpenSans-Regular.ttf
- OpenSans-Semibold.ttf

İndirme linki: https://fonts.google.com/specimen/Open+Sans

### Adım 4: NuGet Paketlerini Geri Yükleyin
```bash
dotnet restore
```

### Adım 5: Projeyi Derleyin
```bash
# Tüm platformlar için
dotnet build

# Sadece Android için
dotnet build -f net8.0-android

# Sadece iOS için (macOS)
dotnet build -f net8.0-ios

# Sadece Windows için
dotnet build -f net8.0-windows10.0.19041.0
```

## ▶️ Uygulamayı Çalıştırma

### Android Emulator'de
```bash
# Emulator'ü başlat
# Sonra:
dotnet build -t:Run -f net8.0-android
```

### iOS Simulator'de (macOS)
```bash
dotnet build -t:Run -f net8.0-ios
```

### Windows
```bash
dotnet build -t:Run -f net8.0-windows10.0.19041.0
```

### Visual Studio'dan Çalıştırma
1. `ToptanciHub.sln` dosyasını açın (yoksa oluşturun)
2. Platform seçin (Android, iOS, Windows, macOS)
3. Hedef cihaz/emulator seçin
4. F5 veya "Start Debugging" düğmesine basın

## 🔧 Sorun Giderme

### Workload Hataları
Eğer "workload not installed" hatası alırsanız:
```bash
dotnet workload restore
```

### Android SDK Bulunamadı
Android SDK yolunu ayarlayın:
```bash
# Linux/macOS
export ANDROID_SDK_ROOT=$HOME/Android/Sdk

# Windows (PowerShell)
$env:ANDROID_SDK_ROOT="C:\Users\<username>\AppData\Local\Android\Sdk"
```

### iOS Build Hataları (macOS)
Xcode komut satırı araçlarını yükleyin:
```bash
xcode-select --install
```

### NuGet Geri Yükleme Hataları
NuGet cache'i temizleyin:
```bash
dotnet nuget locals all --clear
dotnet restore
```

### Font Eksik Hatası
Eğer font dosyaları eksikse:
1. Open Sans fontlarını indirin
2. `Resources/Fonts/` dizinine kopyalayın
3. Projeyi yeniden derleyin

## 🧪 Test Etme

### Unit Testleri (Gelecek güncellemede)
```bash
dotnet test
```

### Debug Mode
```bash
dotnet build -c Debug
```

### Release Mode
```bash
dotnet build -c Release
```

## 📦 Yayınlama

### Android APK
```bash
dotnet publish -f net8.0-android -c Release
```

APK dosyası: `bin/Release/net8.0-android/publish/`

### Android AAB (Google Play için)
```bash
dotnet publish -f net8.0-android -c Release -p:AndroidPackageFormat=aab
```

### iOS IPA (macOS)
```bash
dotnet publish -f net8.0-ios -c Release -p:ArchiveOnBuild=true
```

### Windows MSIX
```bash
dotnet publish -f net8.0-windows10.0.19041.0 -c Release -p:GenerateAppxPackageOnBuild=true
```

## 🎯 İlk Çalıştırma Sonrası

Uygulama ilk kez çalıştırıldığında:
1. SQLite veritabanı otomatik oluşturulur
2. Uygulama veri dizini: `FileSystem.AppDataDirectory`
3. Veritabanı dosyası: `toptancihub.db`

## 📚 Ek Kaynaklar

- [.NET MAUI Dokümantasyonu](https://learn.microsoft.com/dotnet/maui/)
- [Visual Studio MAUI Kurulum](https://learn.microsoft.com/dotnet/maui/get-started/installation)
- [Android Emulator Kurulum](https://learn.microsoft.com/dotnet/maui/android/emulator/)
- [SQLite-net Dokümantasyonu](https://github.com/praeclarum/sqlite-net)

## ⚠️ Bilinen Sorunlar

1. **Workload Gereksinimi**: .NET MAUI workload'ı yüklenmeden proje derlenemez
2. **Font Dosyaları**: Open Sans fontları repository'e dahil değil, ayrıca indirilmeli
3. **Platform Desteği**: Her platformun kendi gereksinimleri var

## 💬 Yardım

Sorun yaşarsanız:
1. [Issues](https://github.com/murat-atalay/toptanci-hub/issues) sayfasında benzer sorunları arayın
2. Yeni issue açın
3. Dokümantasyonu kontrol edin

---

**Not**: Bu kılavuz ADIM 1 için hazırlanmıştır. Gelecek adımlarda ek kurulum gereksinimleri eklenebilir.
