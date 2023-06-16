using mschreiber_c971MobileApp.Services;
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
        int _selectCourseId;
        public AddAssessments(int courseId)
        {
            InitializeComponent();
            _selectCourseId = courseId;
        }

        async void AddOA_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Status", "Enabled", "OK");

            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Name", "Please enter a name.", "Ok");

            }

            await DatabaseService.AddObjectiveAssessment(_selectCourseId, CourseName.Text, StartDatePicker.Date, EndDatePicker.Date);




        }

        async void AddPA_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Status", "Enabled", "OK");
        }
    }
}