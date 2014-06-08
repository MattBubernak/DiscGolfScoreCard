using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.ViewModels;
using Disc_Golf_Scorecard.Models;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class CreateScorecardViewModel : BaseViewModel
    {
        public HomePageViewModel homePageViewModel = null;

        private static CreateScorecardViewModel _instance = null;

        public static CreateScorecardViewModel get_instance()
        {
            if (_instance == null)
            {
                _instance = new CreateScorecardViewModel();
            }
            return _instance;
        }


    }
}
