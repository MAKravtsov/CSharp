using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping
{
    class UniqueGroup : Group
    {
        public List<string> daughters;

        public UniqueGroup(string nam, string str, int tm) : base(nam, str, tm)
        {
            daughters = new List<string>();
        }
        public UniqueGroup(string nam, string str, int tm, List<string> dghts) : base(nam, str, tm)
        {
            daughters = new List<string>();
            daughters.AddRange(dghts);
        }

    }
}
