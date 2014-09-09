using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;
using Disc_Golf_Scorecard.ViewModels;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        public DatabaseContext.Player player {get;set;}

        public PlayerViewModel(DatabaseContext.Player player)
        {
            this.player = player; 
            db = App.DB; 
        }

        public string FullName
        {
            get { return player.FirstName + " " + player.LastName; }
        }
        public string FirstName
        {
            get { return player.FirstName; }
        }
        public string LastName
        {
            get { return player.LastName; }
        }
        public string Email
        {
            get { return player.EmailAddress; }
        }
        public string Phone
        {
            get { return player.PhoneNumber; }
        }
        public string NickName
        {
            get 
            { 
                return player.NickName.PadRight(6); 
            }
        }

        public string PlayerInfo
        {
            get { return player.PlayerRounds.Count + " rounds played" ; }
        }

        public int Rounds
        {
            get { return player.PlayerRounds.Count; }
        }

        public void Update(string NickName, string FirstName, string LastName, string Email, string Phone)
        {
            player.NickName = NickName; 
            player.FirstName = FirstName; 
            player.LastName = LastName; 
            player.EmailAddress = Email; 
            player.PhoneNumber = Phone; 
            db.SubmitChanges(); 
        }



        

    }
}
