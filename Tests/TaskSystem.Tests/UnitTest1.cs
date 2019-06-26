using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.Lib;

namespace TaskSystem.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Action<Object> r = (obj) =>
            {
                Thread.Sleep(5000);
            };

            //var task = new Task(r);
            ITaskManager taskManager = new TaskManagerImpl();

            var task = new UserTaskBase("Main Task", TaskPriorityUtil.High, r);
            taskManager.AddTask(task);


            //task.CreationOptions
        }
    }
}
