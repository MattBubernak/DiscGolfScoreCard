using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;
using Disc_Golf_Scorecard.ViewModels;
using System.Diagnostics;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private static HomePageViewModel _instance;
        public ObservableCollection<PlayerViewModel> players { get; set; }
        public ObservableCollection<CourseViewModel> courses { get; set; }
        public ObservableCollection<ScorecardViewModel> scorecards { get; set; }

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
            populate_courses();
            populate_scorecards(); 

        }

        void populate_players()
        {
            players = new ObservableCollection<PlayerViewModel>(from DatabaseContext.Player instance in db.Players select new PlayerViewModel(instance));
        }

        void populate_courses()
        {
            courses = new ObservableCollection<CourseViewModel>(from DatabaseContext.Course instance in db.Courses select new CourseViewModel(instance));
        }
        void populate_scorecards()
        {
            scorecards = new ObservableCollection<ScorecardViewModel>(from DatabaseContext.Scorecard instance in db.Scorecards select new ScorecardViewModel(instance));
        }

        public void add_player(string fname, string lname, string email, string phone)
        {
            DatabaseContext.Player newPlayer = new DatabaseContext.Player { FirstName = fname, LastName = lname, EmailAddress = email, PhoneNumber = phone };
            db.Players.InsertOnSubmit(newPlayer);
            db.SubmitChanges();
            players.Add(new PlayerViewModel(newPlayer));
            NotifyPropertyChanged("players");
        }

        //creates a new course, puts it in the DB, adds it to the course list, and returns the courseviewmodel
        public CourseViewModel create_course()
        {
            DatabaseContext.Course newCourse = new DatabaseContext.Course {  };
            db.Courses.InsertOnSubmit(newCourse);
            db.SubmitChanges();
            courses.Add(new CourseViewModel(newCourse));
            NotifyPropertyChanged("courses");
            return courses[courses.Count-1];
        }

        public ScorecardViewModel create_scorecard()
        {
            DatabaseContext.Scorecard newScorecard = new DatabaseContext.Scorecard {ScorecardDate = DateTime.Now };
            db.Scorecards.InsertOnSubmit(newScorecard);
            db.SubmitChanges();
            scorecards.Add(new ScorecardViewModel(newScorecard));
            NotifyPropertyChanged("scorecards");
            return scorecards[scorecards.Count - 1];
        }



    }
}
