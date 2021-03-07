using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using TrainProject.Experiments;

namespace TrainProject
{
    public class Program
    {
        private static Dictionary<string, int> Dict = new Dictionary<string, int>();
        private static bool B;
        
        static void Main(string[] args)
        {
            ////var cs = new ArrayTakeZero();
            ////cs.Method();

            //var e = new Prop();

            //var type = e.GetType();
            //var t = e.GetType().GetProperties();
            //var i = t[0].GetValue(e);

            //var o = t[1].Name;
            //var act = Activator.CreateInstance(t[3].PropertyType);
            //var h = t[3].PropertyType.GetProperties().Select(y => y.GetValue(act));

            ////DateTime dt1 = new DateTime(2020, 10,11,0,0,0);
            ////DateTime dt2 = new DateTime(2020, 11, 13, 0, 0, 0);
            ////var tt = dt1.Subtract(dt2).TotalSeconds;

            ////var ff = new StringBuilder();
            ////var fff = ff.ToString();

            ////for (int im = 0; im < 1000000; im++)
            ////{
            ////    Console.Write(im);
            ////}

            //var intList = new List<int>().AddItems(1,2,3);
            //var strList = new List<string>().AddItems("one").AddItems("two");

            //var name = "Description";
            //var descs = Assembly.GetExecutingAssembly().GetTypes().Where(y => y.IsClass)
            //    .Select(typ => typ.GetProperties()
            //    .Where(y => y.Name == name)
            //    .Select(y => y.GetValue(Activator.CreateInstance(typ))))
            //    .SelectMany(y => y);

            //int[] integ = new[] {1};
            //var jhj = integ.Take(2);

            //IEnumerable<SomeData> data = null;
            //var emptyInfoRecords = data?.Where(y => string.IsNullOrWhiteSpace(y.Info));
            //var setFlag = data?.Any(y => y.Flag);
            //var noFlag = data?.All(y => !y.Flag);
            //var uniqueCouters = data?.Select(y => y.Counter).Distinct();
            //var bigCouter = data?.FirstOrDefault(y => y.Counter == 10);
            //var twoCouters = data?.Where(y => y.Counter == 0).Take(2);

            //var first = "Привет";
            //var second = "прИВет";

            //Console.WriteLine(first == second); // false

            //Console.WriteLine(String.Equals(first, second, StringComparison.CurrentCultureIgnoreCase)); // true

            //// Менее интересные способы
            //Console.WriteLine(first.ToLower() == second.ToLower()); // true
            //Console.WriteLine(first.ToUpper() == second.ToUpper()); // true

            //Console.ReadLine();

            //var firstStr = "first";
            //var secondStr = "second";
            //var thirdStr = "third";

            //var strs = string.Join("", new[] {firstStr, secondStr, thirdStr});

            //// Можно вот так
            //var res1 = firstStr + secondStr + thirdStr;
            //var res2 = $"{firstStr}{secondStr}{thirdStr}";
            //var res3 = String.Concat(firstStr, secondStr, thirdStr);

            //int[] strs = null;

            //var t = strs?.First();

            //var num = ReverseNumber(701);


            //var propertyInfos = typeof(string).GetProperties();

            //var e = new List<int?>() {1, 2};
            //e.Clear();
            //e.Add(null);
            //var c = e.Where(t => t != null).ToArray();
            //foreach (var s in c)
            //{

            //}
            //bool k = c is null;
            //var q = (Queue<int>) e.OrderByDescending(y => y);
            //Console.ReadLine();

            //var e = new int[0];
            //var t = e is null;
            //var s = e.Any();

            //var e = new Dictionary<string, List<int>>();
            //e.Add("a", new List<int>(){1,2});
            //var a = e["a"];
            //a[1] = 10;

            //var a = new OrderedDictionary();
            //a.Add(2, "a");
            //a.Add(1, "b");

            //var a = (object)null;
            //var b = (object)3;
            //var d = a != null && a.Equals(b);
            //try
            //{
            //    var c = (double)(object)b;
            //}
            //catch (Exception e)
            //{
            //    var t = e.GetType();
            //}

            //var e = new Dictionary<string, List<int>>
            //{
            //    {"1", new List<int> {1}}, {"2", new List<int> {2}}, {"3", new List<int> {3}}
            //};

            //var t = new string[e.Keys.Count];
            //e.Keys.CopyTo(t, 0);
            //foreach (var r in t)
            //{
            //    e[r] = e[r].Where(y => y > 1).ToList();
            //}

            //double a = 0d;
            //var t = a == 0;

            //Task.Factory.StartNew(() => Method1(5000));
            ////Thread.Sleep(1000);
            //Task.Factory.StartNew(() => Method1(10000));
            ////Thread.Sleep(1000);
            //Task.Factory.StartNew(() => Method1(2000));
            ////Thread.Sleep(1000);
            //Console.ReadLine();

            //var a = new int[]{1,2,3};
            //var b = (int[])(object)a;
            //b[0] = 20;
            //Console.ReadLine();

            //var e = new Prop().GetFields();

            //var mt = new MT();

            //var thdPush = new Thread(mt.Process1);
            //var thdPop = new Thread(mt.Process2);

            //thdPush.Start();
            //thdPop.Start();

            //object a = 5.1;
            //int? b = null;
            //var c = a is int?;
            //b = (int?) a;

            //Type a = null;
            //var b = a.IsValueType;

            //IEnumerable<string> bonuses = null;
            //var bonusesArr = bonuses as string[] ?? bonuses.ToArray();

            //var cl = new Prop();
            //cl.Method();

            var a = new List<int> {1,2,3};
            var b = ((int[])a.ToArray().Clone()).ToList();


        }

        private static void Method1(int a)
        {
            if (Monitor.IsEntered(Dict))
                Monitor.Exit(Dict);

            Monitor.Enter(Dict);

            Thread.Sleep(a);
            Console.WriteLine($"Method{a}");
            Dict.Add(a.ToString(), a);

            //lock (Dict)
            //{
            //    Thread.Sleep(a);
            //    Console.WriteLine($"Method{a}");
            //}
        }

        public static int ReverseNumber(int a)
        {
            int result = 0;
            while (a != 0)
            {
                var ost = a % 10;
                result = result * 10 + ost;
                a = (a / 10);
            }
            //result = result * 10 + a;

            return result;
        }
    }

    class Prop
    {
        public string a { get; }

        public double b => 4;

        public List<int> c => new List<int>() {1, 2, 3};

        public Dop f => new Dop();

        public string Desc => "PROP";

        [Description("Дарова")]
        public void Method()
        {
            var cl = MethodBase.GetCurrentMethod().Name;
            var descr = this.GetElementDescription(cl);
        }

        public string ss= "fff";

    }

    class Dop
    {
        public int d => 5;

        public string Desc => "DOP";
    }

    public class SomeClass
    {
        public int[] Arr;

        public SomeClass()
        {
            Arr = new int[10000];
        }

        public override string ToString()
        {
            return string.Join(",", Arr);
        }

    }

    class MT
    {

        public void Process1()
        {
            for (; ; )
            {
                var obj = new SomeClass();
                push(obj);
            }
        }
        public void Process2()
        {
            for (; ; )
            {
                pop();
            }
        }

        Queue<SomeClass> queue = new Queue<SomeClass>();

        void push(SomeClass obj)
        {
            lock (queue) {
                queue.Enqueue(obj);
            }
        }

        void pop()
        {
            lock (queue) {
                if (queue.Any()) {

                    var t = queue.Dequeue();
                    //Console.Clear();
                    Console.WriteLine(t);
                    //Thread.Sleep(1000);
                }
            }
        }
    }
}
