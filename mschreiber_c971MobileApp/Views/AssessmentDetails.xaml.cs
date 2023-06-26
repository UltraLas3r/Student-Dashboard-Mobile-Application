﻿using System;
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
        private readonly int courseId;
        CourseInfo courseInfo = new CourseInfo();
        public AssessmentDetails(Assessment assessment)
        {
            InitializeComponent();
            courseId = assessment.CourseId;
            CourseId.Text = assessment.CourseId.ToString();
            AssessmentName.Text = assessment.AssessmentName;
            AssessmentType.Text = assessment.AssessmentType;
        }

        public void GetCourseInfo(CourseInfo course)
        {
         
        }

        protected override async void OnAppearing()
        {

           // AssessmentCollection.ItemsSource = await DatabaseService.GetAssessments(courseId);


        }

        private void EditAssessment_Clicked(object sender, EventArgs e)
        {

        }

        async void SaveAssessment_Clicked(object sender, EventArgs e)
        {

            await DatabaseService.UpdateAssessment(Int32.Parse(CourseId.Text), AssessmentName.Text, DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString());
            
        }

        async void CancelAssessment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void RemoveAssessment_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete this Test?", "Delete this Assessment?", "Yes", "No");

            if (answer == true)
            {
                var id = int.Parse(CourseId.Text);

                await DatabaseService.RemoveAssessment(id);

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