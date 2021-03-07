using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkWithThread
{
    class AsyncMethods
    {
        static bool Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 6; i++)
                {
                    result *= i;
                }
                Thread.Sleep(8000);
                Console.WriteLine($"Факториал равен {result}");
                return true;
            }
            // определение асинхронного метода
            static async Task<bool> FactorialAsync()
            {
                Thread.Sleep(5000);
                Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
                //var e = Task.Run(() => Factorial());                // выполняется асинхронно
                //Console.WriteLine(e);
                var e = Task.Run(() => Factorial()).Result;
                Console.WriteLine("Конец метода FactorialAsync");
                return e;
            }

            public void General()
            {
                var e = FactorialAsync();   // вызов асинхронного метода

                Console.WriteLine("Введите число: ");
                int n = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"Квадрат числа равен {n * n}");

                Console.Read();
            }
    }
}
