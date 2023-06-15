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
    public partial class TermList : ContentPage
    {
        private int termId;
        public TermList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            TermCollectionView.ItemsSource = await DatabaseService.GetTerms();
        }

        async void ViewCourses_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermList());
        }

       

        async void AddNewTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermAdd());
        }

        private void Notes_Clicked(object sender, EventArgs e)
        {

        }

        private void StudentProfile_Clicked(object sender, EventArgs e)
        {

        }

        async void TermCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                TermInfo term = (TermInfo)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new TermEdit(term));
            }
        }

        async void EditTerm_Clicked(object sender, EventArgs e)
        {
   
                await Navigation.PushAsync(new TermEdit(termId));
            
        }
    }
}