using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class HoleViewModel : BaseViewModel
    {
        public DatabaseContext.Hole hole;

        public HoleViewModel(DatabaseContext.Hole hole)
        {
            this.hole = hole; 
        }
        
        public int Par
        {
            get { return hole.Par; }
        }
        public string ParString
        {
            get { return "Par is " + hole.Par; }
        }
        public int HoleNumber
        {
            get { return hole.HoleNumber; }
        }
        public string ParString
        {
            get { return "Par " + Par; }
        }

        public void addPar()
        {
            hole.Par++;
            NotifyPropertyChanged("Par");
        }

        public void minusPar()
        {
            hole.Par--;
            NotifyPropertyChanged("Par");
        }
        
        public string HoleString
        {
            get { return " Hole # " + hole.HoleNumber;  }
        }
    }
}
