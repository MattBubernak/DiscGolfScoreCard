using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models

namespace Disc_Golf_Scorecard.ViewModels
{
    class CourseViewModel : BaseViewModel
    {
        public DatabaseContext.Course course; 

        public CourseViewModel(DatabaseContext.Course course)
        {
            this.course = course;
        }

        public int NumberOfHoles
        {
            //todo: return course.holes.count;
            get {return course.Holes.Count;}
        }


    }
}
