using mschreiber_c971MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mschreiber_c971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseAdd : ContentPage
    {
        int _selectTermId;
        int _courseCount;

        public CourseAdd(int termId)
        {
            InitializeComponent();
            _selectTermId = termId;
            
          
        }

        async void SaveCourse_Clicked(object sender, EventArgs e)
        {
            DateTime startDate = StartDatePicker.Date;
            DateTime endDate = AnticipatedEndDate.Date;

            if (endDate < startDate)
            {
                await DisplayAlert("Invalid End Date", "End Date cannot be before Start Date", "OK");
                return;
            }


            if (string.IsNullOrEmpty(InstructorName.Text))
            {
                await DisplayAlert("Instructor Name Check", "Please provide instructor Name", "Ok");
                return;
            }

            if (!IsValidEmail(InstructorEmail.Text))
            {
                await DisplayAlert("Email Check", "Email must be in valid format \n name@xyz.com", "Ok");
                return;
            }

            if (!IsValidPhoneNumber(InstructorPhone.Text))
            {
                await DisplayAlert("Phone Check", "Phone number must be in valid format \n 555 555 5555", "Ok");
                return;
            }
          

            if (StatusTypePicker.SelectedItem == null)
            {
                await DisplayAlert("status check", "Please select a Course Status", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }
            if (string.IsNullOrWhiteSpace(StartDatePicker.ToString()))
            {
                await DisplayAlert("Missing start date", "Please pick a start date", "Ok");
            }

            if (string.IsNullOrWhiteSpace(AnticipatedEndDate.ToString()))
            {
                await DisplayAlert("Missing end date", "Please pick an end date", "Ok");
            }

            //look for the value of the start/end date switch


            await DatabaseService.AddCourse(_selectTermId, CourseName.Text, StartDateNotify.IsToggled, EndDateNotify.IsToggled, StatusTypePicker.SelectedItem.ToString(), StartDatePicker.Date, AnticipatedEndDate.Date, InstructorName.Text, InstructorPhone.Text, InstructorEmail.Text, NotesEditor.Text);
            

            await Navigation.PopAsync();
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

        async void CancelCourse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Home_Clicked(object sender, EventArgs e)
        {

            Dashboard page = new Dashboard();
            await Navigation.PushAsync(page);
        }
    }
}