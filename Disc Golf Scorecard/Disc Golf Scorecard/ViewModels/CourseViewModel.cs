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

        public CourseViewModel(DatabaseContext.Course course)
        {
            this.course = course;
            this.db = App.DB;
            holes = new ObservableCollection<HoleViewModel>(from DatabaseContext.Hole instance in db.Holes select new HoleViewModel(instance));
        }
       

        public int NumberOfHoles
        {
            get {return course.Holes.Count;}
        }

        public string CourseName
        {
            get { return course.CourseName; }
        }

        public string CourseInfo
        {
            get { return NumberOfHoles + " holes"; }
        }

        public void Create_Hole()
        {
            DatabaseContext.Hole newHole = new DatabaseContext.Hole { HoleNumber = course.Holes.Count+1, _linkedCourseID = course.CourseID };
            db.Holes.InsertOnSubmit(newHole);
            Debug.WriteLine(newHole.HoleNumber + "id: " + newHole.HoleID + "linked: " + newHole._linkedCourseID);
            Debug.WriteLine(course.CourseID);
            db.SubmitChanges();
            course.Holes.Add(newHole);
            holes.Add(new HoleViewModel(newHole));
            NotifyPropertyChanged("NumberOfHoles");
        }

        public void update_in_db(string CourseName)
        {
            course.CourseName = CourseName;
            db.SubmitChanges();
        }


    }
}
