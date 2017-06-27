using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Load_Balanced_by_Cores
{
    class Program
    {
        static void Main(string[] args)
        {
            before objBefore = new before();
            //objBefore.OverSubscription();

            after objAfter = new after();
            objAfter.Utilize();

            Console.Read();

        }
    }
}
