using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLab5
{
    public struct City
    {
        public string mycountry, mycity;

        public City(string country, string city)
        {
            mycountry = country;
            mycity = city;
        }
    }

    abstract class Man
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Man(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public virtual void PrintInfo(string Name)
        {
            Console.Write(Name + " " + Surname);
        }
    }

    class Teen : Man
    {
        public string Age { get; private set; }
        public Teen(string Name, string Surname, string age) : base(Name, Surname)
        {
            this.Age = age;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine(Name + " " + Surname + " " + Age);
        }
    }

    class Student : Man
    {
        public string Univer { get; private set; }
        public Student(string Name, string Surname, string univer) : base(Name, Surname)
        {
            this.Univer = univer;
        }
        public virtual void PrintInfo()
        {
            base.PrintInfo(Name);
            Console.WriteLine(" " + Univer);
        }
    }

    enum MobilePhone
    {
        Samsung,
        Xiaomi,
        Apple
    }

    enum Laptop
    {
        Asus,
        HP,
        Dell,
        Macbook
    }

    class Program
    {
        static void Main(string[] args)
        {
            Teen teen = new Teen("Maxim", "Galuk", "18");
            Student student = new Student("Mihail", "Bogomolov", "BSUIR");
            teen.PrintInfo();
            student.PrintInfo();
            City city1 = new City("Belarus", "Svetlogorsk");
            City city2 = new City("Belarus", "Minsk");
            Console.WriteLine("Live in: ");
            Console.WriteLine("{0}, {1}", city1.mycountry, city1.mycity);
            Console.WriteLine("{0}, {1}", city2.mycountry, city2.mycity);
            MobilePhone mp;
            Laptop l;
            mp = MobilePhone.Samsung;
            l = Laptop.Asus;
            Console.WriteLine("Has the mobile" + " " + mp);
            Console.WriteLine("Has laptop" + " " + l);
            Console.ReadKey(true);
        }
    }
}
