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
    public partial class CourseAdd : ContentPage
    {
        int _selectTermId;
        public CourseAdd(int termId)
        {
            InitializeComponent();
            _selectTermId  = termId;
        }

        private void SaveCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelCourse_Clicked(object sender, EventArgs e)
        {

        }

        async void Home_Clicked(object sender, EventArgs e)
        {

            Dashboard page = new Dashboard();
            await Navigation.PushAsync(page);
        }
    }
}