using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Lib
{
    public interface ITaskManager
    {
        void AddTask(UserTaskBase task); // add task to task list
        void StartTask(UserTaskBase task);
        void StartTasksAsync();
        void StopAllTasks();
        List<UserTaskBase> GetTasks();
    }
}
