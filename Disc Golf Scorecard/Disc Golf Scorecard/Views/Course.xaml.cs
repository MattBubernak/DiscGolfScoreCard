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
    public partial class Course : PhoneApplicationPage
    {
        public CourseViewModel courseViewModel = null; 

        public Course()
        {
            InitializeComponent();
            DataContext = null;
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
                    courseViewModel.NotifyProperties(); 
                }
                

            }
        }


        private void Edit(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/NewCourse.xaml?courseIndex=" + HomePageViewModel.get_instance().courses.IndexOf(courseViewModel), UriKind.Relative));

        }



    }
}