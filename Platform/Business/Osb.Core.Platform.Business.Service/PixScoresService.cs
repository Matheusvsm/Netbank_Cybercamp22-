using System;
using  Osb.Core.Platform.Business.Service.Interfaces;
namespace Osb.Core.Platform.Business.Service
{
    public class PixScoresService : IScoresService
    {
        public double TotalIncome { get; set; }
        public DateTime Date { get; set; }

        public PixScoresService(double totalIncome, DateTime date)
        {
            TotalIncome = totalIncome;
            Date = date;
        }
        public int generateScores()
        {
           if (!validateScores())
           {
                return 0;
           }
           else 
           {
                int total = (int)TotalIncome;
                total /= 10;
                return total;
           }
        }

        public bool validateScores()
        {
            if ( TotalIncome <= 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}