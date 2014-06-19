using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc_Golf_Scorecard.Models;

namespace Disc_Golf_Scorecard.ViewModels
{
    public class ShotViewModel : BaseViewModel
    {
        public DatabaseContext.Shot shot; 

        public ShotViewModel(DatabaseContext.Shot shot)
        {
            this.shot = shot; 
        }

    }
}
