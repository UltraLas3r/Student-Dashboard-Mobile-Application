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
        int _courseId;
        string assessmentName;
        string assessmentType;
        Assessment assessment = new Assessment();
        public AddAssessments(string courseName, int _selectCourseId, Assessment assessment)
        {
            InitializeComponent();
            _course = courseName;
            _courseId = _selectCourseId;

            Title = "Add Assessment to: " + _course;
            CourseId.Text = _courseId.ToString();
            TestTypePicker.SelectedItem = assessment.AssessmentType;
            AssessmentName.Text = assessment.AssessmentName;
        }

        protected override void OnAppearing()
        {
            

            base.OnAppearing();
           
        }

        //TODO: possibly get rid of confirmuserinput()

        //private bool ConfirmUserInput() 
        //{
        //    bool valid = true;

        //    if (string.IsNullOrWhiteSpace(AssessmentName.ToString()) || string.IsNullOrWhiteSpace(_courseId.ToString()) || string.IsNullOrWhiteSpace(TestTypePicker.SelectedItem.ToString()) 
        //        || StartDatePicker.Date == null 
        //        || EndDatePicker.Date == null || EndDatePicker.Date < StartDatePicker.Date) 
        //    {
        //        return false;
        //    }
            
            
        //    return valid; 
        //}

        

        async void SaveAssessmentToCourse_Clicked(object sender, EventArgs e)
        {
            CourseInfo course = new CourseInfo();

            if (string.IsNullOrWhiteSpace(AssessmentName.ToString()))
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }

            //get values from form controls to pass into the method 
            await DatabaseService.AddAssessment(Int32.Parse(_courseId.ToString()), AssessmentName.Text, TestTypePicker.SelectedItem.ToString(), StartDatePicker.Date, EndDatePicker.Date, StartDateNotify.IsToggled, EndDateNotify.IsToggled);

            await Navigation.PopAsync();
        }
    }
}