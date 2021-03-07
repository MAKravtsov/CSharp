using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping
{
    class NonuniqueGroup : Group
    {
        public List<string> parents;

        public NonuniqueGroup(string nam, string str, int tm) : base(nam, str, tm)
        {
            parents = new List<string>();
        }
        public NonuniqueGroup(string nam, string str, int tm, List<string> prts) : base(nam, str, tm)
        {
            parents = new List<string>();
            parents.AddRange(prts);
        }
    }
}
