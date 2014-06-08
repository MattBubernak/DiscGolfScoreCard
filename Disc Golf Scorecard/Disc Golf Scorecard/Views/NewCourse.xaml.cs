using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Disc_Golf_Scorecard.ViewModels;
using System.Diagnostics;

namespace Disc_Golf_Scorecard.Views
{
    public partial class NewCourse : PhoneApplicationPage
    {
        public CourseViewModel courseViewModel = null; 


        public NewCourse()
        {
            InitializeComponent();
            DataContext = null;
        }

        private void Add_Hole(object sender, EventArgs e)
        {
            courseViewModel.Create_Hole();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("courseIndex", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    DataContext = HomePageViewModel.get_instance().courses[index];
                    courseViewModel = HomePageViewModel.get_instance().courses[index];
                }
            }
        }

        private void Save_Course(object sender, EventArgs e)
        {

        }

        private void add(object sender, RoutedEventArgs e)
        {
            HoleViewModel clicked = ((sender as Button).DataContext as HoleViewModel);
            clicked.addPar();

        }

        private void subtract(object sender, RoutedEventArgs e)
        {
            HoleViewModel clicked = ((sender as Button).DataContext as HoleViewModel);
            clicked.minusPar();

        }

        private void df_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void HoleLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("I was called!");
        }


    }
}