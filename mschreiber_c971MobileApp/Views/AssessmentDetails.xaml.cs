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
        private readonly int _courseId;
        private readonly int _assessmentId;
        private readonly string _assessmentType;
        CourseInfo courseInfo = new CourseInfo();
        public AssessmentDetails(Assessment assessment)
        {
            InitializeComponent();
            _assessmentId = assessment.AssessmentId;
            _assessmentType = assessment.AssessmentType;
            _courseId = assessment.CourseId;
            AssessmentId.Text = assessment.AssessmentId.ToString();

            AssessmentName.Text = assessment.AssessmentName;
            AssessmentType.Text = assessment.AssessmentType;
            StartDatePicker.Date = assessment.StartDate;
            EndDatePicker.Date = assessment.AnticipatedEndDate;

            StartDateNotify.IsToggled = assessment.StartDateNotify;
            EndDateNotify.IsToggled =assessment.EndDateNotify;

        }

        async void SaveAssessment_Clicked(object sender, EventArgs e)
        {
            await DatabaseService.UpdateAssessment(_courseId, AssessmentName.Text, DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()), StartDateNotify.IsToggled, EndDateNotify.IsToggled);
            await Navigation.PopAsync();
        }

        async void CancelAssessment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        //todo change this to look at AsessmentId
        async void RemoveAssessment_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete this Test?", "Delete this Assessment?", "Yes", "No");

            if (answer == true)
            {
                await DatabaseService.RemoveAssessment(_assessmentId, _assessmentType);

                await DisplayAlert("Assessment Deleted", "Assement Deleted", "Ok");
            }

            else
            {
                await DisplayAlert("Delete Canceled", "Assessment Delete Canceled", "Ok");
            }

            await Navigation.PopAsync();
        }
    }
}