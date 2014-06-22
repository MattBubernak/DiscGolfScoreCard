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
            this.scorecard = scorecard;
            scorecardHoles = new ObservableCollection<ScorecardHoleViewModel>();
            playerRoundViewModels = new ObservableCollection<PlayerRoundViewModel>(); 
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
                scorecardHoles.Add(new ScorecardHoleViewModel(newScorecardHole)); 
            }
        }

        public void Update_Player(PlayerViewModel playerViewModel)
        {
            DatabaseContext.PlayerRound newPlayerRound = new DatabaseContext.PlayerRound(playerViewModel.player);
            scorecard.PlayerRounds.Add(newPlayerRound);
            playerRoundViewModels.Add(new PlayerRoundViewModel(newPlayerRound)); 
        }

        public string ScorecardName
        {
            get { return "nud"; }
        }



    }
}
