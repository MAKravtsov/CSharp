using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public abstract class A
    {
        public static int a;
    }

    public class D : A
    {
        public D()
        {
            D.a = new int();
        }
    }

    public class C : A
    {
        public C()
        {
            C.a = new int();
        }
    }
}
