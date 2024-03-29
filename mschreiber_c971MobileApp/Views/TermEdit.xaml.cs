﻿using System;
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
    public partial class TermEdit : ContentPage
    {
        private readonly int _selectTermId;
        private int termId;
        
        Assessment assessment = new Assessment();

        public TermEdit(TermInfo termId)
        {
            InitializeComponent();

            _selectTermId = termId.Id;
            TermId.Text = termId.Id.ToString();
            TermName.Text = termId.Name;
            StartDatePicker.Date = termId.StartDate;
            EndDatePicker.Date = termId.AnticipatedEndDate;
           

        }

     

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
     
                //where the data is coming from
            
            CourseCollectionView.ItemsSource = await DatabaseService.GetCourses(_selectTermId);
            

        }
        public TermEdit(int termId)
        {
            this.termId = termId;
            InitializeComponent();
        }

        async void SaveTerm_Clicked(object sender, EventArgs e)
        {
            DateTime startDate = StartDatePicker.Date;
            DateTime endDate = EndDatePicker.Date;

            if (endDate < startDate)
            {
                await DisplayAlert("Invalid End Date", "End Date cannot be before Start Date", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(TermName.Text))
            {
                await DisplayAlert("Missing Name", "Must enter a name.", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(StartDatePicker.ToString()))
            {
                await DisplayAlert("Missing start date", "Please pick a start date", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(EndDatePicker.ToString()))
            {
                await DisplayAlert("Missing end date", "Please pick an end date", "Ok");
                return;
            }


            await DatabaseService.UpdateTerm(Int32.Parse(_selectTermId.ToString()), TermName.Text,  DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()));

            await Navigation.PopAsync();

        }

        async void CancelTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void RemoveTerm_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete Term and Related Courses?", "Delete this Term?", "Yes", "No");

            if (answer == true)
            {
                var id = int.Parse(TermId.Text);

                await DatabaseService.RemoveTerm(id);

                await DisplayAlert("Term Deleted", "Term Deleted", "Ok");
            }

            else
            {
                await DisplayAlert("Delete Canceled", "Nothing Deleted", "Ok");
            }

            await Navigation.PopAsync();
        }

        async void AddClass_Clicked(object sender, EventArgs e)
        {

            var termId = Int32.Parse(TermId.Text);

            await Navigation.PushAsync(new CourseAdd(termId));
        }

        async void CourseCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var course = (CourseInfo)e.CurrentSelection.FirstOrDefault();
            if (e.CurrentSelection != null)
            {
                await Navigation.PushAsync(new CourseEdit(course));
            }
        }
    }
}