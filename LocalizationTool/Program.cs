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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// [0] path to project directory
        /// [1] name of injected Localizer component
        /// </param>
        public static void Main(string[] args)
        {
            var locales = new List<string> {"it-IT"};
            var matcher = new Matcher(args[0]);
            
            /*var content = matcher.SearchContentInTags();
            var contentJson = new ContentReplacementModel(content,locales).ToJson();
            File.WriteAllText("D:\\contents.json",contentJson);*/
            
            // create localization.json with labels
            var matches = new List<string>();
            matches.AddRange(matcher.SearchLocalizationComponentLabels(args[1])); 
            matches.AddRange(matcher.SearchDisplayNameLabels());
            matches.AddRange(matcher.SearchValidationMessageLabels());

            var localizationJson = new LocalizationModel(matches,locales).ToJson();
            File.WriteAllText("D:\\localization.json",localizationJson);
        }

    }
}