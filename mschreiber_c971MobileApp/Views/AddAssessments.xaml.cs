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

        async void SaveAssessmentToCourse_Clicked(object sender, EventArgs e)
        {
            CourseInfo course = new CourseInfo();
            DateTime startDate = StartDatePicker.Date;
            DateTime endDate = EndDatePicker.Date;


            string courseId = CourseId.Text;
            string assessmentName = AssessmentName.Text;
            string testType = TestTypePicker.SelectedItem as string;
            string performanceTest = "Performance";
            string objectiveTest = "Objective";
          
            int PAcount = await DatabaseService.GetPACount(_selectCourseId);
            int OAcount = await DatabaseService.GetOACount(_selectCourseId);

            if (PAcount == 1 && OAcount == 0)
            {
                if (PAcount == 0 && testType == objectiveTest)
                {
                    return;
                }

                if (PAcount == 0 || testType == performanceTest)
                    {
                        await DisplayAlert("Assessment Type max", "You already have a PA assigned to course ", "OK");
                        return;
                    } 
            }

            if (PAcount == 0 && OAcount == 1)
            {
                if (OAcount == 0 && testType == performanceTest)
                {
                    return;
                }

                if (OAcount == 0 || testType == objectiveTest /*!string.IsNullOrEmpty(testType)*/)
                {
                    await DisplayAlert("Assessment Type max", "You already have an OA assigned to course ", "OK");
                    return;
                }
            }

            if (PAcount == 1 && OAcount == 1)
            {
                await DisplayAlert("Assessment Type max", "Unable to add more assessments to course", "OK");
                return;
            }

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



            //get values from form controls to pass into the method 
            await DatabaseService.AddAssessments(_selectCourseId, AssessmentName.Text, TestTypePicker.SelectedItem.ToString(), StartDatePicker.Date, EndDatePicker.Date, StartDateNotify.IsToggled, EndDateNotify.IsToggled);

           
            await Navigation.PopAsync();
        }
    }
}