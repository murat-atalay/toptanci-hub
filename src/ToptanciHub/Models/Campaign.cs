using SQLite;

namespace ToptanciHub.Models;

public class Campaign
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public int ToptanciId { get; set; }
    public string Baslik { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public string GorselUrl { get; set; } = string.Empty;
    public DateTime BaslangicTarihi { get; set; }
    public DateTime BitisTarihi { get; set; }
    public bool AktifMi { get; set; }
    public int GoruntulenmeSayisi { get; set; }
    public int BegeniSayisi { get; set; }
    public DateTime OlusturmaTarihi { get; set; }
}
