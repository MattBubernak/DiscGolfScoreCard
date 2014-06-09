using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;
using Disc_Golf_Scorecard.ViewModels;
using System.Collections;
using System.Diagnostics;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class CreateScorecardViewModel : BaseViewModel
    {
        public HomePageViewModel homePageViewModel = null;

        public ObservableCollection<PlayerViewModel> players= null; 

        private static CreateScorecardViewModel _instance = null;

        public static CreateScorecardViewModel get_instance()
        {
            if (_instance == null)
            {
                _instance = new CreateScorecardViewModel();
            }
            return _instance;
        }

        private CreateScorecardViewModel()
        {
            players = new ObservableCollection<PlayerViewModel>(); 
        }


    }
}
