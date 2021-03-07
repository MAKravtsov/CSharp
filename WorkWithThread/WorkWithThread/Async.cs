using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WorkWithThread
{
    class Async
    {
        static object locker = new object();
        // определение асинхронного метода
        static async void FactorialAsync(int l)
        {
            int x = await Task.Run(() =>
            {
                int result = 1;
                for (int i = 1; i <= l; i++)
                {
                    result *= i;
                }
                lock (locker)
                {
                    Thread.Sleep(8000);
                }
                return result;
            });
            Console.WriteLine($"Факториал равен {x}"); // выполняется асинхронно
        }

        public static void General()
        {

            FactorialAsync(3);
            FactorialAsync(4);
            // вызов асинхронного метода

            Console.WriteLine("Введите число: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Квадрат числа равен {n * n}");

            Console.Read();
        }
    }
}
