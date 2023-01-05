using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using System;

namespace Osb.Core.Platform.Auth.Service
{
    public class ActionFunctionService : IActionFunctionService
    {
        private readonly IActionFunctionRepositoryFactory _actionFunctionRepositoryFactory;
        private readonly IConnectionFactory _connectionFactory;

        public ActionFunctionService(
            IActionFunctionRepositoryFactory actionFunctionRepositoryFactory,
            IConnectionFactory connectionFactory
        )
        {
            _actionFunctionRepositoryFactory = actionFunctionRepositoryFactory;
            _connectionFactory = connectionFactory;
        }
    }
}
