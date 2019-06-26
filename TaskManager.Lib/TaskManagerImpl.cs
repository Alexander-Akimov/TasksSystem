using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager.Lib
{
    public class TaskManagerImpl : ITaskManager
    {
        private List<UserTaskBase> _taskList = new List<UserTaskBase>();

        private bool running = true;

        public void AddTask(UserTaskBase task)
        {
            _taskList.Add(task);
        }

        public async void StartTasksAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                while (running == true)
                {
                    var waitingTasks = _taskList.Where(task => task.Status == TaskStatus.Waiting).ToList();
                    if (waitingTasks.Count == 0) continue;

                    var runningTasks = _taskList.Where(task => task.Status == TaskStatus.Running).ToList();
                    if (runningTasks.Count > 0) continue;

                    foreach (var taskPriority in TaskPriorityUtil.Values)
                    {
                        var taskToRun = waitingTasks.FirstOrDefault(wt => wt.Priority == taskPriority);
                        if (taskToRun == null) continue;
                        taskToRun?.Run();
                        break;                        
                    }
                    Thread.Sleep(1000);
                }                
            });
        }
        private void HandleTaskStop(Object obj, TaskStoppedEventArgs e)
        {
            StartTasksAsync();
            var task = obj as UserTaskBase;
            if (task != null)
                task.Stop -= this.HandleTaskStop;
        }
        public void StopAllTasks()
        {
            //var waitingTasks = _taskList.Where(task => task.Status == TaskStatus.Running).ToList();
            running = false;
        }

        public List<UserTaskBase> GetTasks()
        {
            throw new NotImplementedException();
        }

        public void StartTask(UserTaskBase task)
        {
            throw new NotImplementedException();
        }
    }
}
