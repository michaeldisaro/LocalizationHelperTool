using System;
using System.Collections.Generic;

namespace LocalizationTool.Helpers
{
    public static class ListHelper
    {

        public static void PrettyPrint<T>(this List<T> list)
        {
            foreach (var item in list)
                Console.WriteLine($"{item.ToString()}");
        }

    }
}