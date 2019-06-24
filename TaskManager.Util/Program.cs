using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Lib;

namespace TaskManager.Util
{
    class Program
    {
        static void Main(string[] args)
        {
            //var task = new Task(() => { });
            //Console.WriteLine(task.Status);
            //var queue = new Queue<int>();
            //queue.

            var userTask = new UserTaskBase();

            for (int i = 1; i <= 100; i++)
            {
                var strNum = i.ToString();
                userTask.Stop += (sender, e) =>
                {
                    Console.WriteLine($"{strNum} Stop event handler result: {e.Obj.ToString()}");
                };
            }

            for (int i = 1; i <= 100; i++)
            {
                var strNum = i.ToString();
                userTask.Start += (sender, e) =>
                {
                    Console.WriteLine($"{strNum} Start event handler result: {e.Obj.ToString()}");
                };
            }
           

            Console.ReadKey();

            userTask.DoWork();

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

    }
}
