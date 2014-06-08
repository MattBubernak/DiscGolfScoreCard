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
    public partial class NewCourse : PhoneApplicationPage
    {
        public NewCourse()
        {
            InitializeComponent();
            DataContext = CreateScorecardViewModel.get_instance(); 
        }

        private void Add_Hole(object sender, EventArgs e)
        {

        }
    }
}