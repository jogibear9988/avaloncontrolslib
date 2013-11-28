using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AC.AvalonControlsLibrary.Core;

namespace TestApplication
{
    /// <summary>
    /// Object used for testing
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        string name;
        /// <summary>
        /// Gets or sets the Name of the person
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        string surname;
        /// <summary>
        /// Gets or sets the surname of the person
        /// </summary>
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="name">The name of the person</param>
        /// <param name="surname">The surname of the person</param>
        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        #endregion
    }

    /// <summary>
    /// Comparer used for sorting
    /// This is used for faster sorting on the list view.
    /// </summary>
    public class PersonComparer : GridViewCustomComparer
    {
        /// <summary>
        /// Default construtor
        /// </summary>
        public PersonComparer()
            : base(true) // pass false if you need that the CompareOverride passes the actual values of the properties... This operation has an overhead, for better performance pass false.
        {}

        public override int CompareOverride(object x, object y)
        {
            Person x1 = (Person)x;
            Person y1 = (Person)y;
            
            int result = 0;

            switch (base.SortPropertyName)
            {
                case "Name":
                    result = x1.Name.CompareTo(y1.Name);
                    break;
                case "Surname":
                    result = x1.Surname.CompareTo(y1.Surname);
                    break;
                default:
                    return 0;
            }

            if (base.Direction == ListSortDirection.Ascending)
                return result;
            else
                return (-1) * result;
        }
    }

}
