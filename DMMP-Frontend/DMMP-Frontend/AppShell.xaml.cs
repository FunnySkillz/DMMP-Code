using DMMP_Frontend.View;

namespace DMMP_Frontend;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute( nameof(AddPropertyPage), typeof(AddPropertyPage) );

        //// Define the main page
        //ShellSection mainSection = new ShellSection() { Title = "Main" };
        //mainSection.Items.Add(new ShellContent() { Content = new MainPage() });

        //// Define the add page
        //ShellSection addSection = new ShellSection() { Title = "Add" };
        //addSection.Items.Add(new ShellContent() { Content = new AddPropertyPage() });

        //// Define the user profile page
        //ShellSection userProfileSection = new ShellSection() { Title = "User Profile" };
        //userProfileSection.Items.Add(new ShellContent() { Content = new UserProfilePage() });

        //// Add the sections to the Shell
        //Items.Add(mainSection);
        //Items.Add(addSection);
        //Items.Add(userProfileSection);
    }
}
