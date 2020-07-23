using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace LocalizationTool.Models
{
    public class LocalizationModel
    {

        private Dictionary<string, LocalizationItem> Schema { get; } = new Dictionary<string, LocalizationItem>();

        public LocalizationModel(List<string> labels,
                                 List<string> locales)
        {
            var item = new LocalizationItem(locales);

            foreach (var label in labels.Where(label => !Schema.ContainsKey(label)))
                Schema.Add(label, item);
        }

        public string ToJson()
        {
            var ordered = Schema
                          .OrderBy(s => s.Key)
                          .ToDictionary(k => k.Key, v => v.Value);
            return JsonConvert.SerializeObject(ordered, Formatting.Indented);
        }

    }
}