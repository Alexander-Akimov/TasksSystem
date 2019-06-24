using System;

namespace TaskManager.Lib
{
    public class TaskErrorEventArgs : EventArgs
    {
        public Object Obj { get; private set; }
        public TaskErrorEventArgs(Object o)
        {
            this.Obj = o;
        }
    }
}
