using System;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class LimitedPersonRequest
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public PersonRoleType PersonRoleType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}