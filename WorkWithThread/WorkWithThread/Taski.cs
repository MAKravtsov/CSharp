using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace WorkWithThread
{
    class Taski
    {
        static bool flag = false;
        object locker = new object();
        public Task General()
        {
            //Task t = Task.Factory.StartNew(() => {
            //    // Just loop.
            //    int ctr = 0;
            //    for (ctr = 0; ctr <= 1000000; ctr++)
            //    { }
            //    Console.WriteLine("Finished {0} loop iterations",
            //                      ctr);
            //});
            //t.Wait();



            //// Wait on a single task with a timeout specified.
            //Task taskA = Task.Run(() => Thread.Sleep(2000));
            //try
            //{
            //    taskA.Wait();       // Wait for 1 second.
            //    bool completed = taskA.IsCompleted;
            //    Console.WriteLine("Task A completed: {0}, Status: {1}",
            //                     completed, taskA.Status);
            //    if (!completed)
            //        Console.WriteLine("Timed out before task A completed.");
            //}
            //catch (AggregateException)
            //{
            //    Console.WriteLine("Exception in taskA.");
            //}
            //Console.ReadLine();

            Taski taski = new Taski();
            //Task[] tasks = new Task[7];
            //int temp = 1;
            //foreach (var k in tasks)
            //{
            //    int m = temp;
            //    Task.Factory.StartNew(() => taski.Potok());
            //    temp++;
            //}

            while (true)
            {
                Console.ReadLine();

                for (int i = 0; i < 3; i++)
                    taski.Potokasync();
                taski.Potok();

            }
        }

        async void Potokasync()
        {
            await Task.Run(() => Potok());
        }
        void Potok()       
        {
            // Для прослеживания времени выполнения цикла
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Основа. Вывод в консоль
            for (int j = 0; j < 5; j++)
                Console.Write('x');

            stopwatch.Stop();
            // Узнаем, какой это был поток и сколько длилось выполнение. Меняем флаг
            Console.WriteLine($" {Task.CurrentId} {stopwatch.Elapsed}");

            Console.WriteLine("Поток закончил работу");
        }

    }
}
