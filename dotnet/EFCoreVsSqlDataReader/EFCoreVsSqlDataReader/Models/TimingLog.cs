using System;

namespace EFCoreVsSqlDataReader.Models
{
    public class TimingLog
    {
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Context { get; set; }
        public string Query { get; set; }
        public int MilliSeconds { get; set; }
    }
}
