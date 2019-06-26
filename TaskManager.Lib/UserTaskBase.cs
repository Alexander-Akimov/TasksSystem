using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Lib
{
    public class UserTaskBase
    {
        private readonly Action<object> action;

        public Guid TaskId { get; }
        public string TaskName { get; }
        public TaskPriorities Priority { get; }
        public TaskStatus Status { get; private set; }        

        // public event EventHandler<TaskCreatedEventArgs> Create;
        public event EventHandler<TaskStartedEventArgs> Start;
        public event EventHandler<TaskStoppedEventArgs> Stop;
        public event EventHandler<TaskErrorEventArgs> Error;

        public UserTaskBase(string name, TaskPriorities priority, Action<Object> action)
        {
            this.TaskId = Guid.NewGuid();
            this.Status = TaskStatus.Waiting;
            this.TaskName = name;
            this.Priority = priority;
            this.action = action;
        }

        public void Run()
        {
            this.Status = TaskStatus.Running;

            var task = Task.Run(() => action.Invoke(TaskName));
            OnTaskStarted(new TaskStartedEventArgs(TaskName));

            try
            {
                task.Wait();                
            }
            catch (Exception ex)
            {
                OnTaskError(new TaskErrorEventArgs(ex));                
            }
            finally
            {
                OnTaskStopped(new TaskStoppedEventArgs(2));
                this.Status = TaskStatus.Completed;
            }
        }

        private void Dispose()
        {
            this.Stop = null;
            this.Error = null;
            this.Start = null;
        }

        protected virtual void OnTaskStarted(TaskStartedEventArgs e)
        {
            var delegates = Start?.GetInvocationList();
            if (delegates == null) return;
            foreach (EventHandler<TaskStartedEventArgs> d in delegates)
                d?.Invoke(this, e);
        }
        protected virtual void OnTaskStopped(TaskStoppedEventArgs e)
        {
            var delegates = Stop?.GetInvocationList();
            if (delegates == null) return;
            foreach (EventHandler<TaskStoppedEventArgs> d in delegates)
                d?.Invoke(this, e);
        }
        protected virtual void OnTaskError(TaskErrorEventArgs e)
        {
            var delegates = Error?.GetInvocationList();
            if (delegates == null) return;
            foreach (EventHandler<TaskErrorEventArgs> d in delegates)
                d?.Invoke(this, e);
        }
    }
}
