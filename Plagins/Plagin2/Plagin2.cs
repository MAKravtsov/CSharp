using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaginsLibrary;

namespace Plagin2
{
    public class Plagin2 : IPlagin
    {
        public string Name => "Плагин2";

        public int? Calc(int num)
        {
            try
            {
                if (num % 2 != 0)
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
