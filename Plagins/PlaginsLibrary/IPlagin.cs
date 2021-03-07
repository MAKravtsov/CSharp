using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaginsLibrary
{
    public interface IPlagin
    {
        string Name { get; }

        int? Calc(int num);
    }
}
