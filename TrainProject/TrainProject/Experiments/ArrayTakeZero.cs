using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject.Experiments
{
    class ArrayTakeZero
    {
        public void Method()
        {
            var arr = new int[] {1, 2, 3, 4};
            var arr2 = (from a in arr.Take(0).OrderBy(y => y) select a);
            foreach (var a in arr2)
            {
                Console.WriteLine(a);
            }

            Console.ReadLine();
        }
    }
}
