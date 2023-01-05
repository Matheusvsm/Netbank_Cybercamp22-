using System.Collections.Generic;
using Osb.Core.Api.Entity;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;


namespace Osb.Core.Api.Repository
{
    public class InputRepository : IInputRepository
    {
        private readonly IDbContext<Input> _context;

        public InputRepository(IDbContext<Input> context)
        {
            _context = context;
        }

        public Input InsertInputLog(Input input, long? userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBody"] = input.Body,
                ["paramMethod"] = input.Method,
                ["paramHeaders"] = input.Headers,
                ["paramUrl"] = input.Url,
                ["paramUserId"] = userId
            };

            return _context.ExecuteWithSingleResult("InsertInputLog", parameters);
        }
    }
}
