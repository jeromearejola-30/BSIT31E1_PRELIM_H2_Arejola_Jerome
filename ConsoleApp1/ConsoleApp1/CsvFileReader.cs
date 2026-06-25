using System;
using System.IO;

namespace ConsoleApp1
{
    public class CsvFileReader : BaseFileReader
    {
      
        public override string SupportedFormat => "CSV";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"[CSV Engine] Processing {Path.GetFileName(filePath)}...");
            Console.WriteLine(" -> Opening CSV stream...");

          
            string[] lines = File.ReadAllLines(filePath);
            int rowCount = lines.Length;
            int columnCount = 0;

           
            if (rowCount > 0)
            {
                string[] columns = lines[0].Split(',');
                columnCount = columns.Length;
            }

            Console.WriteLine($" -> Detected {rowCount} rows and {columnCount} columns.");

            
            string rawText = File.ReadAllText(filePath);
            string preview = rawText.Length > 100 ? rawText.Substring(0, 100) + "..." : rawText;

            Console.WriteLine("\n--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}