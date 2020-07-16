using System;
using System.Collections.Generic;

namespace LocalizationTool.Models
{
    public class ContentItem
    {

        public string Content { get; set; }

        public List<string> Files { get; set; }

        public Dictionary<string, string> LocalizedLabels { get; set; } = new Dictionary<string, string>();

        public ContentItem(List<string> locales)
        {
            foreach (var locale in locales)
                LocalizedLabels.Add(locale, "");
        }

    }
}