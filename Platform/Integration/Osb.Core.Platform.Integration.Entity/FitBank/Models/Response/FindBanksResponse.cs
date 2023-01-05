using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindBanksResponse
    {
        public IEnumerable<Bank> Banks { get; set; }

        public static FindBanksResponse Create(IEnumerable<Bank> Banks)
        {
            return new FindBanksResponse
            {
                Banks = Banks
            };
        }
    }
}