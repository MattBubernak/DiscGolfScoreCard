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
        public Table<Course> Courses;
        public Table<Hole> Holes;
        public Table<Shot> Shots;
        public Table<ScorecardHole> ScorecardHoles;
        public Table<PlayerRound> PlayerRounds; 


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


              // Define the entity set for the collection side of the relationship.
            private EntitySet<PlayerRound> _playerRounds;

            [Association(Storage = "_playerRounds", OtherKey = "_linkedPlayerID", ThisKey = "PlayerID")]
            public EntitySet<PlayerRound> PlayerRounds
            {
                get { return this._playerRounds; }
                set { this._playerRounds.Assign(value); }
            }

            


            // Assign handlers for the add and remove operations, respectively.
        public Player()
        {
            _playerRounds = new EntitySet<PlayerRound>(
                new Action<PlayerRound>(this.attach_Instance),
                new Action<PlayerRound>(this.detach_Instance)
                );
        }

        // Called during an add operation
        private void attach_Instance(PlayerRound playerRound)
        {
            NotifyPropertyChanging("ExerciseInstance");
            playerRound.Player = this;
        }

        // Called during a remove operation
        private void detach_Instance(PlayerRound playerRound)
        {
            NotifyPropertyChanging("ExerciseInstance");
            playerRound.Player = null;
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

        #region playerround
        //player
        [Table]
        public class PlayerRound : INotifyPropertyChanged, INotifyPropertyChanging
        {
            public PlayerRound()
            {

            }

            // Define ID: private field, public property, and database column.
            private int _playerRoundID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int PlayerRoundID
            {
                get { return _playerRoundID; }
                set
                {
                    if (_playerRoundID != value)
                    {
                        NotifyPropertyChanging("PlayerRoundID");
                        _playerRoundID = value;
                        NotifyPropertyChanged("PlayerRoundID");
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


            [Column]
            internal int _linkedPlayerID;

            // Entity reference
            private EntityRef<Player> _player;

            // Association, to describe the relationship between this key and that "storage" table
            [Association(Storage = "_player", ThisKey = "_linkedPlayerID", OtherKey = "PlayerID", IsForeignKey = true)]
            public Player Player
            {
                get { return _player.Entity; }
                set
                {
                    NotifyPropertyChanging("Player");
                    _player.Entity = value;

                    if (value != null)
                    {
                        _linkedPlayerID = value.PlayerID;
                    }

                    NotifyPropertyChanging("Player");
                }
            }

            [Column]
            internal int _linkedScorecardID;

            // Entity reference
            private EntityRef<Scorecard> _scorecard;

            // Association, to describe the relationship between this key and that "storage" table
            [Association(Storage = "_scorecard", ThisKey = "_linkedScorecardID", OtherKey = "ScorecardID", IsForeignKey = true)]
            public Scorecard Scorecard
            {
                get { return _scorecard.Entity; }
                set
                {
                    NotifyPropertyChanging("Scorecard");
                    _scorecard.Entity = value;

                    if (value != null)
                    {
                        _linkedScorecardID = value.ScorecardID;
                    }

                    NotifyPropertyChanging("Scorecard");
                }
            }


            
            // Define the entity set for the collection side of the relationship.
            private EntitySet<Shot> _shots;

            [Association(Storage = "_shots", OtherKey = "_linkedPlayerRoundID", ThisKey = "PlayerRoundID")]
            public EntitySet<Shot> Shots
            {
                get { return this._shots; }
                set { this._shots.Assign(value); }
            }

            


            // Assign handlers for the add and remove operations, respectively.
        public PlayerRound(Player player)
        {
            _shots = new EntitySet<Shot>(
                new Action<Shot>(this.attach_Instance),
                new Action<Shot>(this.detach_Instance)
                );
            this.Player = player;
            this._linkedPlayerID = player.PlayerID; 
           
        }

        // Called during an add operation
        private void attach_Instance(Shot shot)
        {
            NotifyPropertyChanging("PlayerRound");
            shot.PlayerRound = this;
        }

        // Called during a remove operation
        private void detach_Instance(Shot shot)
        {
            NotifyPropertyChanging("PlayerRound");
            shot.PlayerRound = null;
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
             
            // Define the entity set for the collection side of the relationship.
            private EntitySet<ScorecardHole> _scorecardHoles;

            [Association(Storage = "_scorecardHoles", OtherKey = "_linkedScorecardID", ThisKey = "ScorecardID")]
            public EntitySet<ScorecardHole> ScorecardHoles
            {
                get { return this._scorecardHoles; }
                set { this._scorecardHoles.Assign(value); }
            }

            private EntitySet<PlayerRound> _playerRounds;

            [Association(Storage = "_playerRounds", OtherKey = "_linkedScorecardID", ThisKey = "ScorecardID")]
            public EntitySet<PlayerRound> PlayerRounds
            {
                get { return this._playerRounds; }
                set { this._playerRounds.Assign(value); }
            }


            


            // Assign handlers for the add and remove operations, respectively.
        public Scorecard()
        {
            _scorecardHoles = new EntitySet<ScorecardHole>(
                new Action<ScorecardHole>(this.attach_Instance),
                new Action<ScorecardHole>(this.detach_Instance)
                );
            _playerRounds = new EntitySet<PlayerRound>(
                new Action<PlayerRound>(this.attach_Instance),
                new Action<PlayerRound>(this.detach_Instance)
                );
        }

        // Called during an add operation
        private void attach_Instance(ScorecardHole hole)
        {
            NotifyPropertyChanging("ExerciseInstance");
            hole.ParentScorecard = this;
        }

        // Called during a remove operation
        private void detach_Instance(ScorecardHole hole)
        {
            NotifyPropertyChanging("ExerciseInstance");
            hole.ParentScorecard = null;
        }

        // Called during an add operation
        private void attach_Instance(PlayerRound playerRound)
        {
            NotifyPropertyChanging("ExerciseInstance");
            //playerRound.p = this;
        }

        // Called during a remove operation
        private void detach_Instance(PlayerRound playerRound)
        {
            NotifyPropertyChanging("ExerciseInstance");
            //playerRound.ParentScorecard = null;
        }


           

            // Define item name: private field, public property, and database column.
            private String _scorecardDescription;

            [Column]
            public String ScorecardDescription
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

            // Define the entity set for the collection side of the relationship.
            private EntitySet<Scorecard> _scorecards;

            [Association(Storage = "_scorecards", OtherKey = "_linkedCourseID", ThisKey = "CourseID")]
            public EntitySet<Scorecard> Scorecards
            {
                get { return this._scorecards; }
                set { this._scorecards.Assign(value); }
            }

            


            // Assign handlers for the add and remove operations, respectively.
        public Course()
        {
            _holes = new EntitySet<Hole>(
                new Action<Hole>(this.attach_Instance),
                new Action<Hole>(this.detach_Instance)
                );
            _scorecards = new EntitySet<Scorecard>(
                new Action<Scorecard>(this.attach_Instance),
                new Action<Scorecard>(this.detach_Instance)
                );
        }

        // Called during an add operation
        private void attach_Instance(Hole hole)
        {
            NotifyPropertyChanging("ExerciseInstance");
            hole.Course = this;
        }

        // Called during a remove operation
        private void detach_Instance(Hole hole)
        {
            NotifyPropertyChanging("ExerciseInstance");
            hole.Course = null;
        }

        // Called during an add operation
        private void attach_Instance(Scorecard scorecard)
        {
            NotifyPropertyChanging("ExerciseInstance");
            scorecard.Course = this;
        }

        // Called during a remove operation
        private void detach_Instance(Scorecard scorecard)
        {
            NotifyPropertyChanging("ExerciseInstance");
            scorecard.Course = null;
        }



            private string _courseName;

            [Column]
            public string CourseName
            {
                get { return _courseName; }
                set
                {
                    if (_courseName != value)
                    {
                        NotifyPropertyChanging("CourseName");
                        _courseName = value;
                        NotifyPropertyChanged("CourseName");
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

        #region Hole
        [Table]
        public class Hole : INotifyPropertyChanged, INotifyPropertyChanging
        {

            public Hole() { }
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

            // Define item name: private field, public property, and database column.
            private int _holeNumber;

            [Column]
            public int HoleNumber
            {
                get { return _holeNumber; }
                set
                {
                    if (_holeNumber != value)
                    {
                        NotifyPropertyChanging("HoleNumber");
                        _holeNumber = value;
                        NotifyPropertyChanged("HoleNumber");
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

        #region ScorecardHole
        [Table]
        public class ScorecardHole : INotifyPropertyChanged, INotifyPropertyChanging
        {

            public ScorecardHole(Hole hole)
            {
                this._holeNumber = hole.HoleNumber;
                this._par = hole.Par;
                _shots = new EntitySet<Shot>(
                new Action<Shot>(this.attach_Instance),
                new Action<Shot>(this.detach_Instance)
                );
               
            }
            // Define ID: private field, public property, and database column.
            private int _scorecardHoleID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int ScorecardHoleID
            {
                get { return _scorecardHoleID; }
                set
                {
                    if (_scorecardHoleID != value)
                    {
                        NotifyPropertyChanging("ScorecardHoleID");
                        _scorecardHoleID = value;
                        NotifyPropertyChanged("ScorecardHoleID");
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

            // Define item name: private field, public property, and database column.
            private int _holeNumber;

            [Column]
            public int HoleNumber
            {
                get { return _holeNumber; }
                set
                {
                    if (_holeNumber != value)
                    {
                        NotifyPropertyChanging("HoleNumber");
                        _holeNumber = value;
                        NotifyPropertyChanged("HoleNumber");
                    }
                }
            }


            [Column]
            internal int _linkedScorecardID;

            // Entity reference
            private EntityRef<Scorecard> _parentScorecard;

            // Association, to describe the relationship between this key and that "storage" table
            [Association(Storage = "_parentScorecard", ThisKey = "_linkedScorecardID", OtherKey = "ScorecardID", IsForeignKey = true)]
            public Scorecard ParentScorecard
            {
                get { return _parentScorecard.Entity; }
                set
                {
                    NotifyPropertyChanging("ParentScorecard");
                    _parentScorecard.Entity = value;

                    if (value != null)
                    {
                        _linkedScorecardID = value.ScorecardID;
                    }

                    NotifyPropertyChanging("ParentScorecard");
                }
            }


              // Define the entity set for the collection side of the relationship.
            private EntitySet<Shot> _shots;

            [Association(Storage = "_shots", OtherKey = "_linkedScorecardHoleID", ThisKey = "ScorecardHoleID")]
            public EntitySet<Shot> Shots
            {
                get { return this._shots; }
                set { this._shots.Assign(value); }
            }

            


            // Assign handlers for the add and remove operations, respectively.
        public ScorecardHole()
        {
            _shots = new EntitySet<Shot>(
                new Action<Shot>(this.attach_Instance),
                new Action<Shot>(this.detach_Instance)
                );
        }

        // Called during an add operation
        private void attach_Instance(Shot shot)
        {
            NotifyPropertyChanging("PlayerRound");
            shot.parentScorecardHole = this;
        }

        // Called during a remove operation
        private void detach_Instance(Shot shot)
        {
            NotifyPropertyChanging("PlayerRound");
            shot.parentScorecardHole = null;
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

        #region Shot
        [Table]
        public class Shot : INotifyPropertyChanged, INotifyPropertyChanging
        {

            public Shot() { }
            // Define ID: private field, public property, and database column.
            private int _shotID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int ShotID
            {
                get { return _shotID; }
                set
                {
                    if (_shotID != value)
                    {
                        NotifyPropertyChanging("ShotID");
                        _shotID = value;
                        NotifyPropertyChanged("ShotID");
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

            // Define item name: private field, public property, and database column.
            private int _score;

            [Column]
            public int Score
            {
                get { return _score; }
                set
                {
                    if (_score != value)
                    {
                        NotifyPropertyChanging("Score");
                        _score = value;
                        NotifyPropertyChanged("Score");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private int _holeNumber;

            [Column]
            public int HoleNumber
            {
                get { return _holeNumber; }
                set
                {
                    if (_holeNumber != value)
                    {
                        NotifyPropertyChanging("HoleNumber");
                        _holeNumber = value;
                        NotifyPropertyChanged("HoleNumber");
                    }
                }
            }


            [Column]
            internal int _linkedScorecardHoleID;

            // Entity reference
            private EntityRef<ScorecardHole> _parentScorecardHole;

            // Association, to describe the relationship between this key and that "storage" table
            [Association(Storage = "_parentScorecardHole", ThisKey = "_linkedScorecardHoleID", OtherKey = "ScorecardHoleID", IsForeignKey = true)]
            public ScorecardHole parentScorecardHole
            {
                get { return _parentScorecardHole.Entity; }
                set
                {
                    NotifyPropertyChanging("parentScorecardHole");
                    _parentScorecardHole.Entity = value;

                    if (value != null)
                    {
                        _linkedScorecardHoleID = value.ScorecardHoleID;
                    }

                    NotifyPropertyChanging("parentScorecardHole");
                }
            }

            [Column]
            internal int _linkedPlayerRoundID;

            // Entity reference
            private EntityRef<PlayerRound> _playerRound;

            // Association, to describe the relationship between this key and that "storage" table
            [Association(Storage = "_playerRound", ThisKey = "_linkedPlayerRoundID", OtherKey = "PlayerRoundID", IsForeignKey = true)]
            public PlayerRound PlayerRound
            {
                get { return _playerRound.Entity; }
                set
                {
                    NotifyPropertyChanging("PlayerRound");
                    _playerRound.Entity = value;

                    if (value != null)
                    {
                        _linkedPlayerRoundID = value.PlayerRoundID;
                    }

                    NotifyPropertyChanging("PlayerRound");
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
