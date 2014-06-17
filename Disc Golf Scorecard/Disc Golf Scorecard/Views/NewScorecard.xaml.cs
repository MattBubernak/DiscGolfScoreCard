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

namespace Disc_Golf_Scorecard.Views
{
    public partial class NewScorecard : PhoneApplicationPage
    {
        int playerCount = 1;

        public ScorecardViewModel scorecardViewModel = null; 

        public NewScorecard()
        {
            InitializeComponent();
            CourseSelection.ItemsSource = HomePageViewModel.get_instance().courses;
            PlayerSelection1.ItemsSource = HomePageViewModel.get_instance().players;
            PlayerSelection2.ItemsSource = HomePageViewModel.get_instance().players;
            PlayerSelection3.ItemsSource = HomePageViewModel.get_instance().players;
            PlayerSelection4.ItemsSource = HomePageViewModel.get_instance().players;
            PlayerSelection5.ItemsSource = HomePageViewModel.get_instance().players;
            DataContext = null; 


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("scorecardIndex", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    DataContext = HomePageViewModel.get_instance().scorecards[index];
                    scorecardViewModel = HomePageViewModel.get_instance().scorecards[index];
                }
            }
        }

        private void Save_Scorecard(object sender, EventArgs e)
        {
            scorecardViewModel.Update_Description(DescriptionBox.Text);
            scorecardViewModel.Update_Course(CourseSelection.SelectedItem as CourseViewModel);
            
        }

        private void add_player(object sender, RoutedEventArgs e)
        {
            playerCount++;
            if (playerCount > 5)
                playerCount = 5;
            update_selectors(playerCount);
        }

        private void remove_player(object sender, RoutedEventArgs e)
        {
            playerCount--;
            if (playerCount < 1)
                playerCount = 1;
            update_selectors(playerCount);
        }

        private void update_selectors(int count)
        {
            switch (count)
            {
                case 1:
                    PlayerSelection2.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case 2:
                    PlayerSelection2.Visibility = System.Windows.Visibility.Visible;

                    PlayerSelection3.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case 3:
                    PlayerSelection4.Visibility = System.Windows.Visibility.Collapsed;
                    PlayerSelection3.Visibility = System.Windows.Visibility.Visible;

                    break;
                case 4:
                    PlayerSelection4.Visibility = System.Windows.Visibility.Visible;
                    PlayerSelection5.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case 5:
                    PlayerSelection5.Visibility = System.Windows.Visibility.Visible;
                    break;
            }
        }
    }
}