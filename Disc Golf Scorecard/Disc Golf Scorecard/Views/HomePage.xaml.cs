﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using Disc_Golf_Scorecard.ViewModels;
using Microsoft.Phone.Tasks;


namespace Disc_Golf_Scorecard.Views
{
    public partial class HomePage : PhoneApplicationPage
    {
        public HomePage()
        {
            InitializeComponent();
            UpdatePanoramaAppBar(0);
            this.DataContext = HomePageViewModel.get_instance(); 
        }

        private void PanoramaSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentPanoramaIndex = panoramaControl.SelectedIndex;
            UpdatePanoramaAppBar(currentPanoramaIndex);
        }

        private void UpdatePanoramaAppBar(int index)
        {

            //create a new application bar
            ApplicationBar = new ApplicationBar();

            switch (index)
            {
                case 0:
                    //create a button for new player 
                    ApplicationBarIconButton newScorecard = new ApplicationBarIconButton();
                    //populate the button information 
                    newScorecard.Text = "Add Scorecard";
                    newScorecard.IconUri = new Uri("/Images/add.png", UriKind.Relative);
                    newScorecard.Click += new EventHandler(Add_Scorecard);
                    //add the button to the application bar 
                    ApplicationBar.Buttons.Add(newScorecard);
                    break;
                case 1:
                    //create a button for new player 
                    ApplicationBarIconButton newPlayer = new ApplicationBarIconButton();
                    //populate the button information 
                    newPlayer.Text = "Add Player";
                    newPlayer.IconUri = new Uri("/Images/add.png", UriKind.Relative);
                    newPlayer.Click += new EventHandler(Add_Player);
                    //add the button to the application bar 
                    ApplicationBar.Buttons.Add(newPlayer);
                    break;

                case 2:
                    //create a button for new player 
                    ApplicationBarIconButton newCourse = new ApplicationBarIconButton();
                    //populate the button information 
                    newCourse.Text = "Add Player";
                    newCourse.IconUri = new Uri("/Images/add.png", UriKind.Relative);
                    newCourse.Click += new EventHandler(Add_Course);
                    //add the button to the application bar 
                    ApplicationBar.Buttons.Add(newCourse);
                    break;
                case 3:
                    break;

            }
        }

        private void Add_Scorecard(object sender, EventArgs e)
        {
            ScorecardViewModel newScorecard = HomePageViewModel.get_instance().create_scorecard();
            int index = HomePageViewModel.get_instance().scorecards.IndexOf(newScorecard);
            NavigationService.Navigate(new Uri("/Views/NewScorecard.xaml?scorecardIndex=" + index, UriKind.Relative));

        }

        private void Add_Player(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/NewPlayer.xaml", UriKind.Relative));

        }

        private void Add_Course(object sender, EventArgs e)
        {
            CourseViewModel newCourse = HomePageViewModel.get_instance().create_course();
            int index = HomePageViewModel.get_instance().courses.IndexOf(newCourse);
            NavigationService.Navigate(new Uri("/Views/NewCourse.xaml?courseIndex=" + index, UriKind.Relative));

        }

        private void PlayerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayerViewModel selectedPlayer = PlayerLongListSelector.SelectedItem as PlayerViewModel;
            NavigationService.Navigate(new Uri("/Views/PlayerProfile.xaml?playerIndex=" + HomePageViewModel.get_instance().players.IndexOf(selectedPlayer), UriKind.Relative));

            PlayerLongListSelector.SelectedItem = null; 

        }

        private void CourseSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CourseViewModel selectedCourse = CourseLongListSelector.SelectedItem as CourseViewModel;
            NavigationService.Navigate(new Uri("/Views/NewCourse.xaml?courseIndex=" + HomePageViewModel.get_instance().courses.IndexOf(selectedCourse), UriKind.Relative));
            CourseLongListSelector.SelectedItem = null;

        }

        private void ScorecardSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ScorecardViewModel selectedScorecard = ScorecardLongListSelector.SelectedItem as ScorecardViewModel;
            NavigationService.Navigate(new Uri("/Views/Scorecard.xaml?scorecardIndex=" + HomePageViewModel.get_instance().scorecards.IndexOf(selectedScorecard), UriKind.Relative));
            CourseLongListSelector.SelectedItem = null;
        }

        private void send_email(object sender, RoutedEventArgs e)
        {
            var task = new EmailComposeTask { To = "BirdBucketProductions@gmail.com" };
            task.Show();
        }




    }




}