using mschreiber_c971MobileApp.Models;
using mschreiber_c971MobileApp.Services;
using Plugin.LocalNotifications;
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
    public partial class Dashboard : ContentPage
    {
        private int termId;
        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var CourseList = await DatabaseService.GetCourses();
            var notifyRandom = new Random();
            var notifyId = notifyRandom.Next(1000);

            foreach (CourseInfo courseRecord in CourseList)
            {
                if (courseRecord.StartNotification == true)
                {
                    if (courseRecord.AnticipatedEndDate == DateTime.Today.AddDays(+90))
                    {
                        CrossLocalNotifications.Current.Show("Notice", $"{courseRecord.CourseName} begins today!", notifyId);
                    }
                }
            }

        }

        public Dashboard()
        {
            InitializeComponent();
          
        }

        async void AddTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermAdd());
        }

        

        async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppSettings());
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Rotation == 0)
            {
                button.Rotation += 90;
                button.BackgroundColor = Color.Red;
            }
            else
            {
                button.Rotation = 0;
                button.BackgroundColor = default;
            }
        }

      
        async void ViewTerms_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermList());
        }

        async void Notes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Notes());
        }

        async void StudentProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentProfile());
        }

        async void TermAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermAdd());
        }

        async void CourseAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseAdd(termId));
        }

    
    }
}