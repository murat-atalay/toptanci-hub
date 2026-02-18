# 🔒 Güvenlik Notları - ADIM 1

## ⚠️ Bilinen Güvenlik Kısıtlamaları

### Şifre Yönetimi (Critical)

**Mevcut Durum:**
- Şifreler düz metin (plain text) olarak saklanıyor
- Şifre karşılaştırmaları düz metin üzerinden yapılıyor

**Güvenlik Riski:**
- ⚠️ **YÜKSEKRİSK**: Veritabanına erişim sağlayan biri tüm kullanıcı şifrelerini okuyabilir
- Veri sızıntısı durumunda kullanıcı hesapları tehlikede
- OWASP Top 10 - A02:2021 Cryptographic Failures

**Etkilenen Dosyalar:**
- `src/ToptanciHub/Services/AuthService.cs`:
  - Line 33: LoginAsync - Password comparison
  - Line 88: RegisterAsync - Password storage
  - Line 153: ChangePasswordAsync - Old password comparison
  - Line 163: ChangePasswordAsync - New password storage

**Çözüm (ADIM 2'de uygulanacak):**
```csharp
// Implement password hashing
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        // Generate a 128-bit salt using a cryptographically strong random sequence
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return $"{Convert.ToBase64String(salt)}:{hashed}";
    }

    public static bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var parts = hashedPassword.Split(':');
        var salt = Convert.FromBase64String(parts[0]);
        var hash = parts[1];

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: providedPassword,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return hash == hashed;
    }
}
```

## 📋 Güvenlik İyileştirme Planı

### ADIM 2: Kimlik Doğrulama ve Kullanıcı Yönetimi
- [ ] Password hashing implementasyonu (PBKDF2 veya BCrypt)
- [ ] Salt kullanımı
- [ ] Şifre güvenlik politikası (minimum uzunluk, karmaşıklık)
- [ ] Rate limiting (brute force koruması)
- [ ] Account lockout mekanizması
- [ ] Secure password reset flow

### ADIM 3+: İleri Güvenlik
- [ ] Two-factor authentication (2FA)
- [ ] Session management
- [ ] Token-based authentication (JWT)
- [ ] Secure storage için MAUI SecureStorage API
- [ ] Certificate pinning (API iletişimi için)
- [ ] Input validation ve sanitization
- [ ] SQL injection prevention (zaten parameterized queries kullanılıyor ✅)

## 🛡️ Mevcut Güvenlik Önlemleri

### ✅ İyi Uygulamalar
1. **Parameterized Queries**: SQLite sorgularında parameterized queries kullanılıyor
   - SQL injection koruması sağlanıyor
   
2. **Input Validation**: AuthService'de temel input validasyonu var
   - Email ve şifre boş kontrolü
   - Minimum şifre uzunluğu kontrolü (6 karakter)

3. **Async Operations**: Tüm veritabanı işlemleri async
   - UI thread blocking önleniyor

4. **Null Safety**: C# 12 nullable reference types kullanılıyor
   - Null reference exceptions önleniyor

## 📚 Güvenlik Kaynakları

1. **OWASP Mobile Security**
   - https://owasp.org/www-project-mobile-security/

2. **MAUI Security Best Practices**
   - https://learn.microsoft.com/dotnet/maui/platform-integration/storage/secure-storage

3. **Password Hashing**
   - https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html

## ⚠️ Kullanım Uyarısı

**ADIM 1 projesi sadece geliştirme/test amaçlıdır.**

**Production'da KULLANMAYIN!**

Aşağıdaki güvenlik iyileştirmeleri yapılmadan production'a alınmamalıdır:
- ❌ Şifre hashing
- ❌ Secure storage
- ❌ Rate limiting
- ❌ Session management

## 📝 Sorumlu Açıklama

Bu güvenlik notları:
1. Mevcut güvenlik kısıtlamalarını açıkça belirtir
2. Gelecek iyileştirmeleri planlar
3. Güvenli geliştirme için yol haritası sunar

**Not**: ADIM 1, temel altyapı kurulumu içindir. Güvenlik özellikleri sonraki adımlarda eklenecektir.

---

**Güncelleme**: 18 Şubat 2026  
**Durum**: Documented - To be fixed in ADIM 2  
**Öncelik**: HIGH - Security Critical
