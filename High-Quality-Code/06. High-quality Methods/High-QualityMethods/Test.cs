using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Numbers cannot be negative");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        enum Numbers
        {
            zero,
            one,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine
        };

        static string NumberToDigit(Numbers num)
        {
            string digitNumber;

            switch (num)
            {
                case Numbers.zero: digitNumber = Numbers.zero.ToString(); break;
                case Numbers.one: digitNumber = Numbers.one.ToString(); break;
                case Numbers.two: digitNumber = Numbers.two.ToString(); break;
                case Numbers.three: digitNumber = Numbers.three.ToString(); break;
                case Numbers.four: digitNumber = Numbers.four.ToString(); break;
                case Numbers.five: digitNumber = Numbers.five.ToString(); break;
                case Numbers.six: digitNumber = Numbers.six.ToString(); break;
                case Numbers.seven: digitNumber = Numbers.seven.ToString(); break;
                case Numbers.eight: digitNumber = Numbers.eight.ToString(); break;
                case Numbers.nine: digitNumber = Numbers.nine.ToString(); break;
                default: throw new ArgumentException("This is invalid value.");
            }

            return digitNumber;
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new IndexOutOfRangeException("Array is empty.");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        static void PrintAsNumber(object number,char format)
        {
            switch(format)
            {
                case 'f': Console.WriteLine("{0:f2}", number); break;
                case '%': Console.WriteLine("{0:p0}", number); break;
                case 'r': Console.WriteLine("{0,8}", number); break;
                default: throw new InvalidOperationException("Invalid symbol.");
            }

        }

        static bool Horizontal(double y1,double y2)
        {
            return y1 == y2;
        }

        static bool Vertical(double x1,double x2)
        {
            return x1 == x2;
        }

        static double CalcDistance(double x1, double y1, double x2, double y2,
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = Horizontal(y1, y2);
            isVertical = Vertical(x1, x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }


        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(Numbers.five));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, 'f');
            PrintAsNumber(0.75, '%');
            PrintAsNumber(2.30, 'r');

            bool horizontal = true;
            bool vertical = true;
            
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}