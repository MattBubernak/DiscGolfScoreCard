﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Disc_Golf_Scorecard.Views
{
    public partial class HomePage : PhoneApplicationPage
    {
        public HomePage()
        {
            InitializeComponent();
            UpdatePanoramaAppBar(0);
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
                    break;

            }
        }

        private void Add_Scorecard(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/NewScorecard.xaml", UriKind.Relative));

        }

        private void Add_Player(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/NewPlayer.xaml", UriKind.Relative));

        }


    }




}