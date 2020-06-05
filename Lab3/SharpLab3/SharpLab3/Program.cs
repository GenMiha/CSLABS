using System;

namespace SharpLab3
{
    class Man
    {
        public string name, surname, birthday, sex;
        public Man(string Name, string Surname, string Birthday, string Sex)
        {
            name = Name;
            surname = Surname;
            birthday = Birthday;
            sex = Sex;
        }
    }

    class Student : Man
    {
        public string university;

        public Student(string Name, string Surname, string Birthday, string Sex, string University) : base(Name, Surname, Birthday, Sex)
        {
            this.university = University;
            Console.WriteLine(Name);
            Console.WriteLine(Surname);
            Console.WriteLine(Birthday);
            Console.WriteLine(Sex);
            Console.WriteLine(University);
            Console.WriteLine();
        }
    }

    class UniversityEmploye : Student
    {
        public string position;
        public UniversityEmploye(string Name,string Surname,string Birthday,string Sex, string University, string Position) : base(Name,Surname,Birthday, Sex, University)
        {
            this.position = Position;
            Console.WriteLine(Name);
            Console.WriteLine(Surname);
            Console.WriteLine(Birthday);
            Console.WriteLine(Sex);
            Console.WriteLine(University);
            Console.WriteLine(position);
            Console.WriteLine();

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of emploeyes: ");
            int n = Int32.Parse(Console.ReadLine());
            UniversityEmploye[] universityEmployes = new UniversityEmploye[n];
            foreach (var universityEmploeye in universityEmployes)
            {
                Console.WriteLine("Enter emploeye's name: ");
                universityEmploeye.name = Console.ReadLine();
                Console.WriteLine("Enter emploeye's surname: ");
                universityEmploeye.surname = Console.ReadLine();
                Console.WriteLine("Enter emploeye's birthday in dd.mm.yyyy format: ");
                universityEmploeye.birthday = Console.ReadLine();
                Console.WriteLine("Enter emploeye's sex: ");
                universityEmploeye.sex = Console.ReadLine();
                Console.WriteLine("Enter emploeye's university: ");
                universityEmploeye.university = Console.ReadLine();
                Console.WriteLine("Enter emploeye's position: ");
                universityEmploeye.university = Console.ReadLine();
                
            }
            Console.ReadKey(true);
        }
    }
}
