# 🏗️ Mimari Dokümantasyon

## Genel Bakış

Toptancı Hub, modern yazılım geliştirme prensiplerini takip eden, MVVM (Model-View-ViewModel) mimarisine dayanan bir .NET MAUI uygulamasıdır.

## 🎯 Mimari Prensipleri

### 1. Separation of Concerns (SoC)
Her katman kendi sorumluluğuna sahiptir:
- **Models**: Veri yapıları
- **Views**: Kullanıcı arayüzü
- **ViewModels**: İş mantığı ve UI state yönetimi
- **Services**: Veri erişimi ve business logic

### 2. Dependency Injection (DI)
- .NET MAUI'nin built-in DI container'ı kullanılır
- Loosely coupled bileşenler
- Test edilebilirlik artar

### 3. Single Responsibility Principle
- Her sınıf tek bir sorumluluğa sahip
- Küçük, odaklanmış sınıflar

### 4. Don't Repeat Yourself (DRY)
- Kod tekrarı minimize edilir
- BaseViewModel gibi ortak sınıflar kullanılır

## 📐 MVVM Pattern

### Model
Veri yapılarını ve business entities'leri temsil eder.

**Sorumluluklar:**
- Veri yapısını tanımlar
- SQLite için ORM mapping yapar
- Business rules'ları içerebilir

**Örnekler:**
```
Models/
├── User.cs           # Kullanıcı entity
├── Campaign.cs       # Kampanya entity
├── Product.cs        # Ürün entity
├── PriceOffer.cs     # Fiyat teklifi entity
└── PriceTier.cs      # Fiyat kademesi entity
```

### View
XAML ile tanımlı kullanıcı arayüzü bileşenleri.

**Sorumluluklar:**
- UI elementlerini tanımlar
- Data binding yapılandırması
- Navigation flows

**Örnekler:**
```
Views/
├── MainPage.xaml           # Ana sayfa
├── LoginPage.xaml          # Giriş sayfası
├── CampaignListPage.xaml   # Kampanya listesi
└── ProductDetailPage.xaml  # Ürün detay
```

**Best Practices:**
- Code-behind minimal olmalı
- Business logic ViewModels'de olmalı
- UI state ViewModel'de yönetilmeli

### ViewModel
View ve Model arasındaki köprü.

**Sorumluluklar:**
- View state yönetimi
- Commands tanımlar
- Data transformation
- View ile Services arasında aracılık

**Örnekler:**
```
ViewModels/
├── BaseViewModel.cs       # Base class
├── MainViewModel.cs       # Ana sayfa VM
├── LoginViewModel.cs      # Giriş VM
├── CampaignListViewModel.cs   # Kampanya listesi VM
└── ProductDetailViewModel.cs  # Ürün detay VM
```

**CommunityToolkit.Mvvm Kullanımı:**
```csharp
public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _userName;
    
    [RelayCommand]
    private async Task LoadDataAsync()
    {
        // Command implementation
    }
}
```

## 🔧 Servisler

### DatabaseService
SQLite veritabanı operasyonlarını yönetir.

**Sorumluluklar:**
- CRUD operasyonları
- Veritabanı oluşturma ve migration
- Transaction yönetimi
- Query optimization

**Örnek:**
```csharp
public class DatabaseService
{
    private SQLiteAsyncConnection _database;
    
    public async Task<List<User>> GetUsersAsync()
    {
        await InitAsync();
        return await _database.Table<User>().ToListAsync();
    }
}
```

### AuthService
Kimlik doğrulama ve yetkilendirme işlemlerini yönetir.

**Sorumluluklar:**
- Login/Logout
- Kullanıcı kaydı
- Şifre yönetimi
- Session yönetimi

**Örnek:**
```csharp
public class AuthService
{
    private User? _currentUser;
    
    public async Task<(bool Success, string Message)> LoginAsync(
        string email, string password)
    {
        // Authentication logic
    }
}
```

## 🔄 Veri Akışı

### Okuma Operasyonu (Read Flow)
```
View (MainPage.xaml)
    ↓ Binding
ViewModel (MainViewModel)
    ↓ Calls
Service (DatabaseService)
    ↓ Queries
SQLite Database
    ↓ Returns
Model (User)
    ↓ Maps to
ViewModel Properties
    ↓ Data Binding
View UI Updates
```

### Yazma Operasyonu (Write Flow)
```
View (Button Command)
    ↓ User Action
ViewModel (RelayCommand)
    ↓ Validates & Calls
Service (DatabaseService)
    ↓ Saves
Model → SQLite Database
    ↓ Result
ViewModel Updates State
    ↓ Binding
View UI Updates
```

## 📦 Dependency Injection

### Servis Kayıtları (MauiProgram.cs)
```csharp
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        // Services (Singleton)
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<AuthService>();
        
        // ViewModels (Transient)
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        
        // Views (Transient)
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<LoginPage>();
        
        return builder.Build();
    }
}
```

### Injection Kullanımı
```csharp
public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;
    
    // Constructor injection
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}
```

## 🎨 Stil ve Tema Yönetimi

### Resource Dictionaries
```
Resources/
├── Styles/
│   ├── Colors.xaml    # Renk paleti
│   └── Styles.xaml    # UI element stilleri
└── Strings/
    └── AppResources.resx  # Lokalizasyon
```

### Tema Desteği
- Light/Dark mode desteği
- AppThemeBinding kullanımı
- Material Design renk paleti

## 🧪 Test Stratejisi

### Unit Tests
- ViewModel logic testleri
- Service layer testleri
- Model validation testleri

### Integration Tests
- Database operations
- Service integrations

### UI Tests
- User flow testleri
- Navigation testleri

## 📊 Performans Optimizasyonu

### Database
- Asenkron operasyonlar
- İndeksleme
- Lazy loading
- Connection pooling

### UI
- Virtual scrolling
- Image caching
- Async loading

## 🔒 Güvenlik

### Data Protection
- Şifre hashing (gelecek güncellemelerde)
- Secure storage kullanımı
- SQL injection koruması (Parameterized queries)

### Authentication
- Session management
- Token-based auth (gelecek güncellemelerde)
- Role-based access control

## 📱 Platform-Specific Kod

### Conditional Compilation
```csharp
#if ANDROID
    // Android specific code
#elif IOS
    // iOS specific code
#endif
```

### Platform Services
```
Platforms/
├── Android/
│   ├── MainActivity.cs
│   └── AndroidManifest.xml
├── iOS/
│   └── Info.plist
└── Windows/
    └── app.manifest
```

## 🚀 Gelecek Geliştirmeler

### Planlanan Mimari İyileştirmeler
1. **CQRS Pattern**: Command ve Query sorumluluklarını ayır
2. **Event Aggregator**: Loosely coupled event communication
3. **Repository Pattern**: Daha soyut veri erişim katmanı
4. **Unit of Work**: Transaction yönetimi
5. **Background Services**: Arka plan görevleri
6. **Offline-First**: Senkronizasyon mekanizması

### API Integration (Gelecekte)
- RESTful API entegrasyonu
- SignalR real-time notifications
- Cloud sync

## 📚 Referanslar

- [.NET MAUI Documentation](https://learn.microsoft.com/dotnet/maui/)
- [MVVM Pattern](https://learn.microsoft.com/dotnet/architecture/maui/mvvm)
- [CommunityToolkit.Mvvm](https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/)
- [SQLite-net](https://github.com/praeclarum/sqlite-net)
