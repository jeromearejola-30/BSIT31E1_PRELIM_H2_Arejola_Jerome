using System;
using System.IO;
using System.Text.Json; 

namespace ConsoleApp1
{
    public class JsonFileReader : BaseFileReader
    {
        
        public override string SupportedFormat => "JSON";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"[JSON Engine] Processing {Path.GetFileName(filePath)}...");
            Console.WriteLine(" -> Opening JSON stream...");

            
            string rawText = File.ReadAllText(filePath);
            using (JsonDocument doc = JsonDocument.Parse(rawText))
            {
                int rootElementCount = 0;

               
                if (doc.RootElement.ValueKind == JsonValueKind.Object)
                {
                    foreach (var property in doc.RootElement.EnumerateObject()) { rootElementCount++; }
                }
                else if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    rootElementCount = doc.RootElement.GetArrayLength();
                }

                Console.WriteLine($" -> Parsed {rootElementCount} root properties.");
            }

          
            string preview = rawText.Length > 100 ? rawText.Substring(0, 100) + "..." : rawText;

            Console.WriteLine("\n--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}