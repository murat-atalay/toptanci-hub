namespace ToptanciHub.Helpers;

public static class Constants
{
    // Database
    public const string DatabaseFilename = "toptancihub.db";

    // SQLite Flags
    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

    // App Information
    public const string AppName = "Toptancı Hub";
    public const string AppVersion = "1.0.0";
    public const string AppDescription = "B2B Sosyal E-Ticaret Platformu";

    // User Roles
    public const string RoleSatici = "Satıcı";
    public const string RoleToptanci = "Toptancı";

    // Price Offer Status
    public const string StatusBekliyor = "Bekliyor";
    public const string StatusOnaylandi = "Onaylandı";
    public const string StatusReddedildi = "Reddedildi";
    public const string StatusSiparisVerildi = "Sipariş Verildi";

    // Validation
    public const int MinPasswordLength = 6;
    public const int MaxPasswordLength = 50;
    public const int MinUsernameLength = 3;
    public const int MaxUsernameLength = 50;

    // Pagination
    public const int DefaultPageSize = 20;
    public const int MaxPageSize = 100;

    // UI
    public const int DefaultAnimationDuration = 250;
    public const int LongAnimationDuration = 500;

    // Cache Duration (in minutes)
    public const int CacheDuration = 30;
}
