using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Lib
{
    public class TaskManagerImpl : ITaskManager
    {
        private List<UserTaskBase> _taskList = new List<UserTaskBase>();

        public void AddTask(UserTaskBase task)
        {
            _taskList.Add(task);
        }       

        public async void StartTasksAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                var waitingTasks = _taskList.Where(task => task.Status == TaskStatus.Waiting).ToList();

                if (waitingTasks.Count == 0) return;

                foreach (var task in TaskPriority.Values)
                {
                    var taskToRun = waitingTasks.FirstOrDefault(wt => wt.Priority == task);
                    if (taskToRun == null) continue;

                    taskToRun.Stop += this.HandleTaskStop;
                    taskToRun?.Run();
                    return;
                }
            });
        }
        private void HandleTaskStop(Object obj, TaskStoppedEventArgs e)
        {
            StartTasksAsync ();
            var task = obj as UserTaskBase;
            if (task != null)
                task.Stop -= this.HandleTaskStop;
        }
        public void StopAllTasks()
        {
            var waitingTasks = _taskList.Where(task => task.Status == TaskStatus.Running).ToList();

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
