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
    public partial class TermList : ContentPage
    {
        public TermList()
        {
            InitializeComponent();
        }

        async void ViewOtherTerms_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        async void ViewClasses_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClassDetails());
        }

        private void AddOA_Clicked(object sender, EventArgs e)
        {
            //TODO REMOVE THIS FILLER CODE (button rotation stuff
            Button button = (Button)sender;

            if (button.Rotation == 0)
            {
                button.Rotation = 45;
                button.BackgroundColor = Color.Aquamarine;
            }
            else
            {
                button.Rotation = 0;
                button.BackgroundColor = default;
            }
           
        }

        private void AddPA_Clicked(object sender, EventArgs e)
        {
            //TODO REMOVE THIS FILLER CODE (button rotation stuff
            Button button = (Button)sender;
            if (button.Rotation == 0)
            {
                button.Rotation = 45;
                button.BackgroundColor = Color.Aquamarine;
            }
            else
            {
                button.Rotation = 0;
                button.BackgroundColor = default;
            }
        }

        private void AddNewTerm_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Notes_Clicked(object sender, EventArgs e)
        {

        }

        private void StudentProfile_Clicked(object sender, EventArgs e)
        {

        }
    }
}