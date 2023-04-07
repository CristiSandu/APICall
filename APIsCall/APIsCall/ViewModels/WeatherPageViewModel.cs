
using APIsCall.Models;
using APIsCall.Models.WeatherModels;
using APIsCall.Services;
using APIsCall.Views;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace APIsCall.ViewModels;

public partial class WeatherPageViewModel : BaseViewModel
{
    string apiKey = "9c72f587913445e1bff82727230704";

    [ObservableProperty]
    WeatherModel weather;

    [ObservableProperty]
    ObservableCollection<string> airQList;


    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    private readonly IHttpService _httpService;
    public WeatherPageViewModel(IHttpService httpService)
    {
        _httpService = httpService;
        Title = "Weather";
        AirQList = new ObservableCollection<string>();
        GetInitalDataCommand.Execute(null);
    }


    [RelayCommand]
    private async void OpenPopUp()
    {
        var popUp = new BasePopUp("Test trimitere parametrii");
        var respons = await Shell.Current.ShowPopupAsync(popUp);

        if (respons is MonkeyModel res)
        {
          
        }

        if (respons is int res2)
        {
          
        }

    }


    [RelayCommand]
    private async void GetInitalData()
    {
        IsBusy = true;
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Microsoft.Maui.Devices.Sensors.Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
            {
                Weather = await _httpService.GetData(new WeatherModel(), $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={location.Latitude},{location.Longitude}&aqi=yes");

                foreach (KeyValuePair<string, double> pair in Weather.Current.AirQuality)
                {
                    AirQList.Add($"{pair.Key.ToUpper()}\n{pair.Value:0.00}");
                }
            }
            else
            {
                Weather = new WeatherModel();
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Handle not supported on device exception
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // Handle not enabled on device exception
        }
        catch (PermissionException pEx)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to get location
        }
        IsBusy = false;

    }
}
