using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TranslationDictionary
{
    static class Dictionary
    {
        static Dictionary<string, string> _dictionary;

        static Dictionary()
        {
            _dictionary = new Dictionary<string, string>()
            {
                { "I", "boy" },
                { "go", "run" },
                { "to", "to" },
                { "school", "cinema" }
            };
        }

        public static string Translate(string text)
        {
            var matches = Regex.Matches(text, @"\w+");
            StringBuilder result = new StringBuilder();
            int from = 0;
            foreach (Match match in matches)
            {
                result.Append(text[from..match.Index]);
                from = match.Index + match.Length;
                result.Append(GetWordTranslation(match.Value));
            }
            return result.ToString();
        }

        static string GetWordTranslation(string word)
        {
            if (!_dictionary.ContainsKey(word))
            {
                Console.WriteLine($"Having trouble finding a translation for the word \"{word}\"\n" +
                                   "Type your translation and press <Enter>");
                _dictionary[word] = Console.ReadLine();
            }
            return _dictionary[word];
        }
    }
}
