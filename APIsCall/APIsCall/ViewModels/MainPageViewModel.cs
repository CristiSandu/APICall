using APIsCall.Models;
using APIsCall.Services;
using APIsCall.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace APIsCall.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    [ObservableProperty]
    List<MonkeyModel> monkeys;

    [ObservableProperty]
    MonkeyModel monkey;


    readonly IHttpService _httpService;
    public MainPageViewModel(IHttpService httpService)
    {
        _httpService = httpService;
        Title = "Monkey Page";
        Monkeys = new List<MonkeyModel>();

        GetInitialDataCommand.Execute(null);
    }

    [RelayCommand]
    private async void GetInitialData()
    {
        Monkeys = await _httpService.GetData(new List<MonkeyModel>(), "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json");
    }

    partial void OnMonkeyChanged(MonkeyModel value)
    {
        if (value == null) return;
        GoToMoreInfo();
    }

    [RelayCommand]
    private async void GoToMoreInfo()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Monkey", Monkey }
        };

        Monkey = null;

        await Shell.Current.GoToAsync(nameof(InfoPage), navigationParameter);
    }
}
