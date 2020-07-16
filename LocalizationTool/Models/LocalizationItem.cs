using System.Collections.Generic;

namespace LocalizationTool.Models
{
    public class LocalizationItem
    {

        public Dictionary<string,string> Values { get; set; } = new Dictionary<string, string>();

        public LocalizationItem(List<string> locales)
        {
            foreach (var locale in locales)
                Values.Add(locale, "");
        }
    }
}