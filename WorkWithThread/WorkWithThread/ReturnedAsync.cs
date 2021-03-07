using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkWithThread
{
    public class ReturnedAsync
    {
        public void General()
        {
            //for (var i = 0; i < 10; i++)
            //{
            //    AsyncMethod2();
            //}

            AsyncMethod();

            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(i + "General");
                Thread.Sleep(2000);
            }

            Console.ReadLine();
        }

        //public static async Task<bool> AsyncMethod2()
        //{
        //    for (var i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine(i + "AsyncMethod");
        //        Thread.Sleep(1000);
        //    }

        //    return true;
        //}

        public static async void AsyncMethod()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(i + "AsyncMethod");
                Thread.Sleep(1000);
            }

            await Task.Run(() => Method());
        }

        private static void Method()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(i + "Method");
                Thread.Sleep(1000);
            }
        }
    }
}
