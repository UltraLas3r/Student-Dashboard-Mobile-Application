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
            int tossedInt;
            Decimal tossedDecimal;


            if (string.IsNullOrWhiteSpace(TermName.Text))
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }
            if (string.IsNullOrWhiteSpace(TermPicker.SelectedItem.ToString()))
            {
                await DisplayAlert("Missing Term Season", "Please pick a Term Season", "Ok");

            }

            if (!Int32.TryParse(StudentsEnrolled.Text, out tossedInt))
            {
                await DisplayAlert("Missing value", "Please enter a whole number.", "Ok");
            }

            if (!decimal.TryParse(TermFees.Text, out tossedDecimal))
            {
                await DisplayAlert("Missing Price Value", "Please enter a valid price.", "Ok");

            }

            await DatabaseService.AddTerm(TermName.Text, TermPicker.SelectedItem.ToString(), Int32.Parse(StudentsEnrolled.Text), Decimal.Parse(TermFees.Text), StartDatePicker.Date, EndDatePicker.Date);

            await Navigation.PopAsync();
        }

        async void CancelTerm_Clicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync();
        }

    
    }
}