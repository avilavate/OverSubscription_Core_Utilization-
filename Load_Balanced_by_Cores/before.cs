using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Load_Balanced_by_Cores
{
    class before
    {
      public void OverSubscription()
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < constants.N; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(constants.Delay);
                    Console.WriteLine("Task completed!");
                }, TaskCreationOptions.LongRunning));
            }
        }
    }
}
