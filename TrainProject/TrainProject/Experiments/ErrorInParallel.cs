using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject.Experiments
{
    public class ErrorInParallel
    {
        public void General()
        {
            int[] arr = { 1, 2, 0, 3, 4 };
            List<int> output = new List<int>();

            Parallel.ForEach(arr, elem =>
            {
                var e = 10 / elem;
                lock (output)
                {
                    output.Add(elem);
                }
            });
        }
    }
}
