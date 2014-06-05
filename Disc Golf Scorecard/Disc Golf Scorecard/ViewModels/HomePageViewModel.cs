using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;
using Disc_Golf_Scorecard.ViewModels;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private static HomePageViewModel _instance;
        public ObservableCollection<PlayerViewModel> players { get; set; }

        public static HomePageViewModel get_instance()
        {
            if (_instance == null)
            {
                _instance = new HomePageViewModel();
            }
            return _instance;
        }

        private HomePageViewModel()
        {
            db = App.DB;
            populate_players();
        }

        void populate_players()
        {
            players = new ObservableCollection<PlayerViewModel>(from DatabaseContext.Player instance in db.Players select new PlayerViewModel(instance));
        }

    }
}
