using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface INewAccountPersonDocumentRepository
    {
        public void Save(NewAccountPersonDocument newAccountPersonDocument, TransactionScope transactionScope = null);
        public IEnumerable<NewAccountPersonDocument> GetByNewAccountId(long newAccountId);
        public IEnumerable<NewAccountPersonDocument> GetByNewAccountPersonId(long newAccountPersonId);
    }
}