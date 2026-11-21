using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCROO_Frontend
{
    public class Extraction
    {
        public string Location { get; set; } = "";
        public string Timing { get; set; } = "";
        public string Text { get; set; } = "";  
    }

    public static class ExtractionStore
    {
        public static ObservableCollection<Extraction> Items { get; } = new();
    }
}
