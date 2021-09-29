using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TreeNode
    {
        public IEnumerable<TreeNode> Children { get; set; } = new List<TreeNode>();

        public IEnumerable<TreeNode> GetAllNodes()
        {
            var toReturn = new List<TreeNode> { this };

            foreach (var node in Children) {
                var nodes = node.GetAllNodes();
                toReturn.AddRange(nodes);
            }

            return toReturn;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            var a = "A999".ToCharArray();
            Increment(a);
            */

            /*
            int? b = null;
            var c = Task.Factory.StartNew(() => A(out b)).Result;

            int r = 4;
            */
            var t2 = new TreeNode();
            var t1 = new TreeNode();

            var expect = new List<TreeNode> { t1, t2 };

            t1.Children = new List<TreeNode>{ t2 };

            var result = t1.GetAllNodes().ToList();

            bool flag = true;

            for(int i = 0; i < expect.Count; i++) {
                if(!ReferenceEquals(expect[i], result[i])) {

                }
            }
        }

        
        static bool A(out int? num)
        {
            num = 2;
            throw new Exception();
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

            /*
            if (b.Length > referenceNumber.Length) {
                result.Add();
            } else {
                result.AddRange(b);
            }
            */

            referenceNumber = result.ToArray();
        }
    }
}
