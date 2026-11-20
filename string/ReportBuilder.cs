using System;
using System.IO;
using System.Text;

namespace StringsPractice
{
    public class Sale
    {
        public string Product { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public Sale(string product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }
    }

    public class ReportBuilder
    {
        public string BuildReport(Sale[] sales)
        {
            var sb = new StringBuilder();
            decimal grandTotal = 0;

            sb.AppendLine("ОТЧЁТ О ПРОДАЖАХ");
            sb.AppendLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine(new string('-', 56));
            sb.AppendLine(
                "Товар".PadRight(20) +
                "Кол-во".PadLeft(8) +
                "Цена".PadLeft(13) +
                "Сумма".PadLeft(15));
            sb.AppendLine(new string('-', 56));

            foreach (var sale in sales)
            {
                decimal lineTotal = sale.Quantity * sale.Price;
                grandTotal += lineTotal;

                sb.AppendLine(
                    sale.Product.PadRight(20) +
                    sale.Quantity.ToString().PadLeft(8) +
                    $"{sale.Price:F2}".PadLeft(13) +
                    $"{lineTotal:F2}".PadLeft(15));
            }

            sb.AppendLine(new string('-', 56));
            sb.AppendLine($"ИТОГО:".PadRight(41) + $"{grandTotal:F2}".PadLeft(15));

            return sb.ToString();
        }

        public void SaveToFile(string filePath, string reportContent)
        {
            File.WriteAllText(filePath, reportContent, Encoding.UTF8);
        }
    }
}
