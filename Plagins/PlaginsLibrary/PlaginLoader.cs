using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlaginsLibrary
{
    public class PlaginLoader
    {
        
        public static List<IPlagin> Plugins { get; set; }

        public void LoadPlugins()
        {
            try
            {
                Plugins = new List<IPlagin>();

                //Load the DLLs from the Plugins directory
                if (Directory.Exists(Constants.FolderName))
                {
                    string[] files = Directory.GetFiles(Constants.FolderName);
                    foreach (string file in files)
                    {
                        if (file.EndsWith(".dll"))
                        {
                            Assembly.LoadFile(Path.GetFullPath(file));
                        }
                    }
                }

                Type interfaceType = typeof(IPlagin);
                //Fetch all types that implement the interface IPlugin and are a class
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                    .ToArray();
                foreach (Type type in types)
                {
                    //Create a new instance of all found types
                    Plugins.Add((IPlagin)Activator.CreateInstance(type));
                }
            }
            catch (Exception e)
            {
                throw new Exception($"LoadPlugins(): {e.Message}");
            }
        }
    }
}
