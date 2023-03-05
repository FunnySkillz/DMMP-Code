using DMMP_Frontend.View;

namespace DMMP_Frontend;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
