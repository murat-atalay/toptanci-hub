using SQLite;

namespace ToptanciHub.Models;

public class Product
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public int KampanyaId { get; set; }
    public string UrunAdi { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public decimal TemelFiyat { get; set; }
    public string Birim { get; set; } = string.Empty;
    public int StokMiktari { get; set; }
    public string Kategori { get; set; } = string.Empty;
    public string GorselUrl { get; set; } = string.Empty;
}
