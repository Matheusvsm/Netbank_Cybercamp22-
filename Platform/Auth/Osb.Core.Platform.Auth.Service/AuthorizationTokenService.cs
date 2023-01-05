using System;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Validators;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Service.Mapping;
using Osb.Core.Platform.Auth.Util.Resources;
using Osb.Core.Platform.Auth.Util.Resources.AuthorizationTokenExcMsg;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Auth.Util;
using System.IO;

namespace Osb.Core.Platform.Auth.Service
{
    public class AuthorizationTokenService : IAuthorizationTokenService
    {
        private readonly AuthorizationTokenValidator _validator;
        private readonly IAuthorizationTokenRepositoryFactory _tokenRepositoryFactory;
        private readonly IAuthorizationTokenRepositoryFactory _authorizationTokenRepositoryFactory;
        private readonly AuthorizationTokenMapper _mapper;
        private readonly Settings _settings;
        private readonly INotificationServiceFactory _notificationServiceFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;

        public AuthorizationTokenService(
            IAuthorizationTokenRepositoryFactory tokenRepositoryFactory,
            IAuthorizationTokenRepositoryFactory authorizationTokenRepositoryFactory,
            Settings settings,
            INotificationServiceFactory notificationServiceFactory,
            IUserRepositoryFactory userRepositoryFactory
        )
        {
            _tokenRepositoryFactory = tokenRepositoryFactory;
            _validator = new AuthorizationTokenValidator();
            _authorizationTokenRepositoryFactory = authorizationTokenRepositoryFactory;
            _notificationServiceFactory = notificationServiceFactory;
            _userRepositoryFactory = userRepositoryFactory;
            _mapper = new AuthorizationTokenMapper();
            _settings = settings;
        }

        public void GenerateAuthorizationToken(GenerateAuthorizationTokenRequest generateAuthorizationTokenRequest)
        {
            _validator.Validate(generateAuthorizationTokenRequest);

            IAuthorizationTokenRepository generateAuthorizationTokenRepository = _authorizationTokenRepositoryFactory.Create();
            generateAuthorizationTokenRepository.UnauthorizeTokensByUserId(generateAuthorizationTokenRequest.UserId.Value);

            Random valueUtility = new Random();
            long value = valueUtility.Next(111111, 999999);

            AuthorizationToken token = _mapper.Map(
                generateAuthorizationTokenRequest.UserId.Value,
                value,
                _settings.ConnectionKey["AuthorizationTokenExpirationTime"]
                );

            generateAuthorizationTokenRepository.Save(token);

            if (_settings.GenerateTokenFile)
            {
                TokenFileManagement tokenFileManagement = new TokenFileManagement();
                tokenFileManagement.SaveTokenFile(value.ToString(), _settings.TokenFilePath);
            }

            IUserRepository _userRepository = _userRepositoryFactory.Create();
            UserInformation userInformation = _userRepository.GetByUserId(token.UserId.Value);

            INotificationService notificationService = _notificationServiceFactory.Create();

            notificationService.Save(userInformation.Mail, userInformation.PhoneNumber, AuthMsg.MSG0003, String.Format(AuthMsg.MSG0004, value), generateAuthorizationTokenRequest.CompanyId.Value);
        }

        public void GenerateUnauthenticatedAuthorizationToken(GenerateAuthorizationTokenRequest authorizationTokenRequest)
        {
            _validator.Validate(authorizationTokenRequest);

            IAuthorizationTokenRepository generateAuthorizationTokenRepository = _authorizationTokenRepositoryFactory.Create();
            generateAuthorizationTokenRepository.UnauthorizeTokensByTaxId(authorizationTokenRequest.TaxId);

            Random valueUtility = new Random();
            long value = valueUtility.Next(111111, 999999);

            AuthorizationToken token = _mapper.Map(
                authorizationTokenRequest.TaxId,
                value,
                _settings.ConnectionKey["AuthorizationTokenExpirationTime"]
                );

            generateAuthorizationTokenRepository.Save(token);

            if (_settings.GenerateTokenFile)
            {
                TokenFileManagement tokenFileManagement = new TokenFileManagement();
                tokenFileManagement.SaveTokenFile(value.ToString(), _settings.TokenFilePath);
            }

            INotificationService notificationService = _notificationServiceFactory.Create();

            if (authorizationTokenRequest.PhoneNumber != null)
                notificationService.Save(null, authorizationTokenRequest.PhoneNumber, AuthMsg.MSG0003, String.Format(AuthMsg.MSG0004, value), authorizationTokenRequest.CompanyId.Value, SendType.Sms);
            else if (authorizationTokenRequest.Mail != null)
                notificationService.Save(authorizationTokenRequest.Mail, null, AuthMsg.MSG0003, String.Format(AuthMsg.MSG0004, value), authorizationTokenRequest.CompanyId.Value, SendType.Mail);

            if (authorizationTokenRequest.PhoneNumber == null && authorizationTokenRequest.Mail == null)
            {
                IUserRepository userRepository = _userRepositoryFactory.Create();
                User user = userRepository.GetUserByLogin(authorizationTokenRequest.TaxId);

                UserInformation userInformation = userRepository.GetByUserId(user.UserId);

                if (authorizationTokenRequest.SendType == SendType.Mail)
                    notificationService.Save(userInformation.Mail, null, AuthMsg.MSG0003, String.Format(AuthMsg.MSG0004, value), authorizationTokenRequest.CompanyId.Value, SendType.Mail);
                else
                    notificationService.Save(null, userInformation.PhoneNumber, AuthMsg.MSG0003, String.Format(AuthMsg.MSG0004, value), authorizationTokenRequest.CompanyId.Value, SendType.Sms);
            }
        }

        public void ValidateAuthorizationToken(ValidateAuthorizationTokenRequest validateAuthorizationTokenRequest)
        {
            _validator.Validate(validateAuthorizationTokenRequest);

            IAuthorizationTokenRepository authorizationTokenRepository = _authorizationTokenRepositoryFactory.Create();

            AuthorizationToken authorizationToken = new AuthorizationToken();

            if (!validateAuthorizationTokenRequest.UserId.Equals(default(long)))
                authorizationToken = authorizationTokenRepository.GetByUserId(validateAuthorizationTokenRequest.UserId);
            else
                authorizationToken = authorizationTokenRepository.GetByTaxId(validateAuthorizationTokenRequest.TaxId);

            if (authorizationToken == null)
                throw new OsbAuthException(AuthorizationTokenExcMsg.EXC0003);

            if (authorizationToken.ExpirationDate < DateTime.Now)
            {
                authorizationToken.Status = AuthorizationTokenStatus.Canceled;
                authorizationTokenRepository.Update(authorizationToken, validateAuthorizationTokenRequest.UserId);
                throw new OsbAuthException(AuthorizationTokenExcMsg.EXC0004);
            }

            authorizationToken.ValidateAttempts += 1;

            bool match = SHA512Provider.Compare(validateAuthorizationTokenRequest.Code, authorizationToken.Code, authorizationToken.Salt);

            if (!match)
            {
                if (authorizationToken.ValidateAttempts >= _settings.AuthorizationTokenValidateAttempts)
                {
                    authorizationToken.Status = AuthorizationTokenStatus.Canceled;
                    authorizationTokenRepository.Update(authorizationToken, validateAuthorizationTokenRequest.UserId);
                    throw new OsbAuthException(AuthorizationTokenExcMsg.EXC0005);
                }

                authorizationTokenRepository.Update(authorizationToken, validateAuthorizationTokenRequest.UserId);
                throw new OsbAuthException(AuthorizationTokenExcMsg.EXC0006);
            }

            authorizationToken.Status = AuthorizationTokenStatus.Authorized;
            authorizationTokenRepository.Update(authorizationToken, validateAuthorizationTokenRequest.UserId);
        }
    }
}