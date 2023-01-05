/*using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class PointRepositoy : IPointRepository
    {
        private readonly IDbContext<Point> _context;

        public PointRepository(IDbContext<Point> context)
        {
            this._context = context;
        }

        public Point UpdatePoint(Point point, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = point.AccountId,
                ["paramValue"] = point.Value,
                ["paramDate"] = point.Date
            };
             // FALTA DAQUI PRA BAIXO
            Account accountResult = _context.ExecuteWithSingleResult("InsertAccount", parameters, transactionScope);

            return accountResult;             
        }

        public IEnumerable<Point> GetListByAccountID()
        {

        }

        public IEnumerable<Point> GetListByScore()
        {

        }

        public IEnumerable<Point> GetListByMaxScore()
        {

        }

        public IEnumerable<Point> GetListByMinScore()
        {

        }

        public IEnumerable<Point> GetListByCreacionDate()
        {

        }
    }
}*/