using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLab8
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
    public class ChangeUniverEventArgs
    {
        public ChangeUniverEventArgs(string name) { UnivercityName = name; }
        public string UnivercityName { get; private set; }
    }
    class Student : Man
    {
        public event EventHandler<ChangeUniverEventArgs> UnivercityChanged;
        protected virtual void OnUnivercityChanged(ChangeUniverEventArgs e)
        {
            var handler = UnivercityChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public string Univer { get; private set; }
        public void ChangeUniver(string univer)
        {
            if (Univer != univer)
            {
                Univer = univer;
                OnUnivercityChanged(new ChangeUniverEventArgs(Univer));

            }
        }
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
            var teen = new Teen("Maxim", "Galuk", "18");
            var student = new Student("Alex", "Bogomolov", "BSUIR");
            teen.PrintInfo();
            student.PrintInfo();

            student.ChangeUniver("UniverWithoutSubscriptions");
            student.UnivercityChanged += Student_UnivercityChanged;

            student.ChangeUniver("BSU");

            student.UnivercityChanged += (sender, e) =>
            {
                var thisStudent = sender as Student;
                Console.WriteLine("This from lambda. Student {0} is in {1} now.", thisStudent.Name, e.UnivercityName);
            };
            student.ChangeUniver("UniverWith2Subscriptions");
            // non effective call
            student.ChangeUniver("UniverWith2Subscriptions");

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

        static void Student_UnivercityChanged(object sender, ChangeUniverEventArgs e)
        {
            var thisStudent = sender as Student;
            Console.WriteLine("This from static handler. Student {0} is in {1} now.", thisStudent.Name, e.UnivercityName);
        }

    }
}
