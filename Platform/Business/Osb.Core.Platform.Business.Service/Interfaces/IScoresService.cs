using System;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IScoresService
    {
         public double TotalIncome { get; set; }
         public DateTime Date {get; set;}

         public abstract int generateScores();
         public abstract bool validateScores();
    }
}

         