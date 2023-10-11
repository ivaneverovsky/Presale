using Presale.Interfaces;

namespace Presale;

public partial class App : Application
{
    public static IServiceProvider Services;
    public static IAlertService AlertService;

	public App(IServiceProvider provider)
	{
		InitializeComponent();

        Services = provider;
        AlertService = Services.GetService<IAlertService>();

        MainPage = new AppShell();
	}
    protected override void OnStart()
    {
        base.OnStart();
    }

    protected override void OnResume()
    {
        base.OnResume();
    }

    protected override void OnSleep()
    {
        base.OnSleep();
    }
}
