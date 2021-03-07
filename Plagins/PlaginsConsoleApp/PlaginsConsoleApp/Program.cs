using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaginsLibrary;

namespace PlaginsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started plugin app..");
            try
            {
                PlaginLoader loader = new PlaginLoader();
                loader.LoadPlugins();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Plugins couldn't be loaded: {e.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            while (true)
            {
                try
                {
                    //Let the user fill in an plugin name
                    Console.Write("> ");
                    int num = int.Parse(Console.ReadLine() ?? string.Empty);

                    foreach (var plagin in (from plagin in PlaginLoader.Plugins let result = plagin.Calc(num) where result is null select plagin))
                    {
                        Console.WriteLine($"Ошибка \"{plagin.Name}\"");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Caught exception: {e.Message}");
                }
            }
        }
    }
}
