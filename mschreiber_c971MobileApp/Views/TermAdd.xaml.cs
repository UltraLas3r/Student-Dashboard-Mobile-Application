using mschreiber_c971MobileApp.Services;
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
    public partial class TermAdd : ContentPage
    {
        public TermAdd()
        {
            InitializeComponent();
        }

        async void SaveTerm_Clicked(object sender, EventArgs e)
        {
            DateTime? selectedDate = StartDatePicker.Date;
            DateTime? selectedEndDate = AnticipatedEndDatePicker.Date;

            if (string.IsNullOrWhiteSpace(TermName.Text))
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }

            if (!selectedDate.HasValue)
            {
                await DisplayAlert("Missing Name", "Please enter a start date.", "Ok");
            }

            if(!selectedEndDate.HasValue)
            {
                await DisplayAlert("Missing Name", "Please enter an end date.", "Ok");
            }

            await DatabaseService.AddTerm(TermName.Text, StartDatePicker.Date, AnticipatedEndDatePicker.Date);

            await Navigation.PopAsync();
        }

        async void CancelTerm_Clicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync();
        }

    }
}