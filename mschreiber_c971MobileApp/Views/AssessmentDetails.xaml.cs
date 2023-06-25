using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mschreiber_c971MobileApp.Services;
using mschreiber_c971MobileApp.Models;
using Xamarin.Essentials;

namespace mschreiber_c971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentDetails : ContentPage
    {
        private int courseId;
        public AssessmentDetails(Assessment assessment)
        {
            InitializeComponent();
            //CourseID.Text = assessment.CourseId.ToString();
            
        }

        //protected override async void OnAppearing(CourseInfo course)
        //{
        //    courseId = course.Id;
        //    base.OnAppearing();

        //    //CourseName.Text = course.CourseName;

        //    ////where the data is coming from

        //    //CourseCollection.ItemsSource = await DatabaseService.GetCourses(courseId);


        //}

        private void EditAssessment_Clicked(object sender, EventArgs e)
        {

        }

        private void SaveAssessment_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelAssessment_Clicked(object sender, EventArgs e)
        {

        }

        private void RemoveAssessment_Clicked(object sender, EventArgs e)
        {

        }
    }
}