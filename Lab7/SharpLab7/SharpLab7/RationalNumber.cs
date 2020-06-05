using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLab7
{
    class RationalNumber : IComparable
    {
        private int firstNumber;
        private int secondNumber;
        private double _dn;
        private double _dm;

        public RationalNumber()
        {
            firstNumber = 0;
            secondNumber = 0;
        }

        public RationalNumber(int temp)
        {
            N = ToRationalNumber(temp).N;
            M = ToRationalNumber(temp).M;
        }

        public RationalNumber(float temp)
        {
            N = ToRationalNumber(temp).N;
            M = ToRationalNumber(temp).M;
        }

        public RationalNumber(double temp)
        {
            N = ToRationalNumber(temp).N;
            M = ToRationalNumber(temp).M;
        }

        public RationalNumber(string temp)
        {
            N = ToRationalNumber(temp).N;
            M = ToRationalNumber(temp).M;
        }

        public RationalNumber(int n, int m)
        {
            _dn = N = n;
            _dm = M = m;
        }

        public int N { get => firstNumber; set => firstNumber = value; }

        public int M
        {
            get => secondNumber;
            set
            {
                if (value != 0)
                    secondNumber = value;
                else
                    throw new DivideByZeroException();
            }
        }

        public override string ToString() => string.Format(firstNumber + "/" + secondNumber);

        public static implicit operator RationalNumber(float a) => ToRationalNumber(a);

        public static implicit operator RationalNumber(int a) => ToRationalNumber(a);

        public static implicit operator RationalNumber(double a) => ToRationalNumber(a);

        public static implicit operator float(RationalNumber a) => (float)(a._dn / a._dm);

        public static implicit operator double(RationalNumber a) => (double)(a._dn / a._dm);

        public static explicit operator int(RationalNumber a) => (a.firstNumber / a.secondNumber);

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            RationalNumber result = new RationalNumber();
            result.secondNumber = a.secondNumber * b.secondNumber;
            result.firstNumber = a.secondNumber * b.firstNumber + b.secondNumber * a.firstNumber;
            if (result.secondNumber == result.firstNumber)
            { result.secondNumber = result.firstNumber = 1; }
            return result;
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            RationalNumber result = new RationalNumber();
            result.secondNumber = a.secondNumber * b.secondNumber;
            result.firstNumber = a.secondNumber * b.firstNumber - b.secondNumber * a.firstNumber;
            if (result.secondNumber == result.firstNumber)
            { result.secondNumber = result.firstNumber = 1; }
            return result;
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            RationalNumber result = new RationalNumber();
            result.secondNumber = a.secondNumber * b.secondNumber;
            result.firstNumber = a.firstNumber * b.firstNumber;
            if (result.secondNumber == result.firstNumber)
            { result.secondNumber = result.firstNumber = 1; }
            return result;
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            RationalNumber result = new RationalNumber();
            result.secondNumber = a.secondNumber * b.firstNumber;
            result.firstNumber = a.firstNumber * b.secondNumber;
            if (result.secondNumber == result.firstNumber)
            { result.secondNumber = result.firstNumber = 1; }
            return result;
        }

        public static RationalNumber ToRationalNumber(float floatTemp)
        {
            string temp = floatTemp.ToString();
            RationalNumber result = new RationalNumber();
            result.secondNumber = 10 * temp.Length - temp.IndexOf(",");
            result.firstNumber = int.Parse(temp.Remove(temp.IndexOf(","), 1));
            return result;
        }

        public static RationalNumber ToRationalNumber(double doubleTemp)
        {
            string temp = doubleTemp.ToString();
            RationalNumber result = new RationalNumber();
            result.secondNumber = 10 * temp.Length - temp.IndexOf(",");
            result.firstNumber = int.Parse(temp.Remove(temp.IndexOf(","), 1));
            return result;
        }

        public static RationalNumber ToRationalNumber(int intTemp)
        {
            RationalNumber result = new RationalNumber(intTemp, 1);
            return result;
        }

        public static RationalNumber ToRationalNumber(string stringTemp)
        {
            RationalNumber result = new RationalNumber();
            if (stringTemp.Contains(","))
            {
                result.secondNumber = (int)Math.Pow(10, stringTemp.Length - stringTemp.IndexOf(",") - 1);
                result.firstNumber = int.Parse(stringTemp.Remove(stringTemp.IndexOf(","), 1));
                return result;
            }
            else if (stringTemp.Contains("/"))
            {
                result.secondNumber = int.Parse(stringTemp.Remove(0, stringTemp.IndexOf("/") + 1));
                result.firstNumber = int.Parse(stringTemp.Remove(stringTemp.IndexOf("/"), stringTemp.Length - stringTemp.IndexOf("/")));
                return result;
            }
            else if (stringTemp.Contains("/") && stringTemp.Contains(","))
                throw new Exception("Некорректный ввод.");
            else
                return ToRationalNumber(int.Parse(stringTemp));
        }

        public override bool Equals(object obj)
        {
            if (obj is RationalNumber && obj != null)
            {
                RationalNumber temp = (RationalNumber)obj;
                if (temp._dn / temp._dm == temp._dn / temp._dm)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 6188947;
            hashCode = hashCode * -1521134295 + firstNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + secondNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + _dn.GetHashCode();
            hashCode = hashCode * -1521134295 + _dm.GetHashCode();
            hashCode = hashCode * -1521134295 + N.GetHashCode();
            hashCode = hashCode * -1521134295 + M.GetHashCode();
            return hashCode;
        }



        public int CompareTo(object obj)
        {
            RationalNumber temp = obj as RationalNumber;
            if (temp != null)
            {
                if (this.firstNumber / this.secondNumber > temp.firstNumber / temp.secondNumber)
                    return 1;
                if (this.firstNumber / this.secondNumber < temp.firstNumber / temp.secondNumber)
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Параметр не является объектом типа RationalNumber!");
        }
    }
}