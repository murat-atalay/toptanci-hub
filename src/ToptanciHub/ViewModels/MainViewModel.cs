using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToptanciHub.Services;

namespace ToptanciHub.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly AuthService _authService;
    private readonly DatabaseService _databaseService;

    public MainViewModel(AuthService authService, DatabaseService databaseService)
    {
        _authService = authService;
        _databaseService = databaseService;
        Title = "Toptancı Hub";
        WelcomeMessage = "Hoş Geldiniz";
    }

    [ObservableProperty]
    private string _welcomeMessage = string.Empty;

    [ObservableProperty]
    private bool _isLoggedIn;

    [ObservableProperty]
    private string _userName = string.Empty;

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();
        UpdateLoginStatus();
    }

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            ClearError();

            // Load initial data
            var dbExists = await _databaseService.DatabaseExistsAsync();
            if (dbExists)
            {
                WelcomeMessage = "Veritabanı hazır!";
            }
            else
            {
                WelcomeMessage = "Yeni veritabanı oluşturulacak...";
            }

            UpdateLoginStatus();
        }
        catch (Exception ex)
        {
            SetError($"Veri yüklenirken hata oluştu: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void UpdateLoginStatus()
    {
        IsLoggedIn = _authService.IsLoggedIn;
        if (_authService.CurrentUser != null)
        {
            UserName = $"{_authService.CurrentUser.Ad} {_authService.CurrentUser.Soyad}";
            WelcomeMessage = $"Hoş geldiniz, {UserName}!";
        }
        else
        {
            UserName = string.Empty;
            WelcomeMessage = "Toptancı Hub'a Hoş Geldiniz";
        }
    }
}
