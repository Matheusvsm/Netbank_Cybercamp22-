using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Common.Entity.Enums;
using System.Linq;

namespace Osb.Core.Api.Application.Util
{
    public class Formatter
    {
        public static string RemoveMaskFromTaxId(string taxIdWithMask)
        {
            if (taxIdWithMask == null)
                throw new OsbBusinessException("TaxId não pode ser nulo.");

            return Regex.Replace(taxIdWithMask, "[#/,*.()+ -]", "");
        }

        public static string RemoveMaskFromPhoneNumber(string phoneNumberWithMask)
        {
            if (phoneNumberWithMask == null)
                throw new OsbBusinessException("PhoneNumber não pode ser nulo.");

            return Regex.Replace(phoneNumberWithMask, @"[^\d]+", "");
        }

        public static string MaskFromCredential(string input, string request)
        {
            string[] paramList = request.Split(",");
            string maskedRequest = request;

            foreach (SensitiveDataType data in Enum.GetValues(typeof(SensitiveDataType)))
            {
                string type = Enum.GetName(typeof(SensitiveDataType), data);
                type = char.ToLower(type[0]) + type.Substring(1);
                IEnumerable<string> credentials = from param in paramList where param.Contains(type) select param;

                foreach (string withoutMask in credentials)
                {
                    string toBeMasked = withoutMask;
                    string value = JsonDocument.Parse(maskedRequest).RootElement.GetProperty(type).ToString();
                    maskedRequest = maskedRequest.Replace(toBeMasked, withoutMask.Replace(value, "*********"));
                }
            }

            return input.Replace(request, maskedRequest);
        }

        public static string FormatPhoneNumber(string phoneNumber)
        {
            phoneNumber = RemoveMaskFromPhoneNumber(phoneNumber);

            string formattedPhoneNumber = null;

            if (phoneNumber.Length == 11)
            {
                formattedPhoneNumber = "+55" + phoneNumber;
                return formattedPhoneNumber;
            }

            return phoneNumber;
        }

        public static string MaskFromBarcode(string barcode)
        {
            return Regex.Replace(barcode, @"\s*", string.Empty);
        }

        public static DateTime AbsoluteEnd(DateTime date)
        {
            return date.AddHours(date.Hour * -1).AddMinutes(date.Minute * -1).AddSeconds(date.Second * -1).AddDays(1).AddSeconds(-1);
        }

        public static string MaskFromZipCode(string zipCode)
        {
            if (string.IsNullOrEmpty(zipCode))
                throw new OsbBusinessException("ZipCode não pode ser nulo.");

            return Regex.Replace(zipCode, "[^0-9]", string.Empty);
        }
    }
}