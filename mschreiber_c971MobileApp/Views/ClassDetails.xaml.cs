using mschreiber_c971MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace mschreiber_c971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassDetails : ContentPage
    {
        private void AddOA_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddPA_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private ClassInfo MyClass { get; set; }

        public ClassDetails()

        {

            InitializeComponent();

            

           // BindingContext = new CourseModel(MyCourse);

        }

        async void ViewTerms_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermList());
        }

        private void ClassDetailButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewClasses_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Notes_Clicked(object sender, EventArgs e)
        {

        }

        private void StudentProfile_Clicked(object sender, EventArgs e)
        {

        }

        private void AddNewClasses_Clicked(object sender, EventArgs e)
        {

        }



        //        private void Tests_Clicked(object sender, EventArgs e)

        //        {

        //            Button button = (Button)sender;

        //            Course c = (Course)button.BindingContext;

        //            ObservableCollection<Course> select = CourseModel.GetSelected();

        //            Course selected = select[0];



        //            if (c == selected)

        //            {

        //                Navigation.PushModalAsync(new NavigationPage(new Views.Assessments(c)));

        //            }

        //            else

        //            {

        //                Navigation.PushModalAsync(new NavigationPage(new Views.Assessments(selected)));

        //            }



        //        }



        //        private void Notifications_CheckedChanged(object sender, CheckedChangedEventArgs e)

        //        {



        //        }



        //        private void Event_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)

        //        {

        //            //compare collection of courses to selected course and grab the index

        //            ObservableCollection<Course> selected = CourseModel.GetSelected();

        //            Course select = selected[0];



        //            CourseModel.UpdateCourse(select.CourseID);

        //            CourseModel.UpdateCurrentCourse(select.CourseID);

        //        }



        //        private void Email_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)

        //        {

        //            ObservableCollection<Course> selected = CourseModel.GetSelected();

        //            Course select = selected[0];



        //            bool test = true;

        //            char[] invalid = { '!', '@', '#', '$', '%', '^', '&', '*', ',',

        //                        '<', '>', '.', ';', ':', '"', '[', ']', '{', '}' };

        //            //instructor fields are populated

        //            if (select.Instructor.Length > 0 && select.InstructorPhone.Length > 0 && select.InstructorEmail.Length > 0)

        //            {

        //                //works

        //                foreach (char c in invalid)

        //                {

        //                    if (select.Instructor.Contains(c))

        //                    {

        //                        test = false;

        //                    }

        //                }

        //                if (select.InstructorEmail.Contains('@') && test)

        //                {

        //                    //valid email

        //                    CourseModel.UpdateCourse(select.CourseID);

        //                }

        //                else

        //                {

        //                    DisplayAlert("Warning", "Please enter a valid email.", "OK");

        //                }

        //            }

        //            else

        //            {

        //                DisplayAlert("Warning", "Please enter a valid email.", "OK");

        //            }

        //        }



        //        private void Share_Clicked(object sender, EventArgs e)

        //        {

        //            ObservableCollection<ClassInfo> selected = ClassDetails.GetSelected();

        //            Class select = selected[0];

        //            List<string> recipient = new List<string>();

        //            recipient.Add(select.ShareEmail);

        //            _ = SendEmail(select.Notes, recipient);

        //        }



        //        public async Task SendEmail(string body, List<string> recipient)

        //        {
        //            try

        //            {
        //                var message = new EmailMessage
        //                {
        //                    Subject = "Check out my notes!",
        //                    Body = body,
        //                    To = recipient
        //                };
        //                await Email.ComposeAsync(message);
        //            }

        //            catch (FeatureNotSupportedException)

        //            {
        //                await DisplayAlert("Warning", "Email is not supported on this device", "OK");
        //            }

        //            catch
        //            {

        //            }

        //        }



        //        private void Picker_SelectedIndexChanged(object sender, EventArgs e)

        //        {

        //            ObservableCollection<Course> selected = CourseModel.GetSelected();

        //            Course select = selected[0];



        //            Term to Course List clears Course.Status

        //    CourseList(CurrentCourse) not updating Status from CourseDetail(SelectedCourse)

        //    UpdateStatus being passed - 1

        //    Returning from CourseDetail to CourseList clears Status to -1

        //    CourseModel.UpdateStatus(select.Status);

        //            CourseModel.UpdateCourse(select.CourseID);

        //            CourseModel.UpdateCourseStatus(select.CourseID, select.Status);

        //            CourseModel.UpdateCurrentCourse(select.CourseID);

        //        }






    }

}

