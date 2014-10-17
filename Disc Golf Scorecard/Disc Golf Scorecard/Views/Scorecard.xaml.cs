using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Disc_Golf_Scorecard.Models;
using Disc_Golf_Scorecard.ViewModels;

namespace Disc_Golf_Scorecard.Views
{
    public partial class Scorecard : PhoneApplicationPage
    {
        ScorecardViewModel scorecardViewModel = null; 

        public Scorecard()
        {
            InitializeComponent();
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
            HomePageViewModel.get_instance().NotifyPropertyChanged("players");
            NavigationService.Navigate(new Uri("/Views/HomePage.xaml", UriKind.Relative));
        }

        private void Scorecard_View(object sender, EventArgs e)
        {
            int selectedIndex = HomePageViewModel.get_instance().scorecards.IndexOf(scorecardViewModel);
            string selectedIndexString = selectedIndex.ToString(); 
                 NavigationService.Navigate(new Uri("/Views/ScorecardView.xaml?scorecardIndex=" + selectedIndexString, UriKind.Relative));
         
        }

        private void Delete_Scorecard(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this scorecard?", "Delete", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                HomePageViewModel.get_instance().delete_scorecard(this.scorecardViewModel);
                NavigationService.Navigate(new Uri("/Views/HomePage.xaml", UriKind.Relative));

            }
            

        }


        private void add(object sender, RoutedEventArgs e)
        {

            ShotViewModel clicked = ((sender as Button).DataContext as ShotViewModel);
            clicked.addScore();
            scorecardViewModel.NotifyPropertyChangedAllHoles(); 
        }

        private void subtract(object sender, RoutedEventArgs e)
        {
            ShotViewModel clicked = ((sender as Button).DataContext as ShotViewModel);
            clicked.subtractScore();
            scorecardViewModel.NotifyPropertyChangedAllHoles(); 
        }
    }
}