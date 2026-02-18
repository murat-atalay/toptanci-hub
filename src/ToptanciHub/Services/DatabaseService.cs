using SQLite;
using ToptanciHub.Models;

namespace ToptanciHub.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? _database;
    private readonly string _dbPath;

    public DatabaseService()
    {
        _dbPath = Path.Combine(FileSystem.AppDataDirectory, "toptancihub.db");
    }

    private async Task InitAsync()
    {
        if (_database != null)
            return;

        _database = new SQLiteAsyncConnection(_dbPath);
        
        await _database.CreateTableAsync<User>();
        await _database.CreateTableAsync<Campaign>();
        await _database.CreateTableAsync<Product>();
        await _database.CreateTableAsync<PriceOffer>();
        await _database.CreateTableAsync<PriceTier>();
    }

    // User CRUD Operations
    public async Task<List<User>> GetUsersAsync()
    {
        await InitAsync();
        return await _database!.Table<User>().ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        await InitAsync();
        return await _database!.Table<User>()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        await InitAsync();
        return await _database!.Table<User>()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<int> SaveUserAsync(User user)
    {
        await InitAsync();
        if (user.Id != 0)
            return await _database!.UpdateAsync(user);
        else
            return await _database!.InsertAsync(user);
    }

    public async Task<int> DeleteUserAsync(User user)
    {
        await InitAsync();
        return await _database!.DeleteAsync(user);
    }

    // Campaign CRUD Operations
    public async Task<List<Campaign>> GetCampaignsAsync()
    {
        await InitAsync();
        return await _database!.Table<Campaign>().ToListAsync();
    }

    public async Task<List<Campaign>> GetActiveCampaignsAsync()
    {
        await InitAsync();
        return await _database!.Table<Campaign>()
            .Where(c => c.AktifMi)
            .ToListAsync();
    }

    public async Task<Campaign?> GetCampaignByIdAsync(int id)
    {
        await InitAsync();
        return await _database!.Table<Campaign>()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Campaign>> GetCampaignsByToptanciAsync(int toptanciId)
    {
        await InitAsync();
        return await _database!.Table<Campaign>()
            .Where(c => c.ToptanciId == toptanciId)
            .ToListAsync();
    }

    public async Task<int> SaveCampaignAsync(Campaign campaign)
    {
        await InitAsync();
        if (campaign.Id != 0)
            return await _database!.UpdateAsync(campaign);
        else
            return await _database!.InsertAsync(campaign);
    }

    public async Task<int> DeleteCampaignAsync(Campaign campaign)
    {
        await InitAsync();
        return await _database!.DeleteAsync(campaign);
    }

    // Product CRUD Operations
    public async Task<List<Product>> GetProductsAsync()
    {
        await InitAsync();
        return await _database!.Table<Product>().ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        await InitAsync();
        return await _database!.Table<Product>()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetProductsByCampaignAsync(int kampanyaId)
    {
        await InitAsync();
        return await _database!.Table<Product>()
            .Where(p => p.KampanyaId == kampanyaId)
            .ToListAsync();
    }

    public async Task<List<Product>> GetProductsByCategoryAsync(string kategori)
    {
        await InitAsync();
        return await _database!.Table<Product>()
            .Where(p => p.Kategori == kategori)
            .ToListAsync();
    }

    public async Task<int> SaveProductAsync(Product product)
    {
        await InitAsync();
        if (product.Id != 0)
            return await _database!.UpdateAsync(product);
        else
            return await _database!.InsertAsync(product);
    }

    public async Task<int> DeleteProductAsync(Product product)
    {
        await InitAsync();
        return await _database!.DeleteAsync(product);
    }

    // PriceOffer CRUD Operations
    public async Task<List<PriceOffer>> GetPriceOffersAsync()
    {
        await InitAsync();
        return await _database!.Table<PriceOffer>().ToListAsync();
    }

    public async Task<PriceOffer?> GetPriceOfferByIdAsync(int id)
    {
        await InitAsync();
        return await _database!.Table<PriceOffer>()
            .Where(po => po.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<PriceOffer>> GetPriceOffersByProductAsync(int urunId)
    {
        await InitAsync();
        return await _database!.Table<PriceOffer>()
            .Where(po => po.UrunId == urunId)
            .ToListAsync();
    }

    public async Task<List<PriceOffer>> GetPriceOffersBySaticiAsync(int saticiId)
    {
        await InitAsync();
        return await _database!.Table<PriceOffer>()
            .Where(po => po.SaticiId == saticiId)
            .ToListAsync();
    }

    public async Task<List<PriceOffer>> GetPriceOffersByStatusAsync(PriceOfferStatus durum)
    {
        await InitAsync();
        return await _database!.Table<PriceOffer>()
            .Where(po => po.Durum == durum)
            .ToListAsync();
    }

    public async Task<int> SavePriceOfferAsync(PriceOffer priceOffer)
    {
        await InitAsync();
        if (priceOffer.Id != 0)
            return await _database!.UpdateAsync(priceOffer);
        else
            return await _database!.InsertAsync(priceOffer);
    }

    public async Task<int> DeletePriceOfferAsync(PriceOffer priceOffer)
    {
        await InitAsync();
        return await _database!.DeleteAsync(priceOffer);
    }

    // PriceTier CRUD Operations
    public async Task<List<PriceTier>> GetPriceTiersAsync()
    {
        await InitAsync();
        return await _database!.Table<PriceTier>().ToListAsync();
    }

    public async Task<PriceTier?> GetPriceTierByIdAsync(int id)
    {
        await InitAsync();
        return await _database!.Table<PriceTier>()
            .Where(pt => pt.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<PriceTier>> GetPriceTiersByProductAsync(int urunId)
    {
        await InitAsync();
        return await _database!.Table<PriceTier>()
            .Where(pt => pt.UrunId == urunId)
            .ToListAsync();
    }

    public async Task<int> SavePriceTierAsync(PriceTier priceTier)
    {
        await InitAsync();
        if (priceTier.Id != 0)
            return await _database!.UpdateAsync(priceTier);
        else
            return await _database!.InsertAsync(priceTier);
    }

    public async Task<int> DeletePriceTierAsync(PriceTier priceTier)
    {
        await InitAsync();
        return await _database!.DeleteAsync(priceTier);
    }

    // Utility Methods
    public async Task<int> ClearAllDataAsync()
    {
        await InitAsync();
        await _database!.DeleteAllAsync<PriceTier>();
        await _database!.DeleteAllAsync<PriceOffer>();
        await _database!.DeleteAllAsync<Product>();
        await _database!.DeleteAllAsync<Campaign>();
        await _database!.DeleteAllAsync<User>();
        return 0;
    }

    public async Task<bool> DatabaseExistsAsync()
    {
        return await Task.FromResult(File.Exists(_dbPath));
    }
}
