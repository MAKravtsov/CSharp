using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WorkWithThread
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //Starting starting = new Starting();
        //    //starting.General();

        //    //var done = new Done();
        //    // done.General();

        //    var potoks = new ConcurrentDictionary();
        //    potoks.General();

        //    Console.ReadLine();

        //    //Taski taski = new Taski();
        //    //taski.General();

        //    //Async.General();

        //    //ReturnedTask returnedAsync = new ReturnedTask();
        //    //returnedAsync.General();
        //}

        public static void Main(string[] args)
        {
            var a = Task.Factory.StartNew(M).Result;
            Console.ReadLine();
        }

        public static int M()
        {
            throw new Exception("asasa");
            //return 15;
        }
    }
}
