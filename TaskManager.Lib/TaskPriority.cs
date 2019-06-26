using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Lib
{
    public enum TaskPriorities
    {
        VeryLow,
        Low,
        Middle,
        High,
        VeryHigh
    }
    public static class TaskPriorityUtil
    {
        public static IEnumerable<TaskPriorities> Values
        {
            get
            {
                return Enum.GetValues(typeof(TaskPriorities))
                    .Cast<TaskPriorities>()
                    .OrderByDescending(pr => pr)
                    .ToList();
            }
        }
    }
}
