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
using System.Text.RegularExpressions;

namespace mschreiber_c971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseEdit : ContentPage
    {
        private readonly int _selectTermId;
        private readonly int _courseId;
        private int _assessmentId;
        private string _courseName;
        private string _assessmentName;

        bool endNotify;
        bool startNotify;
        
        private string _email;
        Assessment assessment = new Assessment();
        public List<string> pickerStates = new List<string> { "In Progress", "Completed", "Dropped", "Plan To Take" };

        public CourseEdit(CourseInfo course)
        {
            InitializeComponent();

            DateTime CourseStart = course.StartDate;

            _courseId = course.Id;
            _courseName = course.CourseName;
            _email = course.Email;
            //todo: delete this perhaps?
            //CourseId.Text = course.Id.ToString();
            CourseName.Text = course.CourseName;
            CourseInstructorName.Text = course.Instructor;
            StatusTypePicker.SelectedItem = course.CourseStatus;
            PhoneNumber.Text = course.Phone;
            Email.Text = course.Email;
            StartDatePicker.Date = course.StartDate;
            EndDatePicker.Date = course.AnticipatedEndDate;
            NotesEditor.Text = course.Notes;

            StartDateNotify.IsToggled = course.StartNotification;
            EndDateNotify.IsToggled = course.EndNotification;
            
            

        }

        public CourseEdit(Assessment assessment)
        {
            InitializeComponent();
            _assessmentName = assessment.AssessmentName;
            _assessmentId = assessment.AssessmentId;
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();

    
            AssessmentsCollection.ItemsSource = await DatabaseService.GetAssessments(_courseId);
        }

       


        async void SaveCourse_Clicked(object sender, EventArgs e)
        {
           if (!IsValidEmail(Email.Text))
            {
                await DisplayAlert("Email Check", "Email must be in valid format \n name@xyz.com", "Ok");
                return;
            }

            if (!IsValidPhoneNumber(PhoneNumber.Text))
            {
                await DisplayAlert("Phone Check", "Phone number must be in valid format \n 555 555 5555", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Name", "Must enter a name.", "Ok");
                return;
            }


            if (string.IsNullOrWhiteSpace(StartDatePicker.ToString()))
            {
                await DisplayAlert("Missing end date", "Please pick an end date", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(EndDatePicker.ToString()))
            {
                await DisplayAlert("Missing end date", "Please pick an end date", "Ok");
                return;
            }

            if (StatusTypePicker.SelectedItem == null)
            {
                await DisplayAlert("Missing course status", "Select Course Status", "Ok");
                return;
            }

           
            await DatabaseService.UpdateCourse(_courseId, CourseName.Text, StartDateNotify.IsToggled, EndDateNotify.IsToggled, StatusTypePicker.SelectedItem.ToString(), DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()), CourseInstructorName.Text, PhoneNumber.Text, Email.Text, NotesEditor.Text);


        
            await Navigation.PopAsync();

        }

        async void RemoveCourse_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete this Course?", "Delete this Course?", "Yes", "No");

            if (answer == true)
            {
                var id = _courseId;

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

            await Navigation.PushAsync(new AddAssessments(_courseName, _courseId, assessment));
        }



        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\d{3}\s\d{3}\s\d{4}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        async void AssessmentsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.CurrentSelection != null)
            {
                Assessment assessment = (Assessment)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new AssessmentDetails(assessment));
            }

            //await Navigation.PushAsync(new AssessmentDetails(_courseName, courseId, assessment));
        }
    }
}