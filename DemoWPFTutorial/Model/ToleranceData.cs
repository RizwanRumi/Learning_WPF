using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPFTutorial.Model
{
    public class ToleranceData
    {
        public bool IsSelected { get; set; }
        public int Nr { get; set; }
        public string Type { get; set; }
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        public int Int3 { get; set; }
        public string VarMin { get; set; }
        public string VarMax { get; set; }
        public string Comment { get; set; }
    }
}
