using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace WorkWithThread
{
    class Starting
    {
        bool flag = true;
        object locker = new object();
        public void General()
        {
            for (int i = 0; i < 7; i++)
            {
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        lock (locker)
                        {
                            if (!flag)
                                continue;

                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            for (int j = 0; j < 5; j++)
                                Console.Write('x');
                            stopwatch.Stop();

                            Console.WriteLine($" {Thread.CurrentThread.Name} {stopwatch.Elapsed}");
                            flag = false;
                        }
                    }
                });

                thread.Name = $"potok{i}";
            }

            while (true)
            {
                lock (locker)
                {
                    if (Console.ReadLine().ToString() == "")
                        flag = true;
                }
            }
        }
    }
}
