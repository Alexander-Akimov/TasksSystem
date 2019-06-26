using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Lib;

namespace TaskManager.Util
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var taskManager = new TaskManagerImpl();
            taskManager.StartTasksAsync();


            var highTask1 = new UserTaskBase("High priority Task1", TaskPriorities.High, (object obj) =>
            {
                Console.WriteLine(obj as string);
                Thread.Sleep(2000);
            });
            highTask1.Start += (sender, e) =>
            {
                Console.WriteLine($"Start event handler result: {e.Obj.ToString()}");
            };

            var highTask2 = new UserTaskBase("Very High priority Task2", TaskPriorities.VeryHigh, (object obj) =>
            {
                Console.WriteLine(obj as string);
                Thread.Sleep(2000);
            });
            highTask2.Stop += (sender, e) =>
            {
                Console.WriteLine($"Stop event handler result: {e.Obj.ToString()}");
            };

            var lowTask = new UserTaskBase("Low priority Task", TaskPriorities.Low, (object obj) =>
            {
                Console.WriteLine(obj as string);
                Thread.Sleep(2000);
            });

            taskManager.AddTask(highTask1);
            taskManager.AddTask(lowTask);
            taskManager.AddTask(highTask2);

           

            highTask2 = new UserTaskBase("Very High priority Task1", TaskPriorities.VeryHigh, (object obj) =>
            {
                Console.WriteLine(obj as string);
                Thread.Sleep(2000);
            });

            taskManager.AddTask(highTask2);

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }       
    }
}
