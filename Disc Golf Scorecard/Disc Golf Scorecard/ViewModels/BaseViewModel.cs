using System;
using System.ComponentModel;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        protected DatabaseContext db;

        //needed for observer pattern/notify property changed 
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
