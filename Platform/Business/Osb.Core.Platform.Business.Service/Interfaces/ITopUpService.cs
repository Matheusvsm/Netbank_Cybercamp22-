using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface ITopUpService
    {
        FindTopUpProductListResult FindTopUpProductList(FindTopUpProductListRequest findTopUpProductsRequest);
        OperationResult Save(GenerateTopUpRequest topUpRequest);
        IEnumerable<TopUp> FindTopUpListByStatus(TopUpStatus status);
        IEnumerable<TopUp> FindTopUpListByStatusAndTopUpDate(TopUpStatus status, DateTime date);
        void GenerateTopUp(TopUp topUp);
        void AuthorizeTopUp(TopUp topUp);
        void Update(TopUp topUp);
        void UpdateStatus(UpdateTopUpStatusRequest updateTopUpStatusRequest);
        FindTopUpProductListByPhoneNumberResult FindTopUpProductListByPhoneNumber(FindTopUpProductListByPhoneNumberRequest findTopUpByPhoneNumberRequest);
        FindTopUpPeriodicListResult FindTopUpPeriodicList(FindTopUpPeriodicListRequest findTopUpPeriodicListRequest);
        void CancelTopUpPeriodic(CancelTopUpPeriodicRequest businessRequest);
    }
}