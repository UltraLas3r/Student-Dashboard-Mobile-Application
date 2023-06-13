using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mschreiber_c971MobileApp.Models;
using mschreiber_c971MobileApp.Services;
using mschreiber_c971MobileApp.Views;
using Xamarin.Essentials;

namespace mschreiber_c971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSettings : ContentPage
    {
        public AppSettings()
        {
            InitializeComponent();
        }

        private void ClearPreferences_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
        }

        async void LoadSampleData_Clicked(object sender, EventArgs e)
        {
            //helps prevent duplicate data
            if (Settings.FirstRun)
            {
                DatabaseService.LoadSampleData();
                Settings.FirstRun = false;

                await Navigation.PopToRootAsync();
            }
        }

        //todo: check if this is working right
        async void ClearSampleData_Clicked(object sender, EventArgs e) => await DatabaseService.ClearSampleData();
    }
}