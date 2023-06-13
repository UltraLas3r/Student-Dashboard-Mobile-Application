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
        public CourseEdit(CourseInfo course)
        {
            InitializeComponent();

            CourseId.Text = course.Id.ToString();
            CourseName.Text = course.Name;
            CourseTermPicker.SelectedItem = course.Season;
            CoursePrice.Text = course.Price.ToString();
            CreationDatePicker.Date = course.CreationDate;
        }

       async void SaveCourse_Clicked(object sender, EventArgs e)
        {
            //TODO: This is to verify I am saving the information correctly when I CLICK THE SAVE BUTTON!!!
            decimal tossedDecimal;
            int tossedInt;

            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Name", "Must enter a name.", "Ok");
            }

            if (string.IsNullOrWhiteSpace(CourseTermPicker.SelectedItem.ToString()))
            {
                await DisplayAlert("Missing Term", "Must enter a Term Season.", "Ok");
            }

            if (!Int32.TryParse(StudentsEnrolled.Text, out tossedInt))
            {
                await DisplayAlert("Incorrect Inventory Value", "Please enter a whole number.", "Ok");
            }

            if (!Decimal.TryParse(CoursePrice.Text, out tossedDecimal))
            {
                await DisplayAlert("Incorrect Price Value", "Please enter a valid number.", "Ok");
            }

            await DatabaseService.UpdateTerm(Int32.Parse(CourseId.Text), CourseName.Text, CourseTermPicker.SelectedItem.ToString(), Int32.Parse(StudentsEnrolled.Text),
                Decimal.Parse(CoursePrice.Text), DateTime.Parse(CreationDatePicker.Date.ToString()));

            await Navigation.PopAsync();

        }

        async void RemoveCourse_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete this Course?", "Delete this Course?", "Yes", "No");

            if (answer == true)
            {
                var id = int.Parse(CourseId.Text);
                await DatabaseService.RemoveCourse(id);

                await DisplayAlert("Widget Deleted", "Course Deleted", "Ok");
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

        private void AddCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void CourseCollectView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            string uri = "www.Wgu.edu";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = uri,
                Title = "Share Web Link"
            });
        }
    }
}