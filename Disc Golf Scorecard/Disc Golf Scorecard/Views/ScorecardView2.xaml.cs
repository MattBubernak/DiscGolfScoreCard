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
    public partial class ScorecardView2 : PhoneApplicationPage
    {
        public ScorecardViewModel scorecardViewModel = null; 

        public ScorecardView2()
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


    }
}