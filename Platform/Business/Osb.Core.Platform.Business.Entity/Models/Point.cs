using System;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class Point
    {
        public long PointId { get; set; }
        public long AccountId { get; set; }
        public long Value { get; set; }  
        public DateTime Date { get; set; } 

        public Point(long AccountId, long value, DateTime date)
        {
            AccountId = accountId;
            Value = value;
            Date = date;
        }
    }
}