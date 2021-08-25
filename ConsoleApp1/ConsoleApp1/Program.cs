using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = "A999".ToCharArray();
            Increment(a);
        }

        static void Increment(char[] referenceNumber)
        {
            if(referenceNumber == null || !referenceNumber.Any())
                return;

            var reverse = referenceNumber.Reverse().ToList();

            int res = 0;
            var result = new List<char>();
            var first = reverse.First();
            if (!int.TryParse(reverse.First().ToString(), out res))
                return;

            result.Add(first);

            for (int i = 1; i < reverse.Count; i++) {
                if (!int.TryParse(reverse[i].ToString(), out res))
                    break;

                result.Insert(0, reverse[i]);
            }

            var a = string.Join("", result);

            var b = (decimal.Parse(a) + 1).ToString().ToCharArray();

            if (b.Length > referenceNumber.Length) {
                result.Add();
            } else {
                result.AddRange(b);
            }

            referenceNumber = result.ToArray();
        }
    }
}
