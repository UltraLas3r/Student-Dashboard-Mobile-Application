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
            _selectTermId = termId;
        }

        async void SaveCourse_Clicked(object sender, EventArgs e)
        {
            int tossedInt;
            Decimal tossedDecimal;

            int addCourseCounter = 0;


            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }
            if (string.IsNullOrWhiteSpace(StartDatePicker.ToString()))
            {
                await DisplayAlert("Missing start date", "Please pick a start date", "Ok");
            }

            if (string.IsNullOrWhiteSpace(AnticipatedEndDate.ToString()))
            {
                await DisplayAlert("Missing end date", "Please pick an end date", "Ok");
            }

            //TODO add a foreach loop here 
            //if (addCourseCounter == 6)
            //{
            //    await DisplayAlert("Term full", "unable to add any more courses to term (Max 6)", "Cancel");
            //}
           
            await DatabaseService.AddCourse(_selectTermId, CourseName.Text, StartDatePicker.Date, AnticipatedEndDate.Date, InstructorName.Text, PhoneNumber.Text, EmailAddress.Text, Notification.IsToggled, NotesEditor.Text);


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