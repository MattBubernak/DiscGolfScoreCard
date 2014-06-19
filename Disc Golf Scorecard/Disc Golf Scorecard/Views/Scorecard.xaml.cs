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
                }
            }
        }
    }
}