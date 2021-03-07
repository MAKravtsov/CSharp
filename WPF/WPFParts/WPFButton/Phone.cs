using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFButton
{
    public class Phone
    {
        public string Model { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Model} {Price}";
        }
    }
}
