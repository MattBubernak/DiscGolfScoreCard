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
            //load up the player selection 
            PlayerSelection.ItemsSource = HomePageViewModel.get_instance().players;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("courseIndex", out selectedIndex))
                {
                    Debug.WriteLine("recieved a course index...");
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

        private void UpdateAnalytic(object sender, SelectionChangedEventArgs e)
        {
            //Debug.WriteLine(selectedPlayer.NickName);
            if (courseViewModel == null)
            {
                Debug.WriteLine("course view model is null");
                return;
            }
            if (PlayerSelection.SelectedItem != null)
                courseViewModel.update_analytic(PlayerSelection.SelectedItem as PlayerViewModel);
            courseViewModel.NotifyProperties();
        }



    }
}