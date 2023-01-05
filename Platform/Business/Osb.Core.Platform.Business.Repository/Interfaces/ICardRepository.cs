using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface ICardRepository
    {
        ActivateCard Save(ActivateCard activateCard, TransactionScope transactionScope = null);
        void Update(ActivateCard activateCard, TransactionScope transactionScope = null);

        BlockCard Save(BlockCard blockCard, TransactionScope transactionScope = null);
        void Update(BlockCard blockCard, TransactionScope transactionScope = null);

        UnblockCard Save(UnblockCard unblockCard, TransactionScope transactionScope);
        void Update(UnblockCard unblockCard, TransactionScope transactionScope = null);

        ChangePinCard Save(ChangePinCard changePinCard, TransactionScope transactionScope = null);
        void Update(ChangePinCard changePinCard, TransactionScope transactionScope = null);

        BindCard Save(BindCard bindCard, TransactionScope transactionScope = null);
        void Update(BindCard bindCard, TransactionScope transactionScope = null);

        CardOwner Save(CardOwner cardOwner, TransactionScope transactionScope = null);
        CardHolder Save(CardHolder cardHolder, TransactionScope transactionScope = null);
        CardHolderContact Save(CardHolderContact cardHolderContact, TransactionScope transactionScope = null);

        InactivateCard Save(InactivateCard inactivateCard, TransactionScope transactionScope = null);
        void Update(InactivateCard inactivateCard, TransactionScope transactionScope = null);

        CancelCard Save(CancelCard cancelCard, TransactionScope transactionScope = null);
        void Update(CancelCard cancelCard, TransactionScope transactionScope = null);
    }
}