using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaginsLibrary;

namespace Plagin1
{
    public class Plagin1 : IPlagin
    {
        public string Name => "Плагин1";

        public int N;

        public int? Calc(int num)
        {
            try
            {
                if (num > 1000)
                {
                    return null;
                }

                return num;
            }
            catch (Exception e)
            {
                throw new Exception($"Plagin1.Calc(): {e.Message}");
            }
        }
    }
}
