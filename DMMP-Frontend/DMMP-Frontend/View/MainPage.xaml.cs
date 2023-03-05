namespace DMMP_Frontend;

public partial class MainPage : ContentPage
{
	public MainPage(PropertyViewModel viewModel)
	{
		InitializeComponent();

        // Create a new instance of the PropertyViewModel
        //PropertyViewModel viewModel = new PropertyViewModel();

        // Set the BindingContext of the page to the PropertyViewModel instance
        BindingContext = viewModel;
    }
}

