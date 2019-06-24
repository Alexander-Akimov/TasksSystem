using System;

namespace TaskManager.Lib
{
    public class TaskStartedEventArgs : EventArgs
    {
        public Object Obj { get; private set; }
        public TaskStartedEventArgs(Object o)
        {
            this.Obj = o;
        }
    }
}
