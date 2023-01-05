using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class FGTSPayment : BaseEntity
    {
        public long FGTSPaymentId {get; set;}
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string TaxId { get; set; }
        public string ContributorTaxId { get; set; }
        public decimal PrincipalValue { get; set; }
        public string CodeRevenue { get; set; }
        public string Barcode {get; set;}
        public string FGTSIdentifier {get; set;}
        public long SocialConnectivityCode {get; set;}
        public int SocialConnectivityDigit {get; set;}
        public DateTime PaymentDate { get; set; }
        public long RateValueType { get; set; }
        public string Description {get; set;}
        public string Identifier {get; set;}
        public long ExternalIdentifier {get; set;}
        public int Attempts { get; set; }
        public FGTSPaymentStatus Status {get; set;}

        public static FGTSPayment Create(long accountid, long operationId, long userId, string taxid, string contributortaxid, decimal principalvalue, string coderevenue, string barcode, 
                                         string fgtsidentifier, long socialconnectivitycode, int socialconnectivitydigit, DateTime paymentdate, 
                                         long ratevaluetype, string description)
        {

            return new FGTSPayment()
            {
                AccountId = accountid,
                OperationId = operationId,
                TaxId = taxid, 
                ContributorTaxId = contributortaxid,
                PrincipalValue = principalvalue,
                CodeRevenue = coderevenue,
                Barcode = barcode, 
                FGTSIdentifier = fgtsidentifier,
                SocialConnectivityCode = socialconnectivitycode, 
                SocialConnectivityDigit = socialconnectivitydigit,
                PaymentDate = paymentdate,
                RateValueType = ratevaluetype, 
                Status = FGTSPaymentStatus.Created,
                Description = description, 
                Identifier = DateTime.Now.Ticks.ToString(),
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }      
    }
}