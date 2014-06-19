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

        public ScorecardViewModel(DatabaseContext.Scorecard scorecard)
        {
            this.scorecard = scorecard;
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
                scorecardHoles.Add(new ScorecardHoleViewModel(newScorecardHole)); 
            }
        }

        public string ScorecardName
        {
            get { return "nud"; }
        }



    }
}
