using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Lib
{
    public class UserTaskBase
    {
        public string TaskName { get; set; }
        public TaskPriority Priority { get; set; }

        // public event EventHandler<TaskCreatedEventArgs> Create;
        public event EventHandler<TaskStartedEventArgs> Start;
        public event EventHandler<TaskStoppedEventArgs> Stop;
        public event EventHandler<TaskErrorEventArgs> Error;

        public UserTaskBase()
        {

        }

        public void DoWork()
        {
            OnTaskStarted(new TaskStartedEventArgs(1));


            OnTaskStopped(new TaskStoppedEventArgs(2));
        }

        protected virtual void OnTaskStarted(TaskStartedEventArgs e)
        {
            var delegates = Start?.GetInvocationList();
            foreach (EventHandler<TaskStartedEventArgs> d in delegates)
                d?.Invoke(this, e);
        }
        protected virtual void OnTaskStopped(TaskStoppedEventArgs e)
        {
            var delegates = Stop?.GetInvocationList();
            foreach (EventHandler<TaskStoppedEventArgs> d in delegates)
                d?.Invoke(this, e);
        }
        protected virtual void OnTaskError(TaskErrorEventArgs e)
        {
            var delegates = Error?.GetInvocationList();
            foreach (EventHandler<TaskErrorEventArgs> d in delegates)
                d?.Invoke(this, e);
        }
    }
}
