using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    
    public class FileReaderResolver
    {
        
        private readonly List<IFileReader> _availableReaders;

       
        public FileReaderResolver()
        {
            _availableReaders = new List<IFileReader>
            {
                new TextFileReader(),
                new CsvFileReader(),  
                new JsonFileReader(), 
                new XmlFileReader()   
            };
        }

        
        public IFileReader GetReaderForFormat(string format)
        {
            return _availableReaders.FirstOrDefault(r =>
                r.SupportedFormat.Equals(format, StringComparison.OrdinalIgnoreCase));
        }
    }
}