using CommunityToolkit.Mvvm.ComponentModel;
using APIsCall.Models;
using APIsCall.Models.WeatherModels;

namespace APIsCall.ViewModels;

public partial class InfoPageViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    MonkeyModel monkey = new();

    [ObservableProperty]
    string toSave;

    [ObservableProperty]
    string savedTo;

   

    public InfoPageViewModel()
    {

    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Monkey = query["Monkey"] as MonkeyModel;

      
    }
}
