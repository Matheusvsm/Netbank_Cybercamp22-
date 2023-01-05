using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220324113451)]
    public class V20220324113451_US64364_V26 : Migration
    {
        private string namePathScript = "V20220324113451_US64364_V26";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserWebhook", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserWebhookByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserWebhook", namePathScript));
            Delete.Table("UserWebhook");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccountWebhook", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountWebhookByAccountKey", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAccountWebhook", namePathScript));
            Delete.Table("AccountWebhook");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByUserIdAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserAccountByAccountKeyAndUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUser", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserAccount", namePathScript));
        }

        public override void Down()
        {
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
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("LockedUser").AsBoolean().NotNullable().WithDefaultValue(false);

            Create.ForeignKey()
                .FromTable("UserWebhook").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("UserWebhook").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserWebhook", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserWebhookByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserWebhook", namePathScript));

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

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccountWebhook", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountWebhookByAccountKey", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAccountWebhook", namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByUserIdAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("getuseraccountbyaccountkeyanduserid", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUser", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserAccount", namePathScript));
        }
    }
}