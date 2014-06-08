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
        public Table<Scorecard> Scorecards;

        #region player
        //player
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
#endregion 

        #region Scorecard
        [Table]
        public class Scorecard : INotifyPropertyChanged, INotifyPropertyChanging
        {


            // Define ID: private field, public property, and database column.
            private int _scorecardID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int ScorecardID
            {
                get { return _scorecardID; }
                set
                {
                    if (_scorecardID != value)
                    {
                        NotifyPropertyChanging("ScorecardID");
                        _scorecardID = value;
                        NotifyPropertyChanged("ScorecardID");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private DateTime _scorecardDate;

            [Column]
            public DateTime ScorecardDate
            {
                get { return _scorecardDate; }
                set
                {
                    if (_scorecardDate != value)
                    {
                        NotifyPropertyChanging("ScorecardDate");
                        _scorecardDate = value;
                        NotifyPropertyChanged("ScorecardDate");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private DateTime _scorecardDescription;

            [Column]
            public DateTime ScorecardDescription
            {
                get { return _scorecardDescription; }
                set
                {
                    if (_scorecardDescription != value)
                    {
                        NotifyPropertyChanging("ScorecardDescription");
                        _scorecardDescription = value;
                        NotifyPropertyChanged("ScorecardDescription");
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
        #endregion


        #region Course
        [Table]
        public class Course : INotifyPropertyChanged, INotifyPropertyChanging
        {


            // Define ID: private field, public property, and database column.
            private int _courseID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int CourseID
            {
                get { return _courseID; }
                set
                {
                    if (_courseID != value)
                    {
                        NotifyPropertyChanging("CourseID");
                        _courseID = value;
                        NotifyPropertyChanged("CourseID");
                    }
                }
            }


            // Define the entity set for the collection side of the relationship.
            private EntitySet<Hole> _holes;

            [Association(Storage = "_holes", OtherKey = "_linkedCourseID", ThisKey = "CourseID")]
            public EntitySet<Hole> Holes
            {
                get { return this._holes; }
                set { this._holes.Assign(value); }
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
        #endregion

        #region Hole
        [Table]
        public class Hole : INotifyPropertyChanged, INotifyPropertyChanging
        {


            // Define ID: private field, public property, and database column.
            private int _holeID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int HoleID
            {
                get { return _holeID; }
                set
                {
                    if (_holeID != value)
                    {
                        NotifyPropertyChanging("HoleID");
                        _holeID = value;
                        NotifyPropertyChanged("HoleID");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private int _par;

            [Column]
            public int Par
            {
                get { return _par; }
                set
                {
                    if (_par != value)
                    {
                        NotifyPropertyChanging("Par");
                        _par = value;
                        NotifyPropertyChanged("Par");
                    }
                }
            }


            [Column]
            internal int _linkedCourseID;

            // Entity reference
            private EntityRef<Course> _parentCourse;

            // Association, to describe the relationship between this key and that "storage" table
            [Association(Storage = "_parentCourse", ThisKey = "_linkedCourseID", OtherKey = "CourseID", IsForeignKey = true)]
            public Course Course
            {
                get { return _parentCourse.Entity; }
                set
                {
                    NotifyPropertyChanging("parentCourse");
                    _parentCourse.Entity = value;

                    if (value != null)
                    {
                        _linkedCourseID = value.CourseID;
                    }

                    NotifyPropertyChanging("parentCourse");
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
        #endregion





    }
}
