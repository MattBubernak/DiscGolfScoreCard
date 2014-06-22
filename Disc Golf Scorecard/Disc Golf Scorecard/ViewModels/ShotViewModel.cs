using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class ShotViewModel : BaseViewModel
    {
        public DatabaseContext.Shot shot; 

        public ShotViewModel(DatabaseContext.Shot shot)
        {
            this.shot = shot; 
        }

        public string Name
        {
            get { return shot.PlayerRound.Player.FirstName + " " + shot.PlayerRound.Player.LastName ; }
        }
        public int Score
        {
            get { return shot.Score; }
        }
        public int CumulativeScore
        {
            get
            {
                int score = 0;
                foreach (DatabaseContext.Shot shott in shot.PlayerRound.Shots)
                {
                    score += shott.Score; 
                }
                return score; 
            }
        }

    }
}
