using System;
using System.IO;
using System.Linq;
using System.Xml.Linq; 
namespace ConsoleApp1
{
    public class XmlFileReader : BaseFileReader
    {
       
        public override string SupportedFormat => "XML";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"[XML Engine] Processing {Path.GetFileName(filePath)}...");
            Console.WriteLine(" -> Opening XML stream...");

            XDocument xmlDoc = XDocument.Load(filePath);

            
            string rootName = xmlDoc.Root?.Name.LocalName ?? "None";
            int descendantCount = xmlDoc.Descendants().Count();

            Console.WriteLine($" -> Root element: <{rootName}> with {descendantCount} descendant nodes.");

          
            string rawText = File.ReadAllText(filePath);
            string preview = rawText.Length > 100 ? rawText.Substring(0, 100) + "..." : rawText;

            Console.WriteLine("\n--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}