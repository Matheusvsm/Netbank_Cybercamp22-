using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20210901175701)]
    public class V20210901175701_Migration_V0 : Migration
    {
        private string namePathScript = "V20210901175701_Migration_V0";
        public override void Up()
        {
            Create.Table("User")
                  .WithColumn("UserId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Login").AsString(50).NotNullable()
                  .WithColumn("Status").AsInt32().NotNullable()
                  .WithColumn("LoginAttempts").AsInt32().NotNullable().WithDefaultValue(0)
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUser", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUser", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteUser", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLogin", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserById", namePathScript));

            Create.Table("UserCredential")
                  .WithColumn("UserCredentialId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("UserId").AsInt64().NotNullable()
                  .WithColumn("Password").AsString(150).NotNullable()
                  .WithColumn("Salt").AsString(36).NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("UserCredential").ForeignColumn("UserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("UserCredential").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("UserCredential").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserCredentialByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserCredential", namePathScript));

            Create.Table("UserInformation")
                .WithColumn("UserInformationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("Mail").AsString().Nullable()
                .WithColumn("PhoneNumber").AsString().Nullable()
                .WithColumn("ZipCode").AsString().Nullable()
                .WithColumn("Street").AsString().Nullable()
                .WithColumn("Number").AsString().Nullable()
                .WithColumn("District").AsString().Nullable()
                .WithColumn("Complement").AsString().Nullable()
                .WithColumn("City").AsString().Nullable()
                .WithColumn("State").AsString().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable();

            Create.ForeignKey()
                .FromTable("UserInformation").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("UserInformation").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("UserInformation").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserInformation", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserInformationByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserInformation", namePathScript));

            Create.Table("UserCredentialLog")
                  .WithColumn("UserCredentialLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("UserId").AsInt64().NotNullable()
                  .WithColumn("Login").AsString(50).NotNullable()
                  .WithColumn("LogDate").AsDateTime().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("UserCredentialLog").ForeignColumn("UserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("UserCredentialLog").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("UserCredentialLog").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserCredentialLog", namePathScript));

            Create.Table("Company")
                  .WithColumn("CompanyId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(50).NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("Company").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("Company").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCompany", namePathScript));

            Create.Table("Application")
                  .WithColumn("ApplicationId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(50).NotNullable()
                  .WithColumn("CompanyId").AsInt64().NotNullable()
                  .WithColumn("Key").AsString(128).NotNullable()
                  .WithColumn("Secret").AsString(128).NotNullable()
                  .WithColumn("Salt").AsString(36).NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("Application").ForeignColumn("CompanyId")
                  .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                  .FromTable("Application").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("Application").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetApplicationByKey", namePathScript));

            Create.Table("UserApplication")
                  .WithColumn("UserApplicationId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("ApplicationId").AsInt64().NotNullable()
                  .WithColumn("UserId").AsInt64().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("UserApplication").ForeignColumn("ApplicationId")
                  .ToTable("Application").PrimaryColumn("ApplicationId");
            Create.ForeignKey()
                  .FromTable("UserApplication").ForeignColumn("UserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("UserApplication").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("UserApplication").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Create.Table("SubAccount")
                  .WithColumn("SubAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Bank").AsString()
                  .WithColumn("BankBranch").AsString()
                  .WithColumn("BankAccount").AsString()
                  .WithColumn("BankAccountDigit").AsString()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("SubAccount").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("SubAccount").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertSubAccount", namePathScript));

            Create.Table("Account")
                  .WithColumn("AccountId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("CompanyId").AsInt64().NotNullable()
                  .WithColumn("SubAccountId").AsInt64().Nullable()
                  .WithColumn("Name").AsString().NotNullable()
                  .WithColumn("TaxId").AsString(14).NotNullable()
                  .WithColumn("Type").AsInt64().Nullable()
                  .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(0)
                  .WithColumn("AccountKey").AsString(23).Nullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("Account").ForeignColumn("CompanyId")
                  .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                  .FromTable("Account").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("Account").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByLastId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByTaxIdAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByAccountKey", namePathScript));

            Create.Table("CompanyAuthentication")
                  .WithColumn("CompanyAuthenticationId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("CompanyId").AsInt64().NotNullable()
                  .WithColumn("Url").AsString(100).NotNullable()
                  .WithColumn("Salt").AsString(36)
                  .WithColumn("UserName").AsString(255).NotNullable()
                  .WithColumn("Password").AsString(255).NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("CompanyAuthentication").ForeignColumn("CompanyId")
                  .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                  .FromTable("CompanyAuthentication").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("CompanyAuthentication").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCompanyAuthentication", namePathScript));

            Create.Table("Authentication")
                  .WithColumn("AuthenticationId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("UrlApi").AsString(150).NotNullable()
                  .WithColumn("Token").AsString(50).NotNullable()
                  .WithColumn("Username").AsString(50).NotNullable()
                  .WithColumn("Password").AsString(150).NotNullable()
                  .WithColumn("Salt").AsString(50).Nullable()
                  .WithColumn("ApplicationId").AsInt64().NotNullable()
                  .WithColumn("CompanyAuthenticationId").AsInt64().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("Authentication").ForeignColumn("ApplicationId")
                  .ToTable("Application").PrimaryColumn("ApplicationId");
            Create.ForeignKey()
                  .FromTable("Authentication").ForeignColumn("CompanyAuthenticationId")
                  .ToTable("CompanyAuthentication").PrimaryColumn("CompanyAuthenticationId");
            Create.ForeignKey()
                  .FromTable("Authentication").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("Authentication").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Create.Table("UserAccount")
                  .WithColumn("UserAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("AccountId").AsInt64().NotNullable()
                  .WithColumn("UserId").AsInt64().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("UserAccount").ForeignColumn("UserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("UserAccount").ForeignColumn("AccountId")
                  .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                  .FromTable("UserAccount").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("UserAccount").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteUserAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByUserTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByLogin", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByLogin", namePathScript));

            Create.Table("InputLog")
                  .WithColumn("InputLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Request").AsString().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("InputLog").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("InputLog").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInputLog", namePathScript));

            Create.Table("OutputLog")
                  .WithColumn("OutputLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Response").AsString().NotNullable()
                  .WithColumn("LogDate").AsDateTime().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("OutputLog").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("OutputLog").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOutputLog", namePathScript));

            Create.Table("IntegrationLog")
                  .WithColumn("IntegrationLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Body").AsString().NotNullable()
                  .WithColumn("Headers").AsString().NotNullable()
                  .WithColumn("Url").AsString().NotNullable()
                  .WithColumn("StatusCode").AsInt64().NotNullable()
                  .WithColumn("Response").AsString().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("IntegrationLog").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("IntegrationLog").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertIntegrationLog", namePathScript));

            Create.Table("ExceptionLog")
                  .WithColumn("ExceptionLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("ExceptionType").AsInt32().NotNullable()
                  .WithColumn("Message").AsString().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                  .FromTable("ExceptionLog").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("ExceptionLog").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertExceptionLog", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertExceptionLog", namePathScript));
            Delete.Table("ExceptionLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertIntegrationLog", namePathScript));
            Delete.Table("IntegrationLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOutputLog", namePathScript));
            Delete.Table("OutputLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertInputLog", namePathScript));
            Delete.Table("InputLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByLogin", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteUserAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByUserTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByLogin", namePathScript));
            Delete.Table("UserAccount");

            Delete.Table("Authentication");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCompanyAuthentication", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCompanyAuthenticationByCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCompanyAuthenticationByAccountId", namePathScript));
            Delete.Table("CompanyAuthentication");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByTaxIdAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByLastId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByAccountKey", namePathScript));
            Delete.Table("Account");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertSubAccount", namePathScript));
            Delete.Table("SubAccount");

            Delete.Table("UserApplication");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetApplicationByKey", namePathScript));
            Delete.Table("Application");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCompany", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCompanyById", namePathScript));
            Delete.Table("Company");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserCredentialLog", namePathScript));
            Delete.Table("UserCredentialLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserInformation", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserInformationByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserInformation", namePathScript));
            Delete.Table("UserInformation");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserCredential", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserCredentialByUserId", namePathScript));
            Delete.Table("UserCredential");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByLogin", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUser", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUser", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteUser", namePathScript));
            Delete.Table("User");
        }
    }
}
