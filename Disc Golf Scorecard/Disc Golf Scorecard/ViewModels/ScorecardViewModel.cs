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
    public class ScorecardViewModel : BaseViewModel
    {
        public DatabaseContext.Scorecard scorecard { get; set; }
        public ObservableCollection<ScorecardHoleViewModel> scorecardHoles { get; set; }
        public ObservableCollection<PlayerRoundViewModel> playerRoundViewModels { get; set; }
        
        public ScorecardViewModel(DatabaseContext.Scorecard scorecard)
        {
            this.db = App.DB;
            this.scorecard = scorecard;

            scorecardHoles = new ObservableCollection<ScorecardHoleViewModel>(from DatabaseContext.ScorecardHole scorecardHole in db.ScorecardHoles where scorecardHole._linkedScorecardID == scorecard.ScorecardID select new ScorecardHoleViewModel(scorecardHole));
            playerRoundViewModels = new ObservableCollection<PlayerRoundViewModel>(from DatabaseContext.PlayerRound playerRound in db.PlayerRounds where playerRound._linkedScorecardID == scorecard.ScorecardID select new PlayerRoundViewModel(playerRound));
        }

       
        public void Update_Description(string Description)
        {
            this.scorecard.ScorecardDescription = Description;
        }
        public void Update_Course(CourseViewModel course)
        {
            scorecard.Course = course.course; 
            foreach (DatabaseContext.Hole hole in course.course.Holes)
            {
                DatabaseContext.ScorecardHole newScorecardHole = new DatabaseContext.ScorecardHole(hole); 
                scorecard.ScorecardHoles.Add(newScorecardHole);
                newScorecardHole._linkedScorecardID = scorecard.ScorecardID;
                newScorecardHole.ParentScorecard = scorecard;

                db.ScorecardHoles.InsertOnSubmit(newScorecardHole); 
                db.SubmitChanges(); 
                scorecardHoles.Add(new ScorecardHoleViewModel(newScorecardHole)); 
            }
        }

        public void Update_Player(PlayerViewModel playerViewModel)
        {
            DatabaseContext.PlayerRound newPlayerRound = new DatabaseContext.PlayerRound(playerViewModel.player);
            scorecard.PlayerRounds.Add(newPlayerRound);
            newPlayerRound._linkedPlayerID = playerViewModel.player.PlayerID;
            newPlayerRound._linkedScorecardID = scorecard.ScorecardID; 
            db.PlayerRounds.InsertOnSubmit(newPlayerRound); 
            db.SubmitChanges();
            playerRoundViewModels.Add(new PlayerRoundViewModel(newPlayerRound)); 
        }

        public void Create_Shots()
        {
            foreach (ScorecardHoleViewModel hole in scorecardHoles)
            {
                foreach (PlayerRoundViewModel playerRound in playerRoundViewModels)
                {
                    DatabaseContext.Shot newShot = new DatabaseContext.Shot();
                    newShot._linkedPlayerRoundID = playerRound.playerRound.PlayerRoundID;
                    newShot._linkedScorecardHoleID = scorecard.ScorecardID;
                    newShot.HoleNumber = hole.HoleNumber;
                    newShot.Par = hole.Par;
                    newShot.parentScorecardHole = hole.scorecardHole;
                    newShot.PlayerRound = playerRound.playerRound;

                    db.Shots.InsertOnSubmit(newShot);
                    playerRound.playerRound.Shots.Add(newShot); 
                    db.SubmitChanges();
                    ShotViewModel newShotViewModel = new ShotViewModel(newShot);
                    playerRound.shots.Add(newShotViewModel);
                    hole.shots.Add(newShotViewModel);
                }
            }
        }

        public string ScorecardInfo
        {
            get { return " played on " + scorecard.ScorecardDate.ToString(); }
        }
        public int Par
        {
            get
            {
                int par = 0; 
                foreach (DatabaseContext.ScorecardHole hole in scorecard.ScorecardHoles)
                {
                    par += hole.Par; 
                }
                return par;
            }
        }

        public string Winner
        {
            get
            {
                double bestScore = 9999;
                string bestPlayer = ""; 

                foreach (PlayerRoundViewModel round in playerRoundViewModels)
                {
                    if (round.TotalScore < bestScore)
                    {
                        bestScore = round.TotalScore;
                        bestPlayer = round.FullName; 
                    }
                }
                return bestPlayer; 
            }
        }

        public DateTime Date
        {
            get
            {
                return scorecard.ScorecardDate;
            }
        }

        public int WinningScore
        {
            get
            {
                int bestScore = 9999;
                string bestPlayer = "";

                foreach (PlayerRoundViewModel round in playerRoundViewModels)
                {
                    if (round.TotalScore < bestScore)
                    {
                        bestScore = round.TotalScore;
                        bestPlayer = round.FullName;
                    }
                }
                return bestScore; 
            }
        }

        public string TotalString
        {
            get
            {
                string ShotString = "";
               

                ShotString += "SUM".PadRight(8) + Par.ToString() + " ".PadRight(9);
                foreach (PlayerRoundViewModel player in playerRoundViewModels)
                {
                    ShotString += player.Total.ToString().PadRight(12);
                }
                return ShotString;
            }
        }

        public string Name
        {
            get { return scorecard.Course.CourseName; }
        }

        public void NotifyPropertyChangedAllHoles()
        {
            foreach (PlayerRoundViewModel playerRound in playerRoundViewModels)
            {
                foreach (ShotViewModel shot in playerRound.shots )
                {
                    shot.NotifyProperties(); 
                }
            }
        }


    }
}
