using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public static class Extensions
    {
        public static List<T> AddItems<T>(this List<T> list, params T[] pars)
        {
            list.AddRange(pars);
            return list;
        }

        public static string GetElementDescription<T>(this T obj, string elementName)
        {
            try {
                var sb = new StringBuilder();

                var elements = typeof(T).GetMember(elementName);

                if (!elements.Any()) { return ""; }

                foreach (var element in elements) {
                    var attribute = (DescriptionAttribute)element.GetCustomAttribute(typeof(DescriptionAttribute));

                    if (attribute == null) { continue; }

                    return attribute.Description;
                }

                return "";
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}
