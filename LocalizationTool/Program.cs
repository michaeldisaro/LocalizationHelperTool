using System;
using System.Collections.Generic;
using System.IO;
using LocalizationTool.Components;
using LocalizationTool.Helpers;
using LocalizationTool.Models;

namespace LocalizationTool
{
    class Program
    {

        public static void Main(string[] args)
        {
            var locales = new List<string> {"it-IT"};
            var matcher = new Matcher(args[0]);
            
            var content = matcher.SearchContentInTags();
            var contentJson = new ContentReplacementModel(content,locales).ToJson();
            File.WriteAllText("C:\\contents.json",contentJson);
            
            // create localization.json with labels
            var matches = matcher.SearchLocalizationComponentLabels(args[1]);
            var localizationJson = new LocalizationModel(matches,locales).ToJson();
            File.WriteAllText("C:\\localization.json",localizationJson);
        }

    }
}