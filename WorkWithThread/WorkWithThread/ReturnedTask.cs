using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WorkWithThread
{
    class ReturnedTask
    {
        public void General()
        {
            var t = Task<string>.Factory.StartNew(() => "Hi, my friend!");
            Console.WriteLine(t.Result);

            var x = new Task<Book>(() => new Book("Левша", "Чехов"));
            x.Start();
            Book book = x.Result;
            Console.WriteLine($"{ book.Name} {book.Author}");

            Console.Read();
        }
    }

    class Book
    {
        public string Name;
        public string Author;

        public Book (string name, string author)
        {
            Name = name;
            Author = author;
        }
    }

}
