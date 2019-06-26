using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Lib
{
    public enum PriorityEnum
    {
        VeryLow,
        Low,
        Middle,
        High,
        VeryHigh
    }
    public static class TaskPriority
    {
        public static IEnumerable<PriorityEnum> Values
        {
            get
            {
                return Enum.GetValues(typeof(PriorityEnum))
                    .Cast<PriorityEnum>()
                    .OrderByDescending(pr => pr)
                    .ToList();
            }
        }
    }
}
