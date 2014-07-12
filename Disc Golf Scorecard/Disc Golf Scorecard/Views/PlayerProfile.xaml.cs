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
using Microsoft.Phone.Tasks;


namespace Disc_Golf_Scorecard.Views
{
    public partial class PlayerProfile : PhoneApplicationPage
    {

        public PlayerViewModel player = null;
        int recIndex = -1; 

        public PlayerProfile()
        {
            InitializeComponent();
            DataContext = null;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("playerIndex", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    recIndex = index; 
                    player = HomePageViewModel.get_instance().players[index];
                    DataContext = player; 
                }
            }
        }

        private void email_player(object sender, EventArgs e)
        {
            var task = new EmailComposeTask { To = player.player.PhoneNumber };
            task.Show();
        }

        private void call_player(object sender, EventArgs e)
        {
            var task = new PhoneCallTask { PhoneNumber = player.player.PhoneNumber };
            task.Show(); 
        }

        private void edit_player(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/NewPlayer.xaml?playerIndex=" + recIndex, UriKind.Relative));
        }
    }
}