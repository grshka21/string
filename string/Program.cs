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

            Console.WriteLine("\n=== ЗАДАНИЕ 2: ГЕНЕРАТОР ОТЧЁТА ===");
            Sale[] sales = new Sale[]
            {
                new Sale("Клавиатура", 3, 2500.00m),
                new Sale("Мышь беспроводная", 5, 1200.50m),
                new Sale("Монитор 27\"", 2, 18900.00m)
            };

            var reportBuilder = new ReportBuilder();
            string report = reportBuilder.BuildReport(sales);
            Console.WriteLine(report);
            reportBuilder.SaveToFile("sales_report.txt", report);

            Console.WriteLine("\n=== ЗАДАНИЕ 3: ШИФР ЦЕЗАРЯ ===");
            string secret = "Hello, World! C# 2026.";
            int key = 3;

            string encrypted = CaesarCipher.Encrypt(secret, key);
            string decrypted = CaesarCipher.Decrypt(encrypted, key);

            Console.WriteLine($"Исходный текст: {secret}");
            Console.WriteLine($"Зашифровано:    {encrypted}");
            Console.WriteLine($"Расшифровано:   {decrypted}");

            Console.ReadKey();
        }
    }
}
