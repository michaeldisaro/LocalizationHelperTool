using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LocalizationTool.Helpers
{
    public static class DictionaryHelper
    {

        public static void AddListItem<TKey, TListValue>(this Dictionary<TKey, List<TListValue>> dictionary,
                                                         TKey key,
                                                         TListValue value)
        {
            if(!dictionary.ContainsKey(key))
                dictionary.Add(key,new List<TListValue>());
            dictionary[key].Add(value);
        }

        public static void PrettyPrint<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            foreach (var dictionaryKey in dictionary.Keys)
            {
                Console.WriteLine(dictionaryKey);
                foreach (var item in dictionary[dictionaryKey] as List<string>)
                    Console.WriteLine($"\t{item}");
            }
        }
    }
}