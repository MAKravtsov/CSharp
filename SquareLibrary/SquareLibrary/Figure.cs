using System;

namespace SquareLibrary
{
    public abstract class Figure
    {
        public readonly string Name;

        protected Figure(string name)
        {
            Name = name;
        }

        public abstract double Area();
    }
}
