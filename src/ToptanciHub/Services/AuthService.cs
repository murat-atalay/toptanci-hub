using ToptanciHub.Models;

namespace ToptanciHub.Services;

public class AuthService
{
    private readonly DatabaseService _databaseService;
    private User? _currentUser;

    public AuthService(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public User? CurrentUser => _currentUser;

    public bool IsLoggedIn => _currentUser != null;

    public async Task<(bool Success, string Message)> LoginAsync(string email, string sifre)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sifre))
        {
            return (false, "Email ve şifre boş olamaz.");
        }

        var user = await _databaseService.GetUserByEmailAsync(email);

        if (user == null)
        {
            return (false, "Kullanıcı bulunamadı.");
        }

        if (user.Sifre != sifre)
        {
            return (false, "Şifre hatalı.");
        }

        if (!user.AktifMi)
        {
            return (false, "Hesabınız aktif değil.");
        }

        _currentUser = user;
        return (true, "Giriş başarılı.");
    }

    public async Task<(bool Success, string Message)> RegisterAsync(
        string ad,
        string soyad,
        string email,
        string sifre,
        UserRole rol,
        string telefon,
        string adres = "")
    {
        if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
        {
            return (false, "Ad ve soyad boş olamaz.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            return (false, "Email boş olamaz.");
        }

        if (string.IsNullOrWhiteSpace(sifre) || sifre.Length < 6)
        {
            return (false, "Şifre en az 6 karakter olmalıdır.");
        }

        if (string.IsNullOrWhiteSpace(telefon))
        {
            return (false, "Telefon numarası boş olamaz.");
        }

        // Check if user already exists
        var existingUser = await _databaseService.GetUserByEmailAsync(email);
        if (existingUser != null)
        {
            return (false, "Bu email adresi zaten kullanılıyor.");
        }

        var newUser = new User
        {
            Ad = ad,
            Soyad = soyad,
            Email = email,
            Sifre = sifre,
            Rol = rol,
            Telefon = telefon,
            Adres = adres,
            ProfilFotoUrl = string.Empty,
            KayitTarihi = DateTime.Now,
            AktifMi = true
        };

        await _databaseService.SaveUserAsync(newUser);
        _currentUser = newUser;

        return (true, "Kayıt başarılı.");
    }

    public Task LogoutAsync()
    {
        _currentUser = null;
        return Task.CompletedTask;
    }

    public async Task<(bool Success, string Message)> UpdateProfileAsync(
        string ad,
        string soyad,
        string telefon,
        string adres,
        string profilFotoUrl = "")
    {
        if (_currentUser == null)
        {
            return (false, "Oturum açılmamış.");
        }

        if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
        {
            return (false, "Ad ve soyad boş olamaz.");
        }

        if (string.IsNullOrWhiteSpace(telefon))
        {
            return (false, "Telefon numarası boş olamaz.");
        }

        _currentUser.Ad = ad;
        _currentUser.Soyad = soyad;
        _currentUser.Telefon = telefon;
        _currentUser.Adres = adres;

        if (!string.IsNullOrWhiteSpace(profilFotoUrl))
        {
            _currentUser.ProfilFotoUrl = profilFotoUrl;
        }

        await _databaseService.SaveUserAsync(_currentUser);

        return (true, "Profil güncellendi.");
    }

    public async Task<(bool Success, string Message)> ChangePasswordAsync(string eskiSifre, string yeniSifre)
    {
        if (_currentUser == null)
        {
            return (false, "Oturum açılmamış.");
        }

        if (_currentUser.Sifre != eskiSifre)
        {
            return (false, "Eski şifre hatalı.");
        }

        if (string.IsNullOrWhiteSpace(yeniSifre) || yeniSifre.Length < 6)
        {
            return (false, "Yeni şifre en az 6 karakter olmalıdır.");
        }

        _currentUser.Sifre = yeniSifre;
        await _databaseService.SaveUserAsync(_currentUser);

        return (true, "Şifre değiştirildi.");
    }
}
