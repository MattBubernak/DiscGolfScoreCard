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
    public class ScorecardHoleViewModel : BaseViewModel
    {
        public DatabaseContext.ScorecardHole scorecardHole;
        public ObservableCollection<ShotViewModel> shots { get; set;  }

        public ScorecardHoleViewModel(DatabaseContext.ScorecardHole hole)
        {
            this.db = App.DB;

            this.scorecardHole = hole;
            shots = new ObservableCollection<ShotViewModel>(from DatabaseContext.Shot shot in db.Shots where shot._linkedScorecardHoleID == scorecardHole.ScorecardHoleID select new ShotViewModel(shot));
        }

        public int Par
        {
            get { return scorecardHole.Par; }
        }

        public int HoleNumber
        {
            get { return scorecardHole.HoleNumber; }
        }
        public string HoleString
        {
            get { return "Hole # " + scorecardHole.HoleNumber; }
        }
        public string ParString
        {
            get { return "Par is " + Par;  }
        }
        public string ShotString
        {
            get
            {
                string ShotString = scorecardHole.HoleNumber.ToString().PadRight(2);
                ShotString += scorecardHole.Par.ToString().PadLeft(10) + " ".PadRight(11); 
                foreach (ShotViewModel shot in shots)
                {
                    ShotString += shot.Score.ToString().PadRight(12); 
                }
                return ShotString;
            }
        }
       
    }
}
