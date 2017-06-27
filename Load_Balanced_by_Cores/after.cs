using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Load_Balanced_by_Cores
{
    class after
    {
        public void Utilize()
        {
            var counter = constants.N;
            List<Task<string>> tasks = new List<Task<string>>();

            for (int i = 0; i < constants.Cores; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    double someThingUnused = 0;
                    //Thread.Sleep(constants.Delay);
                    for (int j = 0; j < constants.MAX; j++)
                    {
                        someThingUnused = someThingUnused + new Random(j).Next(10);
                    }
                    return $"Task completed! {someThingUnused}";
                }));
            }
            counter = counter - constants.Cores;

            while ((tasks.Count() > 0) == true)
            {
                var index = Task.WaitAny(tasks.ToArray());
                Console.WriteLine(tasks[index].Result);
                tasks.RemoveAt(index);
                if (counter > 0)
                {
                    counter = counter - 1;
                    tasks.Add(Task.Factory.StartNew<string>(() =>
                    {
                        double someThingUnused = 0;
                        //Thread.Sleep(constants.Delay);
                        for (int j = 0; j < constants.MAX; j++)
                        {
                            someThingUnused = someThingUnused + new Random(j).Next(10);
                        }
                        return $"Task completed! {someThingUnused}";
                    }));
                }
            }
        }

    }
}
