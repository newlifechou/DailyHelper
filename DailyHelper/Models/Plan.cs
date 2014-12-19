using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyHelper.Models
{
    public class Plan
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<DateTime>  StartTime { get; set; }
        public Nullable<DateTime>  EndTime { get; set; }
        public int Priority { get; set; }
        public bool IsFinished { get; set; }
        public string Remark { get; set; }
        public bool NeedRemind { get; set; }
        public Nullable<DateTime>  RemindTime { get; set; }

    }
}
