using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestApplication
{
    /// <summary>
    /// This Window is a demo of the DataGridView Control
    /// The DataGridViewControl is able to get the list of properties from the object source type
    /// and auto generate column to display the data
    /// You can even use the DataGridViewPropertyDescriptorAttribute to specify more information for the DataGridView about your properties
    /// The Person object does not use the DataGridViewPropertyDescriptorAttribute
    /// The Student object uses the DataGridViewPropertyDescriptorAttribute
    /// </summary>
    public partial class DataGridViewTest : Window
    {
        
        public DataGridViewTest()
        {
            InitializeComponent();

            List<Person> personList = new List<Person>(5);
            personList.Add( new Person("Marlon", "Grech") );
            personList.Add(new Person("Ema", "Grech"));
            personList.Add(new Person("Jamine", "Grech"));
            personList.Add(new Person("Adam", "Lorenzon"));
            personList.Add(new Person("Rafeale", "Bianco"));
            //the DataGridView will auto generate the columns (a column per property of the object)
            this.dataGridView1.ItemsSource = personList;

            List<Student> studentsList = new List<Student>(2);
            studentsList.Add(new Student("Marlon", "Grech", 22));
            studentsList.Add(new Student("Ema", "Grech", 24));
            //The datagridview will auto generate the columns 
            //(this time it will use the DataGridViewPropertyDescriptorAttribute to make the column generation more precize)
            this.dataGridView2.ItemsSource = studentsList;

        }
    }
}
