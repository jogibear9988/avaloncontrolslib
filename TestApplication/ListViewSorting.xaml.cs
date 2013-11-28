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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for ListViewSorting.xaml
    /// </summary>
    public partial class ListViewSorting : Window
    {
        public ListViewSorting()
        {
            InitializeComponent();

            List<Person> personList = new List<Person>(5);
            personList.Add(new Person("Marlon", "Grech"));
            personList.Add(new Person("Ema", "Grech"));
            personList.Add(new Person("Jamine", "Grech"));
            personList.Add(new Person("Adam", "Lorenzon"));
            personList.Add(new Person("Rafeale", "Bianco"));

            this.listView1.ItemsSource = personList;
            this.listView2.ItemsSource = new List<Person>( personList);//copy in another list
            this.listView3.ItemsSource = new List<Person>(personList);//copy in another list
        }

        private void BulkLoadClick(object sender, RoutedEventArgs e)
        {
            List<Person> personList = new List<Person>(5);

            for (int i = 0; i < 500; i++)
            {
                personList.Add(new Person("Marlon" + i, "Grech" + i));
                personList.Add(new Person("Ema" + i, "Grech" + i));
                personList.Add(new Person("Jamine" + i, "Grech" + i));
                personList.Add(new Person("Adam" + i, "Lorenzon" + i));
                personList.Add(new Person("Rafeale" + i, "Bianco" + i));
            }

            this.listView1.ItemsSource = personList;
            this.listView2.ItemsSource = new List<Person>(personList);//copy in another list
            this.listView3.ItemsSource = new List<Person>(personList);//copy in another list
        }
    }
}
