using mschreiber_c971MobileApp.Services;
using mschreiber_c971MobileApp.Models;
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
    public partial class AddAssessments : ContentPage
    {
        //public CourseInfo _course;
        string _course;
        int _selectCourseId;
        public AddAssessments(string courseName, int courseId)
        {
            InitializeComponent();
            _course = courseName;
            _selectCourseId = courseId;

            Title = _course;
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
        }

        private bool ConfirmUserInput() 
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(_selectCourseId.ToString()) || string.IsNullOrWhiteSpace(TestTypePicker.SelectedItem.ToString()) 
                || StartDatePicker.Date == null 
                || EndDatePicker.Date == null || EndDatePicker.Date < StartDatePicker.Date) 
            {
                return false;
            }
            
            
            return valid; 
        }

        async void AddAssessment_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Status", "Enabled", "OK");

            if (ConfirmUserInput())
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }

            //get values from form controls to pass into the method 
            await DatabaseService.AddAssessment(_selectCourseId, TestName.Text, TestTypePicker.SelectedItem.ToString(), StartDatePicker.Date, EndDatePicker.Date, StartDateNotify.IsToggled, EndDateNotify.IsToggled);




        }
    }
}