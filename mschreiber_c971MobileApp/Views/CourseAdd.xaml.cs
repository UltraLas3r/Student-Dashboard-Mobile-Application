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
    public partial class CourseAdd : ContentPage
    {
        int _selectTermId;
        public CourseAdd(int termId)
        {
            InitializeComponent();
            _selectTermId  = termId;
        }

        async void SaveCourse_Clicked(object sender, EventArgs e)
        {
            int tossedInt;
            Decimal tossedDecimal;


            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }
            if (string.IsNullOrWhiteSpace(CourseTermPicker.SelectedItem.ToString()))
            {
                await DisplayAlert("Missing Color", "Please pick a color", "Ok");

            }

            if (Int32.TryParse(Enrolled.Text, out tossedInt))
            {
                await DisplayAlert("Missing inventory value", "Please enter a whole number.", "Ok");
            }

            if (!decimal.TryParse(CourseFee.Text, out tossedDecimal))
            {
                await DisplayAlert("Missing Price Value", "Please enter a valid price.", "Ok");

            }

            await DatabaseService.AddCourse(_selectTermId, CourseName.Text, CourseTermPicker.SelectedItem.ToString(), Int32.Parse(Enrolled.Text), Decimal.Parse(CourseFee.Text), DatePicker.Date, Notification.IsToggled, NotesEditor.Text);

            await Navigation.PopAsync();

        }

        async void CancelCourse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Home_Clicked(object sender, EventArgs e)
        {

            Dashboard page = new Dashboard();
            await Navigation.PushAsync(page);
        }
    }
}