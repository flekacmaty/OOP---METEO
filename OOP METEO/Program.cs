using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_Meteo
{
    class Calc
    {
        private int[] temperature = new int[7];
        private string[] days = { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" };

        public void Input()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Write("Enter the temperature on {0}: ", days[i]);
                temperature[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\n-------------------------------------\n");
        }

        public void Graphics()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0} ", days[i]);

                if (temperature[i] < 0)
                {
                    for (int l = 0; l > temperature.Min() - temperature[i]; l--)
                    {
                        Console.Write(" ");
                    }
                    for (int l = 0; l > temperature[i]; l--)
                    {
                        Console.Write("*");
                    }
                    Console.Write("|");
                    Console.WriteLine(" {0}", temperature[i]);
                }

                if (temperature[i] >= 0)
                {
                    for (int l = 0; l > temperature.Min(); l--)
                    {
                        Console.Write(" ");
                    }

                    Console.Write("|");

                    for (int k = 0; k < temperature[i]; k++)
                    {
                        Console.Write("+");
                    }
                    Console.WriteLine(" {0}", temperature[i]);
                }
            }

            Console.WriteLine("\n-------------------------------------\n");
        }

        public void Stats()
        {

            int maxIndex = temperature.Max();
            int minIndex = temperature.Min();

            string minString = "(";
            string maxString = "(";

            int counter = 0;
            foreach (var i in temperature)
            {

                if (i == minIndex)
                {
                    if (minString == "(")
                    {
                        minString += String.Format("{0}", days[counter]);
                    }
                    else
                    {
                        minString += String.Format(", {0}", days[counter]);

                    }

                }

                else if (i == maxIndex)
                {
                    if (maxString == "(")
                    {
                        maxString += String.Format("{0}", days[counter]);
                    }
                    else
                    {
                        maxString += String.Format(", {0}", days[counter]);
                    }

                }
                counter++;
            }

            Console.WriteLine("Minimum temperature: {0} {1})", temperature.Min(), minString);
            Console.WriteLine("Maximum temperature {0} {1})", temperature.Max(), maxString);
            Console.WriteLine("Avarage temperature: {0} (Mon to Sun)", Math.Round(temperature.Average(), 2));
            Console.WriteLine("\n--------------------------------");
        }
    }
}

namespace projekt_Meteo
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();

            calc.Input();
            calc.Graphics();
            calc.Stats();

            Console.ReadKey();
        }
    }
}


