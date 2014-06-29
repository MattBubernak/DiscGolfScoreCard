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
using Disc_Golf_Scorecard.Models;

namespace Disc_Golf_Scorecard.Views
{
    public partial class ScorecardView : PhoneApplicationPage
    {
        public ScorecardViewModel scorecardViewModel = null; 

        public ScorecardView()
        {
            InitializeComponent();
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

        private void Edit_Scorecard(object sender, EventArgs e)
        {
            int selectedIndex = HomePageViewModel.get_instance().scorecards.IndexOf(scorecardViewModel);
            string selectedIndexString = selectedIndex.ToString();
            NavigationService.Navigate(new Uri("/Views/Scorecard.xaml?scorecardIndex=" + selectedIndexString, UriKind.Relative));
        }

        private void Email_Scorecad(object sender, EventArgs e)
        {

        }


    }
}