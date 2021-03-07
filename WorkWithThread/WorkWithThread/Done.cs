using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WorkWithThread
{
    class Done
    {
        bool _done = false;
        object obj = new object();
        public void General()
        {
            Thread thread = new Thread(Potok);

            thread.Start();

            Potok();

            Console.Read();
        }

        void  Potok()
        {
            lock (obj)
            {
                if (!_done)
                {
                    Console.WriteLine("Done");
                    _done = true;
                }
            }
        }
    }
}
