using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interwiew
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 1; i <= 100; i++)
            {
                var a = i % 5 == 0 ? 1 : 0;
                var b = i % 3 == 0 ? 2 : 0;
                switch (a + b)
                {
                    case 3:
                        Console.WriteLine("FizzBuzz");
                        break;
                    case 2:
                        Console.WriteLine("Fizz");
                        break;
                    case 1:
                        Console.WriteLine("Buzz");
                        break;
                    case 0:
                        Console.WriteLine(i);
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }

                //if (i % 5 == 0)
                //{
                //    Console.WriteLine(i % 3 == 0 ? "FizzBuzz" : "Buzz");
                //}
                //else if (i % 3 == 0)
                //{
                //    Console.WriteLine("Fizz");
                //}
                //else
                //{
                //    Console.WriteLine(i);
                //}
            }

            Console.ReadLine();
        }
    }
}
