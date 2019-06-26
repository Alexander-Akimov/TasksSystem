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


            var highTask1 = new UserTaskBase("High priority Task1", PriorityEnum.High, (object obj) =>
            {
                Console.WriteLine(obj as string);
                Thread.Sleep(2000);
            });

            var highTask2 = new UserTaskBase("Very High priority Task2", PriorityEnum.VeryHigh, (object obj) =>
            {
                Console.WriteLine(obj as string);
                Thread.Sleep(2000);
            });

            var lowTask = new UserTaskBase("Low priority Task", PriorityEnum.Low, (object obj) =>
            {
                Console.WriteLine(obj as string);
                Thread.Sleep(2000);
            });

            taskManager.AddTask(highTask1);
            taskManager.AddTask(lowTask);
            taskManager.AddTask(highTask2);

            taskManager.StartTasksAsync();

            highTask2 = new UserTaskBase("Very High priority Task1", PriorityEnum.VeryHigh, (object obj) =>
            {
                Console.WriteLine(obj as string);
                Thread.Sleep(2000);
            });

            taskManager.AddTask(highTask2);

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void RunTaskWithException()
        {
            var task = Task.Run(() => throw new Exception("HEllo world"));
            try
            {


                task.Wait();

            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
