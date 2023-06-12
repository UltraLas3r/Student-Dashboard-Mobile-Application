using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mschreiber_c971MobileApp.Services;
using mschreiber_c971MobileApp.Models;

namespace mschreiber_c971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseEdit : ContentPage
    {
        public CourseEdit(CourseInfo course)
        {
            InitializeComponent();

            //CoursId.Text = course.Id.ToString();
            //GadgetName.Text = gadget.Name;
            //GadgetColorPicker.SelectedItem = gadget.Color;
            //GadgetPrice.Text = gadget.Price.ToString();
            //CreationDatePicker.Date = gadget.CreationDate;
        }

        private void AddCourse_Clicked(object sender, EventArgs e)
        {

        }
    }

    //protected override async void OnAppearing()
    //{
        
    //}





}