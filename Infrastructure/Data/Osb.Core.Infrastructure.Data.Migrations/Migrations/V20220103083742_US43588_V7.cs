using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220103083742)]
    public class V20220103083742_US43588_V7 : Migration
    {
        private string namePathScript = "V20220103083742_US43588_V7";

        public override void Up()
        {
            Create.Table("PendingInternalTransfer")
                .WithColumn("PendingInternalTransferId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable()
                .WithColumn("CountryCode").AsString().Nullable()
                .WithColumn("Value").AsDecimal(10, 2).NotNullable()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("FromTaxId").AsString().NotNullable()
                .WithColumn("FromBank").AsString().Nullable()
                .WithColumn("FromBankBranch").AsString().Nullable()
                .WithColumn("FromBankAccount").AsString().Nullable()
                .WithColumn("FromBankAccountDigit").AsString().Nullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("PendingInternalTransfer").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("PendingInternalTransfer").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("PendingInternalTransfer").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("PendingInternalTransfer").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPendingInternalTransferListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertPendingInternalTransfer", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdatePendingInternalTransfer", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPendingInternalTransferListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertPendingInternalTransfer", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdatePendingInternalTransfer", namePathScript));
            Delete.Table("PendingInternalTransfer");
        }
    }
}
