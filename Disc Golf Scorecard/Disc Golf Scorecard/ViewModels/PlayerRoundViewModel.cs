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
            shots = new ObservableCollection<ShotViewModel>(from DatabaseContext.Shot shot in db.Shots where shot._linkedPlayerRoundID == playerRound.PlayerRoundID select new ShotViewModel(shot));

        }

        public string NickName
        {
            get { return playerRound.Player.NickName; }
        }

        public string NickNameConc
        {
            get {
                    return playerRound.Player.NickName.PadRight(6).Substring(0, 6); 
                 }

        }

        public int TotalScore
        {
            get { return playerRound.TotalScore; }
        }

        public int Total
        {
            get 
            {
                int total = 0; 
                foreach (ShotViewModel shot in shots)
                {
                    total += shot.Score;
                }
                return total; 

            }
        }
    }
}
