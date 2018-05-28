using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FunWithObservableCollections
{
    class Program
    {
        static void Main(string[] args)
        {

            var peter = new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 };
            var kevin = new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 };
            var maria = new Person{ FirstName = "Maria", LastName = "Queen", Age = 30 };

            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                peter,
                kevin
            };

            people.CollectionChanged  += people_CollectionChanged;

            people.Add(maria);
            people.Remove(kevin);
        }

        static void people_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"Action for this event {e.Action}");

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach(Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are the NEW items:");
                foreach(Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }

    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Age}";
        }
    }
}
