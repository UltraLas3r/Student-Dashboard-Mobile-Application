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
        string assessmentName;
        string assessmentType;
        Assessment assessment = new Assessment();
        public AddAssessments(string courseName, int courseId, Assessment assessment)
        {
            InitializeComponent();
            _course = courseName;
            _selectCourseId = courseId;

            Title = "Add Assessment to: " + _course;

            CourseId.Text = _selectCourseId.ToString();
           
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

            //if(assessmentType.Contains("PA"))
            //{
            //    await DisplayAlert("PA already assigned", "Unable to assign another PA to course: Max 1 per Course", "Ok");
            //}

            //if(assessmentType.Contains("OA"))
            //{
            //    await DisplayAlert("OA already assigned", "Unable to assign another OA to course: Max 1 per Course", "Ok");
            //}


            //get values from form controls to pass into the method 
            await DatabaseService.AddAssessments(_selectCourseId, AssessmentName.Text, TestTypePicker.SelectedItem.ToString(), StartDatePicker.Date, EndDatePicker.Date, StartDateNotify.IsToggled, EndDateNotify.IsToggled);

            await Navigation.PopAsync();
        }
    }
}