using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace WorkWithThread
{
    class Potoks
    {
        bool flag = true;
        object locker = new object();
        public void General()
        {
            // Запускаем n-ное количество потоков
            for (int i = 0; i < 7; i++)
            {
                // --------------------------------ЗФПОМНИТЬ ФИШКУ, Во время работы потока, i уже может поменяться, поэтому ее надо запомнить отдельно--------------------------------------------
                int temp = i;

                //Запускаем новый поток
                //Thread thread = new Thread(() => Potok(temp));
                //thread.Start();

                Thread thread = new Thread(Potok);
                thread.Start(i);
                thread.Name = $"potok{i}";
            }
            // Делаем так, чтобы на экран выводилось только по нажатию клавиши
            while (true)
            {    
                // Чттобы во время одного выполнения программы нельзя было бы несколько раз нажать
                lock (locker)
                {
                    if (Console.ReadLine().ToString() == "")
                        flag = true;
                }
            }
        }

        void Potok(object cnt)
        {
            // чтобы срабатывало по нажатию клавиши, нужно постоянно следить за состоянием
            while (true)
            {
                // Чтобы потоки не пересеклись
                //lock (locker)
                //{
                    // Переменная флаг по сработке потока
                    if (!flag)
                        continue;

                    // Для прослеживания времени выполнения цикла
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    // Основа. Вывод в консоль
                    for (int j = 0; j < (int)cnt; j++)
                        Console.Write('x');

                    stopwatch.Stop();
                    // Узнаем, какой это был поток и сколько длилось выполнение. Меняем флаг
                    Console.WriteLine($" {Thread.CurrentThread.Name} {stopwatch.Elapsed}");

                    flag = false;
                //}
            }
        }

    }
}
