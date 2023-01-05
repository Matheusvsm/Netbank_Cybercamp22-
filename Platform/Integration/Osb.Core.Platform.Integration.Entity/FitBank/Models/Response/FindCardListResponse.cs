using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindCardListResponse
    {
        public IEnumerable<Card> Cards { get; set; }

        public static FindCardListResponse Create(IEnumerable<Card> Cards)
        {
            return new FindCardListResponse
            {
                Cards = Cards
            };
        }
    }
}