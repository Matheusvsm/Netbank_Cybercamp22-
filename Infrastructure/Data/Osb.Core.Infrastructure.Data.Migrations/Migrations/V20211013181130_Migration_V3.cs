using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20211013181130)]
    public class V20211013181130_Migration_V3 : Migration
    {
        private string namePathScript = "V20211013181130_Migration_V3";
        public override void Up()
        {
            Create.Table("LimitedAccount")
                .WithColumn("LimitedAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("AccountKey").AsString(23).Nullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable()
                .WithColumn("TaxId").AsString().NotNullable()
                .WithColumn("Mail").AsString().Nullable()
                .WithColumn("Nickname").AsString().Nullable()
                .WithColumn("Bank").AsString().Nullable()
                .WithColumn("BankBranch").AsString().Nullable()
                .WithColumn("BankAccount").AsString().Nullable()
                .WithColumn("BankAccountDigit").AsString().Nullable()
                .WithColumn("BirthDate").AsDateTime().NotNullable()
                .WithColumn("TradingName").AsString().Nullable()
                .WithColumn("LegalName").AsString().Nullable()
                .WithColumn("ConstitutionDate").AsDateTime().Nullable()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("Salt").AsString().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("LimitedAccount").ForeignColumn("CompanyId")
                .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                .FromTable("LimitedAccount").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("LimitedAccount").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertLimitedAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetLimitedAccountById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetLimitedAccountListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateLimitedAccount", namePathScript));

            Create.Table("LimitedPerson")
                .WithColumn("LimitedPersonId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("LimitedAccountId").AsInt64().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("TaxNumber").AsString().NotNullable()
                .WithColumn("Mail").AsString().Nullable()
                .WithColumn("Phone").AsString().NotNullable()
                .WithColumn("Nickname").AsString().Nullable()
                .WithColumn("PersonRoleType").AsInt32().NotNullable()
                .WithColumn("BirthDate").AsDateTime().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("LimitedPerson").ForeignColumn("LimitedAccountId")
                .ToTable("LimitedAccount").PrimaryColumn("LimitedAccountId");
            Create.ForeignKey()
                .FromTable("LimitedPerson").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("LimitedPerson").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertLimitedPerson", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetLimitedPersonByLimitedAccountId", namePathScript));

            Create.Table("NewAccount")
                .WithColumn("NewAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString().NotNullable()
                .WithColumn("PersonName").AsString().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable()
                .WithColumn("Mail").AsString().NotNullable()
                .WithColumn("Nickname").AsString().Nullable()
                .WithColumn("BirthDate").AsDateTime().NotNullable()
                .WithColumn("MotherFullName").AsString().Nullable()
                .WithColumn("FatherFullName").AsString().Nullable()
                .WithColumn("Nationality").AsString().NotNullable()
                .WithColumn("BirthCity").AsString().NotNullable()
                .WithColumn("BirthState").AsString().NotNullable()
                .WithColumn("Gender").AsInt32().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("MaritalStatus").AsInt32().NotNullable()
                .WithColumn("SpouseName").AsString().Nullable()
                .WithColumn("Occupation").AsString().Nullable()
                .WithColumn("CompanyType").AsInt32().NotNullable()
                .WithColumn("CompanyActivity").AsString().NotNullable()
                .WithColumn("ConstitutionDate").AsDateTime().NotNullable()
                .WithColumn("PubliclyExposedPerson").AsBoolean().NotNullable()
                .WithColumn("CheckPendingTransfers").AsBoolean().Nullable()
                .WithColumn("IdentityDocument").AsString().NotNullable()
                .WithColumn("Bank").AsString().Nullable()
                .WithColumn("BankBranch").AsString().Nullable()
                .WithColumn("BankAccount").AsString().Nullable()
                .WithColumn("BankAccountDigit").AsString().Nullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("NewAccount").ForeignColumn("CompanyId")
                .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                .FromTable("NewAccount").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("NewAccount").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertNewAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateNewAccount", namePathScript));

            Create.Table("NewAccountAddress")
               .WithColumn("NewAccountAddressId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("NewAccountId").AsInt64().NotNullable()
               .WithColumn("AddressLine").AsString().NotNullable()
               .WithColumn("AddressLine2").AsString().Nullable()
               .WithColumn("ZipCode").AsString().NotNullable()
               .WithColumn("Neighborhood").AsString().NotNullable()
               .WithColumn("CityCode").AsString().NotNullable()
               .WithColumn("CityName").AsString().NotNullable()
               .WithColumn("State").AsString().NotNullable()
               .WithColumn("AddressType").AsInt32().NotNullable()
               .WithColumn("Country").AsString().NotNullable()
               .WithColumn("Complement").AsString().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("NewAccountAddress").ForeignColumn("NewAccountId")
                .ToTable("NewAccount").PrimaryColumn("NewAccountId");
            Create.ForeignKey()
                .FromTable("NewAccountAddress").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("NewAccountAddress").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertNewAccountAddress", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountAddressByNewAccountId", namePathScript));

            Create.Table("NewAccountPerson")
                .WithColumn("NewAccountPersonId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("NewAccountId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Mail").AsString().NotNullable()
                .WithColumn("Occupation").AsString().Nullable()
                .WithColumn("Phone").AsString().NotNullable()
                .WithColumn("PersonRoleType").AsInt32().NotNullable()
                .WithColumn("MotherFullName").AsString().Nullable()
                .WithColumn("FatherFullName").AsString().Nullable()
                .WithColumn("Nationality").AsString().NotNullable()
                .WithColumn("BirthCity").AsString().NotNullable()
                .WithColumn("BirthState").AsString().NotNullable()
                .WithColumn("Gender").AsInt32().NotNullable()
                .WithColumn("MaritalStatus").AsInt32().NotNullable()
                .WithColumn("SpouseName").AsString().Nullable()
                .WithColumn("IdentityDocument").AsString().NotNullable()
                .WithColumn("CompanyType").AsInt32().NotNullable()
                .WithColumn("CompanyActivity").AsString().NotNullable()
                .WithColumn("ConstitutionDate").AsDateTime().NotNullable()
                .WithColumn("CheckPendingTransfers").AsBoolean().Nullable()
                .WithColumn("BirthDate").AsDateTime().NotNullable()
                .WithColumn("PersonName").AsString().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable()
                .WithColumn("Nickname").AsString().Nullable()
                .WithColumn("PubliclyExposedPerson").AsBoolean().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("NewAccountPerson").ForeignColumn("NewAccountId")
                .ToTable("NewAccount").PrimaryColumn("NewAccountId");
            Create.ForeignKey()
                .FromTable("NewAccountPerson").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("NewAccountPerson").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertNewAccountPerson", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountPersonByNewAccountId", namePathScript));

            Create.Table("NewAccountPersonDocument")
                .WithColumn("NewAccountPersonDocumentId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("NewAccountId").AsInt64().Nullable()
                .WithColumn("NewAccountPersonId").AsInt64().Nullable()
                .WithColumn("DocumentFile").AsBinary().NotNullable()
                .WithColumn("DocumentFormat").AsInt32().Nullable()
                .WithColumn("DocumentName").AsString().NotNullable()
                .WithColumn("DocumentType").AsInt32().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("ExpirationDate").AsDateTime().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("NewAccountPersonDocument").ForeignColumn("NewAccountId")
                .ToTable("NewAccount").PrimaryColumn("NewAccountId");
            Create.ForeignKey()
                .FromTable("NewAccountPersonDocument").ForeignColumn("NewAccountPersonId")
                .ToTable("NewAccountPerson").PrimaryColumn("NewAccountPersonId");
            Create.ForeignKey()
                .FromTable("NewAccountPersonDocument").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("NewAccountPersonDocument").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountPersonDocumentByNewAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountPersonDocumentByNewAccountPersonId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertNewAccountPersonDocument", namePathScript));

            Create.Table("AccountWebhook")
                .WithColumn("AccountWebhookId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountConditionType").AsInt64().NotNullable()
                .WithColumn("AccountStatus").AsInt64().NotNullable()
                .WithColumn("AccountKey").AsString(23).Nullable()
                .WithColumn("AccountCreationDate").AsDateTime().Nullable()
                .WithColumn("AccountConditionId").AsInt64().NotNullable()
                .WithColumn("CompanyAuthenticationId").AsInt64().NotNullable()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("Identifier").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString(14).NotNullable()
                .WithColumn("FromBank").AsString().Nullable()
                .WithColumn("FromBankBranch").AsString().Nullable()
                .WithColumn("FromBankAccount").AsString().Nullable()
                .WithColumn("FromBankAccountDigit").AsString().Nullable()
                .WithColumn("SendDate").AsDateTime().NotNullable()
                .WithColumn("ToBank").AsString().Nullable()
                .WithColumn("ToBankBranch").AsString().Nullable()
                .WithColumn("ToBankAccount").AsString().Nullable()
                .WithColumn("ToBankAccountDigit").AsString().Nullable()
                .WithColumn("Method").AsString().Nullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("AccountWebhook").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("AccountWebhook").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccountWebhook", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountWebhookByAccountKey", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAccountWebhook", namePathScript));

            Create.Table("UserWebhook")
                .WithColumn("UserWebhookId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString(14).NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Mail").AsString(50).Nullable()
                .WithColumn("PhoneNumber").AsString(50).NotNullable()
                .WithColumn("AccountName").AsString(200).NotNullable()
                .WithColumn("AccountTaxId").AsString(14).NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("EventType").AsInt64().NotNullable()
                .WithColumn("UserTaxId").AsString(14).NotNullable()
                .WithColumn("AccountKey").AsString(23).Nullable()
                .WithColumn("Password").AsString(150).NotNullable()
                .WithColumn("Salt").AsString(150).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("UserWebhook").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("UserWebhook").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserWebhook", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserWebhookByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserWebhook", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserWebhook", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserWebhookByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserWebhook", namePathScript));
            Delete.Table("UserWebhook");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccountWebhook", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountWebhookByAccountKey", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAccountWebhook", namePathScript));
            Delete.Table("AccountWebhook");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountPersonDocumentByNewAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountPersonDocumentByNewAccountPersonId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertNewAccountPersonDocument", namePathScript));
            Delete.Table("NewAccountPersonDocument");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertNewAccountPerson", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountPersonByNewAccountId", namePathScript));
            Delete.Table("NewAccountPerson");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertNewAccountAddress", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountAddressByNewAccountId", namePathScript));
            Delete.Table("NewAccountAddress");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertNewAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateNewAccount", namePathScript));
            Delete.Table("NewAccount");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertLimitedPerson", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetLimitedPersonByLimitedAccountId", namePathScript));
            Delete.Table("LimitedPerson");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertLimitedAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetLimitedAccountById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetLimitedAccountListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateLimitedAccount", namePathScript));
            Delete.Table("LimitedAccount");
        }
    }
}