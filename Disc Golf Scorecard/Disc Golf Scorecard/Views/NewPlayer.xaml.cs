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
    public partial class NewPlayer : PhoneApplicationPage
    {
        const string INVALID_NICKNAME_MESSAGE = "Please enter a valid nickname that is between 1 and 6 characters";
        const string INVALID_LASTNAME_MESSAGE = "Please enter a first name";
        const string INVALID_FIRSTNAME_MESSAGE ="Please enter a last name";

        const string INVALID_NUMBER_MESSAGE = "Invalid Number(leave blank if unknown).";
        const string ERROR_MESSAGE_TITLE = "Error";

        public NewPlayer()
        {
            
            InitializeComponent();
           // DataContext = HomePageViewModel.get_instance();
        }

        private void Save_Player(object sender, EventArgs e)
        {
           

            //confirm that player number is an integer, otherwise throw error
            //int playerNumber;
            //if (Int32.TryParse(NumberBox.Text.ToString(), out playerNumber) == false && NumberBox.Text.ToString() != "")
            //{
            //    Show_Error_Message(INVALID_NUMBER_MESSAGE);
            //}
            if (NickNameBox.Text.ToString().Length > 6 || NickNameBox.Text.ToString().Length < 1)
            {
                Show_Error_Message(INVALID_NICKNAME_MESSAGE);
            }
            else if (FirstNameBox.Text.ToString().Length < 1)
            {
                Show_Error_Message(INVALID_FIRSTNAME_MESSAGE);
            }
            else if (LastNameBox.Text.ToString().Length < 1)
            {
                Show_Error_Message(INVALID_LASTNAME_MESSAGE);
            }
            else
            {
                HomePageViewModel.get_instance().add_player(NickNameBox.Text.ToString(), FirstNameBox.Text.ToString(), LastNameBox.Text.ToString(), EmailBox.Text.ToString(), PhoneNumberBox.Text.ToString());
                NavigationService.Navigate(new Uri("/Views/HomePage.xaml", UriKind.Relative));
            }

        }

        private void Show_Error_Message(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, ERROR_MESSAGE_TITLE, MessageBoxButton.OK);
        }



    }
}