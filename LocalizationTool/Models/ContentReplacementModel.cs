using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LocalizationTool.Models
{
    public class ContentReplacementModel
    {

        private List<ContentItem> Items { get; } = new List<ContentItem>();

        public ContentReplacementModel(Dictionary<string, List<string>> contentDictionary,
                                       List<string> locales)
        {
            var contents = contentDictionary.Keys;
            foreach (var content in contents)
            {
                var item = new ContentItem(locales)
                {
                    Content = content,
                    Files = contentDictionary[content]
                };

                Items.Add(item);
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(Items, Formatting.Indented);
        }

    }
}