using APIsCall.ViewModels;

namespace APIsCall.Views;

public partial class WeatherPage : ContentPage
{
    public WeatherPage(WeatherPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}