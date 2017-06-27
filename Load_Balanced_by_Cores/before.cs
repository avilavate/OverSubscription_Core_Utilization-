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
            List<Task<string>> tasks = new List<Task<string>>();
            for (int i = 0; i < constants.N; i++)
            {
                tasks.Add(Task.Factory.StartNew<string>(() =>
                {
                    double someThingUnused = 0;
                    //Thread.Sleep(constants.Delay);
                    for (int j = 0; j < constants.MAX; j++)
                    {
                        someThingUnused = someThingUnused + new Random(j).Next(10);
                    }
                    return $"Task completed! {someThingUnused}";
                }, TaskCreationOptions.LongRunning));
            }
            while (tasks.Count() > 0)
            {
                var index = Task.WaitAny(tasks.ToArray());
                Console.WriteLine(tasks[index].Result);
                tasks.RemoveAt(index);

            }
        }
    }
}
