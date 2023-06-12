using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace mschreiber_c971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        

        public Dashboard()
        {
            InitializeComponent();
          
        }

        async void AddTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermAdd());
        }

        

        async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppSettings());
        }

        private void AddClass_Clicked(object sender, EventArgs e)
        {

        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Rotation == 0)
            {
                button.Rotation += 90;
                button.BackgroundColor = Color.Red;
            }
            else
            {
                button.Rotation = 0;
                button.BackgroundColor = default;
            }
        }

        async void ClassDetail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClassDetails());

        }
        async void ViewTerms_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermList());
        }

        async void Notes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Notes());
        }

        async void StudentProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentProfile());
        }
    }
}