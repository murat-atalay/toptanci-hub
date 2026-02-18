# 🗺️ Toptancı Hub - Geliştirme Roadmap

## Genel Bakış

Toptancı Hub projesi 9 temel adımda geliştirilecektir. Her adım, önceki adımın üzerine inşa edilecek ve projenin fonksiyonelliğini artıracaktır.

---

## ✅ ADIM 1: Temel .NET MAUI Proje Altyapısı
**Durum**: ✅ Tamamlandı  
**Süre**: 1 hafta  
**Öncelik**: Kritik

### Hedefler
- [x] .NET 8 MAUI projesi oluşturma
- [x] Klasör yapısının kurulması
- [x] NuGet paketlerinin eklenmesi
- [x] Model sınıflarının oluşturulması
- [x] Service layer implementasyonu
- [x] MVVM yapısının kurulması
- [x] Temel UI componentlerinin oluşturulması
- [x] Dependency injection yapılandırması
- [x] Dokümantasyon

### Çıktılar
- ✅ Çalışır durumda .NET MAUI uygulaması
- ✅ SQLite veritabanı entegrasyonu
- ✅ MVVM pattern implementasyonu
- ✅ Temel stil ve tema sistemi
- ✅ Comprehensive dokümantasyon

---

## ⏳ ADIM 2: Kimlik Doğrulama ve Kullanıcı Yönetimi
**Durum**: 🔜 Sırada  
**Süre**: 1 hafta  
**Öncelik**: Yüksek

### Hedefler
- [ ] Login sayfası (XAML + ViewModel)
- [ ] Kayıt olma sayfası
- [ ] Şifre sıfırlama akışı
- [ ] Profil görüntüleme ve düzenleme sayfası
- [ ] Kullanıcı rolü seçimi (Satıcı/Toptancı)
- [ ] Şifre hashing ve güvenlik
- [ ] Form validasyonları
- [ ] Session yönetimi

### Teknik Detaylar
```
Views/
├── LoginPage.xaml
├── RegisterPage.xaml
├── ForgotPasswordPage.xaml
└── ProfilePage.xaml

ViewModels/
├── LoginViewModel.cs
├── RegisterViewModel.cs
└── ProfileViewModel.cs
```

### Başarı Kriterleri
- [ ] Kullanıcı kayıt olabilir
- [ ] Kullanıcı giriş yapabilir
- [ ] Kullanıcı profilini düzenleyebilir
- [ ] Şifreler güvenli şekilde saklanır
- [ ] Input validasyonları çalışır

---

## ⏳ ADIM 3: Kampanya Yönetimi Modülü
**Durum**: 🔜 Planlandı  
**Süre**: 1.5 hafta  
**Öncelik**: Yüksek

### Hedefler
- [ ] Kampanya listeleme sayfası
- [ ] Kampanya detay sayfası
- [ ] Kampanya oluşturma formu (Toptancı için)
- [ ] Kampanya düzenleme
- [ ] Kampanya silme
- [ ] Görsel yükleme
- [ ] Kampanya filtreleme (aktif/pasif, tarih)
- [ ] Kampanya arama

### Teknik Detaylar
```
Views/
├── CampaignListPage.xaml
├── CampaignDetailPage.xaml
└── CampaignEditPage.xaml

ViewModels/
├── CampaignListViewModel.cs
├── CampaignDetailViewModel.cs
└── CampaignEditViewModel.cs

Services/
└── CampaignService.cs
```

### Başarı Kriterleri
- [ ] Toptancı kampanya oluşturabilir
- [ ] Kampanyalar listelenebilir
- [ ] Kampanya detayları görüntülenebilir
- [ ] Görseller yüklenebilir
- [ ] Filtreleme ve arama çalışır

---

## ⏳ ADIM 4: Ürün Katalog Sistemi
**Durum**: 🔜 Planlandı  
**Süre**: 1.5 hafta  
**Öncelik**: Yüksek

### Hedefler
- [ ] Ürün listeleme sayfası
- [ ] Ürün detay sayfası
- [ ] Ürün ekleme formu (Kampanya sahibi için)
- [ ] Ürün düzenleme
- [ ] Ürün silme
- [ ] Kategori yönetimi
- [ ] Ürün arama ve filtreleme
- [ ] Stok takibi

### Teknik Detaylar
```
Views/
├── ProductListPage.xaml
├── ProductDetailPage.xaml
└── ProductEditPage.xaml

ViewModels/
├── ProductListViewModel.cs
├── ProductDetailViewModel.cs
└── ProductEditViewModel.cs

Services/
└── ProductService.cs
```

### Başarı Kriterleri
- [ ] Kampanyaya ürün eklenebilir
- [ ] Ürünler listelenebilir
- [ ] Ürün detayları görüntülenebilir
- [ ] Kategorilere göre filtreleme yapılabilir
- [ ] Stok bilgisi takip edilir

---

## ⏳ ADIM 5: Fiyat Teklifi Sistemi
**Durum**: 🔜 Planlandı  
**Süre**: 2 hafta  
**Öncelik**: Kritik

### Hedefler
- [ ] Fiyat teklifi verme formu (Satıcı için)
- [ ] Teklif listeleme sayfası
- [ ] Teklif detay sayfası
- [ ] Teklif onaylama/reddetme (Toptancı için)
- [ ] Teklif durumu takibi
- [ ] Teklif bildirimleri
- [ ] Teklif geçmişi

### Teknik Detaylar
```
Views/
├── PriceOfferFormPage.xaml
├── PriceOfferListPage.xaml
└── PriceOfferDetailPage.xaml

ViewModels/
├── PriceOfferFormViewModel.cs
├── PriceOfferListViewModel.cs
└── PriceOfferDetailViewModel.cs

Services/
├── PriceOfferService.cs
└── NotificationService.cs
```

### Başarı Kriterleri
- [ ] Satıcı teklif verebilir
- [ ] Toptancı teklifleri görebilir
- [ ] Toptancı teklifi onaylayabilir/reddedebilir
- [ ] Teklif durumları takip edilir
- [ ] Bildirimler çalışır

---

## ⏳ ADIM 6: Kademeli Fiyatlandırma Modülü
**Durum**: 🔜 Planlandı  
**Süre**: 1 hafta  
**Öncelik**: Orta

### Hedefler
- [ ] Fiyat kademesi oluşturma formu
- [ ] Kademeli fiyat listesi
- [ ] Miktar bazlı fiyat hesaplama
- [ ] Otomatik indirim uygulama
- [ ] Fiyat kademesi düzenleme
- [ ] Fiyat önizleme

### Teknik Detaylar
```
Views/
├── PriceTierFormPage.xaml
└── PriceTierListPage.xaml

ViewModels/
├── PriceTierFormViewModel.cs
└── PriceTierListViewModel.cs

Services/
└── PricingService.cs
```

### Başarı Kriterleri
- [ ] Fiyat kademeleri tanımlanabilir
- [ ] Miktar bazlı fiyat hesaplanır
- [ ] İndirimler otomatik uygulanır
- [ ] Fiyat önizlemesi görülebilir

---

## ⏳ ADIM 7: Sosyal Etkileşim Özellikleri
**Durum**: 🔜 Planlandı  
**Süre**: 1.5 hafta  
**Öncelik**: Orta

### Hedefler
- [ ] Kampanya beğeni sistemi
- [ ] Yorum yapma
- [ ] Kampanya paylaşma
- [ ] Takip sistemi (Satıcıların toptancıları takip etmesi)
- [ ] Aktivite akışı
- [ ] Popüler kampanyalar

### Teknik Detaylar
```
Models/
├── Like.cs
├── Comment.cs
└── Follow.cs

Views/
├── CommentListPage.xaml
└── FollowersPage.xaml

Services/
├── SocialService.cs
└── FeedService.cs
```

### Başarı Kriterleri
- [ ] Kullanıcılar kampanya beğenebilir
- [ ] Kullanıcılar yorum yapabilir
- [ ] Satıcılar toptancıları takip edebilir
- [ ] Aktivite akışı görüntülenebilir

---

## ⏳ ADIM 8: Bildirim ve Mesajlaşma Sistemi
**Durum**: 🔜 Planlandı  
**Süre**: 2 hafta  
**Öncelik**: Orta

### Hedefler
- [ ] Push notification entegrasyonu
- [ ] Local notifications
- [ ] Mesajlaşma sistemi (Toptancı-Satıcı arası)
- [ ] Bildirim tercihleri
- [ ] Bildirim geçmişi
- [ ] Chat UI

### Teknik Detaylar
```
Models/
├── Message.cs
└── Notification.cs

Views/
├── MessagesPage.xaml
├── ChatPage.xaml
└── NotificationSettingsPage.xaml

Services/
├── MessagingService.cs
└── PushNotificationService.cs
```

### Başarı Kriterleri
- [ ] Push notifications çalışır
- [ ] Mesajlaşma yapılabilir
- [ ] Bildirim tercihleri ayarlanabilir
- [ ] Mesaj geçmişi görüntülenebilir

---

## ⏳ ADIM 9: Raporlama ve Analytics
**Durum**: 🔜 Planlandı  
**Süre**: 1.5 hafta  
**Öncelik**: Düşük

### Hedefler
- [ ] Satış raporları
- [ ] Kampanya performans analizi
- [ ] Kullanıcı aktivite raporları
- [ ] Grafik ve chartlar
- [ ] Export functionality (PDF, Excel)
- [ ] Dashboard

### Teknik Detaylar
```
Views/
├── DashboardPage.xaml
├── ReportsPage.xaml
└── AnalyticsPage.xaml

ViewModels/
├── DashboardViewModel.cs
└── ReportsViewModel.cs

Services/
├── ReportingService.cs
└── AnalyticsService.cs
```

### NuGet Paketleri (Ek)
- Microcharts (for charts)
- SkiaSharp (for graphics)

### Başarı Kriterleri
- [ ] Raporlar görüntülenebilir
- [ ] Grafikler çalışır
- [ ] Export yapılabilir
- [ ] Dashboard bilgilendiricidir

---

## 🎯 Toplam Zaman Tahmini
**9-12 hafta** (yaklaşık 2-3 ay)

## 📈 Öncelik Sıralaması
1. **Kritik**: ADIM 1, ADIM 5
2. **Yüksek**: ADIM 2, ADIM 3, ADIM 4
3. **Orta**: ADIM 6, ADIM 7, ADIM 8
4. **Düşük**: ADIM 9

## 🔄 Iterative Geliştirme

Her adımda:
1. ✅ Planlama ve tasarım
2. ✅ Implementation
3. ✅ Testing
4. ✅ Code review
5. ✅ Dokümantasyon
6. ✅ User feedback

## 🚀 Gelecek Özellikler (Post-MVP)

### Faz 2 (v2.0)
- Backend API entegrasyonu
- Cloud sync
- Multi-language support
- Advanced search ve filtering
- AI-powered recommendations
- Video content support

### Faz 3 (v3.0)
- Web portal
- Admin dashboard
- Payment integration
- Logistics integration
- Advanced analytics
- Machine learning predictions

---

**Not**: Bu roadmap esnek bir plandır ve kullanıcı geri bildirimleri doğrultusunda güncellenebilir.
