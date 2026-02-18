using SQLite;

namespace ToptanciHub.Models;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Sifre { get; set; } = string.Empty;
    public UserRole Rol { get; set; }
    public string Telefon { get; set; } = string.Empty;
    public string Adres { get; set; } = string.Empty;
    public string ProfilFotoUrl { get; set; } = string.Empty;
    public DateTime KayitTarihi { get; set; }
    public bool AktifMi { get; set; }
}

public enum UserRole
{
    Satici = 1,
    Toptanci = 2
}
