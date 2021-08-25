using System;

namespace ConsoleAppVsCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new Rec("4", 4);
            var b = a with { Str = "5" };
        }

        public record Rec {
            public string Str { get; init; }

            public int Num { get; init; }

            public Rec(string str, int num)
            {
                Str = str;
                Num = num;
            }
        }
    }
}
