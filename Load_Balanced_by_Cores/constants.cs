using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Load_Balanced_by_Cores
{
    public class constants
    {
        public static int Cores { get; set; }
        public static int N { get; set; }
        public static int Delay { get; set; }
        public static int MAX { get; set; }
        static constants()
        {
            Cores = Environment.ProcessorCount;
            N = 1000;
            Delay = 3000;
            MAX = 10000000;
        }
    }
}
