using mschreiber_c971MobileApp.Models;
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

    public partial class CourseDetails : ContentPage
    {
        private IEnumerable<Assessment> Assessments { get; set; }

        private int courseId;
        
        public CourseDetails()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            // Assign the retrieved assessments to a list or collection property that can be bound to the UI.
            // Example:
            //todo: maybe change this to a collectionview
            //AssessmentCollectionView.ItemsSource = await DatabaseService.GetAssessments(courseId);
        }






    }
}