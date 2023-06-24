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
    public partial class AssessmentDetails : ContentPage
    {
        public AssessmentDetails(Assessment assessment)
        {
            InitializeComponent();
            //CourseID.Text = assessment.CourseId.ToString();
        }

        private void InitializeComponent()
        {
          
        }

        private void EditAssessment_Clicked(object sender, EventArgs e)
        {

        }
    }
}