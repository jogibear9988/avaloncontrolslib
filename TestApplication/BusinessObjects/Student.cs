using System;
using System.Collections.Generic;
using System.Text;
using AC.AvalonControlsLibrary.Core;

namespace TestApplication
{
    /// <summary>
    /// The student object specifies information for the dat grid view
    /// by using the DataGridViewPropertyDescriptorAttribute
    /// </summary>
    public class Student : Person
    {
        public Student(string name, string surname, int age)
            : base (name, surname)
        {
            this.age = age;
        }

        int age;
        /// <summary>
        /// gets or sets the age of the student
        /// This property provides info to the datagrid view by using the attribute
        /// </summary>
        [DataGridViewPropertyDescriptor("Age", "Age of Student", "Age", Position=9)]
        public int Age 
        { 
            get 
            { 
                return age; 
            } 
            set 
            { 
                age = value;
                OnPropertyChanged("Age");
            } 
        }
        
        /// <summary>
        /// Gets and sets the grade for the student
        /// Please note this property has been marked to be excluded from the auto generation of columns
        /// </summary>
        [DataGridViewPropertyDescriptor(true)]
        public int Grade 
        {
            get { return 1; }
        }

        IList<string> subjects = new List<string>(2);

        /// <summary>
        /// Return a list of subjects for the student
        /// This demos the collection behaviour attribute
        /// </summary>
        [DataGridViewPropertyDescriptor("Subjects", "Subjects", "Subjects", CollectionBehaviour=CollectionBehaviour.LastValue)]
        public IList<string> Subjects
        {
            get 
            {
                if (subjects.Count == 0)
                {
                    subjects.Add("Python");
                    subjects.Add("C#");
                }

                return subjects;
            }
        }
    }
}
