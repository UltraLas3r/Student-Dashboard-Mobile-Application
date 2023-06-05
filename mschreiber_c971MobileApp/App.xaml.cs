using mschreiber_c971MobileApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mschreiber_c971MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var dashboard = new Dashboard();
            var navPage = new NavigationPage(dashboard);
            MainPage = navPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
