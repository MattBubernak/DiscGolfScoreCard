using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;
using System.Collections;
using System.Diagnostics;
using Disc_Golf_Scorecard.ViewModels;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class PlayerRoundViewModel : BaseViewModel
    {
        public DatabaseContext.PlayerRound playerRound {get;set;}

        public ObservableCollection<ShotViewModel> shots { get; set; }
        
        public PlayerRoundViewModel(DatabaseContext.PlayerRound playerRound)
        {
            this.db = App.DB;

            this.playerRound = playerRound;
            shots = new ObservableCollection<ShotViewModel>(from DatabaseContext.Shot shot in db.Shots select new ShotViewModel(shot));

        }

        public string Name
        {
            get { return playerRound.Player.FirstName; }
        }
    }
}
