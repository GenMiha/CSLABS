using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLab6
{
    interface IMoney
    {
        int _curmoney { get; }
        void Buysmtg(int mon);
        void AskMoney(int mon);
    }

    interface IMan
    {
        string Name { get; }
        string Surname { get; }
    }

    class Man : IMoney, IMan, ICloneable, IComparable
    {
        int PocketMoney;
        public string Name { get; }
        public string Surname { get; }
        public Man(string name, string surname, int pocmon)
        {
            Name = name;
            Surname = surname;
            PocketMoney = pocmon;
        }
        public int _curmoney
        {
            get { return PocketMoney; }
        }
        public void Buysmtg(int mon)
        {
            if (mon < PocketMoney)
                PocketMoney -= mon;
            else Console.WriteLine("You don't have enough money.");
        }
        public void AskMoney(int mon)
        {
            PocketMoney += mon;
        }
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Man Mihail = new Man("Mihail", "Bogomolov", 800);
            Man Maxim = new Man("Maxim", "Galuk", 800);
            Mihail.Buysmtg(799);
            Maxim.AskMoney(30);
            Console.WriteLine("Mihail's cash left: {0}", Mihail._curmoney);
            Console.WriteLine("Maxim's cash left: {0}", Maxim._curmoney);
            Console.ReadKey(true);
        }
    }
}
