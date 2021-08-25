using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Oracle.ManagedDataAccess.Client;

namespace ConsoleApp2
{
    class Program
    {
        public string Name { get; init; }

        public int Age { get; set; }
        
        static void Main(string[] args)
        {
            var a = new List<int>();
            for(int i = 0; i < 1000000; i++)
                a.Add(i);

            var b = a.Where(y => y > 100000);

            A(b);

            Thread.Sleep(100000);
        }

        static void A(IEnumerable<int> a)
        {
            var s = new Stopwatch();
            s.Start();
            var b = a.Where(y => y > 500000);
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
        }
    }

    record Rec (string Name, int Age);
}
