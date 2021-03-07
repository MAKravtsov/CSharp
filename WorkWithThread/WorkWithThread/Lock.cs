using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkWithThread
{
    public class Lock
    {
        public static List<A> arrA;
        public void General()
        {
            arrA = new List<A>();
            arrA.Add(new A(1));
            arrA.Add(new A(2));

            Task.Factory.StartNew(() =>B(13));
            Task.Factory.StartNew(() => B(4));
        }

        public void B(int r)
        {
            var e = arrA.FirstOrDefault();
            C(e, r);

            lock(e.locker)
            {
                Console.WriteLine(arrA[0].a);
                Thread.Sleep(5000);
            }
        }

        public void C(A e, int r)
        {
            e.a = r;
        }
    }

    public class A
    {
        public int a;
        public object locker;

        public A( int i)
        {
            a = i;
            locker = new object();
        }
    }
}
