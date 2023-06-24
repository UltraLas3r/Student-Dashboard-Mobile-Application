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
        string _selectAssessmentType;
        string _selectAssessmentName;

        Assessment assessment = new Assessment();
        public AddAssessments(string courseName, int courseId, Assessment assessment)
        {
            InitializeComponent();
            _course = courseName;
            _selectCourseId = courseId;
            _selectAssessmentName = assessment.AssessmentName;
            _selectAssessmentType = assessment.AssessmentType;

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
            DateTime startDate = StartDatePicker.Date;
            DateTime endDate = EndDatePicker.Date;


            string courseId = CourseId.Text;
            string assessmentName = AssessmentName.Text;
            string testType = TestTypePicker.SelectedItem as string;
            //TODO: look at this dictionary stuff and figure out if it is necessary
            //IDictionary<int, string> d = new Dictionary<int, string>();

            //if (d.Count > 2)
            //{
            //    await DisplayAlert("Too many assessments", "Only 2 assessments per course", "OK");
            //    return;
            //}

            //TODO: check if this count is actually working
            int count = await DatabaseService.GetPACount(_selectCourseId);

            if (count <= 1)
            {
                if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(assessmentName))
                {
                    await DisplayAlert("Missing Information", "Please fill in all fields", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(testType))
                {
                    await DisplayAlert("Invalid Test Type", "Please select a Test Type", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(StartDatePicker.ToString()))
                {
                    await DisplayAlert("Invalid Start Date", "Invalid Start Date", "Ok");

                }
                if (string.IsNullOrWhiteSpace(EndDatePicker.ToString()))
                {
                    await DisplayAlert("Invalid End Date", "Invalid End Date", "Ok");

                }

                if (endDate < startDate)
                {
                    await DisplayAlert("Invalid End Date", "End Date cannot be before Start Date", "OK");
                }


            }

            //get values from form controls to pass into the method 
            await DatabaseService.AddAssessments(_selectCourseId, AssessmentName.Text, TestTypePicker.SelectedItem.ToString(), StartDatePicker.Date, EndDatePicker.Date, StartDateNotify.IsToggled, EndDateNotify.IsToggled);

            //d.Add(_selectCourseId, TestTypePicker.SelectedItem.ToString());
            //d.Count();
            await Navigation.PopAsync();
        }
    }
}