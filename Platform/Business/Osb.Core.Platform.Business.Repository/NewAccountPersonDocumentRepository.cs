using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class NewAccountPersonDocumentRepository : INewAccountPersonDocumentRepository
    {
        private readonly IDbContext<NewAccountPersonDocument> _context;

        public NewAccountPersonDocumentRepository(IDbContext<NewAccountPersonDocument> context)
        {
            this._context = context;
        }

        public void Save(NewAccountPersonDocument newAccountPersonDocument, TransactionScope transactionScope = null)
        {

            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountId"] = newAccountPersonDocument.NewAccountId,
                ["paramNewAccountPersonId"] = newAccountPersonDocument.NewAccountPersonId,
                ["paramDocumentFile"] = newAccountPersonDocument.DocumentFile,
                ["paramDocumentFormat"] = newAccountPersonDocument.DocumentFormat,
                ["paramDocumentName"] = newAccountPersonDocument.DocumentName,
                ["paramDocumentType"] = newAccountPersonDocument.DocumentType,
                ["paramDescription"] = newAccountPersonDocument.Description,
                ["paramExpirationDate"] = newAccountPersonDocument.ExpirationDate,
                ["paramUserId"] = newAccountPersonDocument.CreationUserId
            };

            _context.ExecuteWithSingleResult("InsertNewAccountPersonDocument", parameters, transactionScope);
        }

        public IEnumerable<NewAccountPersonDocument> GetByNewAccountId(long newAccountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountId"] = newAccountId
            };

            IEnumerable<NewAccountPersonDocument> newAccountPersonDocumentList = _context.ExecuteWithMultipleResults("GetNewAccountPersonDocumentByNewAccountId", parameters);

            return newAccountPersonDocumentList;
        }

        public IEnumerable<NewAccountPersonDocument> GetByNewAccountPersonId(long newAccountPersonId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountPersonId"] = newAccountPersonId
            };

            IEnumerable<NewAccountPersonDocument> newAccountPersonDocumentList = _context.ExecuteWithMultipleResults("GetNewAccountPersonDocumentByNewAccountPersonId", parameters);

            return newAccountPersonDocumentList;
        }
    }
}