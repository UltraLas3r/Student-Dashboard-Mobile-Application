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

        async void AddOA_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Status", "Enabled", "OK");

            if (ConfirmUserInput())
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");




            }
           
            await DatabaseService.AddObjectiveAssessment(_selectCourseId, CourseName.Text, StartDatePicker.Date, EndDatePicker.Date);
        }

        async void AddPA_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Status", "Enabled", "OK");

            if (ConfirmUserInput())
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }

            await DatabaseService.AddPracticeAssessment(_selectCourseId, CourseName.Text, StartDatePicker.Date, EndDatePicker.Date);




        }

        private bool ConfirmUserInput() 
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(CourseName.Text) || string.IsNullOrWhiteSpace(CourseName.Text) 
                || string.IsNullOrWhiteSpace(TestType.Text) || StartDatePicker.Date == null 
                 || EndDatePicker.Date == null || EndDatePicker.Date < StartDatePicker.Date) 
            {
                return false;
            }
            
            
            return valid; 
        }



    }
}