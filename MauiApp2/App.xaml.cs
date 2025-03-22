using MauiApp2;

namespace MauiApp2
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new FinanceListPage());
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }

}
