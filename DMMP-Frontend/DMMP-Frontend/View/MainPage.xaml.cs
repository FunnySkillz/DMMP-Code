namespace DMMP_Frontend;

public partial class MainPage : ContentPage
{
	public MainPage(PropertyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

