using APIsCall.ViewModels;
using CommunityToolkit.Maui.Views;

namespace APIsCall.Views;

public partial class BasePopUp : Popup
{
	public BasePopUp(string text)
	{
		InitializeComponent();
		BindingContext = new BasePopUpViewModel(text);
		this.Size = new Size(400, 400);
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close((BindingContext as BasePopUpViewModel).Title);
    }
}