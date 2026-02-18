using CommunityToolkit.Mvvm.ComponentModel;

namespace ToptanciHub.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    protected void SetError(string message)
    {
        ErrorMessage = message;
    }

    protected void ClearError()
    {
        ErrorMessage = string.Empty;
    }
}
