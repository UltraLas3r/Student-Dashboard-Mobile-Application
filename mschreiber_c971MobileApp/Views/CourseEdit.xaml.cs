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
    public partial class CourseEdit : ContentPage
    {
        private readonly int _selectTermId;
        private readonly int courseId;
        private string _courseName;

        public CourseEdit(CourseInfo course)
        {
            InitializeComponent();

            DateTime CourseStart = course.StartDate;

            courseId = course.Id;
            _courseName = course.CourseName;

            CourseId.Text = course.Id.ToString();
            CourseName.Text = course.CourseName;
            CourseInstructorName.Text = course.Instructor;
            PhoneNumber.Text = course.Phone;
            Email.Text = course.Email;
            StartDatePicker.Date = course.StartDate;
            EndDatePicker.Date = course.AnticipatedEndDate;
            NotesEditor.Text = course.Notes;

        }

        public CourseEdit(Assessment assessment)
        {
            InitializeComponent();
           
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();
            

            AssessmentsCollection.ItemsSource = await DatabaseService.GetAssessments(courseId);
        }


        async void SaveCourse_Clicked(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Name", "Must enter a name.", "Ok");
            }

            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Name", "Must enter a name.", "Ok");
            }

            if (string.IsNullOrWhiteSpace(StartDatePicker.ToString()))
            {
                await DisplayAlert("Missing end date", "Please pick an end date", "Ok");
            }

            if (string.IsNullOrWhiteSpace(EndDatePicker.ToString()))
            {
                await DisplayAlert("Missing end date", "Please pick an end date", "Ok");
            }


            //TODO possibly remobe the UpdateCourse function 
            await DatabaseService.UpdateCourse(Int32.Parse(CourseId.Text), CourseName.Text, DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()), CourseInstructorName.Text, PhoneNumber.Text, Email.Text, NotesEditor.Text);


            //await DatabaseService.UpdateTerm(Int32.Parse(CourseId.Text), CourseName.Text, DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()));
            
            await Navigation.PopAsync();

        }

        async void RemoveCourse_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete this Course?", "Delete this Course?", "Yes", "No");

            if (answer == true)
            {
                var id = int.Parse(CourseId.Text);

                await DatabaseService.RemoveCourse(id);

                await DisplayAlert("Course Deleted", "Course Deleted", "Ok");
            }
            else
            {
                await DisplayAlert("Delete Canceled", "CourseDelete Canceled", "Ok");
            }

            await Navigation.PopAsync();
        }

        async void CancelCourse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void CourseCollectView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: might not need this? not sure...

            //if (e.CurrentSelection != null)
            //{
            //    TermInfo term = (TermInfo)e.CurrentSelection.FirstOrDefault();
            //    await Navigation.PushAsync(new TermEdit(term));
            //}
        }

        async void ShareButton_Clicked(object sender, EventArgs e)
        {
            var text = CourseName.Text;

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Share Text"
            });
        }

       async void ShareUri_Clicked(object sender, EventArgs e)
        {
            string uri = "www.wgu.edu";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = uri,
                Title = "Share Web Link"
            });
        }

        async void AddATestButton_Clicked(object sender, EventArgs e)
        {
            Assessment assessment = new Assessment();

            //TODO: check if I am passing in the right parameters here
            await Navigation.PushAsync(new AddAssessments(_courseName, courseId, assessment));
        }

        private void AssessmentsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //async void RemoveAssessment_Clicked(object sender, EventArgs e)
        //{
        //    var answer = await DisplayAlert("Delete this assessment?", "Delete this assessment?", "Yes", "No");

        //    if (answer == true)
        //    {
        //        var name = AssessmentName.Text;

        //        await DatabaseService.RemoveAssessment(name);

        //        await DisplayAlert("Test Deleted", "Test Deleted", "Ok");
        //    }
        //    else
        //    {
        //        await DisplayAlert("Delete Canceled", "CourseDelete Canceled", "Ok");
        //    }

        //    await Navigation.PopAsync();
        //}
    }
}