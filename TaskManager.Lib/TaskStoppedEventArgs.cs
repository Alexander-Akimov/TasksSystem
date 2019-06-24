using System;

namespace TaskManager.Lib
{
    public class TaskStoppedEventArgs: EventArgs
    {
        public Object Obj { get; private set; }
        public TaskStoppedEventArgs(Object o)
        {
            this.Obj = o;
        }
    }
}
