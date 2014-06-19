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
    public class ScorecardHoleViewModel : BaseViewModel
    {
        public DatabaseContext.ScorecardHole scorecardHole;
        public ScorecardHoleViewModel(DatabaseContext.ScorecardHole hole)
        {
            this.scorecardHole = hole; 
        }

        public int Par
        {
            get { return scorecardHole.Par; }
        }

        public int HoleNumber
        {
            get { return scorecardHole.HoleNumber; }
        }
    }
}
