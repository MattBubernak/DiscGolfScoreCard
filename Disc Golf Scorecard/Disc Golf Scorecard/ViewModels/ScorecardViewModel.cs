﻿using System;
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
            scorecardHoles = new ObservableCollection<ScorecardHoleViewModel>();
            playerRoundViewModels = new ObservableCollection<PlayerRoundViewModel>();
            scorecardHoles = new ObservableCollection<ScorecardHoleViewModel>(); 
        }
        public void Update_Description(string Description)
        {
            this.scorecard.ScorecardDescription = Description;
        }
        public void Update_Course(CourseViewModel course)
        {
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
                    db.SubmitChanges();
                    ShotViewModel newShotViewModel = new ShotViewModel(newShot);
                    playerRound.shots.Add(newShotViewModel);
                    hole.shots.Add(newShotViewModel);
                }
            }
        }

        public string ScorecardInfo
        {
            get { return scorecard.PlayerRounds.Count + " players, played on " + scorecard.ScorecardDate.ToString(); }
        }
        public string Name
        {
            get { return "scorecard name"; }
        }


    }
}
