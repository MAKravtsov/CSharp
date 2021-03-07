using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkWithThread
{
    public class ConcurrentDictionary
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        bool flag = false;

        public void General()
        {
            dict.Add("A", 6);
            var D = dict["D"];
            Task.Factory.StartNew(A);
            Task.Factory.StartNew(() => B(3));
            Task.Factory.StartNew(() => B(4));
            Task.Factory.StartNew(() => B(5));
        }

        public void A()
        {
            flag = true;
            Thread.Sleep(5000);
            dict.Add("B", 5);
            flag = false;
        }

        public void B(int a)
        {
            while (flag) { }
            Console.WriteLine($"{dict.ContainsKey("B")} {a}") ;
        }
    }
}
