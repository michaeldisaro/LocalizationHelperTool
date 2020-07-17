using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LocalizationTool.Helpers;

namespace LocalizationTool.Components
{
    public class Matcher
    {

        private readonly string _appPath;

        private const string LocalizationComponentPattern = "\\[\\\"([a-zA-Z0-9_\\{\\}]*)\\\"";

        private const string TagContentPattern = ">(.*?)<";
        
        private const string DisplayNamePattern = "\\[\\s*Display\\s*\\(Name\\s*\\=\\s*\\\"([a-zA-Z0-9_\\{\\}]*)\\\"\\s*\\)\\s*\\]";

        private const string ValidationMessagePattern = "ErrorMessage\\s*\\=\\s*\\\"([a-zA-Z0-9_\\{\\}]*)\\\"";
        
        private const string ValueAttributePattern = "\\svalue=\\\"(.*)\\\"";

        public Matcher(string appPath)
        {
            _appPath = appPath;
        }

        public List<string> SearchLocalizationComponentLabels(string injectedLocalizationComponentName)
        {
            var results = new List<string>();
            var sourceFiles = Directory.GetFiles(_appPath, "*.cshtml", SearchOption.AllDirectories);
            foreach (var sourceFile in sourceFiles)
            {
                var content = File.ReadAllText(sourceFile);
                var matches =
                    Regex.Matches(content, $"{injectedLocalizationComponentName}{LocalizationComponentPattern}");
                results.AddRange(matches.Select(m => m.Groups).Select(g => g[1].Value));
            }

            return results;
        }
        
        public List<string> SearchDisplayNameLabels()
        {
            var results = new List<string>();
            var sourceFiles = Directory.GetFiles(_appPath, "*.cshtml.cs", SearchOption.AllDirectories);
            foreach (var sourceFile in sourceFiles)
            {
                var content = File.ReadAllText(sourceFile);
                var matches =
                    Regex.Matches(content, $"{DisplayNamePattern}");
                results.AddRange(matches.Select(m => m.Groups).Select(g => g[1].Value));
            }

            return results;
        }
        
        public List<string> SearchValidationMessageLabels()
        {
            var results = new List<string>();
            var sourceFiles = Directory.GetFiles(_appPath, "*.cshtml.cs", SearchOption.AllDirectories);
            foreach (var sourceFile in sourceFiles)
            {
                var content = File.ReadAllText(sourceFile);
                var matches =
                    Regex.Matches(content, $"{ValidationMessagePattern}");
                results.AddRange(matches.Select(m => m.Groups).Select(g => g[1].Value));
            }

            return results;
        }

        public Dictionary<string, List<string>> SearchContentInTags()
        {
            var results = new Dictionary<string, List<string>>();
            var sourceFiles = Directory.GetFiles(_appPath, "*.cshtml", SearchOption.AllDirectories);
            foreach (var sourceFile in sourceFiles)
            {
                var content = File.ReadAllText(sourceFile);
                var matches = Regex.Matches(content, $"{TagContentPattern}",RegexOptions.Singleline);
                var groups = matches.Select(m => m.Groups).Select(g => g[1].Value);
                foreach (var capture in groups)
                {
                    var match = capture.Trim();
                    if (string.IsNullOrEmpty(match)) continue;
                    results.AddListItem(match, sourceFile);
                }
            }

            return results;
        }

    }
}