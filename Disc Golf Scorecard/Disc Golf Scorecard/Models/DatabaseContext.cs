using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Disc_Golf_Scorecard.Models
{
    public class DatabaseContext : DataContext
    {
        // Pass the connection string to the base class.
        public DatabaseContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<Player> Players;


        //same as todocategory
        [Table]
        public class Player : INotifyPropertyChanged, INotifyPropertyChanging
        {

            
            // Define ID: private field, public property, and database column.
            private int _playerID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int PlayerID
            {
                get { return _playerID; }
                set
                {
                    if (_playerID != value)
                    {
                        NotifyPropertyChanging("PlayerID");
                        _playerID = value;
                        NotifyPropertyChanged("PlayerID");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private string _firstName;

            [Column]
            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (_firstName != value)
                    {
                        NotifyPropertyChanging("FirstName");
                        _firstName = value;
                        NotifyPropertyChanged("FirstName");
                    }
                }
            }

            private string _lastName;

            [Column]
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (_lastName != value)
                    {
                        NotifyPropertyChanging("LastName");
                        _lastName = value;
                        NotifyPropertyChanged("LastName");
                    }
                }
            }

            private string _phoneNumber;

            [Column]
            public string PhoneNumber
            {
                get { return _phoneNumber; }
                set
                {
                    if (_phoneNumber != value)
                    {
                        NotifyPropertyChanging("PhoneNumber");
                        _phoneNumber = value;
                        NotifyPropertyChanged("PhoneNumber");
                    }
                }
            }

            private string _emailAddress;

            [Column]
            public string EmailAddress
            {
                get { return _emailAddress; }
                set
                {
                    if (_emailAddress != value)
                    {
                        NotifyPropertyChanging("EmailAddress");
                        _emailAddress = value;
                        NotifyPropertyChanged("EmailAddress");
                    }
                }
            }



            // Version column aids update performance.
            [Column(IsVersion = true)]
            private Binary _version;

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            // Used to notify that a property changed
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            #endregion

            #region INotifyPropertyChanging Members

            public event PropertyChangingEventHandler PropertyChanging;

            // Used to notify that a property is about to change
            private void NotifyPropertyChanging(string propertyName)
            {
                if (PropertyChanging != null)
                {
                    PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
                }
            }

            #endregion
        }




    }
}
