using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.ViewModels;
using Disc_Golf_Scorecard.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Disc_Golf_Scorecard.Models
{
    public class PlayerCourseAnalytic
    {
        PlayerViewModel player;
        CourseViewModel course; 
        public ObservableCollection<PlayerRoundViewModel> playerRounds;
        protected DatabaseContext db;


        //empty constructor 
        public PlayerCourseAnalytic()
        {
            player = null;
            playerRounds = null; 
        }

        //constructor for player 
        public PlayerCourseAnalytic(PlayerViewModel player, CourseViewModel course)
        {
            this.db = App.DB;
            this.player = player;
            this.course = course; 
            refresh(); 
        }

        public void refresh()
        {
            if (player != null && course != null)
            {
                playerRounds = new ObservableCollection<PlayerRoundViewModel>(from DatabaseContext.PlayerRound playerRound
                                                                              in db.PlayerRounds
                                                                              where (playerRound._linkedPlayerID == player.player.PlayerID && playerRound.Scorecard._linkedCourseID == course.course.CourseID)
                                                                              select new PlayerRoundViewModel(playerRound));

                Debug.WriteLine("found " + playerRounds.Count + " playerRounds with this player and course");
            }
        }


        public int timesPlayed
        {
            get
            {
                if (playerRounds != null)
                    return playerRounds.Count;
                else
                    return 0; 
            }
        }
        public int averageScore
        {
            get
            {
                if (playerRounds != null && playerRounds.Count > 0)
                {
                    int sum = 0;
                    foreach (PlayerRoundViewModel round in playerRounds)
                    {
                        sum += round.TotalScore;
                    }
                    sum /= playerRounds.Count;
                    return sum;
                }
                else
                    return 0; 
            }
        }
        public int bestScore
        {
            get
            {
                if (playerRounds != null && playerRounds.Count > 0)
                {
                    int best = int.MaxValue;
                    foreach (PlayerRoundViewModel round in playerRounds)
                    {
                        if (round.TotalScore < best)
                            best = round.TotalScore;
                    }
                    return best;
                }
                else
                    return 0; 
            }
        }
        public int mostRecentScore
        {
            get
            {
                if (playerRounds != null &&  playerRounds.Count > 0)
                    return playerRounds[playerRounds.Count - 1].TotalScore;
                else
                    return 0;
            }
        }


    }
}
