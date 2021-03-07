using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkWithThread
{
    internal class LockArray
    {
        private List<int> _list;

        internal void General()
        {
            _list = new List<int>();
            Task.Factory.StartNew(Write);
            Task.Factory.StartNew(Read);
        }

        internal void Write()
        {
            int cnt = 0;
            while (_list.Count <= 100000)
            {
                _list.Add(cnt);
                Thread.Sleep(500);
                cnt++;
            }
        }

        internal void Read()
        {
            while (true)
            {
                var e = _list.Last();
                Console.WriteLine(e);
            }
        }
    }
}
