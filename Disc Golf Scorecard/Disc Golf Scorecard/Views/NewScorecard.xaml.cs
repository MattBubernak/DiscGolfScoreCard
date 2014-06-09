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
        public NewScorecard()
        {
            InitializeComponent();
            CourseSelection.ItemsSource = HomePageViewModel.get_instance().courses; 

        }

        private void Save_Scorecard(object sender, EventArgs e)
        {

        }

        private void add_new_player(object sender, RoutedEventArgs e)
        {

        }
    }
}