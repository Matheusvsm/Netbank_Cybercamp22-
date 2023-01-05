using Osb.Core.Platform.Common.Entity.Models;
using System.Collections.Generic;
using System;
using System.Linq;
namespace Osb.Core.Platform.Business.Entity.Models
{
    public class Account : BaseEntity
    {
        public long AccountId { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public long Type { get; set; }
        public string AccountKey { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string SPBBank { get; set; }
        public string SPBBankBranch { get; set; }
        public string SPBBankAccount { get; set; }
        public string SPBBankAccountDigit { get; set; }
        public bool IsFixedAccount { get; set; }
        public ICollection<Point> Points { get; set; } = new List<Point>();
        public long Score { get; set; }

        public static Account Create(long companyId, string name, string taxId, string accountKey, long userId)
        {
            return new Account
            {
                CompanyId = companyId,
                Name = name,
                TaxId = taxId,
                AccountKey = accountKey,
                CreationUserId = userId,
                UpdateUserId = userId,
                Score = 0
            };
        }
        public void addPoint(long value)
        {
            Points.Add(new Point(value, DateTime.Now));
            Score = totalPoints();
        }
        public void removePoint(long value, DateTime date)
        {
            Points.Remove(Points.FirstOrDefault(p => p.Date == date && p.Value == value));
            Score = totalPoints();
        }

        public int totalPoints()
        {
            int sum = 0;
            foreach (Point point in Points)
            {
                sum += point.Value;
            }
            return sum;
        }
    }
}