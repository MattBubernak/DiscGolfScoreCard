using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;
using System.Collections;
using System.Diagnostics;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class CourseViewModel : BaseViewModel
    {
        public DatabaseContext.Course course;
        public ObservableCollection<HoleViewModel> holes { get; set; }
        public ObservableCollection<ScorecardViewModel> scorecards { get; set; }

        public PlayerCourseAnalytic playerCourseAnalytic; 

        public CourseViewModel(DatabaseContext.Course course)
        {
            this.course = course;
            this.db = App.DB;
            holes = new ObservableCollection<HoleViewModel>(from DatabaseContext.Hole instance in db.Holes where instance._linkedCourseID == course.CourseID select new HoleViewModel(instance));
            scorecards = new ObservableCollection<ScorecardViewModel>(from DatabaseContext.Scorecard instance in db.Scorecards where instance._linkedCourseID == course.CourseID select new ScorecardViewModel(instance));
            playerCourseAnalytic = new PlayerCourseAnalytic(); 
        }
       

        public int NumberOfHoles
        {
            get {return course.Holes.Count;}
        }

        public int Par
        {
            get
            {
                int Par = 0; 
                foreach (HoleViewModel hole in holes)
                {
                    Par += hole.Par; 
                }
                return Par; 
            }
        }

        public int NumberTimesPlayed
        {
            get
            {
                return scorecards.Count; 
            }

        }

        public string CourseRecordString
        {
            get
            {
                //confirm a scorecard exists for this course. 
                if (scorecards.Count < 1)
                    return "None. Get out there!";

                double bestScore = double.MaxValue;
                string bestPlayer = "yolo";
                DateTime date = DateTime.Now; 
                foreach (ScorecardViewModel scorecard in scorecards)
                {
                        Debug.WriteLine("checking scorecard:" + scorecard.Date);
                        if (scorecard.WinningScore < bestScore)
                        {
                            bestScore = scorecard.WinningScore;
                            bestPlayer = scorecard.Winner;
                            date = scorecard.Date; 
                        }
                }
                string diff;
                if (bestScore > Par)
                    diff = "+" + (bestScore - Par).ToString();
                else if (bestScore < Par)
                    diff = (bestScore - Par).ToString();
                else
                    diff = "par"; 
                return bestPlayer + " shot a " + bestScore + "(" + diff + ")" + " on " + date.ToShortDateString(); 
            }
        }

        public string CourseName
        {
            get { return course.CourseName; }
        }

        public int selectedPlayerAverage
        {
            get { return playerCourseAnalytic.averageScore; }
        }
        public int selectedPlayerTimesPlayed
        {
            get { return playerCourseAnalytic.timesPlayed; }
        }
        public int selectedPlayerBest
        {
            get { return playerCourseAnalytic.bestScore; }
        }

        public void NotifyProperties()
        {
            playerCourseAnalytic.refresh(); 
            scorecards = new ObservableCollection<ScorecardViewModel>(from DatabaseContext.Scorecard instance in db.Scorecards where instance._linkedCourseID == course.CourseID select new ScorecardViewModel(instance));

            NotifyPropertyChanged("NumberOfHoles");
            NotifyPropertyChanged("Par");
            NotifyPropertyChanged("NumberTimesPlayed");
            NotifyPropertyChanged("CourseRecordString");
            NotifyPropertyChanged("selectedPlayerTimesPlayed");
            NotifyPropertyChanged("selectedPlayerAverage");
            NotifyPropertyChanged("selectedPlayerBest");

        }

        public string CourseInfo
        {
            get { return NumberOfHoles + " holes" + ", Par " + Par; }
        }

        public void Create_Hole()
        {
            DatabaseContext.Hole newHole = new DatabaseContext.Hole { HoleNumber = course.Holes.Count+1, _linkedCourseID = course.CourseID , Par = 1};
            db.Holes.InsertOnSubmit(newHole);
            Debug.WriteLine(newHole.HoleNumber + "id: " + newHole.HoleID + "linked: " + newHole._linkedCourseID);
            Debug.WriteLine(course.CourseID);
            db.SubmitChanges();
            course.Holes.Add(newHole);
            holes.Add(new HoleViewModel(newHole));
            NotifyPropertyChanged("NumberOfHoles");
        }

        public void remove_hole()
        {
            if (course.Holes.Count > 0)
            {
                db.Holes.DeleteOnSubmit(course.Holes[course.Holes.Count - 1]);
                holes.Remove(holes[holes.Count-1]);
                db.SubmitChanges();
                NotifyPropertyChanged("holes"); 
                NotifyPropertyChanged("NumberOfHoles");

            }
        }

        public void update_in_db(string CourseName)
        {
            course.CourseName = CourseName;
            db.SubmitChanges();
        }

        public void update_analytic(PlayerViewModel player)
        {
            playerCourseAnalytic = new PlayerCourseAnalytic(player,this);
        }


    }
}
