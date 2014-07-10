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
        }

        public string FullName
        {
            get { return player.FirstName + " " + player.LastName; }
        }

        public string PlayerInfo
        {
            get { return player.PlayerRounds.Count + " rounds played" ; }
        }



        

    }
}
