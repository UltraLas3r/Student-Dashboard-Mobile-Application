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
      
        private string randomName;
        private int _assessmentId;
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            var CourseList = await DatabaseService.GetCourses();
            var AssessmentList = await DatabaseService.GetAssessments();
            var notifyRandom = new Random();

            CheckForEvalStart();
            CheckForEvalEnd();

            foreach (CourseInfo course in CourseList)
            {
                var notifyId = notifyRandom.Next(1000);

                if (course.StartNotification == true)
                {

                    if (course.StartDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Notice", $"{course.CourseName} begins today!", notifyId);
                    }
                }
            }

            foreach (CourseInfo course in CourseList)
            {
                var notifyId = notifyRandom.Next(1000);

                if (course.EndNotification == true)
                {
                    if (course.AnticipatedEndDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Notice", $"{course.CourseName} ENDS today!", notifyId);
                    }
                }

            }

            async void CheckForEvalStart()
            {

                foreach (Assessment assessment in AssessmentList)
                {
                    var notifyId = notifyRandom.Next(1000);

                    if (assessment.StartDateNotify == true)
                    {
                        if (assessment.StartDate == DateTime.Today)
                        {
                            CrossLocalNotifications.Current.Show("Notice", $"{assessment.AssessmentName} begins today!", notifyId);
                        }
                    }

                    if (assessment.StartDateNotify == false && assessment.StartDateNotify == false)
                    {
                        return;
                    }

                }


                return;
            }

            async void CheckForEvalEnd()
            {
                foreach (Assessment assessment in AssessmentList)
                {
                    var notifyId = notifyRandom.Next(1000);

                    if (assessment.EndDateNotify == true)
                    {
                        if (assessment.AnticipatedEndDate == DateTime.Today)
                        {
                            CrossLocalNotifications.Current.Show("Notice", $"{assessment.AssessmentName} ENDS today!", notifyId);
                        }
                    }

                    if (assessment.EndDateNotify == false && assessment.EndDateNotify == false)
                    {
                        return;
                    }

                }


            await DatabaseService.GetOACount(_assessmentId);


            await DatabaseService.GetPACount(_assessmentId);

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

     
      
        async void ViewTerms_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermList());
        }

        async void Notes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Notes());
        }

       

        async void TermAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermAdd());
        }

        async void CourseAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseAdd(termId));
        }

        async void OpenCourseDetails_Clicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new CourseDetails());
        }

        async void CreateAssessment_Clicked(object sender, EventArgs e)
        {
            Assessment assessment = new Assessment();

            await Navigation.PushAsync(new AddAssessments(randomName, termId, assessment));
        }
    }
}