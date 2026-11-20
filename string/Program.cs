using System;

namespace StringsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sampleText = "C# — мощный язык программирования. Строки в C# неизменяемы! " +
                                "Это делает строки безопасными для многопоточности, но требует внимания к памяти.";

            Console.WriteLine("=== ЗАДАНИЕ 1: АНАЛИЗАТОР ТЕКСТА ===");
            TextAnalyzer.Analyze(sampleText);

            Console.ReadKey();
        }
    }
}
