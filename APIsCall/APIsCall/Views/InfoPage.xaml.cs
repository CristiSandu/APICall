using APIsCall.ViewModels;

namespace APIsCall.Views;

public partial class InfoPage : ContentPage
{
    public InfoPage(InfoPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}