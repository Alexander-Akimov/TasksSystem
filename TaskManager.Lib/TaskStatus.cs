using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Lib
{
    public enum TaskStatus
    {
        Waiting, // задача создана но не запущена
        Completed, // задача завершена
        Running // задача выполняется
    }
}
