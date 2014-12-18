using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialyHelper.Models
{
    public class Fee
    {
        public int ID { get; set; }
        public DateTime ItemTime { get; set; }
        public string ItemContent { get; set; }
        public Decimal Cost { get; set; }
        public bool HaveInvoice { get; set; }
        public bool IsReimburse { get; set; }
        public Nullable<DateTime> ReimburseTime { get; set; }
    }
}
