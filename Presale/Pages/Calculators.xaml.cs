namespace Presale.Pages;

public partial class Calculators : ContentPage
{
    public Calculators()
    {
        InitializeComponent();
    }

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        // Navigate to the specified URL in the system browser.
        await Launcher.Default.OpenAsync("https://ya.ru");
    }
}