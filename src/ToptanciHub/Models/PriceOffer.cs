using SQLite;

namespace ToptanciHub.Models;

public class PriceOffer
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public int UrunId { get; set; }
    public int SaticiId { get; set; }
    public int Miktar { get; set; }
    public decimal TeklifEdilenFiyat { get; set; }
    public decimal ToplamTutar { get; set; }
    public PriceOfferStatus Durum { get; set; }
    public DateTime TeklifTarihi { get; set; }
    public DateTime? CevapTarihi { get; set; }
    public string ToptanciNotu { get; set; } = string.Empty;
}

public enum PriceOfferStatus
{
    Bekliyor = 1,
    Onaylandi = 2,
    Reddedildi = 3,
    SiparisVerildi = 4
}
