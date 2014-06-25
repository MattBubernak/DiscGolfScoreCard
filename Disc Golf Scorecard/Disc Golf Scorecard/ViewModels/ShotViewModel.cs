using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;
using System.Diagnostics;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class ShotViewModel : BaseViewModel
    {
        public DatabaseContext.Shot shot; 

        public ShotViewModel(DatabaseContext.Shot shot)
        {
            this.shot = shot;
            this.db = App.DB; 
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
                return shot.PlayerRound.TotalScore; 
            }
        }

        public void NotifyProperties()
        {
            NotifyPropertyChanged("CumulativeScore");
        }

        public void addScore()
        {
            shot.Score++;
            shot.PlayerRound.TotalScore++; 

            Debug.WriteLine("Increased the score of this shot id: " + shot.ShotID);
            NotifyPropertyChanged("Score");
            NotifyPropertyChanged("CumulativeScore");
            
            db.SubmitChanges(); 
        }
        public void subtractScore()
        {
            shot.Score--;
            shot.PlayerRound.TotalScore--; 

            NotifyPropertyChanged("Score");
            NotifyPropertyChanged("CumulativeScore");
            db.SubmitChanges(); 
        }

    }
}
