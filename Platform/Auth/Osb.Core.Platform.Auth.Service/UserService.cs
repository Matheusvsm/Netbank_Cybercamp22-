using System;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Util.Resources;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Auth.Service.Validators;
using Osb.Core.Platform.Auth.Service.Mapping;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Result;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Platform.Common.Util;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Result;
using System.Linq;
using Osb.Core.Platform.Auth.Util.Resources.UserExcMsg;

namespace Osb.Core.Platform.Auth.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryFactory _userRepositoryFactory;
        private readonly IAccountServiceFactory _accountServiceFactory;
        private readonly IUserAccountRepositoryFactory _userAccountRepositoryFactory;
        private readonly IUserCredentialRepositoryFactory _userCredentialRepositoryFactory;
        private readonly IAuthRepositoryFactory _authRepositoryFactory;
        private readonly UserValidator _validator;
        private readonly UserInformationMapper _userInformationMapper;
        private readonly IConnectionFactory _connectionFactory;
        private readonly SenderMapper _senderMapper;
        private readonly INotificationServiceFactory _notificationServiceFactory;

        public UserService(
            IUserRepositoryFactory userRepositoryFactory,
            IAccountServiceFactory accountServiceFactory,
            IUserAccountRepositoryFactory userAccountRepositoryFactory,
            IAuthRepositoryFactory authRepositoryFactory,
            IUserCredentialRepositoryFactory userCredentialRepositoryFactory,
            IConnectionFactory connectionFactory,
            INotificationServiceFactory notificationServiceFactory
        )
        {
            _userRepositoryFactory = userRepositoryFactory;
            _accountServiceFactory = accountServiceFactory;
            _userAccountRepositoryFactory = userAccountRepositoryFactory;
            _userCredentialRepositoryFactory = userCredentialRepositoryFactory;
            _authRepositoryFactory = authRepositoryFactory;
            _validator = new UserValidator();
            _userInformationMapper = new UserInformationMapper();
            _connectionFactory = connectionFactory;
            _notificationServiceFactory = notificationServiceFactory;
            _senderMapper = new SenderMapper();
        }

        public void UserWebhookHandler(UserWebhookRequest userWebhookRequest)
        {
            _validator.Validate(userWebhookRequest);

            switch (userWebhookRequest.EventType)
            {
                case EventType.Creation:
                    Save(userWebhookRequest);
                    break;
                case EventType.Update:
                    Update(userWebhookRequest);
                    break;
                case EventType.Remove:
                    Delete(userWebhookRequest);
                    break;
            }
        }

        public void Save(UserWebhookRequest userWebhookRequest)
        {
            IUserRepository userRepository = _userRepositoryFactory.Create();
            User user = userRepository.GetUserByLogin(userWebhookRequest.Login);

            if (user != null)
                Update(userWebhookRequest);
            else
            {
                TransactionScope transactionScope = _connectionFactory.CreateTransaction();

                try
                {
                    IUserCredentialRepository userCredentialRepository = _userCredentialRepositoryFactory.Create();

                    User newUser = User.Create(userWebhookRequest.Login, true);

                    newUser = userRepository.Save(newUser, transactionScope);

                    UserInformation userInformation = UserInformation.Create(
                                                                            newUser.UserId,
                                                                            userWebhookRequest.Name,
                                                                            userWebhookRequest.Mail,
                                                                            userWebhookRequest.PhoneNumber
                                                                            );

                    userRepository.Save(userInformation, transactionScope);

                    UserCredential newUserCredential = null;
                    string message = null;

                    if (String.IsNullOrEmpty(userWebhookRequest.Password))
                    {
                        string password = Utility.CreatePassword();
                        string salt = SHA512Provider.GenerateSalt();
                        string encryptedPassword = SHA512Provider.Encrypt(password, salt);

                        newUserCredential = UserCredential.Create(
                                                                newUser.UserId,
                                                                encryptedPassword,
                                                                salt
                        );

                        message = String.Format(AuthMsg.MSG0006, password);
                    }
                    else
                    {
                        newUserCredential = UserCredential.Create(
                                                                newUser.UserId,
                                                                userWebhookRequest.Password,
                                                                userWebhookRequest.Salt
                        );

                        message = AuthMsg.MSG0005;
                    };

                    userCredentialRepository.Save(newUserCredential, transactionScope);

                    if (userWebhookRequest.AccountKeyList != null && userWebhookRequest.AccountKeyList.Count > 0)
                    {
                        IUserAccountRepository userAccountRepository = _userAccountRepositoryFactory.Create();
                        IAccountService accountService = _accountServiceFactory.Create();

                        Account account = null;

                        foreach (string accountKey in userWebhookRequest.AccountKeyList)
                        {
                            account = accountService.FindAccountByAccountKey(accountKey);

                            if (account != null && account.CompanyId == userWebhookRequest.CompanyId)
                            {
                                UserAccount userAccount = UserAccount.Create(account.AccountId, newUser.UserId);

                                userAccountRepository.Save(userAccount, transactionScope);
                            }
                            else
                                continue;
                        }
                    }

                    INotificationService notificationService = _notificationServiceFactory.Create();

                    notificationService.Save(userInformation.Mail, userInformation.PhoneNumber, "Criação de usuário", message, userWebhookRequest.CompanyId, null, transactionScope);

                    transactionScope.Transaction.Commit();
                }
                catch
                {
                    transactionScope.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    transactionScope.Connection.Close();
                }
            }
        }

        public void Update(UserWebhookRequest userWebhookRequest)
        {
            IUserRepository userRepository = _userRepositoryFactory.Create();
            User user = userRepository.GetUserByLogin(userWebhookRequest.Login);

            if (user == null)
                Save(userWebhookRequest);
            else
            {
                TransactionScope transactionScope = _connectionFactory.CreateTransaction();

                try
                {
                    if (userWebhookRequest.LockedUser)
                        user.Status = UserStatus.Blocked;
                    else
                        user.Status = UserStatus.Active;

                    userRepository.Update(user, transactionScope);

                    if (userWebhookRequest.AccountKeyList != null && userWebhookRequest.AccountKeyList.Count > 0)
                    {
                        IAccountService accountService = _accountServiceFactory.Create();
                        FindAccountListResult accountList = accountService.FindAccountListByUserIdAndCompanyId(user.UserId, userWebhookRequest.CompanyId);

                        IUserAccountRepository userAccountRepository = _userAccountRepositoryFactory.Create();

                        UserAccount userAccount = null;

                        foreach (Account currentAccount in accountList.AccountList)
                        {
                            if (userWebhookRequest.AccountKeyList.Exists(x => x == currentAccount.AccountKey))
                                continue;
                            else
                            {
                                userAccount = userAccountRepository.GetByAccountKeyAndUserId(currentAccount.AccountKey, user.UserId);

                                userAccount.DeletionDate = DateTime.Now;

                                userAccountRepository.Update(userAccount, transactionScope);
                            }
                        }

                        Account account = null;

                        foreach (string accountKey in userWebhookRequest.AccountKeyList)
                        {
                            if (accountList.AccountList.ToList().Exists(x => x.AccountKey == accountKey))
                                continue;
                            else
                            {
                                account = accountService.FindAccountByAccountKey(accountKey);

                                if (account != null)
                                {
                                    userAccount = UserAccount.Create(account.AccountId, user.UserId);

                                    userAccountRepository.Save(userAccount, transactionScope);
                                }
                                else
                                    continue;
                            }
                        }
                    }

                    transactionScope.Transaction.Commit();
                }
                catch
                {
                    transactionScope.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    transactionScope.Connection.Close();
                }
            }
        }

        public void Delete(UserWebhookRequest userWebhookRequest)
        {
            IUserRepository userRepository = _userRepositoryFactory.Create();
            User user = userRepository.GetUserByLogin(userWebhookRequest.Login);

            user.DeletionDate = DateTime.Now;

            userRepository.Update(user);
        }

        public void SaveUserInformation(UserInformationRequest userInformationRequest)
        {
            _validator.Validate(userInformationRequest);

            UserInformation userInformation = UserInformation.Create(
                userInformationRequest.UserId,
                userInformationRequest.Name,
                userInformationRequest.Mail,
                userInformationRequest.PhoneNumber,
                userInformationRequest.ZipCode,
                userInformationRequest.Street,
                userInformationRequest.Number,
                userInformationRequest.District,
                userInformationRequest.Complement,
                userInformationRequest.Reference,
                userInformationRequest.City,
                userInformationRequest.State,
                userInformationRequest.Country
            );

            IUserRepository userRepository = _userRepositoryFactory.Create();
            userRepository.Save(userInformation);
        }

        public UserInformationResult FindUserInformation(FindUserInformationRequest findUserInformationRequest)
        {
            IUserRepository userRepository = _userRepositoryFactory.Create();
            UserInformation userInformation = userRepository.GetByUserId(findUserInformationRequest.UserId);

            UserInformationResult result = _userInformationMapper.Map(userInformation);
            return result;
        }

        public void UpdateUserInformation(UserInformationRequest userInformationRequest)
        {
            IUserRepository userRepository = _userRepositoryFactory.Create();
            UserInformation userInformation = userRepository.GetByUserId(userInformationRequest.UserId);

            if (userInformation == null)
                throw new OsbAuthException(UserExcMsg.EXC0008);

            userInformation = _userInformationMapper.UpdateMap<UserInformation>(userInformationRequest, userInformation);

            userRepository.Update(userInformation);
        }

        public void ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            _validator.Validate(changePasswordRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                IAuthRepository _authRepository = _authRepositoryFactory.Create();
                UserCredential userCredential = _authRepository.GetUserCredentialByUserId(changePasswordRequest.UserId);

                IUserRepository _userRepository = _userRepositoryFactory.Create();
                User user = _userRepository.GetById(changePasswordRequest.UserId);

                if (!user.IsFirstAccess)
                    if (!SHA512Provider.Compare(changePasswordRequest.CurrentPassword, userCredential.Password, userCredential.Salt))
                        throw new OsbAuthException(UserExcMsg.EXC0009);

                if (SHA512Provider.Compare(changePasswordRequest.NewPassword, userCredential.Password, userCredential.Salt))
                    throw new OsbAuthException(UserExcMsg.EXC0010);

                userCredential.DeletionDate = DateTime.Now;

                IUserCredentialRepository _userCredentialRepository = _userCredentialRepositoryFactory.Create();
                _userCredentialRepository.Update(userCredential, transactionScope);

                string newSalt = SHA512Provider.GenerateSalt();
                string newPassword = SHA512Provider.Encrypt(changePasswordRequest.NewPassword, newSalt);

                UserCredential newUserCredential = UserCredential.Create(
                    changePasswordRequest.UserId,
                    newPassword,
                    newSalt
                );

                _userCredentialRepository.Save(newUserCredential, transactionScope);

                user.IsFirstAccess = false;
                _userRepository.Update(user, transactionScope);

                transactionScope.Transaction.Commit();
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public UserContactsResult FindUserContactsByLogin(FindUserContactsByLoginRequest findUserContactsByLoginRequest)
        {
            _validator.Validate(findUserContactsByLoginRequest);

            IUserRepository userRepository = _userRepositoryFactory.Create();
            User user = userRepository.GetUserByLogin(findUserContactsByLoginRequest.Login);

            if (user == null)
                throw new OsbAuthException(UserExcMsg.EXC0008);

            UserInformation userInformation = userRepository.GetByUserId(user.UserId);

            UserContactsResult result = _userInformationMapper.ContactMap(userInformation);

            return result;
        }

        public void ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            _validator.Validate(resetPasswordRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                IUserRepository userRepository = _userRepositoryFactory.Create();

                User user = userRepository.GetUserByLogin(resetPasswordRequest.Login);

                if (user != null)
                {
                    IUserCredentialRepository userCredentialRepository = _userCredentialRepositoryFactory.Create();

                    UserCredential userCredential = userCredentialRepository.GetUserCredentialByUserId(user.UserId);

                    userCredential.DeletionDate = DateTime.Now;

                    userCredentialRepository.Update(userCredential, transactionScope);

                    string password = Utility.CreatePassword();
                    string salt = SHA512Provider.GenerateSalt();
                    string encryptedPassword = SHA512Provider.Encrypt(password, salt);

                    UserCredential newUserCredential = UserCredential.Create(
                        user.UserId,
                        encryptedPassword,
                        salt
                    );

                    userCredentialRepository.Save(newUserCredential, transactionScope);

                    UserInformation userInformation = userRepository.GetByUserId(user.UserId);

                    string message = String.Format(AuthMsg.MSG0002, password);

                    INotificationService notificationService = _notificationServiceFactory.Create();

                    if (resetPasswordRequest.SendType == SendType.Mail)
                        notificationService.Save(userInformation.Mail, userInformation.PhoneNumber, AuthMsg.MSG0001, message, resetPasswordRequest.CompanyId, SendType.Mail);
                    else
                    {
                        notificationService.Save(userInformation.Mail, userInformation.PhoneNumber, AuthMsg.MSG0001, message, resetPasswordRequest.CompanyId, SendType.Sms);
                    }

                    user.IsFirstAccess = true;
                    user.LoginAttempts = 0;
                    user.Status = 0;

                    userRepository.Update(user, transactionScope);

                    transactionScope.Transaction.Commit();
                }
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public void UpdateUserTerms(UpdateUserTermsRequest updateUserTermsRequest)
        {
            _validator.Validate(updateUserTermsRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                IUserRepository userRepository = _userRepositoryFactory.Create();
                User user = userRepository.GetUserByLoginAndCompanyId(updateUserTermsRequest.Login, updateUserTermsRequest.CompanyId);

                if (user == null)
                    throw new OsbAuthException(UserExcMsg.EXC0008);

                user.AcceptedTerms = !user.AcceptedTerms;

                userRepository.Update(user, transactionScope);

                transactionScope.Transaction.Commit();
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }
    }
}