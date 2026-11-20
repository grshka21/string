using System;
using System.Linq;

namespace StringsPractice
{
    public static class TextAnalyzer
    {
        public static void Analyze(string text)
        {
            int charsWithSpaces = text.Length;
            int charsWithoutSpaces = text.Count(c => !char.IsWhiteSpace(c));

            char[] wordSeparators = { ' ', ',', '.', '!', '?', '\r', '\n', '\t' };
            string[] words = text
                .Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim())
                .ToArray();

            char[] sentenceSeparators = { '.', '!', '?' };
            int sentenceCount = text
                .Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Count(s => !string.IsNullOrWhiteSpace(s));

            string longestWord = words.OrderByDescending(w => w.Length).FirstOrDefault() ?? "";
            string shortestWord = words.OrderBy(w => w.Length).FirstOrDefault() ?? "";

            var topWords = words
                .GroupBy(w => w.ToLower())
                .Select(g => new { Word = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5);

            Console.WriteLine($"Символов (с пробелами): {charsWithSpaces}");
            Console.WriteLine($"Символов (без пробелов): {charsWithoutSpaces}");
            Console.WriteLine($"Количество слов: {words.Length}");
            Console.WriteLine($"Количество предложений: {sentenceCount}");
            Console.WriteLine($"Самое длинное слово: {longestWord}");
            Console.WriteLine($"Самое короткое слово: {shortestWord}");
            Console.WriteLine("Топ-5 частых слов:");
            foreach (var item in topWords)
            {
                Console.WriteLine($"  {item.Word}: {item.Count}");
            }
        }
    }
}
