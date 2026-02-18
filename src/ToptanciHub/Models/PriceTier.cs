using SQLite;

namespace ToptanciHub.Models;

public class PriceTier
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public int UrunId { get; set; }
    public int MinMiktar { get; set; }
    public int MaxMiktar { get; set; }
    public decimal IndirimYuzdesi { get; set; }
    public decimal SabitFiyat { get; set; }
}
