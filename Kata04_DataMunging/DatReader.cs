using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04_DataMunging
{
    class DatReader
    {
        public string FileText { get; set; }
        public string[] FileTextLines { get; set; }

        public DatReader(string fileUrl)
        {
            FileText = File.ReadAllText(fileUrl);
            FileTextLines = File.ReadAllLines(fileUrl);
        }
    }
}
