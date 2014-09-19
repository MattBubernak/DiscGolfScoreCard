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

        public CourseViewModel(DatabaseContext.Course course)
        {
            this.course = course;
            this.db = App.DB;
            holes = new ObservableCollection<HoleViewModel>(from DatabaseContext.Hole instance in db.Holes where instance._linkedCourseID == course.CourseID select new HoleViewModel(instance));
            scorecards = new ObservableCollection<ScorecardViewModel>(from DatabaseContext.Scorecard instance in db.Scorecards where instance._linkedCourseID == course.CourseID select new ScorecardViewModel(instance));
            
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

        public string CourseName
        {
            get { return course.CourseName; }
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


    }
}
